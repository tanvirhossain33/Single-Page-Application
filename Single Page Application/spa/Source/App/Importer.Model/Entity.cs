using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Importer.Model
{
    public abstract class Entity
    {

        private const string Key = "DbContext";

        [Key]
        [Index("IX_Id", 1, IsUnique = true)]
        public string Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        [Required]
        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionTime { get; set; }

        private static string DbContextKey => Key;

        protected static BusinessDbContext GetDbContext(ValidationContext validationContext)
        {
            var dbContext = validationContext.Items.Count == 0
                ? null
                : validationContext.Items.ContainsKey(DbContextKey) == false
                    ? null
                    : validationContext.Items[DbContextKey] as BusinessDbContext;
            return dbContext;
        }
    }
}