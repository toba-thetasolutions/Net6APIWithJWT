using System.ComponentModel.DataAnnotations;

namespace Net6APIWithJWT.Models
{
    public class AppUsers
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
