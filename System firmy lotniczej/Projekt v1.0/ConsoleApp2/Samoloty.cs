using System;


namespace ConsoleApp2
{
    [Serializable]
    public abstract class Samoloty
    {
        public string typ;
        public double zasieg;
        public int liczbamiejsc;
        public Samoloty() { }
        public Samoloty(string typ_, double zasieg_, int liczbamiejsc_)
        {
            typ = typ_;
            zasieg = zasieg_;
            liczbamiejsc = liczbamiejsc_;
        }
        public int GetLiczbaMiejsc()
        {
            return liczbamiejsc;
        }
        public override string ToString()
        {
            return typ + " " + Convert.ToString(zasieg) + " " + Convert.ToString(liczbamiejsc);
        }
    }
}
