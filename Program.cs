namespace Delegates_in_ATM_machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates In ATM");

            ATM atm = new ATM();
            atm.Run();
        }
    }
}
