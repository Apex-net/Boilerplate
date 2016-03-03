namespace Convenient.System.Data.Entity
{
    using global::System.Data.Entity;
    using global::System.Data.Entity.Validation;
    using global::System.Text;

    public abstract class ConvenientDbContext : DbContext
    {
        protected ConvenientDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of state entries written to the underlying database.</returns>
        public override int SaveChanges()
        {
            ////////////////////////////////////////////////////////////////////
            // Ref.: http://stackoverflow.com/questions/10219864/ef-code-first-how-do-i-see-entityvalidationerrors-property-from-the-nuget-pac
            //       http://www.blaiseliu.com/got-entityvalidationerrors-debug-into-entity-framework-code-first/
            ////////////////////////////////////////////////////////////////////
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
        }
    }
}
