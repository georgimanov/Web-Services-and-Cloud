namespace Students.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Students.Data;

    public sealed class StudentsConfiguration : DbMigrationsConfiguration<StudentsDbContext>
    {
        public StudentsConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsDbContext context)
        {
        }
    }
}
