﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anusca_David_Lab2.Data;
using Anusca_David_Lab2.Models;
using Anusca_David_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Anusca_David_Lab2.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Anusca_David_Lab2.Data.Anusca_David_Lab2Context _context;

        public IndexModel(Anusca_David_Lab2.Data.Anusca_David_Lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = CategoryData.Categories
                    .Where(c => c.ID == id.Value).Single();
                CategoryData.Books = selectedCategory.BookCategories
                    .Select(bc => bc.Book);
            }
        }
    }
}
