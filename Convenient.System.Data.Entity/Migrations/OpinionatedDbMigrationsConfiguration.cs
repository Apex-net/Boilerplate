namespace Convenient.System.Data.Entity.Migrations
{
    using global::System.Data.Entity.Migrations;
    using Convenient.System.Data.Entity.SqlServer;

    public class OpinionatedDbMigrationsConfiguration<TContext> : DbMigrationsConfiguration<TContext>
        where TContext : global::System.Data.Entity.DbContext
    {
        public OpinionatedDbMigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("System.Data.SqlClient", new OpinionatedSqlServerMigrationSqlGenerator());
        }
    }
}
