using TechLibrary.Interfaces;

namespace TechLibrary.Domain.Aggregates
{
    public class ContentIndex
    {
        public ContentIndex(IIndexable source, IIndexable target)
        {
            Source = source;
            Target = target;
        }

        public IIndexable Source { get; private set; }

        public IIndexable Target { get; private set; }
    }
}
