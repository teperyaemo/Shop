using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Addressee
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string name { get; set; }

        [Display(Name = "Адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string email { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите номер телефона")]
        public string phoneNumber { get; set; }

        [Display(Name = "Тема")]
        [Required(ErrorMessage = "Введите тему сообщения")]
        public string subject { get; set; }

        [Display(Name = "Сообщение")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите Сообщение")]
        public string message { get; set; }

    }
}
