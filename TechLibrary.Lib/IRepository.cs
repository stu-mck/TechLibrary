using System;

namespace TechLibrary.Interfaces
{
    public interface IRepository<T>
    {
        T GetByID(Guid id);
        void Save(T articleDefinition);
    }
}
