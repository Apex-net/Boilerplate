namespace Convenient.System.Data.Entity.SqlServer
{
    using global::System.Data.Entity.Core.Metadata.Edm;
    using global::System.Data.Entity.Migrations.Model;
    using global::System.Data.Entity.SqlServer;

    // Ref.: https://andy.mehalick.com/2014/02/06/ef6-adding-a-created-datetime-column-automatically-with-code-first-migrations/
    public class OpinionatedSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetDefaultValueSqlForDateColumns(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            foreach (var columnModel in createTableOperation.Columns)
            {
                SetDefaultValueSqlForDateColumns(columnModel);
            }

            base.Generate(createTableOperation);
        }

        private static void SetDefaultValueSqlForDateColumns(PropertyModel column)
        {
            if (column.Type != PrimitiveTypeKind.DateTime)
            {
                return;
            }

            if (column.Name == "CreatedAt" || column.Name == "UpdatedAt")
            {
                column.DefaultValueSql = "GETUTCDATE()";
            }
        }
    }
}
