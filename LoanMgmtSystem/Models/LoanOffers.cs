using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanMgmtSystem.Models
{
    public class LoanOffers
    {
        [Display(Name = "Offer Id")]
        public string OfferId { get; set; }

        [Display(Name = "Offer Name ")]
        [Required(ErrorMessage = "Please Enter Offer.")]
        public string OfferName { get; set; }         
    }
}