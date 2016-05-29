namespace WorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false, identity: true),
                        ExerciseName = c.String(),
                        MuscleGroup = c.String(),
                        ExerciseType = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseID);
            
            CreateTable(
                "dbo.GymVisits",
                c => new
                    {
                        GymVisitID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        Weight = c.Double(),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GymVisitID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Double(),
                        Length = c.Double(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        AmountReps = c.Int(nullable: false),
                        AmountSets = c.Int(nullable: false),
                        Weight = c.Double(),
                        Distance = c.Double(),
                        Time = c.DateTime(),
                        ExerciseID = c.String(),
                        GymVisitID = c.Int(nullable: false),
                        Exercise_ExerciseID = c.Int(),
                    })
                .PrimaryKey(t => t.WorkoutID)
                .ForeignKey("dbo.Exercises", t => t.Exercise_ExerciseID)
                .ForeignKey("dbo.GymVisits", t => t.GymVisitID, cascadeDelete: true)
                .Index(t => t.GymVisitID)
                .Index(t => t.Exercise_ExerciseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "GymVisitID", "dbo.GymVisits");
            DropForeignKey("dbo.Workouts", "Exercise_ExerciseID", "dbo.Exercises");
            DropForeignKey("dbo.GymVisits", "PersonID", "dbo.People");
            DropIndex("dbo.Workouts", new[] { "Exercise_ExerciseID" });
            DropIndex("dbo.Workouts", new[] { "GymVisitID" });
            DropIndex("dbo.GymVisits", new[] { "PersonID" });
            DropTable("dbo.Workouts");
            DropTable("dbo.People");
            DropTable("dbo.GymVisits");
            DropTable("dbo.Exercises");
        }
    }
}
