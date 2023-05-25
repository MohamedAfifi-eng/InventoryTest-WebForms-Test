using InventoryTest_WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryTest_WebForms.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _db;

        public Repository()
        {
            _db = ApplicationDbContext.Create();
        }

        public T Create(T entity)
        {
            _db.Set<T>().Add(entity);
            SaveChanges();
            return entity;
        }

        public IEnumerable<T> CreateRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
            SaveChanges ();
            return entities;
        }

        public bool Delete(T entity)
        {
           _db.Set<T>().Remove(entity);
            return SaveChanges()>0;
        }

        public T FindById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public T Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
            return entity;
        }
    }
}