using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IWebHostEnvironment env = builder.Environment;

//  Console.WriteLine("using sql server db");
//     builder.Services.AddDbContext<AppDBContext>(optionsAction => 
//         optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));

if(env.IsProduction())
{
    Console.WriteLine("using sql server db");
    builder.Services.AddDbContext<AppDBContext>(optionsAction => 
        optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));

}else
{
    Console.WriteLine("using InMem db");
    builder.Services.AddDbContext<AppDBContext>(optionsAction => optionsAction.UseInMemoryDatabase("InMem"));
}



builder.Services.AddScoped<IPlatformRepo,PlatformRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app, env.IsProduction());

app.Run();
