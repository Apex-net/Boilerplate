namespace Convenient.System.Data.Entity.Models
{
    using Convenient.System.Data.Entity.Opinions;
    using global::System;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.ComponentModel.DataAnnotations.Schema;

    public abstract class OpinionatedBaseModel : IOpinionatedModel
    {
        protected OpinionatedBaseModel()
        {
            this.CreatedAt = this.UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Universally unique identifier.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Timestamp for concurrency checking.
        /// (Ref.: https://msdn.microsoft.com/en-us/data/jj591583.aspx#TimeStamp)
        /// </summary>
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// UTC date & time of when object is created.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// UTC date & time of when object is last modified. When using `OpinionatedDbContext` it's updated automatically
        /// otherwise you can call `Update` method on an `IOpinionatedModel` to update its `UpdatedAt` value.
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; private set; }

        public void Update()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}