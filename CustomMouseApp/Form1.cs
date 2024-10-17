using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CustomMouseApp
{
    public partial class Form1 : Form
    {
        private Cursor? customCursor;
        private float cursorScale = 1.0f;
        private string? cursorImagePath;
        private string settingsFilePath = "cursorSettings.json";

        public Form1()
        {
            InitializeComponent();
            LoadSettings(); // Einstellungen beim Start laden
        }

        // Methode zum Setzen des globalen Cursors
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public const int SPI_SETCURSORS = 0x0057;

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpeg;*.jpg";  // Nur .png und .jpeg Dateien

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cursorImagePath = openFileDialog.FileName;
                SetCustomCursor(cursorImagePath);
                SaveSettings(); // Einstellungen speichern nach Auswahl
            }
        }

        private void SetCustomCursor(string imagePath)
        {
            try
            {
                if (!File.Exists(imagePath))
                {
                    MessageBox.Show("Die Cursor-Datei wurde nicht gefunden.");
                    return;
                }

                customCursor = new Cursor(imagePath);
                this.Cursor = customCursor;

                // Den globalen Cursor ändern
                ApplyGlobalCursor(imagePath);

                // Vorschau des benutzerdefinierten Cursors anzeigen
                pictureBoxPreview.Image = new Bitmap(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden des Cursors: " + ex.Message);
            }
        }

        // Methode zum Anwenden des Cursors systemweit
        private void ApplyGlobalCursor(string cursorFilePath)
        {
            bool result = SystemParametersInfo(SPI_SETCURSORS, 0, cursorFilePath, 0);
            if (!result)
            {
                MessageBox.Show("Der Cursor konnte nicht systemweit angewendet werden.");
            }
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            cursorScale = trackBarSize.Value / 10.0f;
            ResizeCursor();
            SaveSettings(); // Speichern, wenn Größe geändert wird
        }

        private void ResizeCursor()
        {
            if (customCursor != null && cursorImagePath != null)
            {
                Bitmap cursorBitmap = new Bitmap(cursorImagePath);
                int newWidth = (int)(cursorBitmap.Width * cursorScale);
                int newHeight = (int)(cursorBitmap.Height * cursorScale);
                Bitmap resizedCursorBitmap = new Bitmap(cursorBitmap, new Size(newWidth, newHeight));

                pictureBoxPreview.Image = resizedCursorBitmap;
                IntPtr ptr = resizedCursorBitmap.GetHicon();
                this.Cursor = new Cursor(ptr);
            }
        }

        private void btnResetCursor_Click(object sender, EventArgs e)
        {
            ResetCursorToDefault();
            SaveSettings(); // Nach dem Zurücksetzen speichern
        }

        private void ResetCursorToDefault()
        {
            Cursor = Cursors.Default;
            SystemParametersInfo(SPI_SETCURSORS, 0, null, 0);  // Setzt systemweiten Cursor zurück
            pictureBoxPreview.Image = null;  // Leere Vorschau nach Zurücksetzen
        }

        // Einstellungen speichern
        private void SaveSettings()
        {
            var settings = new CursorSettings
            {
                ImagePath = cursorImagePath,
                Size = cursorScale
            };

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }

        // Einstellungen laden
        private void LoadSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                try
                {
                    string json = File.ReadAllText(settingsFilePath);
                    var settings = JsonConvert.DeserializeObject<CursorSettings>(json);

                    cursorImagePath = settings.ImagePath;
                    cursorScale = settings.Size;

                    if (!string.IsNullOrEmpty(cursorImagePath))
                    {
                        SetCustomCursor(cursorImagePath);
                        trackBarSize.Value = (int)(cursorScale * 10);  // Setzt den Schieberegler
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Laden der Einstellungen: " + ex.Message);
                }
            }
        }

        // Klasse zur Speicherung der Cursor-Einstellungen
        public class CursorSettings
        {
            public string? ImagePath { get; set; }
            public float Size { get; set; }
        }
    }
}
