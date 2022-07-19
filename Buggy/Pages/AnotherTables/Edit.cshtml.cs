using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buggy.Models.Scaffold;

namespace Buggy.Pages.AnotherTables
{
    public class EditModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;

        public EditModel(Buggy.Models.Scaffold.BuggyDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AnotherTable AnotherTable { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnotherTables == null)
            {
                return NotFound();
            }

            var anothertable =  await _context.AnotherTables.FirstOrDefaultAsync(m => m.AnotherTableId == id);
            if (anothertable == null)
            {
                return NotFound();
            }
            AnotherTable = anothertable;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AnotherTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnotherTableExists(AnotherTable.AnotherTableId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AnotherTableExists(int id)
        {
          return (_context.AnotherTables?.Any(e => e.AnotherTableId == id)).GetValueOrDefault();
        }
    }
}
