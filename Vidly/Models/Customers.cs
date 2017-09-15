using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Vidly.Models.Validations;

namespace Vidly.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        [AgeValidation]
        public DateTime? BirthDate { get; set; }
     

        public MembershipTypes MembershipTypes { get; set; }
        [Display(Name = "Subscribe to Letter")]
        public bool IsSubscribeToLetter { get; set; }
        [Display(Name = "Membership Type")]
        [Required]
        public int MembershipTypesId { get; set; }
    }
}