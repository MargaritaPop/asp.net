using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[a-zA-Zа-яёА-ЯЁ\- ]+", ErrorMessage = "Некорректное имя")]
        public string NameOfProduct { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Некорректное количество")]
        public int Count { get; set; }
    }
}