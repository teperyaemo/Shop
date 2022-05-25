using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name ="Имя")]
        [Required(ErrorMessage ="Введите имя")]
        public string name { get; set; }

        [Display(Name = "Адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string email { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите номер телефона")]
        public string phoneNumber { get; set; }
        
        [BindNever]
        [ScaffoldColumn(false)]
        [Display(Name = "Дата")]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
