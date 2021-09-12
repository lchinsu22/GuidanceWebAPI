using System.Linq;
using System.Collections.Generic;
using System;
using System.Data.Entity;

namespace GuidanceDataAccess.DAModel
{
    public class CRUDContext<T> : GuidanceContext, ICRUDContext<T> where T : class
    {
        public T UpdateContext(T entity)
        {
            if (entity != null)
            {
                try
                {
                    Entry(entity).State = EntityState.Modified;
                    //Set<T>().AddOrUpdate(entity);
                    SaveChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public T AddToContext(T entity)
        {
            if (entity != null)
            {
                try
                {
                    //Entry(entity).State = EntityState.Added;          
                    Set<T>().Add(entity);
                    SaveChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;

        }

        public List<T> AddToContext(List<T> entities)
        {

            if (entities != null)
            {
                try
                {
                    //Entry(entity).State = EntityState.Added;          
                    Set<T>().AddRange(entities);
                    SaveChanges();
                    return entities;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public T GetFromContext(int Id)
        {
            try
            {
                return Set<T>().Find(Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<T> GetAllFromContext()
        {

            try
            {
                return Set<T>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int RemoveFromContext(int Id)
        {
            try
            {
                //Entry(entity).State = EntityState.Added;
                var entity = Set<T>().Find(Id);
                Set<T>().Remove(entity);
                SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}

