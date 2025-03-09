namespace ImageToByteString
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // Asignar eventos a los botones
            btnSelectFile.Click += btnSelectFile_Click;
            btnSaveToFile.Click += btnSaveToFile_Click;
            btnCopyToClipboard.Click += btnCopyToClipboard_Click;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Imágenes (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Todos los archivos|*.*",
                Title = "Seleccionar una imagen"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    // Convertir la imagen a bytes y formatear como string hexadecimal
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    string byteString = "0x" + BitConverter.ToString(imageBytes).Replace("-", "");

                    // Mostrar el resultado en el TextBox
                    txtByteString.Text = byteString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la imagen: " + ex.Message);
                }
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtByteString.Text) || txtByteString.Text == "Resultado")
            {
                MessageBox.Show("No hay datos para guardar.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt",
                Title = "Guardar como"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, txtByteString.Text);
                    MessageBox.Show("Archivo guardado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtByteString.Text) && txtByteString.Text != "Resultado")
            {
                Clipboard.SetText(txtByteString.Text);
                MessageBox.Show("Texto copiado al portapapeles.");
            }
            else
            {
                MessageBox.Show("No hay datos para copiar.");
            }
        }
    }
}
