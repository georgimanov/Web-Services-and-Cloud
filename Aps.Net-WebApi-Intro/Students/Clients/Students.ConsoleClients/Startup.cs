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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDbContext, StudentsConfiguration>());

            var db = new StudentsDbContext();

            db.Courses.Count();
        }
    }
}
