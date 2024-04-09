using System;
using System.Collections.Generic;

namespace app
{
    internal class Equalizer
    {
        // Properties
        public Dictionary<string, string> BalanceParameters { get; set; }
        public bool Active { get; private set; }
        public int BassValue { get; private set; }
        // Constructor
        public Equalizer()
        {
            BalanceParameters = new Dictionary<string, string>();
            Active = false;
            BassValue = 0;
        }

        // BalanceParameters changer
        public void ChangeBalanceParameters(Dictionary<string, string> newParameters)
        {
            BalanceParameters = newParameters;
        }

        public void AdjustBass(int bassLevel)
        {
            BassValue = bassLevel;
        }
        // Activator
        public void Activate()
        {
            Active = true;
        }

        // Deactivator
        public void Deactivate()
        {
            Active = false;
        }
    }
}
