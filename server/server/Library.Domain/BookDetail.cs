using Library.Domain.Common;

namespace Library.Domain
{
    public class BookDetail : BaseDomainModel
    {
        public int? Page { get; set; }
        public string? Content { get; set; }
        public int BookId { get; set; }

        public virtual Book? Book { get; set; }
    }
}
