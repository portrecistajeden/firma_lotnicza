using System;


namespace ConsoleApp2
{
    [Serializable]
    public class Lot
    { 
        private Trasa trasa;
        Samolot samolot;
        private int czaspodrozy;
        private int godzinawylotu;
        private int godzinaprzylotu;
        private int[,] miejsca;
        public Lot()
        {

        }
        public Lot(Trasa trasa_, Samolot samolot_, int czaspodrozy_, int godzinawylotu_, int godzinaprzylotu_)
        {
            trasa = trasa_;
            samolot = samolot_;
            czaspodrozy = czaspodrozy_;
            godzinawylotu = godzinawylotu_;
            godzinaprzylotu = godzinaprzylotu_;
            miejsca = new int[samolot.GetLiczbaMiejsc()/6, 6];
        }
        public Lot(Lot x)
        {
            trasa = x.getTrasa();
            samolot = x.getSamolot();
            czaspodrozy = x.getCzaspodrozy();
            godzinawylotu = x.getGodzinawylotu();
            godzinaprzylotu = x.getGodzinaprzylotu();
            miejsca = x.getMiejsca();
        }
        public Trasa getTrasa()
        {
            return trasa;
        }
        public Samolot getSamolot()
        {
            return samolot;
        }
        public int getGodzinawylotu()
        {
            return godzinawylotu;
        }
        public int getGodzinaprzylotu()
        {
            return godzinaprzylotu;
        }
        public int[,] getMiejsca()
        {
            return miejsca;
        }
        public int getCzaspodrozy()
        {
            return czaspodrozy;
        }
        public void setMiejsce(int rzad, int miejsce)
        {
            miejsca[rzad - 1, miejsce - 1] = 1;
        }
        public override string ToString()
        {
            return samolot.getIDsamolotu() + " " + samolot.getTyp() + " " + samolot.getLiczbamiejsc() / 6 + " " + trasa.getMiejsceWylotu().getNazwalotniska() + " " + trasa.getMiejscePrzylotu().getNazwalotniska() + " " + godzinawylotu.ToString() + " " + godzinaprzylotu.ToString();
        }
    }
    class LotNieIstniejeException : Exception
    {
        public LotNieIstniejeException(string msg) : base(msg)
        {

        }
    }
    class LotySiePokrywajaException : Exception
    {
        public LotySiePokrywajaException(string msg) : base(msg)
        {

        }
    }
    class SamolotJestWInnymMiejscuException : Exception
    {
        public SamolotJestWInnymMiejscuException(string msg) : base(msg)
        {

        }
    }
    class ZasiegSamolotuZaMalyException : Exception
    {
        public ZasiegSamolotuZaMalyException(string msg) : base(msg)
        {

        }
    }
    class ZlaGodzinaException : Exception
    {
        public ZlaGodzinaException(string msg) : base(msg)
        {

        }
    }
}
