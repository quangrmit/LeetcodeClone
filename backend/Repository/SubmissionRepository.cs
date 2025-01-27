using BusinessObjects;
using DataAccess;
using Docker.DotNet.Models;
using Docker.DotNet;
using ICSharpCode.SharpZipLib.Tar;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;
using System.Text.Json.Nodes;
using k8s;
using k8s.Models;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using Microsoft.IdentityModel.Tokens;


namespace Repository
{
    public class SubmissionRepository
    {
        public SubmissionRepository() { }

        public async Task<String> answerQuestion(Testcase testcase, String answer, String lan, int placeholder, string wrapper)
        {
            // Init testcases 
            JObject json = JObject.Parse(testcase.cases);
            JArray testcases = (JArray)json["data"];
            //Console.WriteLine(json.ToString());

            // Init solution
            if (lan == "java")
            {
                // Write user solution to file
                String solutionFilePath = "..\\RunEnv\\javaAlternate\\Solution.java";
                File.WriteAllText(solutionFilePath, answer);
                // Write language wrapper for input and output processing
                String wrapperFilePath = "..\\RunEnv\\javaAlternate\\App.java";
                File.WriteAllText(wrapperFilePath, wrapper);
            }

            // Setup Docker client
            DockerClient client = new DockerClientConfiguration().CreateClient();

            // Build image
            String envPath = "";
            String imageName = "kreden35/leetrun";

            //if (lan == "python")
            //{
            //    envPath = "..\\RunEnv\\pythonTest";
            //}
            
            if (lan == "java")
            {
                envPath = "..\\RunEnv\\javaAlternate";
            }
            // Build docker image
            var watchnew = System.Diagnostics.Stopwatch.StartNew();

            createImage(envPath, imageName);

            watchnew.Stop();
            var elapsedMss = watchnew.ElapsedMilliseconds;
            Console.WriteLine(elapsedMss);

            //Publish docker image
            publishDockerImage(imageName);

            // Run test evaluation
            watchnew = System.Diagnostics.Stopwatch.StartNew();

            String output = runTest(testcases);
            JArray result = formatOutput(testcases, output);

            elapsedMss = watchnew.ElapsedMilliseconds;
            Console.WriteLine(elapsedMss);

            return result.ToString();
        }
        private static Stream CreateTarballForDockerfileDirectory(string directory)
        {
            var tarball = new MemoryStream();
            var files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            using var archive = new TarOutputStream(tarball)
            {
                //Prevent the TarOutputStream from closing the underlying memory stream when done
                IsStreamOwner = false
            };

            foreach (var file in files)
            {
                //Replacing slashes as KyleGobel suggested and removing leading /
                string tarName = file.Substring(directory.Length).Replace('\\', '/').TrimStart('/');

                //Let's create the entry header
                var entry = TarEntry.CreateTarEntry(tarName);
                using var fileStream = File.OpenRead(file);
                entry.Size = fileStream.Length;
                archive.PutNextEntry(entry);

                //Now write the bytes of data
                byte[] localBuffer = new byte[32 * 1024];
                while (true)
                {
                    int numRead = fileStream.Read(localBuffer, 0, localBuffer.Length);
                    if (numRead <= 0)
                        break;

                    archive.Write(localBuffer, 0, numRead);
                }

                //Nothing more to do with this entry
                archive.CloseEntry();
            }
            archive.Close();

            //Reset the stream and return it, so it can be used by the caller
            tarball.Position = 0;
            return tarball;
        }

        private static async Task<bool> createImage(DockerClient client, string imagePath, string imageName)
        {
            var tarball = CreateTarballForDockerfileDirectory(imagePath);

            var imageBuilder = new ImageBuildParameters()
            {
                Tags = new List<string>() { imageName }
            };
            await client.Images.BuildImageFromDockerfileAsync(imageBuilder, tarball, new List<AuthConfig>(), new Dictionary<String, String>(), new Progress<JSONMessage>());
            return true;
        }

