using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryGazi.Models
{
    public class RequestDetails
    {
      
        public string UserName { get; set; }

        [Required(ErrorMessage="Kitapları almaya geleceğiniz tarihi seçiniz.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime alisTarihi { get; set; }

        [Required(ErrorMessage = "Kitapları vermeye geleceğiniz tarihi seçiniz.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime verisTarihi { get; set; }
    }
}