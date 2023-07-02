namespace AlmacenWebApp.Shared
{
    public class Categoria
    {
        public int Id { get; set; } // IDENTITY PRIMARY KEY
        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;
    }
}
