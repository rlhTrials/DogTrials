using DogTrials.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogTrials.Pages.People
{
    public class PersonNamePageModel : PageModel
    {

        public SelectList PersonNameSL { get; set; }

        public void PopulatePersonNamesDropDownList(DogTrialsContext _context,
            object selectedPerson = null)
        {
            var personQuery = from p in _context.People
                              orderby p.LastName
                              select p;

            PersonNameSL = new SelectList(personQuery.AsNoTracking(),
                "ID", "FullName", selectedPerson);
        }
    }
}
