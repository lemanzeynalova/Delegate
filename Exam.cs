using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Exam
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Point Point { get; set; }
        public DataSetDateTime StartDate { get; set; }
        public DataSetDateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
