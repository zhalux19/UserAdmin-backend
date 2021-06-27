using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SATest.Models.DTO
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "You should fill out first name.")]
        [MaxLength(100, ErrorMessage = "The first name shouldn't have more than 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should fill out last name.")]
        [MaxLength(100, ErrorMessage = "The last name shouldn't have more than 100 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You should fill out email.")]
        [MaxLength(100, ErrorMessage = "The email shouldn't have more than 100 characters.")]
        public string Email { get; set; }
        public bool IsMale { get; set; }
        public bool Status { get; set; }
    }
}
