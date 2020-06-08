using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace minecraft_ppmtomap
{
    public partial class Form1 : Form
    {
        bool fileok;
        int progressFile = 0;
        int progressBatch = 0;
        int progressFileMax = 0;
        int progressBatchMax = 0;
        BackgroundWorker worker1;

        public Form1()
        {
            InitializeComponent();

            worker1 = new BackgroundWorker();
            worker1.DoWork += new DoWorkEventHandler(worker1_DoWork);
            worker1.ProgressChanged += new ProgressChangedEventHandler(worker1_ProgressChanged);
            worker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker1_RunWorkCompleted);
            worker1.WorkerReportsProgress = true;
            worker1.WorkerSupportsCancellation = true;
        }

        void worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (checkBox_batch.Checked)
            {
                DirectoryInfo info = new DirectoryInfo(folderBrowserDialog_open.SelectedPath);
                progressBatchMax = info.GetFiles("*.ppm").Length;
                worker1.ReportProgress(0);//update progress bars

                foreach (var file in info.GetFiles("*.ppm"))
                {
                    if (worker1.CancellationPending)
                    {
                        e.Cancel = true;
                        progressBatch = 0;
                        progressFile = 0;
                        worker1.ReportProgress(0);
                        return;
                    }
                    globalvars.pathOpen = folderBrowserDialog_open.SelectedPath + @"\" + file.Name;
                    globalvars.pathSave = folderBrowserDialog_save.SelectedPath + @"\" + file.Name.Remove(file.Name.Length - 4);
                    globalvars.pathSaveLockedMap = folderBrowserDialog_save.SelectedPath + @"\map";
                    start_convert();
                    progressBatch++;
                    worker1.ReportProgress(0);
                }

                progressBatch = 0;
                worker1.ReportProgress(0);
                globalvars.startMap = int.Parse(textBox_startMap.Text);
                MessageBox.Show("Feddisch.");
            }
            else
            {
                globalvars.pathOpen = openFileDialog1.FileName;
                globalvars.pathSave = saveFileDialog1.FileName;
                globalvars.pathSaveLockedMap = saveFileDialog1.FileName;
                start_convert();
            }
        }

        void worker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarBatch.Maximum = progressBatchMax;
            progressBarBatch.Value = progressBatch;
            progressBarFile.Maximum = progressFileMax;
            progressBarFile.Value = progressFile;
        }

        void worker1_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Abgebrochen.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Fehler: Kacke dampft!");
            }

            convert.Enabled = true;
            convert_stop.Enabled = false;

            checkBox_batch.Enabled = true;
            checkBox_schematic.Enabled = true;
            checkBox_commandBlock.Enabled = true;
            checkBox_lockedMap.Enabled = true;
            textBox_y_start.ReadOnly = false;
            textBox_h_max.ReadOnly = false;
            textBox_startMap.ReadOnly = false;
            openfile.Enabled = true;
            save_path.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {                      
            textBox_y_start.Text = globalvars.y_start.ToString();
            textBox_h_max.Text = globalvars.h_max.ToString();
            
            colorcalc();

            //quatsch
            globalvars.checkBox_x_og = checkBox1.Location.X;
            globalvars.checkBox_y_og = checkBox1.Location.Y;
        }

        private void button1_Click(object sender, EventArgs e)//open file
        {
            try
            {
                fileok = true;
               
                if (checkBox_batch.Checked)
                {
                    folderBrowserDialog_open.ShowDialog();
                    textBox_open.Text = folderBrowserDialog_open.SelectedPath;
                }
                else
                {
                    openFileDialog1.ShowDialog();
                    openFileDialog1.Dispose();
                    textBox_open.Text = openFileDialog1.FileName;                   
                }
            }
            catch
            {
                fileok = false;
            }           
        }

        private void save_path_Click(object sender, EventArgs e)
        {
            if (checkBox_batch.Checked)
            {
                folderBrowserDialog_save.ShowDialog();
                textBox_save.Text = folderBrowserDialog_save.SelectedPath;
            }
            else
            {
                saveFileDialog1.ShowDialog();
                textBox_save.Text = saveFileDialog1.FileName;
            }
        }

        private void convert_Click(object sender, EventArgs e)
        {
            convert.Enabled = false;
            convert_stop.Enabled = true;

            checkBox_batch.Enabled = false;
            checkBox_schematic.Enabled = false;
            checkBox_commandBlock.Enabled = false;
            checkBox_lockedMap.Enabled = false;
            textBox_y_start.ReadOnly = true;
            textBox_h_max.ReadOnly = true;
            textBox_startMap.ReadOnly = true;
            openfile.Enabled = false;
            save_path.Enabled = false;

            worker1.RunWorkerAsync();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                globalvars.quatsch_count++;
                Random rnd = new Random();
                checkBox1.CheckState = CheckState.Unchecked;
                int x = rnd.Next(-80, 120) + globalvars.checkBox_x_og;
                int y = rnd.Next(-50, 20) + globalvars.checkBox_y_og;              
                this.checkBox1.Location = new Point(x, y);
                checkBox1.Text = globalvars.quatsch[rnd.Next(globalvars.quatsch.Length)];
                
                if (globalvars.quatsch_count == 21)
                {
                    MessageBox.Show("lassen Spiel");
                    Application.Exit();
                }
            }
        }

        private void convert_stop_Click(object sender, EventArgs e)
        {
            if (worker1.IsBusy)
            {
                worker1.CancelAsync();
            }
        }

        private void textBox_lastMap_TextChanged(object sender, EventArgs e)
        {
            globalvars.startMap = int.Parse(textBox_startMap.Text);
        }

        private void idcounts_Click(object sender, EventArgs e)
        {
            idcountsgen();
        }
    }
}