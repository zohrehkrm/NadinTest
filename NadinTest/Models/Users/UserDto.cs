using System.ComponentModel.DataAnnotations;

namespace NadinTest.Models.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "نام کاربری ضروری است.")]
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
