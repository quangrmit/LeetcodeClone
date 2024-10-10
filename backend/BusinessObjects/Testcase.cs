using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Testcase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestcaseId { get; set; }
        //public string Input { get; set; }
        //public string Output { get; set; }

        public string funcName { get; set; }
        public string cases { get; set; }

        public Question question { get; set; } = null;

        public int QuestionId { get; set; }

    }
}
