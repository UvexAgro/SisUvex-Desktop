using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class SingleImageManager : IDisposable
{
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

    // 1. Cargar imagen específica
    public void LoadImage(string imageFileName)
    {
        CurrentImage?.Dispose();
        CurrentImage = null;
        originalImagePath = null;
        newImagePath = null;

        string[] possibleExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

        foreach (var ext in possibleExtensions)
        {
            string imagePath = Path.Combine(imagesFolderPath, $"{imageFileName}{ext}");
            if (File.Exists(imagePath))
            {
                originalImagePath = imagePath;
                try
                {
                    CurrentImage = Image.FromFile(imagePath);
                    return;
                }
                catch
                {
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
                    CurrentImage?.Dispose();

                    CurrentImage = Image.FromFile(openFileDialog.FileName);
                    newImagePath = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                }
            }
        }
    }

    // 3. Guardar imagen con nombre específico
    public void SaveImage(string imageFileName)
    {
        if (CurrentImage == null)
        {
            if (File.Exists(originalImagePath))
            {
                BackupImage(originalImagePath);
                try
                {
                    File.Delete(originalImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la imagen existente: {ex.Message}");
                }
            }
            return;
        }

        if (File.Exists(originalImagePath))
        {
            if (AreImagesIdentical(CurrentImage, originalImagePath))
            {
                return;
            }

            BackupImage(originalImagePath);

            try
            {
                File.Delete(originalImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la imagen existente: {ex.Message}");
            }
        }

        string newExtension = Path.GetExtension(newImagePath) ?? ".png";
        string newPathInFolder = Path.Combine(imagesFolderPath, $"{imageFileName}{newExtension}");

        try
        {
            CurrentImage.Save(newPathInFolder);
            originalImagePath = newPathInFolder;
            newImagePath = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar la imagen: {ex.Message}");
        }
    }

    private bool AreImagesIdentical(Image? currentImage, string existingImagePath)
    {
        if(currentImage == null || string.IsNullOrEmpty(existingImagePath))
            return false;

        try
        {
            // Crear hash MD5 de la imagen actual
            using (var ms1 = new MemoryStream())
            {
                currentImage.Save(ms1, currentImage.RawFormat);
                byte[] hash1 = System.Security.Cryptography.MD5.Create().ComputeHash(ms1.ToArray());

                // Crear hash MD5 de la imagen existente
                using (var img = Image.FromFile(existingImagePath))
                using (var ms2 = new MemoryStream())
                {
                    img.Save(ms2, img.RawFormat);
                    byte[] hash2 = System.Security.Cryptography.MD5.Create().ComputeHash(ms2.ToArray());

                    // Comparar los hashes
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
            // Si hay algún error en la comparación, asumimos que son diferentes
            return false;
        }
    }

    // 4. Reiniciar imagen (cargar desde disco)
    public void ResetImage(string imageFileName)
    {
        CurrentImage?.Dispose();
        CurrentImage = null;
        originalImagePath = null;
        newImagePath = null;
        LoadImage(imageFileName);
    }

    // 5. Borrar imagen específica
    public void DeleteImage(string imageFileName)
    {
        if (CurrentImage != null)
        {
            CurrentImage.Dispose();
            CurrentImage = null;
            newImagePath = null;
        }

        // Buscar el archivo con cualquier extensión
        string[] possibleExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

        foreach (var ext in possibleExtensions)
        {
            string imagePath = Path.Combine(imagesFolderPath, $"{imageFileName}{ext}");
            if (File.Exists(imagePath))
            {
                BackupImage(imagePath);
                File.Delete(imagePath);
                originalImagePath = null;
                break;
            }
        }
    }

    // Método para hacer backup de una imagen
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
            MessageBox.Show($"Error al hacer backup de la imagen: {ex.Message}");
        }
    }

    // Método para limpiar recursos
    public void Dispose()
    {
        CurrentImage?.Dispose();
    }

    public void ClearNew()
    {
        CurrentImage?.Dispose();
        CurrentImage = null;
        newImagePath = null;
    }
}