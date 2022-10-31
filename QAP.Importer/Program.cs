using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.Importer;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var context = new QAPDBContext();
            var uowFactory = new UoWFactory(context);

            var importer = new Importer(uowFactory);
            importer.Import("Data");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}