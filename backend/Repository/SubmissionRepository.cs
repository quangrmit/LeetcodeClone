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


namespace Repository
{
    public class SubmissionRepository
    {
        public SubmissionRepository() { }

        //public async Task<String> answerQuestion(Testcase testcase, String answer, String lan)
        //{
        //    // Init testcases
        //    String res = "";
        //    JObject json = JObject.Parse(testcase.cases);
        //    json.Add("problem", testcase.funcName);
        //    Console.WriteLine(json);
        //    String dataFilePath = "..\\RunEnv\\mount\\data.json";
        //    File.WriteAllText(dataFilePath, json.ToString());

        //    // Init solution
        //    if (lan == "python")
        //    {
        //        String solutionFilePath = "..\\RunEnv\\pythonTest\\solution.py";
        //        File.WriteAllText(solutionFilePath, answer);
        //    }
        //    else if(lan == "java")
        //    {
        //        String solutionFilePath = "..\\RunEnv\\javaTest\\src\\main\\java\\com\\example\\app\\Solution.java";
        //        answer = "package com.example.app;\r\n" + answer;
        //        File.WriteAllText(solutionFilePath, answer);
        //    }

        //    // Setup Docker client
        //    DockerClient client = new DockerClientConfiguration().CreateClient();

        //    // Build image
        //    String envPath = "";
        //    String imageName = "leetrun";
        //    if (lan == "python")
        //    {
        //        envPath = "..\\RunEnv\\pythonTest";
        //    }
        //    else if (lan == "java")
        //    {
        //        envPath = "..\\RunEnv\\javaTest";
        //    }
        //    bool isCreateImageSuccess = await Task.Run(() => createImage(client, envPath, imageName));

        //    // Run container
        //    bool isContainerRunSuccess = await Task.Run(() => runContainer(client, imageName));

        //    // Return result
        //    String resultFilePath = "..\\RunEnv\\mount\\res.json";
        //    using (StreamReader r = new StreamReader(resultFilePath))
        //    {
        //        res = r.ReadToEnd();

