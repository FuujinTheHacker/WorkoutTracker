using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Entities
{
    public class GymVisit
    {
        public int GymVisitID { get; set; }
        public DateTime TimeStamp { get; set; }
        public double? Weight { get; set; }

        //Navigation Properties
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
