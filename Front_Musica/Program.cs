using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria_Front.Implementaciones;
using Libreria_Front.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IAlbumes_ArtistasPresentacion, Albumes_ArtistasPresentacion>();
builder.Services.AddScoped<IAlbumesPresentacion, AlbumesPresentacion>();
builder.Services.AddScoped<IArtistas_SellosPresentacion, Artistas_SellosPresentacion>();
builder.Services.AddScoped<IArtistasPresentacion, ArtistasPresentacion>();
builder.Services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
builder.Services.AddScoped<ICanciones_CompositoresPresentacion, Canciones_CompositoresPresentacion>();
builder.Services.AddScoped<ICanciones_GenerosPresentacion, Canciones_GenerosPresentacion>();
builder.Services.AddScoped<ICanciones_IdiomasPresentacion, Canciones_IdiomasPresentacion>();
builder.Services.AddScoped<ICancionesPresentacion, CancionesPresentacion>();
builder.Services.AddScoped<ICompositoresPresentacion, CompositoresPresentacion>();
builder.Services.AddScoped<IFav_CancionesPresentacion, Fav_CancionesPresentacion>();
builder.Services.AddScoped<IFavoritosPresentacion, FavoritosPresentacion>();
builder.Services.AddScoped<IGenerosPresentacion, GenerosPresentacion>();
builder.Services.AddScoped<I_IdiomasPresentacion, IdiomasPresentacion>();
builder.Services.AddScoped<IListas_CancionesPresentacion, Listas_CancionesPresentacion>();
builder.Services.AddScoped<IListas_ReproduccionesPresentacion, Listas_ReproduccionesPresentacion>();
builder.Services.AddScoped<ILR_CancionesPresentacion, LR_CancionesPresentacion>();
builder.Services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
builder.Services.AddScoped<IReproduccionesPresentacion, ReproduccionesPresentacion>();
builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
builder.Services.AddScoped<IRoles_PermisosPresentacion, Roles_PermisosPresentacion>();
builder.Services.AddScoped<ISellos_DiscograficosPresentacion, Sellos_DiscograficosPresentacion>();
builder.Services.AddScoped<ISuscripcionesPresentacion, SuscripcionesPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IUsuarios_RolesPresentacion, Usuarios_RolesPresentacion>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.UseSession();
app.Run();