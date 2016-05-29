using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Entities
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public int AmountReps { get; set; }
        public int AmountSets { get; set; }
        public double? Weight { get; set; }
        public double? Distance { get; set; }
        public DateTime? Time { get; set; }

        //Navigation Properties
        public string ExerciseID { get; set; }
        public virtual Exercise Exercise { get; set; }

        public int GymVisitID { get; set; }
        public virtual GymVisit Gymvisit { get; set; }
    }
}
