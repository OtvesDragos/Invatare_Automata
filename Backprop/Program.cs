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
                for (int i = 0; i < 10000; i++)
                {
                    backpropagation.BackPropagationOnline();
                }
            }
            else
            {
                if (input.Equals("1"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        backpropagation.BackPropagationOffline();
                    }
                }
                else
                {
                    throw new InvalidOperationException("Te rog sa introduci 1 sau 0 data viitoare");
                }
            }
        }
    }
}