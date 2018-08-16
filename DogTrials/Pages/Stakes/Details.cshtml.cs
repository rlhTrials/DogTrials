using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogTrials.Models;

namespace DogTrials.Pages.Stakes
{
    public class DetailsModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public DetailsModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        public Stake Stake { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stake = await _context.Stakes.SingleOrDefaultAsync(m => m.ID == id);

            if (Stake == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
