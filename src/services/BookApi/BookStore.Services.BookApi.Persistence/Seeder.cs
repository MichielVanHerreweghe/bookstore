﻿using BookStore.Services.BookApi.Domain.Authors;
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
                "https://m.media-amazon.com/images/I/51G0zeHL2FL._AC_SY780_.jpg",
                1
            ),
            new Book(
                "Skyward",
                "Defeated, crushed, and driven almost to extinction, the remnants of the human race are trapped on a planet that is constantly attacked by mysterious alien starfighters. Spensa, a teenage girl living among them, longs to be a pilot. When she discovers the wreckage of an ancient ship, she realizes this dream might be possible—assuming she can repair the ship, navigate flight school, and (perhaps most importantly) persuade the strange machine to help her. Because this ship, uniquely, appears to have a soul.",
                new DateTime(
                    2018,
                    11,
                    6
                ),
                "https://m.media-amazon.com/images/I/81UalU6lAoL._AC_UF1000,1000_QL80_.jpg",
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
                "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1555447414i/44767458.jpg",
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
