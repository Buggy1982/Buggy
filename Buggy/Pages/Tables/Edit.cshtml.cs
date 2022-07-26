﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buggy.Models.Scaffold;

namespace Buggy.Pages.Tables
{
    public class EditModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;

        public EditModel(Buggy.Models.Scaffold.BuggyDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Table Table { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var table =  await _context.Tables.FirstOrDefaultAsync(m => m.TableId == id);
            if (table == null)
            {
                return NotFound();
            }
            Table = table;
           ViewData["AnotherTableId"] = new SelectList(_context.AnotherTables, "AnotherTableId", "AnotherTableId");
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

            _context.Attach(Table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(Table.TableId))
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

        private bool TableExists(int id)
        {
          return (_context.Tables?.Any(e => e.TableId == id)).GetValueOrDefault();
        }
    }
}
