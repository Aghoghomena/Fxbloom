using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class DocumentDto
    {
        
        public string IDNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Img { get; set; }

    }
}
