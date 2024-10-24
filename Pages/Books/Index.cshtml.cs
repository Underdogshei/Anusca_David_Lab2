﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anusca_David_Lab2.Data;
using Anusca_David_Lab2.Models;

namespace Anusca_David_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Anusca_David_Lab2.Data.Anusca_David_Lab2Context _context;

        public IndexModel(Anusca_David_Lab2.Data.Anusca_David_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Publisher)
                .ToListAsync();
            Book = await _context.Book
                .Include(b => b.Author) 
                .ToListAsync();
        }
    }
}
