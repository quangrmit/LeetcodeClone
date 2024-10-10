using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TestcaseDAO
    {
        public TestcaseDAO() { }

        public static String getTestcasesById(int id)
        {
            try
            {
                using (var db = new ApplicationDBContext())
                {
                    //Testcase t = db.Testcases.Where()
                    return "";

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }
    }
}
