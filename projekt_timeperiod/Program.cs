namespace projekt_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Time time = new Time(20, 20, 25);
                Console.WriteLine(time);

                TimePeriod period = new TimePeriod(15, 75, 100);
                Console.WriteLine(period);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
