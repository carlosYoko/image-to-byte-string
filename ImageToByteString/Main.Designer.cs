namespace ImageToByteString
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnSelectFile = new Button();
            btnSaveToFile = new Button();
            txtByteString = new TextBox();
            btnCopyToClipboard = new Button();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(44, 19);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(131, 28);
            btnSelectFile.TabIndex = 0;
            btnSelectFile.Text = "Seleccionar Imagen";
            btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // btnSaveToFile
            // 
            btnSaveToFile.Location = new Point(44, 56);
            btnSaveToFile.Name = "btnSaveToFile";
            btnSaveToFile.Size = new Size(131, 28);
            btnSaveToFile.TabIndex = 1;
            btnSaveToFile.Text = "Guardar como TXT";
            btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // txtByteString
            // 
            txtByteString.Location = new Point(44, 94);
            txtByteString.Multiline = true;
            txtByteString.Name = "txtByteString";
            txtByteString.ScrollBars = ScrollBars.Vertical;
            txtByteString.Size = new Size(438, 188);
            txtByteString.TabIndex = 2;
            // 
            // btnCopyToClipboard
            // 
            btnCopyToClipboard.Location = new Point(44, 291);
            btnCopyToClipboard.Name = "btnCopyToClipboard";
            btnCopyToClipboard.Size = new Size(131, 39);
            btnCopyToClipboard.TabIndex = 3;
            btnCopyToClipboard.Text = "Copiar al Portapapeles";
            btnCopyToClipboard.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 347);
            Controls.Add(btnCopyToClipboard);
            Controls.Add(txtByteString);
            Controls.Add(btnSaveToFile);
            Controls.Add(btnSelectFile);
            Name = "Form1";
            Text = "Conversor de Imágenes a Bytes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.TextBox txtByteString;
        private System.Windows.Forms.Button btnCopyToClipboard;
    }
}
