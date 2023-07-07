namespace AlmacenWebApp.Server.Servicios;

public class FileUploader : IFileUploader
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<FileUploader> _logger;

    public FileUploader(IConfiguration configuration, ILogger<FileUploader> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<string> SubirArchivo(string? base64Imagen, string? nombre)
    {
        if (string.IsNullOrWhiteSpace(base64Imagen) || string.IsNullOrWhiteSpace(nombre))
            return string.Empty;

        try
        {
            var bytes = Convert.FromBase64String(base64Imagen);

            var ruta = Path.Combine(_configuration["Archivos:Ruta"]!, nombre);

            await using var fileStream = new FileStream(ruta, FileMode.Create);
            await fileStream.WriteAsync(bytes, 0, bytes.Length);

            return $"{_configuration["Archivos:RutaPublica"]}{nombre}";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al subir el archivo {nombre} {message}", nombre, ex.Message);

            return string.Empty;
        }
    }
}