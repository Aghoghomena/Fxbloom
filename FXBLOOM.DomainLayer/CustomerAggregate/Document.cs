using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate
{
    public class Document : ValueObject<Document>
    {
        public string IDNumber { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public string Img { get; private set; }

        internal static Document CreateDocument(DocumentDto documentDto)
        {

            Document dc = new Document();
            dc.IDNumber = documentDto.IDNumber;
            dc.DocumentType = documentDto.DocumentType;
            dc.Img = documentDto.Img;

            return dc;
        }
    }
}
