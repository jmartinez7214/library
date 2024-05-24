using Library.Domain.Common;

namespace Library.Domain
{
    public class Book : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedDate { get; set; }

        public virtual ICollection<BookDetail>? BookDetails { get; set; }
    }
}
