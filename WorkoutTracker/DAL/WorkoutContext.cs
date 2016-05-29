using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WorkoutTracker.Entities;

namespace WorkoutTracker.DAL
{
    public class WorkoutContext : DbContext      
    {
        //public WorkoutContext()
        //    //:base("name=Connstring")
        //{
        //}

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<GymVisit> GymVisits { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
    }
}
