using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //core katmanı başka bir katmandan referans almaz...!!!!
    //class = referans tip demek.
    //Generic constraint
    //IEntity : IEntity olabilir veya IEntity implemente olan nesne olabilir.
    //new(): new'lenebilir olmalı.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
