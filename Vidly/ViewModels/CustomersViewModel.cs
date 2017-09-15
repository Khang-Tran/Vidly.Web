using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public Customers Customers { get; set; }
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }       
    }
}