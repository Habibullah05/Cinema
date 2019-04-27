using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.UI;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Entities
{
    /// <summary>
    /// Зал кинотеатра:
    /// </summary>
    [Serializable]
    public class Hall
    {/// <summary>
     /// название
     /// </summary>
        [Required]
        public string title { get; set; }
        /// <summary>
        ///  тип(2D, 3D, IMAX)
        /// </summary>
        public enum types { _2 = 1, _3D = 2, _IMAX = 3 }
        /// <summary>
        /// для ввода числа в радиусе
        /// </summary>
        [Required]
        [Range(1, 3)]
        public int enumType { get; set; }
        /// <summary>
        /// для записи типов
        /// </summary>
        public string TypeStr { get; set; }
        /// <summary>
        /// количество рядов
        /// </summary>
        public byte num_rows { get; set; }
        /// <summary>
        /// количество мест
        /// </summary>
        public byte num_seats { get; set; }

        public Hall() { }

        public override string ToString()
        {
            return "Hall " + title + " (" + TypeStr + " " + (num_rows * num_seats) + "seats)";
        }
    }
}
