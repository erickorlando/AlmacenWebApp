namespace AlmacenWebApp.Server.Servicios;

public interface IFileUploader
{
    Task<string> SubirArchivo(string? base64Imagen, string? nombre);
}