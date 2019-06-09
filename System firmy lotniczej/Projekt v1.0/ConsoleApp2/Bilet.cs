using System;

namespace ConsoleApp2
{
    [Serializable]
    class Bilet
    {
        private int rzad;
        private int numermiejsca;
        private Trasa trasa;
        private int dzien;
        private int miesiac;
        private int godzinawylotu;
        private int godzinaprzylotu;
        private string idsamolotu;
        public Bilet(int rzad_, int numermiejsca_, Trasa trasa_, int dzien_, int miesiac_, int godzinawylotu_, int godzinaprzylotu_, string idsamolotu_)
        {
            rzad = rzad_;
            numermiejsca = numermiejsca_;
            trasa = trasa_;
            dzien = dzien_;
            miesiac = miesiac_;
            godzinawylotu = godzinawylotu_;
            godzinaprzylotu = godzinaprzylotu_;
            idsamolotu = idsamolotu_;
        }
        public Trasa getTrasa()
        {
            return trasa;
        }
        public int getRzad()
        {
            return rzad;
        }
        public int getNumermiejsca()
        {
            return numermiejsca;
        }
        public int getDzien()
        {
            return dzien;
        }
        public int getMiesiac()
        {
            return miesiac;
        }
        public int getGodzinawylotu()
        {
            return godzinawylotu;
        }
        public int getGodzinaprzylotu()
        {
            return godzinaprzylotu;
        }
        public string getIDsamolotu()
        {
            return idsamolotu;
        }
        public override string ToString()
        {
            return trasa.getMiejsceWylotu().ToString() + " " + trasa.getMiejscePrzylotu().ToString() + " " + dzien.ToString() + " " + miesiac.ToString() + " " + godzinawylotu.ToString() + " " + godzinaprzylotu.ToString() + " " + rzad.ToString() + " " + numermiejsca.ToString() + " " + idsamolotu.ToString();
        }
    }
    class MiejsceNieIstniejeException : Exception
    {
        public MiejsceNieIstniejeException(string msg) : base(msg)
        {

        }
    }
    class MiejsceJestZajeteException : Exception
    {
        public MiejsceJestZajeteException(string msg) : base(msg)
        {

        }
    }
}
