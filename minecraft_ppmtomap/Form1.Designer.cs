namespace minecraft_ppmtomap
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openfile = new System.Windows.Forms.Button();
            this.convert = new System.Windows.Forms.Button();
            this.save_path = new System.Windows.Forms.Button();
            this.textBox_open = new System.Windows.Forms.TextBox();
            this.textBox_save = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_y_start = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox_h_max = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_schematic = new System.Windows.Forms.CheckBox();
            this.checkBox_batch = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog_open = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog_save = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.progressBarFile = new System.Windows.Forms.ProgressBar();
            this.progressBarBatch = new System.Windows.Forms.ProgressBar();
            this.convert_stop = new System.Windows.Forms.Button();
            this.checkBox_lockedMap = new System.Windows.Forms.CheckBox();
            this.checkBox_commandBlock = new System.Windows.Forms.CheckBox();
            this.textBox_startMap = new System.Windows.Forms.TextBox();
            this.idcounts = new System.Windows.Forms.Button();
            this.textBox_idcounts = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "output";
            this.openFileDialog1.Filter = "PPM (*.ppm)|*.ppm";
            // 
            // openfile
            // 
            this.openfile.Location = new System.Drawing.Point(12, 34);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(75, 22);
            this.openfile.TabIndex = 0;
            this.openfile.Text = "open file";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.button1_Click);
            // 
            // convert
            // 
            this.convert.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convert.Location = new System.Drawing.Point(12, 227);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(600, 42);
            this.convert.TabIndex = 1;
            this.convert.Text = "sachen machen";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // save_path
            // 
            this.save_path.Location = new System.Drawing.Point(12, 62);
            this.save_path.Name = "save_path";
            this.save_path.Size = new System.Drawing.Size(75, 22);
            this.save_path.TabIndex = 2;
            this.save_path.Text = "save path";
            this.save_path.UseVisualStyleBackColor = true;
            this.save_path.Click += new System.EventHandler(this.save_path_Click);
            // 
            // textBox_open
            // 
            this.textBox_open.Location = new System.Drawing.Point(95, 35);
            this.textBox_open.Name = "textBox_open";
            this.textBox_open.ReadOnly = true;
            this.textBox_open.Size = new System.Drawing.Size(500, 20);
            this.textBox_open.TabIndex = 3;
            // 
            // textBox_save
            // 
            this.textBox_save.Location = new System.Drawing.Point(95, 63);
            this.textBox_save.Name = "textBox_save";
            this.textBox_save.ReadOnly = true;
            this.textBox_save.Size = new System.Drawing.Size(500, 20);
            this.textBox_save.TabIndex = 4;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "output";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(62, 19);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Y start:";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_y_start
            // 
            this.textBox_y_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_y_start.Location = new System.Drawing.Point(71, 3);
            this.textBox_y_start.MaxLength = 3;
            this.textBox_y_start.Name = "textBox_y_start";
            this.textBox_y_start.Size = new System.Drawing.Size(39, 20);
            this.textBox_y_start.TabIndex = 6;
            this.textBox_y_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(3, 28);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(62, 19);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "h max:";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_h_max
            // 
            this.textBox_h_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_h_max.Location = new System.Drawing.Point(71, 28);
            this.textBox_h_max.MaxLength = 3;
            this.textBox_h_max.Name = "textBox_h_max";
            this.textBox_h_max.Size = new System.Drawing.Size(39, 20);
            this.textBox_h_max.TabIndex = 8;
            this.textBox_h_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_y_start, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_h_max, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 171);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(113, 50);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // checkBox_schematic
            // 
            this.checkBox_schematic.AutoSize = true;
            this.checkBox_schematic.Location = new System.Drawing.Point(12, 113);
            this.checkBox_schematic.Name = "checkBox_schematic";
            this.checkBox_schematic.Size = new System.Drawing.Size(76, 17);
            this.checkBox_schematic.TabIndex = 11;
            this.checkBox_schematic.Text = "Schematic";
            this.checkBox_schematic.UseVisualStyleBackColor = true;
            // 
            // checkBox_batch
            // 
            this.checkBox_batch.AutoSize = true;
            this.checkBox_batch.Location = new System.Drawing.Point(12, 12);
            this.checkBox_batch.Name = "checkBox_batch";
            this.checkBox_batch.Size = new System.Drawing.Size(219, 17);
            this.checkBox_batch.TabIndex = 12;
            this.checkBox_batch.Text = "batch mode (Der gaaaaaanze Ordner, ja)";
            this.checkBox_batch.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(280, 147);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "<- Nein.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // progressBarFile
            // 
            this.progressBarFile.Location = new System.Drawing.Point(237, 11);
            this.progressBarFile.Name = "progressBarFile";
            this.progressBarFile.Size = new System.Drawing.Size(100, 18);
            this.progressBarFile.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarFile.TabIndex = 14;
            // 
            // progressBarBatch
            // 
            this.progressBarBatch.Location = new System.Drawing.Point(343, 11);
            this.progressBarBatch.Name = "progressBarBatch";
            this.progressBarBatch.Size = new System.Drawing.Size(100, 18);
            this.progressBarBatch.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarBatch.TabIndex = 15;
            // 
            // convert_stop
            // 
            this.convert_stop.Enabled = false;
            this.convert_stop.Location = new System.Drawing.Point(537, 199);
            this.convert_stop.Name = "convert_stop";
            this.convert_stop.Size = new System.Drawing.Size(75, 23);
            this.convert_stop.TabIndex = 16;
            this.convert_stop.Text = "STOP";
            this.convert_stop.UseVisualStyleBackColor = true;
            this.convert_stop.Click += new System.EventHandler(this.convert_stop_Click);
            // 
            // checkBox_lockedMap
            // 
            this.checkBox_lockedMap.AutoSize = true;
            this.checkBox_lockedMap.Location = new System.Drawing.Point(12, 136);
            this.checkBox_lockedMap.Name = "checkBox_lockedMap";
            this.checkBox_lockedMap.Size = new System.Drawing.Size(141, 17);
            this.checkBox_lockedMap.TabIndex = 17;
            this.checkBox_lockedMap.Text = "Locked map, start map#";
            this.checkBox_lockedMap.UseVisualStyleBackColor = true;
            // 
            // checkBox_commandBlock
            // 
            this.checkBox_commandBlock.AutoSize = true;
            this.checkBox_commandBlock.Location = new System.Drawing.Point(12, 90);
            this.checkBox_commandBlock.Name = "checkBox_commandBlock";
            this.checkBox_commandBlock.Size = new System.Drawing.Size(103, 17);
            this.checkBox_commandBlock.TabIndex = 18;
            this.checkBox_commandBlock.Text = "Command Block";
            this.checkBox_commandBlock.UseVisualStyleBackColor = true;
            // 
            // textBox_startMap
            // 
            this.textBox_startMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_startMap.Location = new System.Drawing.Point(147, 134);
            this.textBox_startMap.MaxLength = 5;
            this.textBox_startMap.Name = "textBox_startMap";
            this.textBox_startMap.Size = new System.Drawing.Size(40, 20);
            this.textBox_startMap.TabIndex = 19;
            this.textBox_startMap.Text = "0";
            this.textBox_startMap.TextChanged += new System.EventHandler(this.textBox_lastMap_TextChanged);
            // 
            // idcounts
            // 
            this.idcounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idcounts.Location = new System.Drawing.Point(128, 199);
            this.idcounts.Name = "idcounts";
            this.idcounts.Size = new System.Drawing.Size(88, 20);
            this.idcounts.TabIndex = 20;
            this.idcounts.Text = "idcounts.dat: #";
            this.idcounts.UseVisualStyleBackColor = true;
            this.idcounts.Click += new System.EventHandler(this.idcounts_Click);
            // 
            // textBox_idcounts
            // 
            this.textBox_idcounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idcounts.Location = new System.Drawing.Point(217, 199);
            this.textBox_idcounts.MaxLength = 5;
            this.textBox_idcounts.Name = "textBox_idcounts";
            this.textBox_idcounts.Size = new System.Drawing.Size(40, 20);
            this.textBox_idcounts.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.textBox_idcounts);
            this.Controls.Add(this.idcounts);
            this.Controls.Add(this.textBox_startMap);
            this.Controls.Add(this.checkBox_commandBlock);
            this.Controls.Add(this.checkBox_lockedMap);
            this.Controls.Add(this.convert_stop);
            this.Controls.Add(this.progressBarBatch);
            this.Controls.Add(this.progressBarFile);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox_batch);
            this.Controls.Add(this.checkBox_schematic);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBox_save);
            this.Controls.Add(this.textBox_open);
            this.Controls.Add(this.save_path);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.openfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Minecraft Map Map Generator 2000";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openfile;
        private System.Windows.Forms.Button convert;
        private System.Windows.Forms.Button save_path;
        private System.Windows.Forms.TextBox textBox_open;
        private System.Windows.Forms.TextBox textBox_save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_y_start;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox_h_max;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_schematic;
        private System.Windows.Forms.CheckBox checkBox_batch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_open;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_save;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ProgressBar progressBarFile;
        private System.Windows.Forms.ProgressBar progressBarBatch;
        private System.Windows.Forms.Button convert_stop;
        private System.Windows.Forms.CheckBox checkBox_lockedMap;
        private System.Windows.Forms.CheckBox checkBox_commandBlock;
        private System.Windows.Forms.TextBox textBox_startMap;
        private System.Windows.Forms.Button idcounts;
        private System.Windows.Forms.TextBox textBox_idcounts;
    }
}

