﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TestingGiant.Data.Interfaces;
using TestingGiant.Data.Models;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.Data.Repositories
{
    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IKeepDates
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override void Add(T entity, int? creatorId = null)
        {
            entity.CreatedOn = DateTime.Now;
            
            if(entity is IKeepDatesAndCreator && creatorId != null)
            {
                (entity as IKeepDatesAndCreator).CreatorId = (int)creatorId;
            }

            base.Add(entity);
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void ActualDelete(T entity)
        {
            base.Delete(entity);
        }
    }
}