        private void createImage(string imagePath, string imageName)
        {
            string command = $"docker build {imagePath} -t {imageName}";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {command}",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process process = Process.Start(startInfo);

            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            Console.WriteLine("Wait job");

            Console.WriteLine(output);
            Console.WriteLine("Error is" + error);

            if (error.EndsWith("1\n"))
            {
                throw new Exception(error);
            }

        }

        private String runTest(JArray testcases)
        {
            String result = "";

            // Build config file
            String configmapFile = "D:\\personalProject\\test\\kubelearn\\config.yaml";
            Dictionary<string, string> data = new Dictionary<string, string>();
            int count = 0;
            foreach (JToken i in testcases) {
                // Extract testcase
                JObject mid = (JObject)i;
                string input = (string)mid["run_test_input"];

                data[$"input-{count}"] = input;
                count++;
            }
            var yamlObject = new
            {
                apiVersion = "v1",
                kind = "ConfigMap",
                metadata = new
                {
                    name = "job-input-config",
                    @namespace = "default"
                },
                data = data
            };

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            string yamlContent = serializer.Serialize(yamlObject);

            File.WriteAllText(configmapFile, yamlContent);
            Console.WriteLine($"YAML file written successfully to {configmapFile}");

            // Load config map
            String loadCofigmapCommand = "kubectl apply -f ";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {loadCofigmapCommand + configmapFile}",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process process = Process.Start(startInfo);

            process.WaitForExit();
            Console.WriteLine("Load configmap");

            // Build job file
            int numTestcases = testcases.Count;

            // Start job
            String jobFile = "D:\\personalProject\\test\\kubelearn\\job.yaml";

            String startJobCommand = "kubectl apply -f ";

            startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {startJobCommand + jobFile}",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            process = Process.Start(startInfo);

            process.WaitForExit();
            Console.WriteLine("Start job");

            // Wait for job (must wait for 2 condition fail and success)
            //Boolean fail = false;
            //Boolean success = false;

            //String waitJobCommand = "kubectl wait --for=condition=complete --timeout=120s job/indexed-job-example";
            //startInfo = new ProcessStartInfo
            //{
            //    FileName = "cmd.exe",
            //    Arguments = $"/C {waitJobCommand}",
            //    RedirectStandardError = true,
            //    RedirectStandardOutput = true,
            //    UseShellExecute = false,
            //    CreateNoWindow = true,
            //};

            //process = Process.Start(startInfo);

            //process.WaitForExit();

            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();

            //Console.WriteLine("Wait job");

            //Console.WriteLine(output);
            //Console.WriteLine(error);

            //// If job fail, select 1 fail pod and throw the result

            string jobName = "indexed-job-example"; // Replace with your job name
            int timeoutInSeconds = 120; // Adjust timeout as needed
            DateTime startTime = DateTime.Now;

            while (true)
            {
                // Check job status
                string statusCommand = $@"kubectl get job {jobName} -o jsonpath=""{{range .status.conditions[*]}}{{.type}}={{.status}} {{end}}""";
                string statusOutput = ExecuteCommand(statusCommand);

                if (!string.IsNullOrEmpty(statusOutput))
                {
                    string[] statuses = statusOutput.Split(' ');
                    Console.WriteLine(statuses.ToString());
                    bool isSucceeded = false;
                    bool isFailed = false;
                    if (statuses[1].Equals("Complete=True"))
                    {
                        isSucceeded = true;
                    }
                    else if (statuses[1].Equals("Failed=True"))
                    {
                        isFailed = true;
                    }

                    if (isSucceeded || isFailed)
                    {
                        //if (isFailed)
                        //{
                        //    HandleFailure(jobName);
                        //}
                        break;
                    }
                }

                // Check timeout
                if ((DateTime.Now - startTime).TotalSeconds > timeoutInSeconds)
                {
                    Console.WriteLine("Job waiting timed out.");
                    break;
                }

                System.Threading.Thread.Sleep(1000); // Wait for 1 second before checking again
            }


            // Collect output
            String outputCommand = "kubectl logs -l job-name=indexed-job-example --all-containers=true";
            startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {outputCommand}",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            process = Process.Start(startInfo);

            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            Console.WriteLine("Collect output");
            result = output;
            Console.WriteLine(output);
            Console.WriteLine(error);

            // Clean job
            String cleanupCommand = "kubectl delete job indexed-job-example";
            startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {cleanupCommand}",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            process = Process.Start(startInfo);

            process.WaitForExit();
            Console.WriteLine("Clean up data");

            return result;
        }

