using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSharp.Examples
{
    public interface IRepository<T> where T : class
    {
        void Delete(T entityToDelete);
        T GetById(int id);
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}