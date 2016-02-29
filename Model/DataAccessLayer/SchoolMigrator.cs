namespace Model.DataAccessLayer
{
    using Model.Migrations;

    public class SchoolMigrator : System.Data.Entity.MigrateDatabaseToLatestVersion<SchoolContext, Configuration>
    {
    }
}