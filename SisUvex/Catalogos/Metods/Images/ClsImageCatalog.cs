using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ServiceModel.Channels;
using System.Windows.Forms;

public class SingleImageManager : IDisposable
{
    private bool _disposed = false;
    public Image? CurrentImage { get; private set; }
    private string? originalImagePath;
    private string? newImagePath;
    private string imagesFolderPath;
    private string backupFolderPath;

    public SingleImageManager(string baseImagesPath)
    {
        this.imagesFolderPath = baseImagesPath;
        this.backupFolderPath = Path.Combine(baseImagesPath, "ImagesBackUp");

        Directory.CreateDirectory(imagesFolderPath);
        Directory.CreateDirectory(backupFolderPath);
    }

    // 1. Cargar imagen específica sin bloquear el archivo
    public void LoadImage(string imageFileName)
    {
        ClearCurrentImage();
        originalImagePath = null;
        newImagePath = null;

        string[] possibleExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

        foreach (var ext in possibleExtensions)
        {
            string imagePath = Path.Combine(imagesFolderPath, $"{imageFileName}{ext}");
            if (File.Exists(imagePath))
            {
                try
                {
                    // Cargar la imagen sin bloquear el archivo
                    using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        CurrentImage = Image.FromStream(fs);
                        originalImagePath = imagePath;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar imagen {imagePath}: {ex.Message}");
                    continue;
                }
            }
        }
    }

    // 2. Cargar nueva imagen desde archivo
    public void LoadNewImageFromFile()
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Seleccionar imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ClearCurrentImage();

                    // Cargar la imagen sin bloquear el archivo
                    using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        CurrentImage = Image.FromStream(fs);
                        newImagePath = openFileDialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // 3. Guardar imagen con nombre específico
    public void SaveImage(string imageFileName)
    {
        if (newImagePath == "EMPTY_IMAGE")
        {
            if (!string.IsNullOrEmpty(originalImagePath) && File.Exists(originalImagePath))
            {
                BackupAndDeleteOriginal();
            }
            return;
        }

        if (string.IsNullOrEmpty(newImagePath))
            return;

        if (!string.IsNullOrEmpty(originalImagePath) && File.Exists(originalImagePath))
        {
            if (AreImagesIdentical(CurrentImage, originalImagePath))
            {
                return;
            }

            BackupAndDeleteOriginal();
        }

        string newExtension = Path.GetExtension(newImagePath ?? originalImagePath) ?? ".png";
        string newPathInFolder = Path.Combine(imagesFolderPath, $"{imageFileName}{newExtension}");

        try
        {
            // Crear una copia de la imagen para evitar problemas de disposición
            using (Bitmap copy = new Bitmap(CurrentImage))
            {
                // Especificar el códec JPEG manualmente
                if (newExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    newExtension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 90L); // Calidad 90%

                    copy.Save(newPathInFolder, jpegCodec, encoderParams);
                }
                else
                {
                    copy.Save(newPathInFolder);
                }
            }

            originalImagePath = newPathInFolder;
            newImagePath = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar la imagen: {ex.Message}\n\nDetalles técnicos:\n{ex.ToString()}",
                          "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Método auxiliar para obtener el códec de imagen
    private ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.MimeType == mimeType)
                return codec;
        }
        return null;
    }

    private void BackupAndDeleteOriginal()
    {
        try
        {
            BackupImage(originalImagePath);
            File.Delete(originalImagePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al manejar la imagen existente: {ex.Message}", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool AreImagesIdentical(Image currentImage, string existingImagePath)
    {
        if (currentImage == null || string.IsNullOrEmpty(existingImagePath) || !File.Exists(existingImagePath))
            return false;

        // Primera verificación rápida: tamaño del archivo
        FileInfo fi = new FileInfo(existingImagePath);
        if (fi.Length == 0) return false; // Archivo corrupto

        try
        {
            // Comparación rápida de dimensiones
            using (var existingImage = Image.FromFile(existingImagePath))
            {
                if (currentImage.Width != existingImage.Width || currentImage.Height != existingImage.Height)
                    return false;
            }

            // Si pasa la prueba rápida, hacer comparación de hash
            using (var ms1 = new MemoryStream())
            {
                currentImage.Save(ms1, currentImage.RawFormat);
                byte[] hash1 = System.Security.Cryptography.MD5.Create().ComputeHash(ms1.ToArray());

                using (var fs = new FileStream(existingImagePath, FileMode.Open, FileAccess.Read))
                using (var existingImage = Image.FromStream(fs))
                using (var ms2 = new MemoryStream())
                {
                    existingImage.Save(ms2, existingImage.RawFormat);
                    byte[] hash2 = System.Security.Cryptography.MD5.Create().ComputeHash(ms2.ToArray());

                    for (int i = 0; i < hash1.Length; i++)
                    {
                        if (hash1[i] != hash2[i]) return false;
                    }
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    // 4. Reiniciar imagen (cargar desde disco)
    public void ResetImage(string imageFileName)
    {
        ClearCurrentImage();
        LoadImage(imageFileName);
    }

    // 5. Borrar imagen específica
    public void DeleteImage(string imageFileName)
    {
        ClearCurrentImage();

        string[] possibleExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

        foreach (var ext in possibleExtensions)
        {
            string imagePath = Path.Combine(imagesFolderPath, $"{imageFileName}{ext}");
            if (File.Exists(imagePath))
            {
                try
                {
                    BackupImage(imagePath);
                    File.Delete(imagePath);
                    originalImagePath = null;
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la imagen: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void BackupImage(string imagePath)
    {
        try
        {
            string fileName = Path.GetFileName(imagePath);
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            string ext = Path.GetExtension(fileName);
            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string backupPath = Path.Combine(backupFolderPath, $"{nameWithoutExt}_{timeStamp}{ext}");

            File.Copy(imagePath, backupPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al hacer backup de la imagen: {ex.Message}", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearCurrentImage()
    {
        if (CurrentImage != null)
        {
            CurrentImage.Dispose();
            CurrentImage = null;
        }
    }

    public void ClearNew()
    {
        ClearCurrentImage();
        newImagePath = "EMPTY_IMAGE";
    }

    // Implementación de IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                ClearCurrentImage();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~SingleImageManager()
    {
        Dispose(false);
    }
}