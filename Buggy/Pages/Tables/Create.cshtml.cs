using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Buggy.Models.Scaffold;

namespace Buggy.Pages.Tables
{
    public class CreateModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;

        public CreateModel(Buggy.Models.Scaffold.BuggyDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnotherTableId"] = new SelectList(_context.AnotherTables, "AnotherTableId", "AnotherTableId");
            return Page();
        }

        [BindProperty]
        public Table Table { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tables == null || Table == null)
            {
                return Page();
            }

            _context.Tables.Add(Table);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
