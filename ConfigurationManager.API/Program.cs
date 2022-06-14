using ConfigurationManager.Core.Repositories;
using ConfigurationManager.Core.Services;
using ConfigurationManager.Core.UnitOfWorks;
using ConfigurationManager.Repository;
using ConfigurationManager.Repository.Providers.MongoDB;
using ConfigurationManager.Repository.Repositories;
using ConfigurationManager.Repository.UnitOfWorks;
using ConfigurationManager.Service.Mappings;
using ConfigurationManager.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbConfiguration>(builder.Configuration.GetSection("MongoDbConnection"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
     {
         option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
     });
});

var app = builder.Build();

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