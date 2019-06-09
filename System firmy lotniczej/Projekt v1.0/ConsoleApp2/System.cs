using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp2
{
    class System
    {
        public pom K = new pom();
        private Lot[,,,] LotyRok = new Lot[12, 30, 24, 10];
        private List<Samolot> ListaSamolotow = new List<Samolot>();
        private List<Lotnisko> ListaLotnisk = new List<Lotnisko>();
        private List<Klient> ListaKlientow = new List<Klient>();
        private List<Trasa> ListaTras = new List<Trasa>();
        public void Zapis()
        {
            Console.Clear();
            //lotniska
            FileStream Mystream;
            Mystream = new FileStream("lotniska.dat", FileMode.Create);
            BinaryFormatter MyFormatter = new BinaryFormatter();
            try
            {
                MyFormatter.Serialize(Mystream, ListaLotnisk);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            //samoloty            
            Mystream = new FileStream("samoloty.dat", FileMode.Create);
            MyFormatter = new BinaryFormatter();
            try
            {
                MyFormatter.Serialize(Mystream, ListaSamolotow);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            //trasy            
            Mystream = new FileStream("trasy.dat", FileMode.Create);
            MyFormatter = new BinaryFormatter();
            try
            {
                MyFormatter.Serialize(Mystream, ListaTras);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            //klienci
            Mystream = new FileStream("klienci.dat", FileMode.Create);
            MyFormatter = new BinaryFormatter();
            try
            {
                MyFormatter.Serialize(Mystream, ListaKlientow);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            //loty
            Mystream = new FileStream("loty.dat", FileMode.Create);
            MyFormatter = new BinaryFormatter();
            try
            {
                MyFormatter.Serialize(Mystream, LotyRok);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            Console.ReadKey();
            Console.Clear();
        }
        public void Odczyt()
        {
            Console.Clear();
            //lotniska
            
            try
            {
                FileStream Mystream;
                Mystream = new FileStream("lotniska.dat", FileMode.Open);
                BinaryFormatter MyFormatter = new BinaryFormatter();
                ListaLotnisk = (List<Lotnisko>)MyFormatter.Deserialize(Mystream);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            
            //samoloty
            
            try
            {
                FileStream Mystream;
                Mystream = new FileStream("samoloty.dat", FileMode.Open);
                BinaryFormatter MyFormatter = new BinaryFormatter();
                ListaSamolotow = (List<Samolot>)MyFormatter.Deserialize(Mystream);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            };
            //trasy
            
            try
            {
                FileStream Mystream = new FileStream("trasy.dat", FileMode.Open);
                BinaryFormatter MyFormatter = new BinaryFormatter();
                ListaTras = (List<Trasa>)MyFormatter.Deserialize(Mystream);

                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            //klienci
            
            try
            {
                FileStream Mystream = new FileStream("klienci.dat", FileMode.Open);
                BinaryFormatter MyFormatter = new BinaryFormatter();
                ListaKlientow = (List<Klient>)MyFormatter.Deserialize(Mystream);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
           
            try
            {
                FileStream Mystream = new FileStream("loty.dat", FileMode.Open);
                BinaryFormatter MyFormatter = new BinaryFormatter();
                LotyRok = (Lot[,,,])MyFormatter.Deserialize(Mystream);
                Mystream.Close();
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            Console.ReadKey();
            Console.Clear();
        }
        public void DodajTrase(Trasa x)
        {
            int i, a = 0, b = 0;
            for (i = 0; i < ListaLotnisk.Count(); i++)
            {
                if (ListaLotnisk[i].getNazwalotniska() == (x.getMiejsceWylotu().getNazwalotniska())) a++;
            }
            if (a == 0) throw new LotniskoNieIstniejeException("Lotnisko o podanej nazwie nie istnieje");
            for (i = 0; i< ListaLotnisk.Count();i++)
            {
                if (ListaLotnisk[i].getNazwalotniska() == (x.getMiejscePrzylotu().getNazwalotniska())) b++;
            }
            if (b == 0) throw new LotniskoNieIstniejeException("Lotnisko o podanej nazwie nie istnieje");
            if ((x.getMiejsceWylotu()).getNazwalotniska() == (x.getMiejscePrzylotu().getNazwalotniska()))
            {
                throw new LotniskaTakieSameException("Miejsce wylotu oraz przylotu jest takie same");
            }
            for (i = 0; i < ListaTras.Count(); i++)
            {
                if ((ListaTras[i].getMiejsceWylotu()).getNazwalotniska() == (x.getMiejsceWylotu()).getNazwalotniska() && (ListaTras[i].getMiejscePrzylotu()).getNazwalotniska() == (x.getMiejscePrzylotu()).getNazwalotniska())
                {
                    throw new TrasaIstniejeException("Trasa już istnieje");
                }
            }
            for (i=0;i<ListaTras.Count();i++)
            {
                if (x.getMiejsceWylotu().getNazwalotniska() == ListaTras[i].getMiejscePrzylotu().getNazwalotniska() && x.getMiejscePrzylotu().getNazwalotniska() == ListaTras[i].getMiejsceWylotu().getNazwalotniska() && x.getOdleglosc() !=ListaTras[i].getOdleglosc())
                {
                    throw new TrasaZlaOdlegloscException("Podano złą odległość");
                }
            }
            ListaTras.Add(x);
        }
        public void UsunTrase(Trasa x)
        {
            int i, z = 0;
            for (i = 0; i < ListaTras.Count(); i++)
            {
                if ((ListaTras[i].getMiejsceWylotu()).getNazwalotniska() == (x.getMiejsceWylotu()).getNazwalotniska() && (ListaTras[i].getMiejscePrzylotu()).getNazwalotniska() == (x.getMiejscePrzylotu()).getNazwalotniska())
                {
                    ListaTras.RemoveAt(i);
                    z++;
                }
            }
            if (z == 0) throw new TrasaNieIstniejeException("Trasa nie istnieje");
        }
        public List<Trasa> PrzegladTras()
        {
            return ListaTras;
        }

        public double ZnajdzOdleglosc(Lotnisko miejscewylotu, Lotnisko miejsceprzylotu)
        {
            int i;
            for(i=0; i<ListaTras.Count(); i++)
            {
                if(miejsceprzylotu.getNazwalotniska() == ListaTras[i].getMiejscePrzylotu().getNazwalotniska() && miejscewylotu.getNazwalotniska() == ListaTras[i].getMiejsceWylotu().getNazwalotniska())
                {
                    return ListaTras[i].getOdleglosc();
                }
            }
            return 0;
        }
        public void DodajLotnisko(Lotnisko x)
        {
            int i;
            for (i= 0;i<ListaLotnisk.Count();i++)
            {
                if (ListaLotnisk[i].getNazwalotniska()==x.getNazwalotniska())
                {
                    throw new LotniskoIstniejeException("Lotnisko o podanej nazwie istnieje");
                }
            }
            ListaLotnisk.Add(x);
        }
        public void UsunLotnisko(Lotnisko x)
        {
            int i,z=0;
            for (i = 0; i < ListaTras.Count(); i++)
            {
                if (x.getNazwalotniska() == ListaTras[i].getMiejsceWylotu().getNazwalotniska() || x.getNazwalotniska() == ListaTras[i].getMiejscePrzylotu().getNazwalotniska())
                {
                    throw new TrasaIstniejeException("Istnieje trasa zawierająca to lotnisko");
                }
            }
            for (i=0;i<ListaLotnisk.Count();i++)
            {
                if (ListaLotnisk[i].getNazwalotniska() == x.getNazwalotniska())
                {
                    ListaLotnisk.RemoveAt(i);
                    z++;
                }
            }
            if (z==0) throw new LotniskoNieIstniejeException("Lotnisko o podanej nazwie nie istnieje");
        }
        public List<Lotnisko> PrzegladLotnisk()
        {
            return ListaLotnisk;
        }
        public void DodajSamolot(Samolot x)
        {
            int i;
            for (i = 0; i < ListaSamolotow.Count(); i++)
            {
                if (ListaSamolotow[i].getIDsamolotu() == x.getIDsamolotu())
                {
                    throw new SamolotIstniejeException("Samolot o podanym ID już istnieje");
                }
            }
            ListaSamolotow.Add(x);
        }
        public void UsunSamolot(string ID)
        {
            int i, z = 0;
            for (i = 0; i < ListaSamolotow.Count(); i++)
            {
                if (ListaSamolotow[i].getIDsamolotu() == ID)
                {
                    ListaSamolotow.RemoveAt(i);
                    z++;
                }
            }
            if (z == 0) throw new SamolotNieIstniejeException("Samolot o tym ID nie istnieje");
        }
        public List<Samolot> PrzegladSamolotow()
        {
            return ListaSamolotow;
        }
        public void DodajKlienta(Klient x)
        {
            int i;
            KlientIndywidualny a = new KlientIndywidualny("x", "y");
            FirmaPosrednik b = new FirmaPosrednik("x");
            if ((x.GetType()).Equals(a.GetType()))
            {
                for (i = 0; i < ListaKlientow.Count(); i++)
                {
                    if (ListaKlientow[i].getImie() == x.getImie() && ListaKlientow[i].getNazwisko() == x.getNazwisko() && (ListaKlientow[i].GetType()).Equals(x.GetType()))
                    {
                        throw new KlientIndywidualnyIstniejeException("Klient indywidualny już istnieje");
                    }
                }
                ListaKlientow.Add(x);
            }
            else
            {
                for (i=0;i<ListaKlientow.Count();i++)
                {
                    if (ListaKlientow[i].getNazwafirmy() == x.getNazwafirmy() && (ListaKlientow[i].GetType()).Equals(x.GetType()))
                    {
                        throw new FirmaPosrednikIstniejeException("Firma pośrednik już istnieje");
                    }
                }
                ListaKlientow.Add(x);
            }
        }
        public void UsunKlienta(Klient x)
        {
            int i, z = 0;
            KlientIndywidualny a = new KlientIndywidualny("x","y");
            FirmaPosrednik b = new FirmaPosrednik("x");
            if ((x.GetType()).Equals(a.GetType()))
            {
                for (i=0;i<ListaKlientow.Count();i++)
                {
                    if (ListaKlientow[i].getImie() == x.getImie() && ListaKlientow[i].getNazwisko() == x.getNazwisko() && (ListaKlientow[i].GetType()).Equals(x.GetType()))
                    {
                        ListaKlientow.RemoveAt(i);
                        z++;
                    }
                }
                if (z == 0) throw new KlientIndywidualnyNieIstniejeException("Klient indywidualny nie istnieje");
            }
            else
            {
                for (i = 0; i < ListaKlientow.Count(); i++)
                {
                    if (ListaKlientow[i].getNazwafirmy() == x.getNazwafirmy() && (ListaKlientow[i].GetType()).Equals(x.GetType()))
                    {
                        ListaKlientow.RemoveAt(i);
                        z++;
                    }
                }
                if (z == 0) throw new FirmaPosrednikNieIstniejeException("Firma pośrednik nie istnieje");
            }
        }
        public List<Klient> PrzegladKlientow()
        {
            return ListaKlientow;
        }
        
        public void GenerujLot(Lot x, int dzien, int miesiac, int cykl)
        {
            int a = 7;
            int i, j, k, l, z = 0;
            string zmienna_tekstowa, zmienna_tekstowa2, zmienna_tekstowa3, zmienna_tekstowa4;
            z = 0;
            for (i = 0; i < ListaSamolotow.Count(); i++)
            {
                zmienna_tekstowa = ListaSamolotow[i].getIDsamolotu();
                zmienna_tekstowa2 = (x.getSamolot()).getIDsamolotu();
                if (zmienna_tekstowa == zmienna_tekstowa2)
                {
                    z++;
                }
            }
            if (z == 0) throw new SamolotNieIstniejeException("Samolot nie istnieje");
            z = 0;
            for (i = 0; i < ListaTras.Count(); i++)
            {
                zmienna_tekstowa = (ListaTras[i].getMiejsceWylotu()).getNazwalotniska();
                zmienna_tekstowa2 = ((x.getTrasa()).getMiejsceWylotu()).getNazwalotniska();
                zmienna_tekstowa3 = (ListaTras[i].getMiejscePrzylotu()).getNazwalotniska();
                zmienna_tekstowa4 = ((x.getTrasa()).getMiejscePrzylotu()).getNazwalotniska();
                if (zmienna_tekstowa == zmienna_tekstowa2 && zmienna_tekstowa3 == zmienna_tekstowa4)
                {
                    z++;
                }
            }
            if (z == 0) throw new TrasaNieIstniejeException("Trasa nie istnieje");
            if (x.getGodzinawylotu() > x.getGodzinaprzylotu()) throw new ZlaGodzinaException("Godzina wylotu jest większa od godziny przylotu");
            if ((x.getTrasa()).getOdleglosc() > (x.getSamolot()).getZasieg()) throw new ZasiegSamolotuZaMalyException("Zasięg samolotu jest za mały");
            for (i=miesiac-1;i<12;i++)
            {
                if (i== miesiac-1)
                {
                    for (j = dzien-1; j < 30; j++)
                    {
                        for (k = x.getGodzinawylotu(); k < x.getGodzinaprzylotu(); k++)
                        {
                            for (l = 0; l < 10; l++)
                            {
                                if (LotyRok[i, j, k, l] != null && LotyRok[i, j, k, l].getTrasa().getMiejsceWylotu().getNazwalotniska() == x.getTrasa().getMiejsceWylotu().getNazwalotniska() && LotyRok[i, j, k, l].getTrasa().getMiejscePrzylotu().getNazwalotniska() == x.getTrasa().getMiejscePrzylotu().getNazwalotniska() && LotyRok[i, j, k, l].getSamolot().getIDsamolotu() == x.getSamolot().getIDsamolotu())
                                {
                                    throw new LotySiePokrywajaException("Loty sie pokrywaja");
                                }
                                if (K.ZnajdzMiejsceSamolotu(x, dzien, miesiac, LotyRok) != x.getTrasa().getMiejsceWylotu().getNazwalotniska() && K.ZnajdzMiejsceSamolotu(x, dzien, miesiac, LotyRok) != null)
                                {
                                    throw new SamolotJestWInnymMiejscuException("Samolot jest w innym miejscu");
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (j = 0; j < 30; j++)
                    {
                        for (k = x.getGodzinawylotu(); k < x.getGodzinaprzylotu(); k++)
                        {
                            for (l = 0; l < 10; l++)
                            {
                                if (LotyRok[i, j, k, l] != null && LotyRok[i, j, k, l].getTrasa().getMiejsceWylotu().getNazwalotniska() == x.getTrasa().getMiejsceWylotu().getNazwalotniska() && LotyRok[i, j, k, l].getTrasa().getMiejscePrzylotu().getNazwalotniska() == x.getTrasa().getMiejscePrzylotu().getNazwalotniska() && LotyRok[i, j, k, l].getSamolot().getIDsamolotu() == x.getSamolot().getIDsamolotu())
                                {
                                    throw new LotySiePokrywajaException("Loty sie pokrywaja");
                                }
                                if (K.ZnajdzMiejsceSamolotu(x, dzien, miesiac, LotyRok) != x.getTrasa().getMiejsceWylotu().getNazwalotniska() && K.ZnajdzMiejsceSamolotu(x, dzien, miesiac, LotyRok) != null)
                                {
                                    throw new SamolotJestWInnymMiejscuException("Samolot jest w innym miejscu");
                                }
                                
                            }
                        }
                    }
                }
                
            }
            if (cykl == 1)
            {
                for (i = miesiac - 1; i < 12; i++)
                {
                    if (i == miesiac - 1)
                    {
                        for (j = dzien - 1; j < 30; j++)
                        {
                            for (k = x.getGodzinawylotu(); k < x.getGodzinaprzylotu(); k++)
                            {
                                for (l = 0; l < 10; l++)
                                {
                                    if (LotyRok[i, j, k, l] == null)
                                    {
                                        LotyRok[i, j, k, l] = new Lot(x.getTrasa(), x.getSamolot(), x.getCzaspodrozy(), x.getGodzinawylotu(), x.getGodzinaprzylotu());
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (j = 0; j < 30; j++)
                        {
                            for (k = x.getGodzinawylotu(); k < x.getGodzinaprzylotu(); k++)
                            {
                                for (l = 0; l < 10; l++)
                                {
                                    if (LotyRok[i, j, k, l] == null)
                                    {
                                        LotyRok[i, j, k, l] = new Lot(x.getTrasa(), x.getSamolot(), x.getCzaspodrozy(), x.getGodzinawylotu(), x.getGodzinaprzylotu());
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                for (i = miesiac - 1; i < 12; i++)
                {
                    if (i == miesiac - 1)
                    {
                        for (j = dzien - 1; j < 30; j++)
                        {
                            if (a==7)
                            {
                                for (k = x.getGodzinawylotu(); k < x.getGodzinaprzylotu(); k++)
                                {
                                    for (l = 0; l < 10; l++)
                                    {
                                        if (LotyRok[i, j, k, l] == null)
                                        {
                                            LotyRok[i, j, k, l] = new Lot(x.getTrasa(), x.getSamolot(), x.getCzaspodrozy(), x.getGodzinawylotu(), x.getGodzinaprzylotu());
                                            break;
                                        }
                                    }
                                }
                                a = 0;
                            }
                            a++;
                        }
                    }
                    else
                    {
                        for (j = 0; j < 30; j++)
                        {
                            if (a == 7)
                            {
                                for (k = x.getGodzinawylotu(); k < x.getGodzinaprzylotu(); k++)
                                {
                                    for (l = 0; l < 10; l++)
                                    {
                                        if (LotyRok[i, j, k, l] == null)
                                        {
                                            LotyRok[i, j, k, l] = new Lot(x.getTrasa(), x.getSamolot(), x.getCzaspodrozy(), x.getGodzinawylotu(), x.getGodzinaprzylotu());
                                            break;
                                        }
                                    }
                                }
                                a = 0;
                            }
                            a++;
                        }
                    }

                }
            }
        }
        public Lot[,,,] PrzegladLotow()
        {
            return LotyRok;
        }
        
    }

    class pom
    {
        public string ZnajdzMiejsceSamolotu(Lot lot, int dzien, int miesiac,Lot[,,,] tablica)
        {
            int i, j, k,l;
            for (i = miesiac-1; i >= 0; i--)
            {
                for (j = dzien-1; j >= 0; j--)
                {
                    for (l = 23; l >= 0; l--)
                    {
                        for (k = 0; k < 10; k++)
                        {
                            if (tablica[i,j,l,k]!=null && tablica[i,j,l,k].getSamolot().getIDsamolotu() == lot.getSamolot().getIDsamolotu()) return tablica[i, j, l, k].getTrasa().getMiejscePrzylotu().getNazwalotniska();
                        }
                    }
                }
            }
            return null;
        }
        
    } 
}
