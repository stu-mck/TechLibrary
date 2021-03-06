﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;

namespace TechLibrary.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T Save(T entity);
        T Load(Guid Id);
        IQueryable<T> AsQueryable();
    }
}
