using Microsoft.EntityFrameworkCore;
using Supermarket_multiplemodels.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<marketDbContext>(options => options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));
builder.Services.AddControllers();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

