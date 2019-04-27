using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities
{
    /// <summary>
    /// Class which containt information about statistic
    /// </summary>
    [Serializable]
    class Statistic
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Infomation about statistics</param>
        public Statistic(string text)
        {
            Text = text;
        }
        /// <summary>
        /// Property which contains information about statistics
        /// </summary>
        public string Text { get; set; }
    }
}
