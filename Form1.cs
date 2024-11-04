using System.Windows.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;

namespace Webphotos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ReportProgress(int value)
        {
            ProgressBar1.Value += 1;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
        }

        private void AddFiles()
        {
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in OpenFileDialog1.FileNames)
                {
                    ListBox1.Items.Add(file);
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            AddFiles();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFiles();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one image file.");
                return;
            }

            if (!int.TryParse(MaskedTextBox2.Text.Replace(" ", "").Trim(), out int newSize) || newSize <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer value for the new size.");
                return;
            }

            ProgressBar1.Value = 0;
            ProgressBar1.Maximum = ListBox1.Items.Count -1;

            System.Collections.IList list = ListBox1.Items;
            for (int i = 0; i < list.Count; i++)
            {
                string filePath = (string)list[i];
                FileInfo fileInfo = new FileInfo(filePath);

                ResizeImage(fileInfo, newSize);
                ProgressBar1.Value = i;
            }

            MessageBox.Show("All images have been resized.");
            ListBox1.Items.Clear();
        }

        private void ResizeImage(FileInfo fileInfo, int maxSizeInBytes)
        {
            string extension = fileInfo.Extension.ToLowerInvariant();
            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            {
                MessageBox.Show($"Unsupported file type: {fileInfo.Name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string backupPath = Path.Combine(fileInfo.DirectoryName ?? string.Empty, $"{Path.GetFileNameWithoutExtension(fileInfo.Name)}.old{extension}");

            // Check for existing backup
            if (File.Exists(backupPath))
            {
                MessageBox.Show($"Backup file already exists for: {fileInfo.Name}. Please resolve and retry.", "File Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create backup by renaming the original file
            File.Move(fileInfo.FullName, backupPath);

            try
            {
                using (Image image = Image.Load(backupPath))
                {
                    // Calculate initial scale to resize image if needed
                    int scalePercent = 100;
                    MemoryStream memoryStream = new MemoryStream();
                    while (true)
                    {
                        memoryStream.SetLength(0); // Reset the memory stream for reuse
                        image.Mutate(x => x.Resize(image.Width * scalePercent / 100, image.Height * scalePercent / 100));

                        // Save to stream to check file size
                        image.Save(memoryStream, GetEncoder(extension));
                        if (memoryStream.Length <= maxSizeInBytes)
                            break; // Stop if the file size is under the required size
                        scalePercent -= 10; // Decrease scale percent to reduce size

                        if (scalePercent <= 10) // Prevent too much quality loss
                        {
                            MessageBox.Show($"Unable to compress the image to the desired size.", "Compression Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Save the image to the file with adjusted quality
                    using (var fileStream = new FileStream(fileInfo.FullName, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.WriteTo(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                // Attempt to restore the original file in case of an error
                File.Move(backupPath, fileInfo.FullName);
                MessageBox.Show($"Error processing image '{fileInfo.FullName}': {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IImageEncoder GetEncoder(string extension)
        {
            if (extension == ".png")
            {
                return new SixLabors.ImageSharp.Formats.Png.PngEncoder();
            }
            else // Default to JPEG if it's not PNG
            {
                return new JpegEncoder { Quality = 75 }; // Adjust quality for JPEG
            }
        }

    }
}
