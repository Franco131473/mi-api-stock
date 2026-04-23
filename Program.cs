using Microsoft.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

// 🔥 ACTIVAR CORS
builder.Services.AddCors();
builder.WebHost.UseUrls("http://0.0.0.0:10000");
var app = builder.Build();

// 🔥 PERMITIR TODO (para desarrollo)
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/stock", (IConfiguration config) =>
{
        var lista = new[]
    {
        new { Id = 1, Producto = "Cloro", Stock = 15 },
        new { Id = 2, Producto = "Ácido", Stock = 8 }
    };

    return Results.Ok(lista);
    // using var conexion = new SqlConnection(
    //     config.GetConnectionString("DefaultConnection"));

    // var lista = conexion.Query("SELECT * FROM StockQuimica");

    // return Results.Ok(lista);
});

app.Run();