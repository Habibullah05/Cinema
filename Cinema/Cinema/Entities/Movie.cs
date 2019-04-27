using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.UI;
using Cinema.Entities;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Entities
{/// <summary>
/// Фильм:
/// </summary>
    [Serializable]
    public class Movie 
    {
        /// <summary>
        /// название
        /// </summary>
        [Required]
        public string title { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// год выпуска
        /// </summary>
        [Required]
        [Range(1900,2019)]
        public int yearIssue { get; set; }
        /// <summary>
        /// жанр
        /// </summary>
        public string genre { get; set; }
        /// <summary>
        /// продюсер
        /// </summary>
        public string producer { get; set; }
        /// <summary>
        /// состояние (показывают сейчас, будут показывать или уже показывали)
        /// </summary>
        public enum condition { Past=1, Current=2, Future=3 };
        /// <summary>
        /// запись состояния
        /// </summary>
        public string ConditionStr { get; set; }
        public Movie() { }

        public override string ToString()
        {
            return  "Movie "+title+" ("+genre+", "+yearIssue+", "+producer+")";
        }

    }
}
