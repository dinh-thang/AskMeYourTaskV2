using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Mappers;
using ApplicationCore.Services;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register data services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register application services
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<ITodoServices, TodoServices>();
builder.Services.AddScoped<ITodoListServices, TodoListServices>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

TodoEndpoints.MapEndpoints(app);
TodoListEndpoints.MapEndpoints(app);

app.Run();