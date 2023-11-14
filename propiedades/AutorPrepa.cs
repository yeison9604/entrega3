namespace Entrega3.AutorPrepa;
using Entrega3.Autor;

public class AutorPrepa
{
    private List<Autores> _autor;

    public List<Autores> Autor { get => _autor; set => _autor = value; }

    public AutorPrepa()
    {
        this.Autor = new List<Autores>();
    }


    public List<Autores> ALL()
    {
        return this.Autor;
    }

    public void Crear_Autor(Autores autor)
    {
        this.Autor.Add(autor);
    }



    public void Actualizar_Autor(Autores autor, Guid id)
    {
        foreach (Autores buscarAutor in this.Autor)
            if (buscarAutor.id == id)
            {
                buscarAutor.nombre = autor.nombre;
                buscarAutor.pais = autor.pais;

                break;
            }
    }

    public void Eliminar_Autor(Guid id)
    {
        foreach (Autores buscarAutor in this.Autor)
            if (buscarAutor.id == id)
            {
                this._autor.Remove(buscarAutor);
                break;
            }
    }

    public Boolean Hallado(Guid id)
    {
        Boolean Hallado = false;
        foreach (Autores buscarAutor in this.Autor)
            if (buscarAutor.id == id)
            {
                Hallado = true;
                break;
            }

        return Hallado;
    }

    public Autores Buscar_Autores(Guid id)
    {
        Autores Hallado = null;

        foreach (Autores buscarAutor in this.Autor)
            if (buscarAutor.id == id)
            {
                return buscarAutor;

            }
        return Hallado;
    }



}