        private void publishDockerImage(String dockerImage)
        {
            String pushImageCommand = "docker push " + dockerImage;
            Console.WriteLine(pushImageCommand);
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {pushImageCommand}",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process process = Process.Start(startInfo);

            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (!error.IsNullOrEmpty())
            {
                Console.WriteLine(error);
                throw new Exception(error);
            }

            Console.WriteLine(output);
        }


        private JArray formatOutput(JArray testData, string rawOutput)
        {
            JArray formattedResults = new JArray();
            string[] results = rawOutput.Trim().Split('\n');
            Console.WriteLine(results.ToString());
            for (int i = 0; i < results.Length; i += 3)
            {
                // If test result is runtime error
                if (results[i+1].Equals("error"))
                {
                    // Collect stacktrace
                    string message = "";
                    int count = 2;
                    while (true)
                    {
                        if (results[i+count].StartsWith("JOB"))
                        {
                            break;
                        }
                        message += results[i + count];
                        message += "\n";
                        count++;
                    }
                    JObject errorResult = new JObject
                    {
                        ["input"] = testData[i / 3]["input"],
                        ["output"] = testData[i / 3]["output"],
                        ["message"] = message,
                        ["status"] = "runtime error"
                    };

                    formattedResults.Add(errorResult);
                    break;
                }
                bool status = bool.Parse(results[i + 1].Trim());
                string result = results[i + 2].Trim();

                JObject testResult = new JObject
                {
                    ["input"] = testData[i / 3]["input"],
                    ["output"] = testData[i / 3]["output"],
                    ["result"] = result,
                    ["status"] = status.ToString().ToLower()
                };

                formattedResults.Add(testResult);
            }

            return formattedResults;
        }

        private String ExecuteCommand(string command) 
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c {command}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                Console.WriteLine (output);
                Console.WriteLine (error);
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing command: {ex.Message}");
                return null;
            }
        }

        private void HandleFailure(string jobName)
        {
            string failedPodsCommand = $"kubectl get pods --selector=job-name={jobName} --field-selector=status.phase=Failed -o jsonpath='{{.items[*].metadata.name}}'";
            string failedPodsOutput = ExecuteCommand(failedPodsCommand);

            if (!string.IsNullOrEmpty(failedPodsOutput))
            {
                string[] failedPods = failedPodsOutput.Split(' ');

                if (failedPods.Length > 0)
                {
                    string firstFailedPod = failedPods[0];
                    firstFailedPod = firstFailedPod.Replace("\"", "").Replace("\'", "");
                    string logCommand = $"kubectl logs {firstFailedPod}";
                    string logOutput = ExecuteCommand(logCommand);

                    Console.WriteLine($"Logs from failed pod {firstFailedPod}:");
                    Console.WriteLine(logOutput);

                    // Extract job index from the log if present
                    string jobIndex = ExtractJobIndex(logOutput);
                    if (!string.IsNullOrEmpty(jobIndex))
                    {
                        Console.WriteLine($"Extracted Job Index: {jobIndex}");
                    }
                }
            }
        }

        private string ExtractJobIndex(string logOutput)
        {
            // Assuming the job index is at the beginning of the log and delimited by whitespace
            if (!string.IsNullOrEmpty(logOutput))
            {
                string[] logLines = logOutput.Split('\n');
                if (logLines.Length > 0)
                {
                    string firstLine = logLines[0];
                    string[] parts = firstLine.Split(' ');
                    if (parts.Length > 0)
                    {
                        return parts[0]; // First token is assumed to be the job index
                    }
                }
            }
            return null;
         
        }

    }

    
}
