using System;


namespace ConsoleApp2
{
    [Serializable]
    class FirmaPosrednik: Klient
    {
        private string nazwafirmy;
        public FirmaPosrednik(string nazwafirmy_)
        {
            nazwafirmy = nazwafirmy_;
        }
        public override string getNazwafirmy()
        {
            return nazwafirmy;
        }
        public override string ToString()
        {
            return nazwafirmy;
        }
    }
    class FirmaPosrednikIstniejeException : Exception
    {
        public FirmaPosrednikIstniejeException(string msg) : base(msg)
        {

        }
    }
    class FirmaPosrednikNieIstniejeException : Exception
    {
        public FirmaPosrednikNieIstniejeException(string msg) : base(msg)
        {

        }
    }
}
