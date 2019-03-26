using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership type")]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        [Min18ifamember]
        public DateTime? Birthday { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customers customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            MemberShipTypeId = customer.MemberShipTypeId;
            MembershipType = customer.MembershipType;
            IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;
            Birthday = customer.Birthday;
        }
    }
}