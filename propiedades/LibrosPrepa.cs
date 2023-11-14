namespace Entrega3.LibrosPrepa;
using Entrega3.Libro;
using Entrega3.AutorPrepa;
public class LibrosPrepa
{
    private AutorPrepa _autorprepa;
    private List<Libritos> _libro;
    public LibrosPrepa(List<Libritos> libro, AutorPrepa autorprepa)
    {
        this.AutorPrepa = autorprepa;
        this._libro = libro;
    }

    public AutorPrepa AutorPrepa { get => _autorprepa; set => _autorprepa = value; }

    public List<Libritos> ALL()
    {
        return this._libro;
    }

    public Boolean Crea_Libro(Libritos libro)
    {
        Boolean registrado = false;
        if (AutorPrepa.Hallado(libro.autorid))
        {
            this._libro.Add(libro);
            registrado = true;
        }
        return registrado;

    }

    public void Actua_Libro(Libritos libro, Guid id)
    {
        foreach (Libritos buscarlibro in this._libro)
            if (buscarlibro.id == id)
            {
                buscarlibro.titulo = libro.titulo;
                break;
            }
    }

    public void Eliminar_Libro(Guid id)
    {
        foreach (Libritos buscarlibro in this._libro)
            if (buscarlibro.id == id)
            {
                this._libro.Remove(buscarlibro);
                break;
            }
    }
    public Boolean Hallado(Guid id)
    {
        Boolean Hallado = false;
        foreach (Libritos buscarlibro in this._libro)
            if (buscarlibro.id == id)
            {
                Hallado = true;
                break;
            }

        return Hallado;
    }

    public Libritos Adquirir_Libro(Guid id)
    {
        Libritos Hallado = null;

        foreach (Libritos buscarlibro in this._libro)
            if (buscarlibro.id == id)
            {
                return buscarlibro;
                break;
            }
        return Hallado;
    }


}