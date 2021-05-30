using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class DocumentDto
    {
        public int Id { get; private set; }
        public string IDNumber { get; private set; }
        public int DocumentType { get; private set; }

    }
}
