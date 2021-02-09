using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Phone_Contacts.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a note.")]
        public string Note { get; set; }

        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + PhoneNumber?.ToString();
    }
}
