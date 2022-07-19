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
    public class IndexModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;

        public IndexModel(Buggy.Models.Scaffold.BuggyDBContext context)
        {
            _context = context;
        }

        public IList<AnotherTable> AnotherTable { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AnotherTables != null)
            {
                AnotherTable = await _context.AnotherTables.ToListAsync();
            }
        }
    }
}
