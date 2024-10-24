using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anusca_David_Lab2.Models;

namespace Anusca_David_Lab2.Data
{
    public class Anusca_David_Lab2Context : DbContext
    {
        public Anusca_David_Lab2Context (DbContextOptions<Anusca_David_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Anusca_David_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Anusca_David_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Anusca_David_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
