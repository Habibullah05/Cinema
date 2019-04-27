using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.Logic
{
    /// <summary>
    /// База Данных
    /// </summary>
    [Serializable]
    [XmlType(TypeName = "DataBase")]
    public class DataBase
    {
        /// <summary>
        /// Лист Залов
        /// </summary>
        public List<Hall> halls {set; get; } = new List<Hall>();
        /// <summary>
        /// Лист Фильмов 
        /// </summary>
        public List<Movie> movies { set; get; } = new List<Movie>();
        /// <summary>
        /// Лист Сессий
        /// </summary>
        public List<Session> sessions { set; get; } = new List<Session>();

        private DataBase()
        {
               

        }

        /// <summary>
        /// Чтение из .xml
        /// файла
        /// </summary>
        /// <returns>DataBase</returns>
        public static DataBase Load()
        {
            DataBase database = new DataBase();
            XmlWriter xml = new XmlWriter();
            DataBase dataBase = new DataBase();
            dataBase= xml.Load<DataBase>("DataBase.xml");
            return dataBase;
        }
        /// <summary>
        /// Запись в .xml
        /// фаил
        /// </summary>
        /// <param name="database"></param>
        public void Write(DataBase database)
        {

            XmlWriter writer = new XmlWriter();
            writer.Write(database,"DataBase.xml");
        }

    }
}
