namespace QAP.Importer;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Importer.Import();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}