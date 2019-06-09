using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            System system = new System();
            Lot lot;
            Lot[,,,] lotyrok;
            Bilet bilet;
            FirmaPosrednik firmaposrednik;
            KlientIndywidualny klientindywidualny;
            Lotnisko lotnisko, lotnisko2;
            List<Lotnisko> listalotnisk;
            Samolot samolot;
            Trasa trasa;
            List<Trasa> listatras;
            List<Klient> listaklientow;
            List<Samolot> listasamolotow;
            List<Bilet> listabiletow;
            string caseSwitch1, caseSwitch2, caseSwitch3;
            string zmienna_tekstowa, zmienna_tekstowa2;
            double zmienna_double;
            int i, j, zmienna_int1, zmienna_int2, zmienna_int3, zmienna_int4, zmienna_int5, zmienna_int6, zmienna_int7;
            string title = @"
 _   _ _     _    _        _           _         
| \ | (_)   | |  (_)      | |         | |        
|  \| |_ ___| | ___  ___  | |     ___ | |_ _   _ 
| . ` | / __| |/ / |/ _ \ | |    / _ \| __| | | |
| |\  | \__ \   <| |  __/ | |___| (_) | |_| |_| |
\_| \_/_|___/_|\_\_|\___| \_____/\___/ \__|\__, |
                                            __/ |
                                           |___/ 
";
            Console.WriteLine(title);
            Console.WriteLine("\tSystem Zarządzania Lotniskiem");
            Console.WriteLine("\n\nDev Team:\n~Michał Szorc\n~Piotr Awramiuk\n~Adrianna Krymska\n\n\n\nNaciśnij dowolny klawisz by kontynuować");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                
                Console.WriteLine("1 - Panel Administratora");
                Console.WriteLine("2 - Panel Użytkownika");
                Console.WriteLine("3 - Wyjdź");
                caseSwitch1 = Console.ReadLine();
                Console.Clear();
                while (caseSwitch1 == "1" || caseSwitch1=="2")
                {
                    if (caseSwitch1 == "1")
                    {
                        Console.WriteLine("1 - Dodaj lotnisko");
                        Console.WriteLine("2 - Usuń lotnisko");
                        Console.WriteLine("3 - Przegląd lotnisk");
                        Console.WriteLine("4 - Dodaj samolot");
                        Console.WriteLine("5 - Usuń samolot");
                        Console.WriteLine("6 - Przegląd samolotów");
                        Console.WriteLine("7 - Dodaj trasę");
                        Console.WriteLine("8 - Usuń trasę");
                        Console.WriteLine("9 - Przegląd tras");
                        Console.WriteLine("10 - Generuj lot codzienny");
                        Console.WriteLine("11 - Generuj lot cotygodniowy");
                        Console.WriteLine("12 - Zapis");
                        Console.WriteLine("13 - Odczyt");
                        Console.WriteLine("14 - Wyjdź");
                        caseSwitch2 = Console.ReadLine();
                        Console.Clear();
                        switch (caseSwitch2)
                        {
                            
                            case "1":
                                Console.WriteLine("Podaj nazwę lotniska");
                                zmienna_tekstowa = Console.ReadLine();
                                lotnisko = new Lotnisko(zmienna_tekstowa);
                                try
                                {
                                    system.DodajLotnisko(lotnisko);
                                }
                                catch (LotniskoIstniejeException)
                                {
                                    Console.WriteLine("Lotnisko o podanej nazwie już istnieje");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                Console.WriteLine("Podaj nazwę lotniska");
                                zmienna_tekstowa = Console.ReadLine();
                                lotnisko = new Lotnisko(zmienna_tekstowa);
                                try
                                {
                                    system.UsunLotnisko(lotnisko);
                                }
                                catch (LotniskoNieIstniejeException)
                                {
                                    Console.WriteLine("Lotnisko o podanej nazwie nie istnieje");
                                }
                                catch (TrasaIstniejeException)
                                {
                                    Console.WriteLine("Istnieje trasa zawierająca to lotnisko");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "3":
                                listalotnisk = new List<Lotnisko>();
                                listalotnisk = system.PrzegladLotnisk();
                                Console.WriteLine("Nazwalotniska");
                                for (i = 0; i < listalotnisk.Count(); i++)
                                {
                                    Console.WriteLine(listalotnisk[i].ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            
                            case "4":
                                Console.WriteLine("Podaj typ samolotu");
                                Console.WriteLine("1 - Osobowy duży, liczba miejsc - 300, zasięg - 9000km");
                                Console.WriteLine("2 - Osobowy średni, liczba miejsc - 180, zasięg - 3000km");
                                Console.WriteLine("3 - Osobowy mały, liczba - 102, zasięg - 1500km");
                                zmienna_tekstowa = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Podaj ID samolotu");
                                zmienna_tekstowa2 = Console.ReadLine();
                                switch (zmienna_tekstowa)
                                {
                                    case "1":
                                        samolot = new Samolot("Osobowy duży", 9000, 300, zmienna_tekstowa2);
                                        try
                                        {
                                            system.DodajSamolot(samolot);
                                        }
                                        catch (SamolotIstniejeException)
                                        {
                                            Console.WriteLine("Samolot o podanym ID istnieje");
                                        }
                                        break;
                                    case "2":
                                        samolot = new Samolot("Osobowy średni", 3000, 180, zmienna_tekstowa2);
                                        try
                                        {
                                            system.DodajSamolot(samolot);
                                        }
                                        catch (SamolotIstniejeException)
                                        {
                                            Console.WriteLine("Samolot o podanym ID istnieje");
                                        }
                                        break;
                                    case "3":
                                        samolot = new Samolot("Osobowy mały", 1500, 102, zmienna_tekstowa2);
                                        try
                                        {
                                            system.DodajSamolot(samolot);
                                        }
                                        catch (SamolotNieIstniejeException)
                                        {
                                            Console.WriteLine("Samolot o podanym ID istnieje");
                                        }
                                        break;
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                Console.WriteLine("Podaj ID samolotu");
                                zmienna_tekstowa = Console.ReadLine();
                                try
                                {
                                    system.UsunSamolot(zmienna_tekstowa);
                                }
                                catch (SamolotNieIstniejeException)
                                {
                                    Console.WriteLine("Samolot o tym ID nazwie nie istnieje");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "6":
                                listasamolotow = new List<Samolot>();
                                listasamolotow = system.PrzegladSamolotow();
                                Console.WriteLine("Typ Zasięg LiczbaMiejsc ŚredniaPrędkość ID ");
                                for(i=0;i<listasamolotow.Count();i++)
                                {
                                    Console.WriteLine(listasamolotow[i].ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "7":
                                Console.WriteLine("Podaj miejsce wylotu");
                                zmienna_tekstowa = Console.ReadLine();
                                lotnisko = new Lotnisko(zmienna_tekstowa);
                                Console.Clear();
                                Console.WriteLine("Podaj miejsce przylotu");
                                zmienna_tekstowa2 = Console.ReadLine();
                                lotnisko2 = new Lotnisko(zmienna_tekstowa2);
                                Console.Clear();
                                Console.WriteLine("Podaj odległość");
                                zmienna_double = Convert.ToDouble(Console.ReadLine());
                                Console.Clear();
                                trasa = new Trasa(zmienna_double, lotnisko, lotnisko2);
                                try
                                {
                                    system.DodajTrase(trasa);
                                }
                                catch (TrasaIstniejeException)
                                {
                                    Console.WriteLine("Trasa już istnieje");
                                }
                                catch (LotniskoNieIstniejeException)
                                {
                                    Console.WriteLine("Lotnisko o podanej nazwie nie istnieje");
                                }
                                catch (LotniskaTakieSameException)
                                {
                                    Console.WriteLine("Miejsce wylotu oraz przylotu jest takie same");
                                }
                                catch (TrasaZlaOdlegloscException)
                                {
                                    Console.WriteLine("Podano złą odległość");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "8":
                                Console.WriteLine("Podaj miejsce wylotu");
                                zmienna_tekstowa = Console.ReadLine();
                                lotnisko = new Lotnisko(zmienna_tekstowa);
                                Console.Clear();
                                Console.WriteLine("Podaj miejsce przylotu");
                                zmienna_tekstowa2 = Console.ReadLine();
                                lotnisko2 = new Lotnisko(zmienna_tekstowa2);
                                Console.Clear();
                                zmienna_double = system.ZnajdzOdleglosc(lotnisko, lotnisko2);
                                trasa = new Trasa(zmienna_double, lotnisko, lotnisko2);
                                try
                                {
                                    system.UsunTrase(trasa);
                                }
                                catch (TrasaNieIstniejeException trasa_)
                                {
                                    Console.WriteLine("Trasa nie istnieje", trasa_);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "9":
                                listatras = new List<Trasa>();
                                listatras = system.PrzegladTras();
                                Console.WriteLine("MiejsceWylotu MiejscePrzylotu Odległość");
                                for (i = 0; i < listatras.Count(); i++)
                                {
                                    Console.WriteLine(listatras[i].ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "10":
                                Console.WriteLine("Podaj miejsce wylotu");
                                zmienna_tekstowa = Console.ReadLine();
                                Console.Clear();
                                lotnisko = new Lotnisko(zmienna_tekstowa);
                                Console.WriteLine("Podaj miejse przylotu");
                                zmienna_tekstowa2 = Console.ReadLine();
                                Console.Clear();
                                lotnisko2 = new Lotnisko(zmienna_tekstowa2);
                                zmienna_double = system.ZnajdzOdleglosc(lotnisko, lotnisko2);
                                trasa = new Trasa(zmienna_double, lotnisko, lotnisko2);
                                do
                                {
                                    Console.WriteLine("Podaj godzinę wylotu");
                                    zmienna_int1 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int1 < 0 || zmienna_int1 > 23);
                                do
                                {
                                    Console.WriteLine("Podaj godzinę przylotu");
                                    zmienna_int2 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int2 < 0 || zmienna_int2 > 23);
                                Console.Clear();
                                zmienna_int3 = zmienna_int2 - zmienna_int1;
                                Console.WriteLine("Podaj ID samolotu");
                                zmienna_tekstowa = Console.ReadLine();
                                Console.Clear();
                                do
                                {
                                    Console.WriteLine("Podaj dzień pierwszego lotu");
                                    zmienna_int4 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int4 < 1 || zmienna_int4>30);
                                do
                                {
                                    Console.WriteLine("Podaj miesiąc pierwszego lotu");
                                    zmienna_int5 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int5 < 1 || zmienna_int5 > 12); 
                                listasamolotow = new List<Samolot>();
                                listasamolotow = system.PrzegladSamolotow();
                                samolot = new Samolot();
                                for (i=0;i<listasamolotow.Count();i++)
                                {
                                    if (zmienna_tekstowa == listasamolotow[i].getIDsamolotu())
                                    {
                                        zmienna_double = 0.2;
                                        samolot = new Samolot(listasamolotow[i].getTyp(), listasamolotow[i].getZasieg(), listasamolotow[i].getLiczbamiejsc(), listasamolotow[i].getIDsamolotu());
                                    }
                                }
                                lot = new Lot(trasa, samolot, zmienna_int3, zmienna_int1, zmienna_int2);
                                try
                                {
                                    system.GenerujLot(lot, zmienna_int4, zmienna_int5, 1);
                                }
                                catch (SamolotNieIstniejeException)
                                {
                                    Console.WriteLine("Samolot nie istnieje");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch (TrasaNieIstniejeException)
                                {
                                    Console.WriteLine("Trasa nie istnieje");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch(ZlaGodzinaException)
                                {
                                    Console.WriteLine("Godzina wylotu jest większa od godziny przylotu");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch (ZasiegSamolotuZaMalyException)
                                {
                                    Console.WriteLine("Zasieg samolotu jest za maly");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch (LotySiePokrywajaException)
                                {
                                    Console.WriteLine("Loty pokrywają się");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch(SamolotJestWInnymMiejscuException)
                                {
                                    Console.WriteLine("Samolot jest w innym miejscu");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                Console.WriteLine("Wygenerowano lot");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "11":
                                Console.WriteLine("Podaj miejsce wylotu");
                                zmienna_tekstowa = Console.ReadLine();
                                Console.Clear();
                                lotnisko = new Lotnisko(zmienna_tekstowa);
                                Console.WriteLine("Podaj miejse przylotu");
                                zmienna_tekstowa2 = Console.ReadLine();
                                Console.Clear();
                                lotnisko2 = new Lotnisko(zmienna_tekstowa2);
                                zmienna_double = system.ZnajdzOdleglosc(lotnisko, lotnisko2);
                                trasa = new Trasa(zmienna_double, lotnisko, lotnisko2);
                                do
                                {
                                    Console.WriteLine("Podaj godzinę wylotu");
                                    zmienna_int1 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int1 < 0 || zmienna_int1 > 23);
                                do
                                {
                                    Console.WriteLine("Podaj godzinę przylotu");
                                    zmienna_int2 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int2 < 0 || zmienna_int2 > 23);
                                Console.Clear();
                                if (zmienna_int1 > zmienna_int2)
                                {
                                    zmienna_int3 = zmienna_int2 + 24 - zmienna_int1;
                                }
                                else
                                {
                                    zmienna_int3 = zmienna_int2 - zmienna_int1;
                                }
                                Console.WriteLine("Podaj ID samolotu");
                                zmienna_tekstowa = Console.ReadLine();
                                Console.Clear();
                                do
                                {
                                    Console.WriteLine("Podaj dzień pierwszego lotu");
                                    zmienna_int4 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int4 < 1 || zmienna_int4 > 30);
                                do
                                {
                                    Console.WriteLine("Podaj miesiąc pierwszego lotu");
                                    zmienna_int5 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                } while (zmienna_int5 < 1 || zmienna_int5 > 12);
                                listasamolotow = new List<Samolot>();
                                listasamolotow = system.PrzegladSamolotow();
                                samolot = new Samolot();
                                for (i = 0; i < listasamolotow.Count(); i++)
                                {
                                    if (zmienna_tekstowa == listasamolotow[i].getIDsamolotu())
                                    {
                                        zmienna_double = 0.2;
                                        samolot = new Samolot(listasamolotow[i].getTyp(), listasamolotow[i].getZasieg(), listasamolotow[i].getLiczbamiejsc(), listasamolotow[i].getIDsamolotu());
                                    }
                                }
                                lot = new Lot(trasa, samolot, zmienna_int3, zmienna_int1, zmienna_int2);                                try
                                {
                                    system.GenerujLot(lot, zmienna_int4, zmienna_int5, 2);
                                }
                                catch (SamolotNieIstniejeException)
                                {
                                    Console.WriteLine("Samolot nie istnieje");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch (TrasaNieIstniejeException)
                                {
                                    Console.WriteLine("Trasa nie istnieje");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch (ZasiegSamolotuZaMalyException)
                                {
                                    Console.WriteLine("Zasieg samolotu jest za maly");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch (LotySiePokrywajaException)
                                {
                                    Console.WriteLine("Loty pokrywają się");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                catch (SamolotJestWInnymMiejscuException)
                                {
                                    Console.WriteLine("Samolot jest w innym miejscu");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                Console.WriteLine("Wygenerowano lot");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "12":
                                system.Zapis();
                                break;
                            case "13":
                                system.Odczyt();
                                break;
                            case "14":
                                caseSwitch1 = "4";
                                break;
                        }
                       
                       
                    }
                    if (caseSwitch1 == "2")
                    {
                        Console.WriteLine("1 - Przegląd Lotów");
                        Console.WriteLine("2 - Zarezerwuj bilet");
                        Console.WriteLine("3 - Przegląd biletów");
                        Console.WriteLine("4 - Zarejestruj się jako klient indywidualny");
                        Console.WriteLine("5 - Usuń konto klienta indywidualnego");
                        Console.WriteLine("6 - Przegląd klientów indywidualnych");
                        Console.WriteLine("7 - Zarejestruj firmę pośredniczą");
                        Console.WriteLine("8 - Usuń konto firmy pośredniczej");
                        Console.WriteLine("9 - Przegląd firm pośredniczych");
                        Console.WriteLine("10 - Przegląd wszystkich klientów");
                        Console.WriteLine("11 - Zapis");
                        Console.WriteLine("12 - Odczyt");
                        Console.WriteLine("13 - Wyjdź");
                        caseSwitch2 = Console.ReadLine();
                        Console.Clear();
                        switch (caseSwitch2)
                        {
                            case "1":
                                lotyrok = new Lot[12,30,24,10];
                                lotyrok = system.PrzegladLotow();
                                Console.WriteLine("Podaj dzień");
                                zmienna_int1 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Podaj miesiąc");
                                zmienna_int2 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("IDSamolotu TypSamolotu LiczbaRzędów MiejsceWylotu MiejscePrzylotu GodzinaWylotu GodzinaPrzylotu");
                                for (i=0;i<24;i++)
                                {
                                    for (j=0;j<10;j++)
                                    {
                                        if (lotyrok[zmienna_int2-1, zmienna_int1-1, i, j] != null ) 
                                        {
                                            Console.WriteLine(lotyrok[zmienna_int2 - 1, zmienna_int1 - 1, i, j].ToString());
                                        }
                                    }
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                int index;
                                Console.WriteLine("1 - Kup bilet jako klient indywidualny");
                                Console.WriteLine("2 - Kup bilet jako firma pośrednik");
                                caseSwitch3 = Console.ReadLine();
                                Console.Clear();
                                index = -1;
                                switch (caseSwitch3)
                                {
                                    case "1":
                                        Console.WriteLine("Podaj imię");
                                        zmienna_tekstowa = Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("Podaj nazwisko");
                                        zmienna_tekstowa2 = Console.ReadLine();
                                        Console.Clear();
                                        listaklientow = new List<Klient>();
                                        listaklientow = system.PrzegladKlientow();
                                        for (i = 0; i < listaklientow.Count(); i++)
                                        {
                                            if (listaklientow[i].getImie() == zmienna_tekstowa && listaklientow[i].getNazwisko() == zmienna_tekstowa2)
                                            {
                                                index = i;
                                            }
                                        }
                                        if (index != -1)
                                        {
                                            Console.WriteLine("Podaj miejsce wylotu");
                                            zmienna_tekstowa = Console.ReadLine();
                                            Console.Clear();
                                            lotnisko = new Lotnisko(zmienna_tekstowa);
                                            Console.WriteLine("Podaj miejse przylotu");
                                            zmienna_tekstowa2 = Console.ReadLine();
                                            Console.Clear();
                                            lotnisko2 = new Lotnisko(zmienna_tekstowa2);
                                            zmienna_double = system.ZnajdzOdleglosc(lotnisko, lotnisko2);
                                            trasa = new Trasa(zmienna_double, lotnisko, lotnisko2);
                                            do
                                            {
                                                Console.WriteLine("Podaj dzień lotu");
                                                zmienna_int4 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int4 < 1 || zmienna_int4 > 30);
                                            do
                                            {
                                                Console.WriteLine("Podaj miesiąc lotu");
                                                zmienna_int5 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int5 < 1 || zmienna_int5 > 12);
                                            do
                                            {
                                                Console.WriteLine("Podaj godzinę wylotu");
                                                zmienna_int1 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int1 < 0 || zmienna_int1 > 23);
                                            do
                                            {
                                                Console.WriteLine("Podaj godzinę przylotu");
                                                zmienna_int2 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int2 < 0 || zmienna_int2 > 23);
                                            Console.WriteLine("Podaj numer rzędu");
                                            zmienna_int6 = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            do
                                            {
                                                Console.WriteLine("Podaj miejsce 1-6");
                                                zmienna_int7 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int7 < 1 || zmienna_int7 > 6);
                                            Console.WriteLine("Podaj id samolotu");
                                            zmienna_tekstowa = Console.ReadLine();
                                            Console.Clear();
                                            bilet = new Bilet(zmienna_int6, zmienna_int7, trasa, zmienna_int4, zmienna_int5, zmienna_int1, zmienna_int2, zmienna_tekstowa);
                                            lotyrok = system.PrzegladLotow();
                                            try
                                            {
                                                listaklientow[index].ZarezerwujBilet(bilet,lotyrok);
                                            }
                                            catch(TrasaNieIstniejeException)
                                            {
                                                Console.WriteLine("Taka trasa nie istnieje");
                                            }
                                            catch (LotNieIstniejeException)
                                            {
                                                Console.WriteLine("Taki lot tego dnia nie istnieje");
                                            }
                                            catch (MiejsceNieIstniejeException)
                                            {
                                                Console.WriteLine("Miejsce nie istnieje");
                                            }
                                            catch(MiejsceJestZajeteException)
                                            {
                                                Console.WriteLine("Miejsce jest już zajęte");
                                            } 
                                        }
                                        else Console.WriteLine("Klient nie istnieje");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.WriteLine("Podaj nazwę firmy pośredniczej");
                                        zmienna_tekstowa = Console.ReadLine();
                                        Console.Clear();
                                        listaklientow = new List<Klient>();
                                        listaklientow = system.PrzegladKlientow();
                                        for (i = 0; i < listaklientow.Count(); i++)
                                        {
                                            if (listaklientow[i].getNazwafirmy() == zmienna_tekstowa)
                                            {
                                                index = i;
                                            }
                                        }
                                        if (index != -1)
                                        {
                                            Console.WriteLine("Podaj miejsce wylotu");
                                            zmienna_tekstowa = Console.ReadLine();
                                            Console.Clear();
                                            lotnisko = new Lotnisko(zmienna_tekstowa);
                                            Console.WriteLine("Podaj miejse przylotu");
                                            zmienna_tekstowa2 = Console.ReadLine();
                                            Console.Clear();
                                            lotnisko2 = new Lotnisko(zmienna_tekstowa2);
                                            zmienna_double = system.ZnajdzOdleglosc(lotnisko, lotnisko2);
                                            trasa = new Trasa(zmienna_double, lotnisko, lotnisko2);
                                            do
                                            {
                                                Console.WriteLine("Podaj dzień lotu");
                                                zmienna_int4 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int4 < 1 || zmienna_int4 > 30);
                                            do
                                            {
                                                Console.WriteLine("Podaj miesiąc lotu");
                                                zmienna_int5 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int5 < 1 || zmienna_int5 > 12);
                                            do
                                            {
                                                Console.WriteLine("Podaj godzinę wylotu");
                                                zmienna_int1 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int1 < 0 || zmienna_int1 > 23);
                                            do
                                            {
                                                Console.WriteLine("Podaj godzinę przylotu");
                                                zmienna_int2 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int2 < 0 || zmienna_int2 > 23);
                                            Console.WriteLine("Podaj numer rzędu");
                                            zmienna_int6 = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            do
                                            {
                                                Console.WriteLine("Podaj miejsce 1-6");
                                                zmienna_int7 = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                            } while (zmienna_int7 < 1 || zmienna_int7 > 6);
                                            Console.WriteLine("Podaj id samolotu");
                                            zmienna_tekstowa = Console.ReadLine();
                                            Console.Clear();
                                            bilet = new Bilet(zmienna_int6, zmienna_int7, trasa, zmienna_int4, zmienna_int5, zmienna_int1, zmienna_int2, zmienna_tekstowa);
                                            lotyrok = system.PrzegladLotow();
                                            try
                                            {
                                                listaklientow[index].ZarezerwujBilet(bilet, lotyrok);
                                            }
                                            catch (TrasaNieIstniejeException)
                                            {
                                                Console.WriteLine("Taka trasa nie istnieje");
                                            }
                                            catch (LotNieIstniejeException)
                                            {
                                                Console.WriteLine("Taki lot tego dnia nie istnieje");
                                            }
                                            catch (MiejsceNieIstniejeException)
                                            {
                                                Console.WriteLine("Miejsce nie istnieje");
                                            }
                                            catch (MiejsceJestZajeteException)
                                            {
                                                Console.WriteLine("Miejsce jest już zajęte");
                                            }
                                        }
                                        else Console.WriteLine("Klient nie istnieje");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                }
                                break;
                            case "3":
                                index = -1;
                                Console.WriteLine("1 - Przegląd biletów klienta indywidualnego");
                                Console.WriteLine("2 - Przegląd biletów firmy pośredniczej");
                                caseSwitch3 = Console.ReadLine();
                                Console.Clear();
                                switch(caseSwitch3)
                                {
                                    case "1":
                                        Console.WriteLine("Podaj imię");
                                        zmienna_tekstowa = Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("Podaj nazwisko");
                                        zmienna_tekstowa2 = Console.ReadLine();
                                        Console.Clear();
                                        listaklientow = new List<Klient>();
                                        listaklientow = system.PrzegladKlientow();
                                        for (i = 0; i < listaklientow.Count(); i++)
                                        {
                                            if (listaklientow[i].getImie() == zmienna_tekstowa && listaklientow[i].getNazwisko() == zmienna_tekstowa2)
                                            {
                                                index = i;
                                            }
                                        }
                                        if (index != -1)
                                        {
                                            listabiletow = new List<Bilet>();
                                            listabiletow = listaklientow[index].PrzegladBiletow();
                                            Console.WriteLine("MiejsceWylotu MiejscePrzylotu Dzień Miesiąc GodzinaWylotu GodzinaPrzylotu Rząd Miejsce IDSamolotu");
                                            for (i=0;i<listabiletow.Count();i++)
                                            {
                                                Console.WriteLine(listabiletow[i].ToString());
                                            }
                                        }
                                        else Console.WriteLine("Klient nie istnieje");
                                        break;
                                    case "2":
                                        Console.WriteLine("Podaj nazwę firmy pośredniczej");
                                        zmienna_tekstowa = Console.ReadLine();
                                        Console.Clear();
                                        listaklientow = new List<Klient>();
                                        listaklientow = system.PrzegladKlientow();
                                        for (i = 0; i < listaklientow.Count(); i++)
                                        {
                                            if (listaklientow[i].getNazwafirmy() == zmienna_tekstowa)
                                            {
                                                index = i;
                                            }
                                        }
                                        if (index != -1)
                                        {
                                            listabiletow = new List<Bilet>();
                                            listabiletow = listaklientow[index].PrzegladBiletow();
                                            Console.WriteLine("MiejsceWylotu MiejscePrzylotu Dzień Miesiąc GodzinaWylotu GodzinaPrzylotu Rząd Miejsce IDSamolotu");
                                            for (i = 0; i < listabiletow.Count(); i++)
                                            {
                                                Console.WriteLine(listabiletow[i].ToString());
                                            }
                                        }
                                        else Console.WriteLine("Firma podśrednicza nie istnieje");
                                        break;
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "4":
                                Console.WriteLine("Podaj imię");
                                zmienna_tekstowa = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Podaj nazwisko");
                                zmienna_tekstowa2 = Console.ReadLine();
                                klientindywidualny = new KlientIndywidualny(zmienna_tekstowa, zmienna_tekstowa2);
                                try
                                {
                                    system.DodajKlienta(klientindywidualny);
                                }
                                catch (KlientIndywidualnyIstniejeException)
                                {
                                    Console.WriteLine("Klient indywidualny już istnieje");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                Console.WriteLine("Podaj imię");
                                zmienna_tekstowa = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Podaj nazwisko");
                                zmienna_tekstowa2 = Console.ReadLine();
                                Console.Clear();
                                klientindywidualny = new KlientIndywidualny(zmienna_tekstowa, zmienna_tekstowa2);
                                try
                                {
                                    system.UsunKlienta(klientindywidualny);
                                }
                                catch (KlientIndywidualnyNieIstniejeException)
                                {
                                    Console.WriteLine("Klient indywidualny nie istnieje");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "6":
                                listaklientow = new List<Klient>();
                                listaklientow = system.PrzegladKlientow();
                                Console.WriteLine("Imię Nazwisko");
                                for (i = 0; i < listaklientow.Count(); i++)
                                {
                                    if ((listaklientow[i].GetType()).Equals(typeof(KlientIndywidualny))) Console.WriteLine(listaklientow[i].ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "7":
                                Console.WriteLine("Podaj nazwę firmy");
                                zmienna_tekstowa = Console.ReadLine();
                                firmaposrednik = new FirmaPosrednik(zmienna_tekstowa);
                                try
                                {
                                    system.DodajKlienta(firmaposrednik);
                                }
                                catch (FirmaPosrednikIstniejeException)
                                {
                                    Console.WriteLine("Firma pośrednik już istnieje");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "8":
                                Console.WriteLine("Podaj nazwę firmy");
                                zmienna_tekstowa = Console.ReadLine();
                                firmaposrednik = new FirmaPosrednik(zmienna_tekstowa);
                                try
                                {
                                    system.UsunKlienta(firmaposrednik);
                                }
                                catch (FirmaPosrednikNieIstniejeException)
                                {
                                    Console.WriteLine("Firma pośrednik nie istnieje");
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "9":
                                listaklientow = new List<Klient>();
                                listaklientow = system.PrzegladKlientow();
                                Console.WriteLine("NazwaFirmy");
                                for (i = 0; i < listaklientow.Count(); i++)
                                {
                                    if ((listaklientow[i].GetType()).Equals(typeof(FirmaPosrednik))) Console.WriteLine(listaklientow[i].ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "10":
                                listaklientow = new List<Klient>();
                                listaklientow = system.PrzegladKlientow();
                                for (i = 0; i < listaklientow.Count(); i++)
                                {
                                    Console.WriteLine(listaklientow[i].ToString());
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "11":
                                system.Zapis();
                                break;
                            case "12":
                                system.Odczyt();
                                break;
                            case "13":
                                caseSwitch1 = "4";
                                break;
                        }
                        Console.Clear();
                    }
                   
                }
                if (caseSwitch1 == "3")
                {
                    break;
                }
            }
        }
    }
}
