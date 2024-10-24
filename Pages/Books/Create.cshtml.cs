using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Anusca_David_Lab2.Data;
using Anusca_David_Lab2.Models;

namespace Anusca_David_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Anusca_David_Lab2.Data.Anusca_David_Lab2Context _context;

        public CreateModel(Anusca_David_Lab2.Data.Anusca_David_Lab2Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
        "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
