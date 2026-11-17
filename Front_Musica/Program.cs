using Libreria_Front.Interfaces;
using Libreria_Front.Implementaciones;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();

    builder.Services.AddControllers();
    builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
    builder.Services.AddScoped<IAlbumesPresentacion, AlbumesPresentacion>();
    builder.Services.AddScoped<IArtistasPresentacion, ArtistasPresentacion>();
    builder.Services.AddScoped<IAlbumes_ArtistasPresentacion, Albumes_ArtistasPresentacion>();

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

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Error occurred: {ex.Message}");
}


