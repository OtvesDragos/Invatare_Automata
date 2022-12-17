namespace Backprop
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var backpropagation = new Backpropagation();
            Console.WriteLine("Scrie 0 pentru on-line si 1 pentru off-line");
            var input = Console.ReadLine();
            if (input.Equals("0"))
            {
                do
                {
                    backpropagation.BackPropagationOnline();
                } while (backpropagation.Eglobal > 0.1);
            }
            else
            {
                if (input.Equals("1"))
                {
                    backpropagation.BackPropagationOffline();
                }
                else
                {
                    throw new InvalidOperationException("Te rog sa introduci 1 sau 0 data viitoare");
                }
            }
        }
    }
}