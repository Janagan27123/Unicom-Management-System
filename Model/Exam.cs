using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManagementSystem.Model
{
    public class Exam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }
    }
}
