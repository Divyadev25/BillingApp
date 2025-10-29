using System.ComponentModel.DataAnnotations;
namespace RestaurantBillingApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
