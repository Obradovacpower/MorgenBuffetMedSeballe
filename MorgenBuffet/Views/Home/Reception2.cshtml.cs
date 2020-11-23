using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MorgenBuffet.Models;
using MorgenBuffet.DTO;

namespace MorgenBuffet.Views.Home
{
    public class Reception2Model : PageModel
    {
        private Repository _repo;

        public Reception2Model(Repository repo)
        {
            _repo = repo;
        }

        public class InputModel
        {
            public int RoomNumber { get; set; }
            public int Adults { get; set; }
            public int Kids { get; set; }
        }

        public OrderDTO orderDTO { get; set; }
        public void OnGet()
        {
        }
        public async Task post(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                await _repo.AddOrder(orderDTO);
            }
        }
    }
}
