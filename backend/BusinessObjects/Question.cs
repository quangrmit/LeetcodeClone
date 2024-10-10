using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        [Required]
        public String QuestionTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public String pythonAnswerTemplate { get; set; }

        //[Required]
        //public String javaAnswerTemplate { get; set; }

        public ICollection<Testcase> Testcases { get; } = new List<Testcase>();

    }
}
