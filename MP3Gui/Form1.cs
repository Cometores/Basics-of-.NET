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
        private ID3Tag id3Tag;
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(openFileDialog1.FileName))
                {
                    try
                    {
                        id3Tag = ID3Tag.FromStream(fs);
                        
                        titleTextBox.Text = id3Tag.Title;
                        artistTextBox.Text = id3Tag.Artist;
                        albumTextBox.Text = id3Tag.Album;
                        yearTextBox.Text = id3Tag.Year;
                        commentaryTextBox.Text = id3Tag.Comment;
                        genreTextBox.Text = id3Tag.Genre;

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
                // using (BinaryReader binary_reader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
                // {
                //     
                // }
            }
        }

        private void fileNameLabel_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}