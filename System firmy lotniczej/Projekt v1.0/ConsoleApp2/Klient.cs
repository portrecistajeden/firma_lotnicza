using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp2
{
    [Serializable]
    abstract class Klient
    {
        private List<Bilet> ListaBiletow = new List<Bilet>();
        public void ZarezerwujBilet(Bilet bilet_, Lot[,,,] tablica)
        {
            int i, j, k, l, m, n, y=-1, z;
            i = bilet_.getDzien();
            j = bilet_.getMiesiac();
            k = bilet_.getGodzinawylotu();
            l = bilet_.getGodzinaprzylotu();
            m = bilet_.getRzad();
            n = bilet_.getNumermiejsca();
            for (z=0;z<10;z++)
            {
                if (tablica [j-1,i-1,k,z] != null && tablica[j-1,i-1,k,z].getGodzinawylotu() == k && tablica[j-1,i-1,k,z].getGodzinaprzylotu() == l && tablica[j-1,i-1,k,z].getSamolot().getIDsamolotu() == bilet_.getIDsamolotu())
                {
                    y = z;
                }
            }
            if (y == -1) throw new LotNieIstniejeException("Tego dnia taki lot nie istnieje");
            if (bilet_.getTrasa().getMiejsceWylotu().getNazwalotniska() != tablica[j-1,i-1,k,y].getTrasa().getMiejsceWylotu().getNazwalotniska() || bilet_.getTrasa().getMiejscePrzylotu().getNazwalotniska() != tablica[j-1,i-1,k,y].getTrasa().getMiejscePrzylotu().getNazwalotniska())
            {
                throw new TrasaNieIstniejeException("Trasa nie istnieje");
            }
            if (bilet_.getRzad() > tablica[j-1,i-1,k,y].getSamolot().getLiczbamiejsc()/6 || bilet_.getRzad() < 1)
            {
                throw new MiejsceNieIstniejeException("Miejsce nie istnieje");
            }
            int[,] miejsca = new int[tablica[j-1, i-1, k, y].getSamolot().getLiczbamiejsc() / 6, 6]; 
            miejsca = tablica[j-1, i-1, k, y].getMiejsca();
            if (miejsca[m-1,n-1] == 1)
            {
                throw new MiejsceJestZajeteException("Miejsce jest zajęte");
            }
            tablica[j - 1, i - 1, k, y].setMiejsce(m, n);
            ListaBiletow.Add(bilet_);
        }
        public List<Bilet> PrzegladBiletow()
        {
            return ListaBiletow;
        }
        public int getLiczbabiletow()
        {
            return ListaBiletow.Count();
        }
        public virtual string getImie()
        {
            return null;
        }
        public virtual string getNazwisko()
        {
            return null;
        }
        public virtual string getNazwafirmy()
        {
            return null;
        }
    }
}
