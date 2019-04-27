using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Cinema.Entities;

namespace Cinema.Logic
{/// <summary>
/// Класс для 
/// работы 
/// с .xml
/// </summary>
    class XmlWriter : IWriter
    {

        /// <summary>
        /// Чтение из .xml
        /// файла
        /// </summary>
        /// <param name="database"></param>
        /// <returns>DataBase</returns>
        public T Load<T>(string path)
        {
            T database;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (Stream fs = File.OpenRead(path))
            {
                database = (T)serializer.Deserialize(fs);
            }
            return database;
        }


        /// <summary>
        ///  Запись в .xml
        /// фаил
        /// </summary>
        /// <param name="database"></param>
        public void Write<T>(T collection, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (Stream fs = File.Create(path))
            {
                serializer.Serialize(fs, collection);
            }
        }


       




        /*  static public void MyXmlSerializable(List<Hall> halls,List<Movie> movies,List<Session> sessions)
          {
              XmlSerializer xml_halls = new XmlSerializer(typeof(List<Hall>));
              XmlSerializer xml_movies = new XmlSerializer(typeof(List<Movie>));
              XmlSerializer xml_Session = new XmlSerializer(typeof(List<Session>));
              using (Stream fs=File.Create("Halls.xml"))
              {
                  xml_halls.Serialize(fs, halls);
              }
              using (Stream fs = File.Create("Movie.xml"))
              {
                  xml_movies.Serialize(fs, movies);
              }
              using (Stream fs = File.Create("Sessions.xml"))
              {
                  xml_Session.Serialize(fs, sessions);
              }


          }
          static public List<Hall> MyXmlHallDesSerializable()
          {



              XmlSerializer xml_halls = new XmlSerializer(typeof(List<Hall>));
              using (Stream fs=File.OpenRead("Halls.xml"))
              {
                  return xml_halls.Deserialize(fs) as List<Hall>;
              }



          }
                  static public List<Movie> MyXmlMovieDesSerializable()
          {
              XmlSerializer xml_Movie = new XmlSerializer(typeof(List<Movie>));
              using (Stream fs = File.OpenRead("Movie.xml"))
              {
                  return xml_Movie.Deserialize(fs) as List<Movie>;
              }

          }
          static public List<Session> MyXmlSessionsDesSerializable()
          {
              XmlSerializer xml_Session = new XmlSerializer(typeof(List<Session>));
              using (Stream fs = File.OpenRead("Sessions.xml"))
              {
                  return xml_Session.Deserialize(fs) as List<Session>;
              }

          }*/
    }
}
