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

namespace Wc3ConstantObjects
{
    public partial class MainForm : Form
    {
        string loadPath;
        string savePath;
        string constant;
        public MainForm()
        {
            InitializeComponent();
            string loadSaved = Wc3ConstantObjects.Properties.Settings.Default.LoadDirectory;
            string saveSaved = Wc3ConstantObjects.Properties.Settings.Default.SaveDirectory;
            if (loadSaved != "")
            {
                loadPath = loadSaved;
                textBoxLoad.Text = loadSaved;
            }
            if (saveSaved != "")
            {
                savePath = saveSaved;
                textBoxSave.Text = saveSaved;
            }

        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLoad.Text = openFileDialog.FileName;
                loadPath = openFileDialog.FileName;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
           
            if (loadPath == null)
            {
                ShowError(new Exception("File has not been selected!"));
                return;
            }
            else if (savePath == null)
            {
                ShowError(new Exception("Save file has not been selected!"));
                return;
            }
            Properties.Settings.Default.SaveDirectory = savePath;
            Properties.Settings.Default.LoadDirectory = loadPath;
            Properties.Settings.Default.Save();
            try
            {
                //ReadFile();
                backgroundWorkerReader.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                ShowError(exception);
                progressBarMain.Value = 0;
            }
                   
            


        }

        private void ReadFile()
        {

            List<Wc3Class> wc3Classes = new List<Wc3Class>();
            for(int i = 0; i < checkedListBoxObjects.Items.Count; i++)
            {
                if (checkedListBoxObjects.GetItemChecked(i))
                    wc3Classes.Add(new Wc3Class((Wc3Class.ObjectType)i));
            }
            FileStream fileStream = null;
            StreamReader streamReader = null;
            StreamWriter streamWriter = null;
            try
            {

                fileStream = File.Open(loadPath, FileMode.Open, FileAccess.ReadWrite);
                streamReader = new StreamReader(fileStream);
                string content = streamReader.ReadToEnd();
                streamReader.Close();
                fileStream.Close();

                Converter converter = new Converter(backgroundWorkerReader);
                string constants = converter.ListToFile(converter.CreateWarcraftObjectList(content,wc3Classes,checkBoxAddInitial.Checked,checkBoxRemoveColor.Checked),radioButtonFourCC.Checked);

                fileStream = File.Open(savePath, FileMode.Create, FileAccess.ReadWrite);
                streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(constants);

                streamWriter.Flush();
                streamWriter.Close();

            }
            catch(Exception exception)
            {
                backgroundWorkerChecker.ReportProgress(0, exception);
            }
            finally
            {
                if(fileStream != null)
                    fileStream.Close();
                if(streamReader != null)
                    streamReader.Close();
                if(streamWriter != null)
                {
                    if(streamWriter.BaseStream != null)
                        streamWriter.Flush();
                    streamWriter.Close();
                }
                
            }


        }

        private void ShowError(Exception exception)
        {
            MessageBox.Show(this, "Error: " + exception.Message, "Exception", MessageBoxButtons.OK);
        }

        private void backgroundWorkerReader_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadFile();
        }

        private void backgroundWorkerReader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.UserState != null)
            {
                ShowError((Exception)e.UserState);
                progressBarMain.Value = 0;
            }
            else
                progressBarMain.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                ShowError(e.Error);
                progressBarMain.Value = 0;
            }
            else
            {
                progressBarMain.Value = 100;
                MessageBox.Show("Success!");
            }
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog.FileName;
                textBoxSave.Text = savePath;
            }
        }
    }
}
