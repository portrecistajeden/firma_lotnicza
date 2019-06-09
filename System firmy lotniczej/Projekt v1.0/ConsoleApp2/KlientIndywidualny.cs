using System;


namespace ConsoleApp2
{
    [Serializable]
    class KlientIndywidualny: Klient
    {
        private string imie;
        private string nazwisko;
        public KlientIndywidualny(string imie_, string nazwisko_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
        }
        public override string getImie()
        {
            return imie;
        }
        public override string getNazwisko()
        {
            return nazwisko;
        }
        public override string ToString()
        {
            return imie + " " + nazwisko;
        }
    }
    class KlientIndywidualnyIstniejeException : Exception
    {
        public KlientIndywidualnyIstniejeException(string msg) : base(msg)
        {

        }
    }
    class KlientIndywidualnyNieIstniejeException : Exception
    {
        public KlientIndywidualnyNieIstniejeException(string msg) : base(msg)
        {

        }
    }
}