        //    }
        //    File.Delete(resultFilePath);
        //    return res;
        //}
        public async Task<String> answerQuestion(Testcase testcase, String answer, String lan, int placeholder)
        {
            // Init testcases 
            String res = "import java.util.HashMap;\r\nclass Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n        HashMap<Integer, Integer> archive = new HashMap<Integer, Integer>();\r\n        int[] answer = new int[2];\r\n        for (int i=0; i< nums.length; i++) {\r\n                if (archive.get(nums[i]) == null) {\r\n                    archive.put(target - nums[i],i);\r\n                }\r\n                else {\r\n                    answer[0] = archive.get(nums[i]);\r\n                    answer[1] = i;\r\n                }\r\n        }\r\n        return answer;\r\n    }\r\n}";
            JObject json = JObject.Parse(testcase.cases);
            JArray testcases = (JArray)json["data"];
            Console.WriteLine(json.ToString());

            //json.Add("problem", testcase.funcName);
            //String dataFilePath = "..\\RunEnv\\mount\\data.json";
            //File.WriteAllText(dataFilePath, json.ToString());

            // Init solution
            if (lan == "java")
            {
                String solutionFilePath = "..\\RunEnv\\javaAlternate\\Solution.java";
                File.WriteAllText(solutionFilePath, answer);
            }
            else if (lan == "cpp")
            {
                String solutionFilePath = "..\\RunEnv\\cppTest_copy\\Solution.cpp";
                File.WriteAllText(solutionFilePath, answer);
            }

            // Setup Docker client
            DockerClient client = new DockerClientConfiguration().CreateClient();

            // Build image
            String envPath = "";
            String imageName = "leetrun";

            //if (lan == "python")
            //{
            //    envPath = "..\\RunEnv\\pythonTest";
            //}
            //"import java.util.HashMap;\r\npublic class Solution {\r\n    public int[] twoSum(int[] nums, int target) {\r\n        HashMap<Integer, Integer> archive = new HashMap<Integer, Integer>();\r\n        int[] answer = new int[2];\r\n        for (int i=0; i< nums.length; i++) {\r\n                if (archive.get(nums[i]) == null) {\r\n                    archive.put(target - nums[i],i);\r\n                }\r\n                else {\r\n                    answer[0] = archive.get(nums[i]);\r\n                    answer[1] = i;\r\n                }\r\n        }\r\n        return answer;\r\n    }\r\n}"
            //"#include <iostream>\r\n#include <map>\r\n#include<vector>\r\nusing namespace std;\r\n\r\nclass Solution{\r\npublic:\r\n    vector<int> twoSum (vector<int> nums, int target){\r\n        \r\n        map<int, int> archive = {};\r\n        vector<int> answer = {};\r\n        for (int i = 0; i < nums.size(); i ++){\r\n            if (archive.find(nums[i]) == archive.end()){\r\n                archive[target - nums[i]] = i;\r\n            }else {\r\n                answer.push_back(archive.at(nums[i]));\r\n                answer.push_back(i);\r\n\r\n            }\r\n        }\r\n        return answer;\r\n\r\n    }\r\n\r\n};\r\n"
            if (lan == "java")
            {
                envPath = "..\\RunEnv\\javaAlternate";
            }
            else if (lan == "cpp")
            {
                envPath = "..\\RunEnv\\cppTest_copy";
            }

            // Build docker image as an executable
            var watchnew = System.Diagnostics.Stopwatch.StartNew();

            bool isCreateImageSuccess = await Task.Run(() => createImage(client, envPath, imageName));
            watchnew.Stop();
            var elapsedMss = watchnew.ElapsedMilliseconds;
            Console.WriteLine(elapsedMss);

            // Run docker image
            watchnew = System.Diagnostics.Stopwatch.StartNew();
            JArray result = new JArray();
            foreach (JToken i in testcases)
            {
                JObject mid = (JObject)i;
                string input = (string)mid["run_test_input"];

                string dockerCommand = "docker run leetrun " + input;

                //Console.WriteLine(dockerCommand);
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {dockerCommand}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using Process process = Process.Start(processStartInfo);

                // Read output
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Display output
                String[] outp = getReturnOutput(output);

                Console.WriteLine($"Status is {outp[0]}");
                Console.WriteLine($"Output is {outp[1]}");

                Console.WriteLine($"Error is {error}");

                JObject testres = new JObject();
                testres.Add("status", outp[0]);
                testres.Add("result", outp[1]);
                testres.Add("expected_result", (string)mid["output"]);
                testres.Add("input", mid["input"]);
                result.Add(testres);

            }

            elapsedMss = watchnew.ElapsedMilliseconds;
            Console.WriteLine(elapsedMss);


            //foreach (var test in testcases)
            //{
            //    JObject mid = (JObject)test;
            //    Console.WriteLine((string) mid["cla"]);

            //    //Run container
            //    var watch = System.Diagnostics.Stopwatch.StartNew();

            //    bool isContainerRunSuccess = await Task.Run(() => runContainer(client, imageName, (string)mid["cla"]));

            //    watch.Stop();
            //    var elapsedMs = watch.ElapsedMilliseconds;
            //    Console.WriteLine(elapsedMs);

            //}

            // Return result
            //String resultFilePath = "..\\RunEnv\\mount\\res.json";
            //using (StreamReader r = new StreamReader(resultFilePath))
            //{
            //    res = r.ReadToEnd();

            //}
            //File.Delete(resultFilePath);

            //return getReturnOutput(output);
            return result.ToString();
        }
        private static Stream CreateTarballForDockerfileDirectory(string directory)
        {
            var tarball = new MemoryStream();
            var files = Directory.GetFiles(directory, ".", SearchOption.AllDirectories);

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

        private static async Task<bool> runContainer(DockerClient client, string imageName, string args)
        {
            // Create container
            var container = await client.Containers.CreateContainerAsync(new Docker.DotNet.Models.CreateContainerParameters()
            {
                Image = imageName,
                HostConfig = new HostConfig
                {
                    Binds = ["D:\\personalProject\\LeetcodeClone\\backend\\RunEnv\\mount:/usr/src/app/mount"]
                    //Binds = ["C:\\Users\\Lenovo\\OneDrive\\Desktop\\LeetcodeClone\\backend\\RunEnv\\mount:/usr/src/app/mount"]
                },
                Env = new List<String>
                {
                    "testcases=" + args
                }
            });

            // Run container
            await client.Containers.StartContainerAsync(container.ID, new Docker.DotNet.Models.ContainerStartParameters() { });
            await client.Containers.WaitContainerAsync(container.ID);
            client.Containers.KillContainerAsync(container.ID, new ContainerKillParameters() { });
            return true;

        }

        private String[] getReturnOutput(String output)
        {
            String[] res = output.Split("\n");
            return res;
        }

        private String evaluateTest(String test)
        {
            return "";
        }
    }
}