using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLibrary.Domain.Aggregates;
using TechLibrary.Interfaces;

namespace TechLibrary.Domain.Repositories
{
    public class ContentRepository : RepositoryBase<ContentElement>, IRepository<ContentElement>
    {

    }
}
