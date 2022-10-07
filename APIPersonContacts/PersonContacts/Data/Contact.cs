using System.ComponentModel.DataAnnotations;

namespace PersonContacts.Data
{
    public class Contact
    {
        [Key]
        [Required]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PersonName { get; set; }

        [Required]
        public string PersonEmail { get; set; }

        [Required]
        [MaxLength(10)]
        public string PersonPhone { get; set; }
    }
}