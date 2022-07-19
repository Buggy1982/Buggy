using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Buggy.Models.Scaffold;

namespace Buggy.Pages.AnotherTables
{
    public class DeleteModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;

        public DeleteModel(Buggy.Models.Scaffold.BuggyDBContext context)
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

            var anothertable = await _context.AnotherTables.FirstOrDefaultAsync(m => m.AnotherTableId == id);

            if (anothertable == null)
            {
                return NotFound();
            }
            else 
            {
                AnotherTable = anothertable;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AnotherTables == null)
            {
                return NotFound();
            }
            var anothertable = await _context.AnotherTables.FindAsync(id);

            if (anothertable != null)
            {
                AnotherTable = anothertable;
                _context.AnotherTables.Remove(AnotherTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
