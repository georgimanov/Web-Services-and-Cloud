namespace Students.Api
{ 
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, StudentsSystemConfiguration>());
            StudentsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}