namespace ExJ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int DictLenght = int.Parse(Console.ReadLine());
            char[][] dict = new char[DictLenght][];
            for (int i = 0; i < DictLenght; i++)
            {
                Char[] cha = Console.ReadLine().ToCharArray();
                Array.Reverse(cha);
                dict[i] = cha;

            }
            Array.Sort(dict,);
            int nRequests = int.Parse(Console.ReadLine());
            Char [][] requeststrings = new char[nRequests][];
            for (int i = 0; i < nRequests; i++)
            {
                Char[] cha = Console.ReadLine().ToCharArray();
                Array.Reverse(cha);
                requeststrings[i] = cha;
            }
            Array.Sort(requeststrings);

            C
            //Console.Read();
        }
    }
}