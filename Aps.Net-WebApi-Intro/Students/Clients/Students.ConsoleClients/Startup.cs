namespace Students.ConsoleClients
{
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Data.Migrations;

    public class Startup
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, StudentsSystemConfiguration>());

            var db = new StudentsSystemDbContext();

            db.Courses.Count();
        }
    }
}
