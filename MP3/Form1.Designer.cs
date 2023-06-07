namespace MP3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.genreLabel = new System.Windows.Forms.Label();
            this.commentaryLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.albumLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.albumTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.commentaryTextBox = new System.Windows.Forms.TextBox();
            this.genreTextBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.8843F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.1157F));
            this.tableLayoutPanel1.Controls.Add(this.genreLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.commentaryLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.yearLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.albumLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.artistLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.titleTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.artistTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.albumTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.yearTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.commentaryTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.genreTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.openButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // genreLabel
            // 
            this.genreLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreLabel.Location = new System.Drawing.Point(112, 417);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(49, 18);
            this.genreLabel.TabIndex = 13;
            this.genreLabel.Text = "Genre";
            // 
            // commentaryLabel
            // 
            this.commentaryLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.commentaryLabel.AutoSize = true;
            this.commentaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentaryLabel.Location = new System.Drawing.Point(67, 347);
            this.commentaryLabel.Name = "commentaryLabel";
            this.commentaryLabel.Size = new System.Drawing.Size(94, 18);
            this.commentaryLabel.TabIndex = 12;
            this.commentaryLabel.Text = "Commentary";
            // 
            // yearLabel
            // 
            this.yearLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLabel.Location = new System.Drawing.Point(53, 278);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(108, 18);
            this.yearLabel.TabIndex = 11;
            this.yearLabel.Text = "YearOfRelease";
            // 
            // albumLabel
            // 
            this.albumLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.albumLabel.AutoSize = true;
            this.albumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumLabel.Location = new System.Drawing.Point(52, 209);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(109, 18);
            this.albumLabel.TabIndex = 10;
            this.albumLabel.Text = "Album / CD title";
            // 
            // artistLabel
            // 
            this.artistLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.artistLabel.AutoSize = true;
            this.artistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.Location = new System.Drawing.Point(120, 140);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(41, 18);
            this.artistLabel.TabIndex = 9;
            this.artistLabel.Text = "Artist";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleTextBox.Location = new System.Drawing.Point(167, 49);
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(314, 63);
            this.titleTextBox.TabIndex = 0;
            // 
            // artistTextBox
            // 
            this.artistTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artistTextBox.Location = new System.Drawing.Point(167, 118);
            this.artistTextBox.Multiline = true;
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(314, 63);
            this.artistTextBox.TabIndex = 1;
            // 
            // albumTextBox
            // 
            this.albumTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumTextBox.Location = new System.Drawing.Point(167, 187);
            this.albumTextBox.Multiline = true;
            this.albumTextBox.Name = "albumTextBox";
            this.albumTextBox.Size = new System.Drawing.Size(314, 63);
            this.albumTextBox.TabIndex = 2;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yearTextBox.Location = new System.Drawing.Point(167, 256);
            this.yearTextBox.Multiline = true;
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(314, 63);
            this.yearTextBox.TabIndex = 3;
            // 
            // commentaryTextBox
            // 
            this.commentaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentaryTextBox.Location = new System.Drawing.Point(167, 325);
            this.commentaryTextBox.Multiline = true;
            this.commentaryTextBox.Name = "commentaryTextBox";
            this.commentaryTextBox.Size = new System.Drawing.Size(314, 63);
            this.commentaryTextBox.TabIndex = 4;
            // 
            // genreTextBox
            // 
            this.genreTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genreTextBox.Location = new System.Drawing.Point(167, 394);
            this.genreTextBox.Multiline = true;
            this.genreTextBox.Name = "genreTextBox";
            this.genreTextBox.Size = new System.Drawing.Size(314, 64);
            this.genreTextBox.TabIndex = 5;
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.AutoSize = true;
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Location = new System.Drawing.Point(38, 6);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(123, 37);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "Open MP3 File";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(84, 70);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(77, 20);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Piece title";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.fileNameLabel);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(167, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(314, 40);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Location = new System.Drawing.Point(3, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(236, 40);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "FileName";
            this.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(245, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(61, 37);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Music (.mp3)|*.mp3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "MP3 editor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button saveButton;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Label albumLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label commentaryLabel;
        private System.Windows.Forms.Label genreLabel;

        private System.Windows.Forms.Label titleLabel;

        private System.Windows.Forms.Button openButton;

        private System.Windows.Forms.TextBox genreTextBox;

        private System.Windows.Forms.TextBox commentaryTextBox;

        private System.Windows.Forms.TextBox yearTextBox;

        private System.Windows.Forms.TextBox albumTextBox;

        private System.Windows.Forms.TextBox artistTextBox;

        private System.Windows.Forms.TextBox titleTextBox;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}