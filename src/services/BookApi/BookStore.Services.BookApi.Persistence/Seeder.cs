using BookStore.Services.BookApi.Domain.Authors;
using BookStore.Services.BookApi.Domain.Books;

namespace BookStore.Services.BookApi.Persistence;

public class Seeder
{
    private readonly BookDbContext _dbContext;

    public Seeder(
        BookDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        SeedAuthors();
        SeedBooks();
    }

    private void SeedAuthors()
    {
        List<Author> authors = new()
        {
            new Author(
                1,
                "Brandon Sanderson"
            ),
            new Author(
                2,
                "Frank Herbert"
            )
        };

        _dbContext
            .Authors
            .AddRange(authors);

        _dbContext
            .SaveChanges();
    }

    private void SeedBooks()
    {
        List<Book> books = new()
        {
            new Book(
                "The Final Empire",
                "For a thousand years the ash fell and no flowers bloomed. For a thousand years the Skaa slaved in misery and lived in fear. For a thousand years the Lord Ruler, the \"Sliver of Infinity,\" reigned with absolute power and ultimate terror, divinely invincible. Then, when hope was so long lost that not even its memory remained, a terribly scarred, heart-broken half-Skaa rediscovered it in the depths of the Lord Ruler's most hellish prison. Kelsier \"snapped\" and found in himself the powers of a Mistborn. A brilliant thief and natural leader, he turned his talents to the ultimate caper, with the Lord Ruler himself as the mark.\r\n\r\nKelsier recruited the underworld's elite, the smartest and most trustworthy allomancers, each of whom shares one of his many powers, and all of whom relish a high-stakes challenge. Then Kelsier reveals his ultimate dream, not just the greatest heist in history, but the downfall of the divine despot.\r\n\r\nBut even with the best criminal crew ever assembled, Kel's plan looks more like the ultimate long shot, until luck brings a ragged girl named Vin into his life. Like him, she's a half-Skaa orphan, but she's lived a much harsher life. Vin has learned to expect betrayal from everyone she meets. She will have to learn trust if Kel is to help her master powers of which she never dreamed.",
                new DateTime(
                    2006,
                    7,
                    17
                ),
                1
            ),
            new Book(
                "Dune",
                "Set on the desert planet Arrakis, Dune is the story of the boy Paul Atreides, heir to a noble family tasked with ruling an inhospitable world where the only thing of value is the “spice” melange, a drug capable of extending life and enhancing consciousness. Coveted across the known universe, melange is a prize worth killing for...",
                new DateTime(
                    2006,
                    7,
                    17
                ),
                2
            )
        };

        _dbContext
            .Books
            .AddRange(books);

        _dbContext
            .SaveChanges();
    }
}
