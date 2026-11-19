using Libreria_Front.Interfaces;
using Libreria_Front.Implementaciones;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IAlbumesPresentacion, AlbumesPresentacion>();
builder.Services.AddScoped<IArtistasPresentacion, ArtistasPresentacion>();
builder.Services.AddScoped<IAlbumes_ArtistasPresentacion, Albumes_ArtistasPresentacion>();
builder.Services.AddScoped<ICancionesPresentacion, CancionesPresentacion>();

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