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
    public class IndexModel : PageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public IndexModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        public IList<Stake> Stake { get;set; }

        public async Task OnGetAsync()
        {
            Stake = await _context.Stakes.ToListAsync();
        }
    }
}
