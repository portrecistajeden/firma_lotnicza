using System;


namespace ConsoleApp2
{
    [Serializable]
   public class Trasa
    {
        public double odleglosc;
        private Lotnisko miejscewylotu;
        private Lotnisko miejsceprzylotu;
        public string PrzylotZapis;
        public string WylotZapis;
        public Trasa() {}
        public Trasa(double odleglosc_, Lotnisko miejscewylotu_, Lotnisko miejsceprzylotu_)
        {
            odleglosc = odleglosc_;
            miejscewylotu = miejscewylotu_;
            PrzylotZapis = miejsceprzylotu_.ToString();
            miejsceprzylotu = miejsceprzylotu_;
            WylotZapis = miejscewylotu_.ToString();
        }
        public Lotnisko getMiejscePrzylotu()
        {
            return miejsceprzylotu;
        }

        public Lotnisko getMiejsceWylotu()
        {
            return miejscewylotu;
        }

        public double getOdleglosc()
        {
            return odleglosc;
        }

        public override string ToString()
        {
            return miejscewylotu.ToString() + " " + miejsceprzylotu.ToString() + " " + odleglosc.ToString();
        }
    }
    class TrasaIstniejeException: Exception
    {
        public TrasaIstniejeException(string msg) : base(msg)
        {

        }
    }
    class TrasaNieIstniejeException: Exception
    { 
        public TrasaNieIstniejeException(string msg) : base(msg)
        {

        }
    }
    class TrasaZlaOdlegloscException : Exception
    {
        public TrasaZlaOdlegloscException(string msg) : base(msg)
        {

        }
    }
}
