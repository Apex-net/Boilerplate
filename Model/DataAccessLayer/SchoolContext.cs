namespace Model.DataAccessLayer
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Model.Models;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("SchoolDatabase")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Enrollment> Enrollments { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
