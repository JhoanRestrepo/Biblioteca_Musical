using Libreria.Implementaciones;
using Libreria.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IAlbumes_ArtistasAplicacion, Albumes_ArtistasAplicacion>();
builder.Services.AddScoped<IAlbumesAplicacion, AlbumesAplicacion>();
builder.Services.AddScoped<IArtistas_SellosAplicacion, Artistas_SellosAplicacion>();
builder.Services.AddScoped<IArtistasAplicacion, ArtistasAplicacion>();
builder.Services.AddScoped<ISellos_DiscograficosAplicacion, Sellos_DiscograficosAplicacion>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();