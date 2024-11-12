using System.ComponentModel.DataAnnotations;

namespace Laptopy.DTOs
{
    public class LoginDTo
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
