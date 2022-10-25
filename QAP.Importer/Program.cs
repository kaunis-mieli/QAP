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
            var solutionUnitOfWork = new SolutionUnitOfWork(context);
            var problemUnitOfWork = new ProblemUnitOfWork(context, solutionUnitOfWork);

            var importer = new Importer(problemUnitOfWork);
            importer.Import("Data");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}