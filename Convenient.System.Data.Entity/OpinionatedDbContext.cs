namespace Convenient.System.Data.Entity
{
    using global::System.Data.Entity;
    using global::System.Linq;
    using Convenient.System.Data.Entity.Opinions;

    public abstract class OpinionatedDbContext : ConvenientDbContext
    {
        protected OpinionatedDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database according to our opinions.
        /// </summary>
        /// <returns>The number of state entries written to the underlying database.</returns>
        public override int SaveChanges()
        {
            ////////////////////////////////////////////////////////////////////
            // Ref.: http://axial.agency/activerecord-niceties-in-entity-framework/
            //       https://gist.github.com/andy-mehalick/11253571
            ////////////////////////////////////////////////////////////////////
            var modifiedModels = this.ChangeTracker.Entries()
                                      .Where(entry => entry.State == EntityState.Modified)
                                      .Where(entry => entry.Entity is IOpinionatedModel)
                                      .Select(entry => entry.Entity as IOpinionatedModel);

            // Set `UpdatedAt` column with current UTC date & time
            foreach (var model in modifiedModels)
            {
                model.Update();
            }

            return base.SaveChanges();
        }
    }
}
