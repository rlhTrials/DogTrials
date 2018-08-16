using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogTrials.Models;
using DogTrials.Pages.People;

namespace DogTrials.Pages.Dogs
{
    public class CreateModel : PersonNamePageModel
    {
        private readonly DogTrials.Models.DogTrialsContext _context;

        public CreateModel(DogTrials.Models.DogTrialsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulatePersonNamesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyDog = new Dog();

            if(await TryUpdateModelAsync<Dog>(
                emptyDog,
                "dog",
                s => s.RegisteredName,
                s => s.CallName,
                s => s.Sex,
                s => s.DateOfBirth, 
                s => s.RegistrationNumber,
                s => s.Breed,
                s => s.OwnerID))
            {
                _context.Dogs.Add(emptyDog);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulatePersonNamesDropDownList(_context, emptyDog.Owner);
            return Page();
        }
    }
}