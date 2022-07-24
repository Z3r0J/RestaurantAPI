using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.DTOS.Account
{
    public class PasswordRequest
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
