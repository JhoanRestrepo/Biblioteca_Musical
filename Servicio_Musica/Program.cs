using Libreria.Implementaciones;
using Libreria.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IAlbumes_ArtistasAplicacion, Albumes_ArtistasAplicacion>();
builder.Services.AddScoped<IAlbumesAplicacion, AlbumesAplicacion>();
builder.Services.AddScoped<IArtistas_SellosAplicacion, Artistas_SellosAplicacion>();
builder.Services.AddScoped<IArtistasAplicacion, ArtistasAplicacion>();
builder.Services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
builder.Services.AddScoped<ICanciones_CompositoresAplicacion, Canciones_CompositoresAplicacion>();
builder.Services.AddScoped<ICanciones_GenerosAplicacion, Canciones_GenerosAplicacion>();
builder.Services.AddScoped<ICanciones_IdiomasAplicacion, Canciones_IdiomasAplicacion>();
builder.Services.AddScoped<ICancionesAplicacion, CancionesAplicacion>();
builder.Services.AddScoped<ICancionesAplicacion, CancionesAplicacion>();
builder.Services.AddScoped<ICompositoresAplicacion, CompositoresAplicacion>();
builder.Services.AddScoped<IFav_CancionesAplicacion, Fav_CancionesAplicacion>();
builder.Services.AddScoped<IFavoritosAplicacion, FavoritosAplicacion>();
builder.Services.AddScoped<IGenerosAplicacion, GenerosAplicacion>();
builder.Services.AddScoped<IIdiomasAplicacion, IdiomasAplicacion>();
builder.Services.AddScoped<IListas_CancionesAplicacion, Listas_CancionesAplicacion>();
builder.Services.AddScoped<IListas_ReproduccionesAplicacion, Listas_ReproduccionesAplicacion>();
builder.Services.AddScoped<ILR_CancionesAplicacion, LR_CancionesAplicacion>();
builder.Services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
builder.Services.AddScoped<IReproduccionesAplicacion, ReproduccionesAplicacion>();
builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<ISellos_DiscograficosAplicacion, Sellos_DiscograficosAplicacion>();
builder.Services.AddScoped<ISuscripcionesAplicacion, SuscripcionesAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();