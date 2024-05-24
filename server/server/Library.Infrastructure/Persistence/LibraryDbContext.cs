using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data source=localhost; Initial Catalog=Library; Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookDetails)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookDetail>();

            modelBuilder.Entity<Book>()
                .HasData(
                    new Book
                    {
                        Id = 1,
                        Name = "You don't know JS: Scope and Closures",
                        Author = "Kyle Simpson",
                        PublishedDate = DateTime.Now,
                    },
                    new Book
                    {
                        Id = 2,
                        Name = "You don't know JS: Async & Performance",
                        Author = "Kyle Simpson",
                        PublishedDate = DateTime.Now,
                    },
                    new Book
                    {
                        Id = 3,
                        Name = "You don't know JS: Up & Going",
                        Author = "Kyle Simpson",
                        PublishedDate = DateTime.Now,
                    }
                );

            modelBuilder.Entity<BookDetail>()
                .HasData(
                    new BookDetail
                    {
                        Id = 1,
                        Page = 1,
                        Content = "When I was a young child, I would often enjoy taking things apart and putting them back together again—old mobile phones, hi - fi stereos, and anything else I could get my hands on. I was too young to really use these devices, but whenever one broke, I would instantly ask if I could figure out how it worked. I remember once looking at a circuit board for an old radio.It had this weird long tube with copper wire wrapped around it.I couldn’t work out its purpose, but I immediately went into research mode.What does it do? Why is it in a radio? It doesn’t look like the other parts of the circuit board, why? Why does it have copper wrapped around it? What happens if I remove the copper ? !Now I know it was a loop antenna, made by wrapping copper wire around a ferrite rod, which are often used in transistor radios.",
                        BookId = 1,
                    },
                    new BookDetail
                    {
                        Id = 2,
                        Page = 2,
                        Content = "Did you ever become addicted to figuring out all of the answers to every why question ? Most children do.In fact it is probably my favorite thing about children—their desire to learn. Unfortunately, now I’m considered a professional and spend my days making things. When I was young, I loved the idea of one day making the things that I took apart.Of course, most things I make now are with JavaScript and not ferrite rods…but close enough! However, de‐ spite once loving the idea of making things, I now find myself longing for the desire to figure things out. Sure, I often figure out the best way to solve a p",
                        BookId = 1,
                    },
                    new BookDetail
                    {
                        Id = 3,
                        Page = 1,
                        Content = "Over the years, my employer has trusted me enough to conduct interviews. If we're looking for someone with skills in JavaScript, my first line of questioning… actually that's not true, I first check if the candidate needs the bathroom and/or a drink, because comfort is important, but once I'm past the bit about the candidate's fluid in/out-take, I set about determining if the candidate knows JavaScript, or just jQuery. Not that there's anything wrong with jQuery. It lets you do a lot without really knowing JavaScript, and that's a feature not a bug.But if the job calls for advanced skills in JavaScript performance and maintainability, you need someone who knows how libraries such as jQuery are put together.You need to be able to harness the core of JavaScript the same way they do.",
                        BookId = 2,
                    },
                    new BookDetail
                    {
                        Id = 4,
                        Page = 2,
                        Content = "If I want to get a picture of someone's core JavaScript skill, I'm most interested in what they make of closures (you've read that book of this series already, right ?) and how to get the most out of asynchronicity, which brings us to this book. For starters, you'll be taken through callbacks, the bread and butter of asynchronous programming. Of course, bread and butter does not make for a particularly satisfying meal, but the next course is full of tasty tasty promises!",
                        BookId = 2,
                    },
                    new BookDetail
                    {
                        Id = 5,
                        Page = 3,
                        Content = "If you don't know promises, now is the time to learn. Promises are now the official way to provide async return values in both JavaScript and the DOM.All future async DOM APIs will use them, many already do, so be prepared! At the time of writing, Promises have shipped in most major browsers, with IE shipping soon. Once you've finished that, I hope you left room for the next course, Generators.",
                        BookId = 2,
                    },
                    new BookDetail
                    {
                        Id = 6,
                        Page = 4,
                        Content = "Generators snuck their way into stable versions of Chrome and Firefox without too much pomp and ceremony, because, frankly, they're more complicated than they are interesting. Or, that's what I thought until I saw them combined with promises.There, they become an important tool in readability and maintenance.",
                        BookId = 2,
                    },
                    new BookDetail
                    {
                        Id = 7,
                        Page = 1,
                        Content = "What was the last new thing you learned? Perhaps it was a foreign language, like Italian or German.Or maybe it was a graphics editor, like Photoshop.Or a cooking technique or woodworking or an exercise routine.I want you to remember that feeling when you finally got it: the lightbulb moment.When things went from blurry to crystal clear, as you mastered the table saw or understood the difference between masculine and feminine nouns in French.How did it feel? Pretty amazing, right?",
                        BookId = 3,
                    },
                    new BookDetail
                    {
                        Id = 8,
                        Page = 2,
                        Content = "Now I want you to travel back a little bit further in your memory to right before you learned your new skill.How did that feel ? Probably slightly intimidating and maybe a little bit frustrating, right ? At one point, we all did not know the things that we know now, and that’s totally OK; we all start somewhere. Learning new material is an exciting adventure, especially if you are looking to learn the subject efficiently",
                        BookId = 3,
                    },
                    new BookDetail
                    {
                        Id = 9,
                        Page = 3,
                        Content = "I teach a lot of beginner coding classes. The students who take my classes have often tried teaching themselves subjects like HTML or JavaScript by reading blog posts or copying and pasting code, but they haven’t been able to truly master the material that will allow them to code their desired outcome.And because they don’t truly grasp the ins and outs of certain coding topics, they can’t write powerful code or debug their own work because they don’t really understand what is happening",
                        BookId = 3,
                    }
                );
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<BookDetail>? BookDetails { get; set; }
    }
}
