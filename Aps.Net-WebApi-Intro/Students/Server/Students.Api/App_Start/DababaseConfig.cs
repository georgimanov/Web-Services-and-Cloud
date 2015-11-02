namespace Students.Api
{ 
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDbContext, StudentsConfiguration>());
            StudentsDbContext.Create().Database.Initialize(true);
        }
    }
}