﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGuild_Demo.EntityFramework
{    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {
            //Database.SetInitializer(new SchoolDBInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }

    public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            IList<Grade> grades = new List<Grade>();

            grades.Add(new Grade() { GradeName = "Grade 1", Section = "A" });         
            grades.Add(new Grade() { GradeName = "Grade 2", Section = "B" });
            grades.Add(new Grade() { GradeName = "Grade 3", Section = "C" });
            grades.Add(new Grade() { GradeName = "Grade 4", Section = "D" });

            context.Grades.AddRange(grades);

            base.Seed(context);
        }
    }
}
