namespace CustomMouseApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button btnResetCursor;  // Reset Button

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
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.btnResetCursor = new System.Windows.Forms.Button();  // Reset Button hinzufügen
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();

            // 
            // trackBarSize
            // 
            this.trackBarSize.Location = new System.Drawing.Point(12, 12);
            this.trackBarSize.Maximum = 20;
            this.trackBarSize.Minimum = 1;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(776, 45);
            this.trackBarSize.TabIndex = 0;
            this.trackBarSize.Value = 10;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);

            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(12, 63);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(776, 23);
            this.btnSelectImage.TabIndex = 1;
            this.btnSelectImage.Text = "Select Custom Cursor Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);

            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(12, 92);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(776, 300);
            this.pictureBoxPreview.TabIndex = 2;
            this.pictureBoxPreview.TabStop = false;

            // 
            // btnResetCursor
            // 
            this.btnResetCursor.Location = new System.Drawing.Point(12, 400);
            this.btnResetCursor.Name = "btnResetCursor";
            this.btnResetCursor.Size = new System.Drawing.Size(776, 23);
            this.btnResetCursor.TabIndex = 3;
            this.btnResetCursor.Text = "Reset Cursor to Default";
            this.btnResetCursor.UseVisualStyleBackColor = true;
            this.btnResetCursor.Click += new System.EventHandler(this.btnResetCursor_Click);  // Reset Event

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnResetCursor);  // Reset Button hinzufügen
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.trackBarSize);
            this.Name = "Form1";
            this.Text = "Custom Mouse App";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
