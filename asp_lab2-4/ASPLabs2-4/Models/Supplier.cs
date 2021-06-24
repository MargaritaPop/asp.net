using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[a-zA-Zа-яёА-ЯЁ\- ]+", ErrorMessage = "Некорректное имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[a-zA-Zа-яёА-ЯЁ\- ]+", ErrorMessage = "Некорректная страна")]
        public string Country { get; set; }
    }
}
