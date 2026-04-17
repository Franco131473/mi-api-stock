using Microsoft.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

// 🔥 ACTIVAR CORS
builder.Services.AddCors();

var app = builder.Build();

// 🔥 PERMITIR TODO (para desarrollo)
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/stock", (IConfiguration config) =>
{
    using var conexion = new SqlConnection(
        config.GetConnectionString("DefaultConnection"));

    var lista = conexion.Query("SELECT * FROM StockQuimica");

    return Results.Ok(lista);
});

app.Run();