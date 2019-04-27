using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Entities;

namespace Cinema.Logic
{
  /// <summary>
     /// This interface must be overrided for writing,reading objects
     /// </summary>
    interface IWriter
    {
        /// <summary>
        /// Method for reading file
        /// </summary>
        /// <typeparam name="T">Object that we will use in function<</typeparam>
        /// <param name="path">Path to file</param>
        /// <returns></returns>
        T Load<T>(string path);
        /// <summary>
        /// Method for writing file
        /// </summary>
        /// <typeparam name="T">Object that we will use in function<</typeparam>
        /// <param name="dataBase">Collection that we will work with</param>
        /// <param name="path">Path to file</param>
        void Write<T>(T dataBase, string path);
    }
}
