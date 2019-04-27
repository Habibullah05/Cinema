using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Entities;

namespace Cinema.Entities
{
    /// <summary>
    /// Сеанс:
    /// </summary>
    [Serializable]
    public class Session
    {
        /// <summary>
        /// Холл
        /// </summary>
        public Hall hall { set; get; }
        /// <summary>
        /// Фильм
        /// </summary>
        public Movie movie { set; get; }
        /// <summary>
        /// время
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// Массив проданных билетов
        /// </summary>
        public List<Ticket> tickets { get; set; } = new List<Ticket>();

        public override string ToString()
        {
            return $"Hall:{hall.title},Movie:{movie.title},Time{time.ToString()},Sold Ticket{tickets.Count}";
        }
    }
}
