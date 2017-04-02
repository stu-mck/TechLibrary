using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Domain.Values
{
    public class ArticleIndex
    {
        public ArticleIndex(Guid entityId, IndexType indexType)
        {
            ReferenceId = entityId;
        }

        public ArticleIndex Index { get; set; }
        public Guid ReferenceId { get; private set; }
    }
}
