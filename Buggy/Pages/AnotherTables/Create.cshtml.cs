using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Buggy.Models.Scaffold;
using System.Timers;

namespace Buggy.Pages.AnotherTables
{
    public class CreateModel : PageModel
    {
        private readonly Buggy.Models.Scaffold.BuggyDBContext _context;
        private static System.Timers.Timer aTimer;

        public CreateModel(Buggy.Models.Scaffold.BuggyDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AnotherTable AnotherTable { get; set; } = default!;
        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.AnotherTables == null || AnotherTable == null)
            {
                return Page();
            }

            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            _context.AnotherTables.Add(AnotherTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        
        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            await Task.Delay(3000);

            string[] logMeTwice = {DateTime.Now.ToLongTimeString() };
            await System.IO.File.AppendAllLinesAsync(@"\\rds2\toolkat\Log\log.txt", logMeTwice);


            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
        
    }
}
