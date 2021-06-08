using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace FXBLOOM.DomainLayer.SubsriptionAggregate
{
    public class Subscription
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(500, ErrorMessage = "name email can only be 100 characters long")]
        public string email { get; set; }

        public bool IsCurrentlySubscribed { get; set; } = true;

        public DateTime dateAdded { get; private set; }= System.DateTime.Now;

        public bool emailSent { get; private set; } = false;

    }
}
