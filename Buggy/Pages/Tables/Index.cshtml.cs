using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Buggy.Models.Scaffold;

namespace Buggy.Pages.Tables
{
    public class IndexModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;

        public IndexModel(Buggy.Models.Scaffold.BuggyDBContext context)
        {
            _context = context;
        }

        public IList<Table> Table { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tables != null)
            {
                Table = await _context.Tables
                .Include(t => t.AnotherTable).ToListAsync();
            }
        }
    }
}
