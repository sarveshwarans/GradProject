﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class CheckoutViewModel
    {
        [RegularExpression(@"[0-9]+-", ErrorMessage = "The Credit Card number must be 16 digits")]
        [Display(Name = "Credit Card Number")]
        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Cardholder Name")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string CardholderName { get; set; }


        [Display(Name = "Card Type")]
        [Required]
        [StringLength(6, MinimumLength = 5)]
        public string CardType { get; set; }


        [Display(Name = "Card Provider")]
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string CardProvider { get; set; }


        [Display(Name = "Expiration Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM}")]
        public DateTime ExpirationDate { get; set; }


        [Display(Name = "First Name")]
        [Required]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "The Name must be at least 4 - 100 "
      + "characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "The Last Name must be at least 4 - 100 "
        + "characters long.")]
        public string LastName { get; set; }


        [Display(Name = "Address")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Address { get; set; }


        [Display(Name = "City")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string City { get; set; }


        [Display(Name = "State")]
        [Required]
        [StringLength(5, MinimumLength = 2)]
        public string State { get; set; }


        [Display(Name = "Postal Code")]
        [Required]
        [StringLength(11, MinimumLength = 5)]
        public string PostalCode { get; set; }


        [Display(Name = "Country")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Country { get; set; }


        [RegularExpression(@"[0-9]+-", ErrorMessage = "The Phone number must be 10 digits")]
        [Display(Name = "Phone Number")]
        [Required]
        [StringLength(14, MinimumLength = 12)]
        public string PhoneNumber { get; set; }


        [Display(Name = "Email Address")]
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Email { get; set; }

    }
}
