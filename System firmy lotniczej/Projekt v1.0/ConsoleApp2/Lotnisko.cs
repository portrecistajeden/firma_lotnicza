using System;


namespace ConsoleApp2
{
    [Serializable]
    public class Lotnisko
    {
        public string nazwalotniska;
        public Lotnisko() { }
        public Lotnisko(string nazwalotniska_)
        {
            nazwalotniska = nazwalotniska_;
        }
        public string getNazwalotniska()
        {
            return nazwalotniska;
        }
        public override string ToString()
        {
            return nazwalotniska;
        }
    }
    class LotniskoIstniejeException : Exception
    {
        public LotniskoIstniejeException(string msg) : base(msg)
        {

        }
    }
    class LotniskoNieIstniejeException : Exception
    {
        public LotniskoNieIstniejeException(string msg): base(msg)
        {

        }
    }
    class LotniskaTakieSameException : Exception
    {
        public LotniskaTakieSameException(string msg) : base(msg)
        {

        }
    }
}
