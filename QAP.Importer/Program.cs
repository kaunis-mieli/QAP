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
            new Importer(new UoWFactory(new QAPDBContext())).Import("Data");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}