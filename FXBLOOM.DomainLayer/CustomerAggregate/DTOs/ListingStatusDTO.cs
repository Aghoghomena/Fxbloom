using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class ListingStatusDTO
    {
        [Required(ErrorMessage = "Listing Status is Required")]
        public ListingStatus listingStatus { get; set; }
        [Required(ErrorMessage = "Listing Id is Required")]
        public Guid listingId { get; set; }
    }
}
