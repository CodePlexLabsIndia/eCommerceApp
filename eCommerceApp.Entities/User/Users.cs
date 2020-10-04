using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCommerceApp.Entities
{
    public class Users
    {
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddileName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        [Display(Name = "Remember me?")]
        [NotMapped]
        public bool RememberMe { get; set; }
    }
}
