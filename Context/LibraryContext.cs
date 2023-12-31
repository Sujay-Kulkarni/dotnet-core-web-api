﻿using Microsoft.EntityFrameworkCore;
using my_books.Models;


namespace my_books.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorId);
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book_Author> Books_Authors { get; set; }

    }
}
