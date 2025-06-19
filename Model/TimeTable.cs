using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManagementSystem.Model
{
    public class Timetable
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int RoomId { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
