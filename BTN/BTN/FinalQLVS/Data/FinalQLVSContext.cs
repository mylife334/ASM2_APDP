using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalQLVS.Models;

namespace FinalQLVS.Data
{
    public class FinalQLVSContext : DbContext
    {
        public FinalQLVSContext (DbContextOptions<FinalQLVSContext> options)
            : base(options)
        {
        }

        public DbSet<FinalQLVS.Models.Staff> Staff { get; set; } = default!;
        public DbSet<FinalQLVS.Models.Course> Course { get; set; } = default!;
        public DbSet<FinalQLVS.Models.Student> Student { get; set; } = default!;
        public DbSet<FinalQLVS.Models.Lecture> Lecture { get; set; } = default!;
        public DbSet<FinalQLVS.Models.Class> Class { get; set; } = default!;
        public DbSet<FinalQLVS.Models.SubjectCourse> SubjectCourse { get; set; } = default!;
        public DbSet<FinalQLVS.Models.TimeTable> TimeTable { get; set; } = default!;
        public DbSet<FinalQLVS.Models.NoticeClass> NoticeClass { get; set; } = default!;
        public DbSet<FinalQLVS.Models.NoticeLecture> NoticeLecture { get; set; } = default!;
    }
}
