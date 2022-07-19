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
    public class DetailsModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;

        public DetailsModel(Buggy.Models.Scaffold.BuggyDBContext context)
        {
            _context = context;
        }

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
    }
}
