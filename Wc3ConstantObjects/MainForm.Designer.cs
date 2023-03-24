
namespace Wc3ConstantObjects
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxLoad = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorkerReader = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerChecker = new System.ComponentModel.BackgroundWorker();
            this.textBoxSave = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.checkedListBoxObjects = new System.Windows.Forms.CheckedListBox();
            this.checkBoxAddInitial = new System.Windows.Forms.CheckBox();
            this.radioButtonFourCC = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.checkBoxRemoveColor = new System.Windows.Forms.CheckBox();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxDuplicate = new System.Windows.Forms.CheckBox();
            this.progressBarThreads = new System.Windows.Forms.ProgressBar();
            this.groupBoxOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.Navy;
            this.buttonLoad.FlatAppearance.BorderSize = 0;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonLoad.Location = new System.Drawing.Point(248, 9);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.toolTipMain.SetToolTip(this.buttonLoad, "Warcraft String File");
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Navy;
            this.buttonStart.FlatAppearance.BorderSize = 0;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(248, 176);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.toolTipMain.SetToolTip(this.buttonStart, "Create variables based on your warcraft string file!");
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxLoad
            // 
            this.textBoxLoad.AllowDrop = true;
            this.textBoxLoad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLoad.Location = new System.Drawing.Point(12, 14);
            this.textBoxLoad.Name = "textBoxLoad";
            this.textBoxLoad.ReadOnly = true;
            this.textBoxLoad.Size = new System.Drawing.Size(230, 13);
            this.textBoxLoad.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "wts";
            this.openFileDialog.FileName = "war3map";
            this.openFileDialog.Filter = "Warcraft String| *.wts";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Choose file";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "ts";
            this.saveFileDialog.FileName = "ObjectConstants";
            this.saveFileDialog.Filter = "typescript| *ts";
            // 
            // backgroundWorkerReader
            // 
            this.backgroundWorkerReader.WorkerReportsProgress = true;
            this.backgroundWorkerReader.WorkerSupportsCancellation = true;
            this.backgroundWorkerReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReader_DoWork);
            this.backgroundWorkerReader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerReader_ProgressChanged);
            this.backgroundWorkerReader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReader_RunWorkerCompleted);
            // 
            // backgroundWorkerChecker
            // 
            this.backgroundWorkerChecker.WorkerReportsProgress = true;
            this.backgroundWorkerChecker.WorkerSupportsCancellation = true;
            // 
            // textBoxSave
            // 
            this.textBoxSave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSave.Location = new System.Drawing.Point(12, 41);
            this.textBoxSave.Name = "textBoxSave";
            this.textBoxSave.ReadOnly = true;
            this.textBoxSave.Size = new System.Drawing.Size(230, 13);
            this.textBoxSave.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Navy;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSave.Location = new System.Drawing.Point(248, 36);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.toolTipMain.SetToolTip(this.buttonSave, "Save File");
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(12, 175);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(230, 11);
            this.progressBarMain.TabIndex = 9;
            // 
            // checkedListBoxObjects
            // 
            this.checkedListBoxObjects.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.checkedListBoxObjects.CheckOnClick = true;
            this.checkedListBoxObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checkedListBoxObjects.FormattingEnabled = true;
            this.checkedListBoxObjects.Items.AddRange(new object[] {
            "Unit",
            "Item",
            "Destructible",
            "Doodad",
            "Ability",
            "Buff/Effect",
            "Upgrade"});
            this.checkedListBoxObjects.Location = new System.Drawing.Point(12, 60);
            this.checkedListBoxObjects.Name = "checkedListBoxObjects";
            this.checkedListBoxObjects.Size = new System.Drawing.Size(120, 109);
            this.checkedListBoxObjects.TabIndex = 4;
            this.toolTipMain.SetToolTip(this.checkedListBoxObjects, "Which objects do you want?");
            // 
            // checkBoxAddInitial
            // 
            this.checkBoxAddInitial.AutoSize = true;
            this.checkBoxAddInitial.Location = new System.Drawing.Point(138, 60);
            this.checkBoxAddInitial.Name = "checkBoxAddInitial";
            this.checkBoxAddInitial.Size = new System.Drawing.Size(72, 17);
            this.checkBoxAddInitial.TabIndex = 5;
            this.checkBoxAddInitial.Text = "Add Initial";
            this.toolTipMain.SetToolTip(this.checkBoxAddInitial, "example: ability named Bash will be abBash");
            this.checkBoxAddInitial.UseVisualStyleBackColor = true;
            // 
            // radioButtonFourCC
            // 
            this.radioButtonFourCC.AutoSize = true;
            this.radioButtonFourCC.Location = new System.Drawing.Point(5, 42);
            this.radioButtonFourCC.Name = "radioButtonFourCC";
            this.radioButtonFourCC.Size = new System.Drawing.Size(88, 17);
            this.radioButtonFourCC.TabIndex = 8;
            this.radioButtonFourCC.Text = "Four Code ID";
            this.radioButtonFourCC.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(5, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Name";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.radioButtonFourCC);
            this.groupBoxOrder.Controls.Add(this.radioButton2);
            this.groupBoxOrder.Location = new System.Drawing.Point(248, 65);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(99, 100);
            this.groupBoxOrder.TabIndex = 6;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "Order By";
            // 
            // checkBoxRemoveColor
            // 
            this.checkBoxRemoveColor.AutoSize = true;
            this.checkBoxRemoveColor.Checked = true;
            this.checkBoxRemoveColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRemoveColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.checkBoxRemoveColor.Location = new System.Drawing.Point(138, 83);
            this.checkBoxRemoveColor.Name = "checkBoxRemoveColor";
            this.checkBoxRemoveColor.Size = new System.Drawing.Size(108, 16);
            this.checkBoxRemoveColor.TabIndex = 11;
            this.checkBoxRemoveColor.Text = "Remove Color Code";
            this.toolTipMain.SetToolTip(this.checkBoxRemoveColor, "Removes argb letters");
            this.checkBoxRemoveColor.UseVisualStyleBackColor = true;
            // 
            // toolTipMain
            // 
            this.toolTipMain.AutomaticDelay = 200;
            this.toolTipMain.ToolTipTitle = "?";
            // 
            // checkBoxDuplicate
            // 
            this.checkBoxDuplicate.AutoSize = true;
            this.checkBoxDuplicate.Checked = true;
            this.checkBoxDuplicate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDuplicate.Location = new System.Drawing.Point(138, 105);
            this.checkBoxDuplicate.Name = "checkBoxDuplicate";
            this.checkBoxDuplicate.Size = new System.Drawing.Size(92, 17);
            this.checkBoxDuplicate.TabIndex = 12;
            this.checkBoxDuplicate.Text = "Fix Duplicates";
            this.toolTipMain.SetToolTip(this.checkBoxDuplicate, "Tries to rename duplicates using editor suffix and fourcc id");
            this.checkBoxDuplicate.UseVisualStyleBackColor = true;
            // 
            // progressBarThreads
            // 
            this.progressBarThreads.Location = new System.Drawing.Point(12, 188);
            this.progressBarThreads.Name = "progressBarThreads";
            this.progressBarThreads.Size = new System.Drawing.Size(230, 11);
            this.progressBarThreads.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(348, 236);
            this.Controls.Add(this.progressBarThreads);
            this.Controls.Add(this.checkBoxDuplicate);
            this.Controls.Add(this.checkBoxRemoveColor);
            this.Controls.Add(this.groupBoxOrder);
            this.Controls.Add(this.checkBoxAddInitial);
            this.Controls.Add(this.checkedListBoxObjects);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSave);
            this.Controls.Add(this.textBoxLoad);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonLoad);
            this.MaximumSize = new System.Drawing.Size(375, 275);
            this.MinimumSize = new System.Drawing.Size(350, 250);
            this.Name = "MainForm";
            this.Text = "Warcraft Objects Converter ";
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReader;
        private System.ComponentModel.BackgroundWorker backgroundWorkerChecker;
        private System.Windows.Forms.TextBox textBoxSave;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.CheckedListBox checkedListBoxObjects;
        private System.Windows.Forms.CheckBox checkBoxAddInitial;
        private System.Windows.Forms.RadioButton radioButtonFourCC;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.CheckBox checkBoxRemoveColor;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.CheckBox checkBoxDuplicate;
        private System.Windows.Forms.ProgressBar progressBarThreads;
    }
}

