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


namespace Repository
{
    public class SubmissionRepository
    {
        public SubmissionRepository() { }

        public async Task<String> answerQuestion(Testcase testcase, String answer, String lan)
        {
            // Init testcases
            String res = "";
            JObject json = JObject.Parse(testcase.cases);
            json.Add("problem", testcase.funcName);
            Console.WriteLine(json);
            String dataFilePath = "..\\RunEnv\\mount\\data.json";
            File.WriteAllText(dataFilePath, json.ToString());

            // Init solution
            if (lan == "python")
            {
                String solutionFilePath = "..\\RunEnv\\pythonTest\\solution.py";
                File.WriteAllText(solutionFilePath, answer);
            }
            else if(lan == "java")
            {
                String solutionFilePath = "..\\RunEnv\\javaTest\\src\\main\\java\\com\\example\\app\\Solution.java";
                answer = "package com.example.app;\r\n" + answer;
                File.WriteAllText(solutionFilePath, answer);
            }

            // Setup Docker client
            DockerClient client = new DockerClientConfiguration().CreateClient();

            // Build image
            String envPath = "";
            String imageName = "leetrun";
            if (lan == "python")
            {
                envPath = "..\\RunEnv\\pythonTest";
            }
            else if (lan == "java")
            {
                envPath = "..\\RunEnv\\javaTest";
            }
            bool isCreateImageSuccess = await Task.Run(() => createImage(client, envPath, imageName));

            // Run container
            bool isContainerRunSuccess = await Task.Run(() => runContainer(client, imageName));

            // Return result
            String resultFilePath = "..\\RunEnv\\mount\\res.json";
            using (StreamReader r = new StreamReader(resultFilePath))
            {
                res = r.ReadToEnd();

            }
            File.Delete(resultFilePath);
            return res;


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

        private static async Task<bool> createImage( DockerClient client ,string imagePath, string imageName) 
        {
            var tarball = CreateTarballForDockerfileDirectory(imagePath);

            var imageBuilder = new ImageBuildParameters()
            {
                Tags = new List<string>() { imageName }
            };
            //var responseStream = await client.Images.BuildImageFromDockerfileAsync(tarball, imageBuilder);
            await client.Images.BuildImageFromDockerfileAsync(imageBuilder, tarball, new List<AuthConfig>(), new Dictionary<String, String>(), new Progress<JSONMessage>());
            return true;
        }

        private static async Task<bool> runContainer(DockerClient client, string imageName)
        {
            // Create container
            var container = await client.Containers.CreateContainerAsync(new Docker.DotNet.Models.CreateContainerParameters()
            {
                Image = imageName,
                HostConfig = new HostConfig
                {
                    Binds = ["D:\\personalProject\\LeetcodeClone\\backend\\RunEnv\\mount:/usr/src/app/mount"]
                }
            });

            // Run container
            await client.Containers.StartContainerAsync(container.ID, new Docker.DotNet.Models.ContainerStartParameters(){});
            await client.Containers.WaitContainerAsync(container.ID);
            return true;

        }
    }
}
