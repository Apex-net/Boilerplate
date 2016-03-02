namespace Model.DataAccessLayer
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var generator = new SeedGenerator(context);
            generator.Generate();
        }
    }
}
