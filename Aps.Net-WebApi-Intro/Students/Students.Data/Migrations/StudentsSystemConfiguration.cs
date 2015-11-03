namespace Students.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Students.Data;

    public sealed class StudentsSystemConfiguration : DbMigrationsConfiguration<StudentsSystemDbContext>
    {
        public StudentsSystemConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsSystemDbContext context)
        {
        }
    }
}
