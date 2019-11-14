using System;
using Importer.Model;

namespace Importer.ViewModel
{
    public abstract class BaseViewModel<TEntity> where TEntity : Entity
    {
        protected BaseViewModel()
        {
            
        }

        protected BaseViewModel(TEntity model)
        {
            Id = model.Id;
            Created = model.Created;
            CreatedBy = model.CreatedBy;
            Modified = model.Modified;
            ModifiedBy = model.ModifiedBy;
            IsDeleted = model.IsDeleted;
            DeletedBy = model.DeletedBy;
            DeletionTime = model.DeletionTime;
        }


        public string Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionTime { get; set; }

        public bool IsEnableDelete { get; set; }
    }
}