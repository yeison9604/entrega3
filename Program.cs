using System.Reflection.Metadata;
using Entrega3.Autor;
using Entrega3.Libro;
using Entrega3.AutorPrepa;
using Entrega3.LibrosPrepa;
var buil = WebApplication.CreateBuilder(args);
var appii = buil.Build();


List<Libritos> PS4 = new List<Libritos>();
AutorPrepa autorprepa = new AutorPrepa();
List<Autores> PS5 = autorprepa.Autor;
LibrosPrepa librosprepa = new LibrosPrepa(PS4, autorprepa);

appii.MapGet("/api/v1/autores", () =>
{
    return Results.Ok(autorprepa.ALL());
});

appii.MapPost("/api/v1/autores", (Autores autor) =>
{
    autorprepa.Crear_Autor(autor);

    return Results.Ok(autor);
});

appii.MapPut("/api/v1/autores/{id:guid}", (Guid id, Autores autor) =>
{
    autorprepa.Actualizar_Autor(autor, id);
    return Results.Ok(autorprepa.ALL());
});


appii.MapDelete("/api/v1/autores/{id:guid}", (Guid id) =>
{
    autorprepa.Eliminar_Autor(id);
    return Results.Ok(autorprepa.ALL());
});

appii.MapGet("/api/v1/libro", () =>
{
    return Results.Ok(librosprepa.ALL());
});
appii.MapGet("/api/v1/autores/{id}", (Guid id) =>
{
    if (autorprepa.Hallado(id))
    {
        return Results.Ok(autorprepa.Buscar_Autores(id));
    }
    return Results.BadRequest("No Hay Autor");

});

appii.MapPost("/api/v1/libro", (Libritos libro) =>
{
    if (librosprepa.Crea_Libro(libro))
    {
        return Results.Ok(libro);
    }
    return Results.BadRequest(libro);
});

appii.MapPut("/api/v1/libros/{id:guid}", (Guid id, Libritos libro) =>
{
    librosprepa.Actua_Libro(libro, id);
    return Results.Ok(librosprepa.ALL());
});

appii.MapDelete("/api/v1/libros/{id:guid}", (Guid id) =>
{
    librosprepa.Eliminar_Libro(id);
    return Results.Ok(librosprepa.ALL());
});
appii.MapGet("/api/v1/libros/{id:guid}", (Guid id) =>
{

    if (librosprepa.Hallado(id))
    {
        return Results.Ok(librosprepa.Adquirir_Libro(id));
    }
    return Results.BadRequest("No Hay Libro");

});



appii.Run();