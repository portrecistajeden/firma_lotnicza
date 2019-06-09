using System;

namespace ConsoleApp2
{
    [Serializable]
    public class Samolot : Samoloty
    {
        public string IDsamolotu;
        public Samolot() { }
        public Samolot(string typ_, double zasieg_, int liczbamiejsc_, string IDsamolotu_) : base(typ_, zasieg_, liczbamiejsc_)
        {
            IDsamolotu = IDsamolotu_;
        }
        public string getTyp()
        {
            return typ;
        }
        public string getIDsamolotu()
        {
            return IDsamolotu;
        }
        public double getZasieg()
        {
            return zasieg;
        }
        public int getLiczbamiejsc()
        {
            return liczbamiejsc;
        }
        public override string ToString()
        {
            return base.ToString() + " " + IDsamolotu;
        }
    }
    
    class SamolotIstniejeException : Exception
    {
        public SamolotIstniejeException(string msg) : base(msg)
        {

        }
    }
    class SamolotNieIstniejeException : Exception
    {
        public SamolotNieIstniejeException(string msg) : base(msg)
        {

        }
    }

}
