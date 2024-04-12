using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class Song
    {
        private string name { get; set; }
        private string artist { get; set; }
        private int likes { get; set; }
        private string album { get; set; }

        private int id { get; set; }
        private int duration { get; set; }

        private int timePlayed { get; set; }
    }
}
