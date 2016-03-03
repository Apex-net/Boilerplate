namespace Convenient.System.Data.Entity.Seeding
{
    using global::System.Data.Entity;

    public abstract class BaseSeedGenerator : ISeedGenerator
    {
        private readonly DbContext context;

        protected BaseSeedGenerator(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Inherited classes usually overrides this method to generate seed data to their needs.
        /// </summary>
        public virtual void Generate()
        {
            this.context.SaveChanges();
        }
    }
}
