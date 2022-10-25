using QAP.DataContext;
using QAP.Repository.Repositories.ProblemRepo;
using QAP.UnitOfWork.UnitOfWork;

namespace QAP.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<IQAPDBContext, QAPDBContext>();
        builder.Services.AddTransient<SolutionUnitOfWork>();
        builder.Services.AddTransient<ProblemUnitOfWork>();

        var app = builder.Build();

        app.UseCors("CorsApi");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}