
namespace detectFractureUI
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.pythonComboBox = new System.Windows.Forms.ComboBox();
            this.python_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.envGroupBox = new System.Windows.Forms.GroupBox();
            this.dicomComboBox = new System.Windows.Forms.ComboBox();
            this.DicomLabel = new System.Windows.Forms.Label();
            this.imgPosition = new System.Windows.Forms.Label();
            this.dicomFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DetectButton = new System.Windows.Forms.Button();
            this.imageLabel = new System.Windows.Forms.Label();
            this.imgPictureBox = new System.Windows.Forms.PictureBox();
            this.detectLabel = new System.Windows.Forms.Label();
            this.detectPictureBox = new System.Windows.Forms.PictureBox();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.envGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Python interpreter";
            // 
            // pythonComboBox
            // 
            this.pythonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pythonComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pythonComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pythonComboBox.FormattingEnabled = true;
            this.pythonComboBox.Items.AddRange(new object[] {
            "-----Click here to select other path-----"});
            this.pythonComboBox.Location = new System.Drawing.Point(140, 56);
            this.pythonComboBox.Name = "pythonComboBox";
            this.pythonComboBox.Size = new System.Drawing.Size(739, 27);
            this.pythonComboBox.TabIndex = 1;
            this.pythonComboBox.SelectedIndexChanged += new System.EventHandler(this.pythonComboBox_SelectedIndexChanged);
            // 
            // python_openFileDialog
            // 
            this.python_openFileDialog.FileName = "openFileDialog1";
            this.python_openFileDialog.Filter = "python interpreter (*.exe)|*.exe";
            // 
            // envGroupBox
            // 
            this.envGroupBox.Controls.Add(this.dicomComboBox);
            this.envGroupBox.Controls.Add(this.DicomLabel);
            this.envGroupBox.Controls.Add(this.label1);
            this.envGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.envGroupBox.Location = new System.Drawing.Point(12, 25);
            this.envGroupBox.Name = "envGroupBox";
            this.envGroupBox.Size = new System.Drawing.Size(890, 124);
            this.envGroupBox.TabIndex = 2;
            this.envGroupBox.TabStop = false;
            this.envGroupBox.Text = "Environment";
            // 
            // dicomComboBox
            // 
            this.dicomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicomComboBox.Enabled = false;
            this.dicomComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dicomComboBox.FormattingEnabled = true;
            this.dicomComboBox.Items.AddRange(new object[] {
            "-----Click here to select other path-----"});
            this.dicomComboBox.Location = new System.Drawing.Point(128, 87);
            this.dicomComboBox.Name = "dicomComboBox";
            this.dicomComboBox.Size = new System.Drawing.Size(739, 27);
            this.dicomComboBox.TabIndex = 2;
            this.dicomComboBox.SelectedIndexChanged += new System.EventHandler(this.dicomComboBox_SelectedIndexChanged);
            // 
            // DicomLabel
            // 
            this.DicomLabel.AutoSize = true;
            this.DicomLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DicomLabel.Location = new System.Drawing.Point(6, 90);
            this.DicomLabel.Name = "DicomLabel";
            this.DicomLabel.Size = new System.Drawing.Size(79, 19);
            this.DicomLabel.TabIndex = 1;
            this.DicomLabel.Text = "Dicom path";
            // 
            // imgPosition
            // 
            this.imgPosition.AutoSize = true;
            this.imgPosition.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgPosition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.imgPosition.Location = new System.Drawing.Point(56, 699);
            this.imgPosition.Name = "imgPosition";
            this.imgPosition.Size = new System.Drawing.Size(29, 19);
            this.imgPosition.TabIndex = 3;
            this.imgPosition.Text = "0/0";
            // 
            // DetectButton
            // 
            this.DetectButton.Enabled = false;
            this.DetectButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetectButton.Location = new System.Drawing.Point(931, 25);
            this.DetectButton.Name = "DetectButton";
            this.DetectButton.Size = new System.Drawing.Size(172, 124);
            this.DetectButton.TabIndex = 4;
            this.DetectButton.Text = "Detect Fracture";
            this.DetectButton.UseVisualStyleBackColor = true;
            this.DetectButton.Click += new System.EventHandler(this.DetectButton_Click);
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageLabel.Location = new System.Drawing.Point(300, 173);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(46, 19);
            this.imageLabel.TabIndex = 5;
            this.imageLabel.Text = "Image";
            // 
            // imgPictureBox
            // 
            this.imgPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPictureBox.Location = new System.Drawing.Point(53, 209);
            this.imgPictureBox.Name = "imgPictureBox";
            this.imgPictureBox.Size = new System.Drawing.Size(512, 512);
            this.imgPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPictureBox.TabIndex = 6;
            this.imgPictureBox.TabStop = false;
            // 
            // detectLabel
            // 
            this.detectLabel.AutoSize = true;
            this.detectLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detectLabel.Location = new System.Drawing.Point(830, 173);
            this.detectLabel.Name = "detectLabel";
            this.detectLabel.Size = new System.Drawing.Size(49, 19);
            this.detectLabel.TabIndex = 7;
            this.detectLabel.Text = "Detect";
            // 
            // detectPictureBox
            // 
            this.detectPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detectPictureBox.Location = new System.Drawing.Point(591, 209);
            this.detectPictureBox.Name = "detectPictureBox";
            this.detectPictureBox.Size = new System.Drawing.Size(512, 512);
            this.detectPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.detectPictureBox.TabIndex = 8;
            this.detectPictureBox.TabStop = false;
            // 
            // vScrollBar
            // 
            this.vScrollBar.LargeChange = 1;
            this.vScrollBar.Location = new System.Drawing.Point(12, 209);
            this.vScrollBar.Maximum = 0;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(18, 512);
            this.vScrollBar.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1119, 734);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.detectPictureBox);
            this.Controls.Add(this.detectLabel);
            this.Controls.Add(this.imgPosition);
            this.Controls.Add(this.imgPictureBox);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.DetectButton);
            this.Controls.Add(this.pythonComboBox);
            this.Controls.Add(this.envGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Fracture Detection";
            this.envGroupBox.ResumeLayout(false);
            this.envGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pythonComboBox;
        private System.Windows.Forms.OpenFileDialog python_openFileDialog;
        private System.Windows.Forms.GroupBox envGroupBox;
        private System.Windows.Forms.ComboBox dicomComboBox;
        private System.Windows.Forms.Label DicomLabel;
        private System.Windows.Forms.Label imgPosition;
        private System.Windows.Forms.FolderBrowserDialog dicomFolderBrowserDialog;
        private System.Windows.Forms.Button DetectButton;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.PictureBox imgPictureBox;
        private System.Windows.Forms.Label detectLabel;
        private System.Windows.Forms.PictureBox detectPictureBox;
        private System.Windows.Forms.VScrollBar vScrollBar;
    }
}

