using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.Importer;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var context = new QAPDBContext();
            var problemRepo = new ProblemRepo(context);
            var importUnitOfWork = new ImportUnitOfWork(problemRepo);

            var importer = new Importer(importUnitOfWork);
            importer.Import("Data");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}