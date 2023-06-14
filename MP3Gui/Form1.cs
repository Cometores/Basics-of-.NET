using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MP3FileStream;

namespace MP3Gui
{
    public partial class Form1 : Form
    {
        private ID3Tag _id3Tag;
        private string _mp3OriginalPath;
        private string _mp3NewPath;
        
        public Form1()
        {
            InitializeComponent();
            genreDropDown.DataSource = Enum.GetNames(typeof(GenreTypes)).ToList();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _mp3OriginalPath = openFileDialog1.FileName;
                
                using (FileStream fs = File.OpenRead(openFileDialog1.FileName))
                {
                    try
                    {
                        _id3Tag = ID3Tag.FromStream(fs);
                        
                        titleTextBox.Text = _id3Tag.Title;
                        artistTextBox.Text = _id3Tag.Artist;
                        albumTextBox.Text = _id3Tag.Album;
                        yearTextBox.Text = _id3Tag.Year;
                        commentaryTextBox.Text = _id3Tag.Comment;
                        genreDropDown.Text = _id3Tag.Genre.ToString();

                        fileNameLabel.Text = openFileDialog1.SafeFileName;
                    }
                    catch (NotValidMP3FileException exception)
                    {
                        Console.WriteLine(exception);
                        //TODO: ExceptionHandling
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        throw;
                    }
                }

                saveButton.Enabled = true;
            }
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _mp3NewPath = saveFileDialog1.FileName;
                
                if(File.Exists(_mp3NewPath))
                    File.Delete(_mp3NewPath);
                
                File.Copy(_mp3OriginalPath, _mp3NewPath);
                
                string title = titleTextBox.Text;
                string artist = artistTextBox.Text;
                string album = albumTextBox.Text;
                string year = yearTextBox.Text;
                string comment = commentaryTextBox.Text;
                string genre =  ((int)((GenreTypes)Enum.Parse(typeof(GenreTypes), genreDropDown.Text))).ToString();

                ID3Tag id3Tag = ID3Tag.FromStrings(title, artist, album, year, comment, genre);

            
                using (FileStream fs = File.OpenWrite(_mp3NewPath))
                    id3Tag.WriteToStream(fs);
                
                MessageBox.Show("File was saved");
            }
        }

        private void fileNameLabel_Click(object sender, EventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}