using System;
using System.Collections.Generic;
using System.Linq;
using TechLibrary.Domain.Interfaces;

namespace TechLibrary.Domain.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T: IEntity
    {
        private List<T> _entities = new List<T>();

        public T Save(T element)
        {
            element.EntityId = Guid.NewGuid();
            _entities.Add(element);
            return element;
        }

        public T Load(Guid entityId)
        {
            return _entities.FirstOrDefault(ce => ce.EntityId.Equals(entityId));
        }

        public IQueryable<T> AsQueryable(){
            return _entities.AsQueryable();
       }
    }
}
