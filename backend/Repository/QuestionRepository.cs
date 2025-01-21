using BusinessObjects;
using DataAccess;
using k8s.Models;
using k8s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class QuestionRepository
    {
        public QuestionRepository() { }

        public List<ListQuestionResponseDTO> listAllQuestions() {
            setUpKube();
           return QuestionDAO.getAllQuestions();
        }

        public Question findQuestionById(int id)
        {

            // Attach testcase in response
            return QuestionDAO.getQuestionById(id);
        }

        private void setUpKube()
        {
            var config = KubernetesClientConfiguration.BuildDefaultConfig();

            var client = new Kubernetes(config);

            var ns = new V1Namespace
            {
                Metadata = new V1ObjectMeta
                {
                    Name = "test"
                }
            };

            var result = client.CoreV1.CreateNamespace(ns);
            
            Console.WriteLine(result);

        }

    }
}
