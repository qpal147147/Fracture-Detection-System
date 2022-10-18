using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace detectFractureUI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // add mouse wheel event
            imgPictureBox.MouseWheel += imgPictureBox_MouseWheel;
            detectPictureBox.MouseWheel += DetectPictureBox_MouseWheel;
            vScrollBar.Scroll += vScrollBar_Scroll;

            // get conda virtual env
            string condaEnvFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".conda", "environments.txt");
            if (File.Exists(condaEnvFile)) {
                string[] lines= File.ReadAllLines(condaEnvFile);
                foreach(string line in lines) {
                    pythonComboBox.Items.Add(Path.Combine(line, "python.exe"));
                }
            }
        }

        private void pythonComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int index = pythonComboBox.SelectedIndex;
            int itemCount = pythonComboBox.Items.Count;
            if (index == 0) {
                if (python_openFileDialog.ShowDialog() == DialogResult.OK) {
                    string fileName = python_openFileDialog.FileName;
                    pythonComboBox.Items.Add(fileName);

                    if (itemCount > 1) {
                        pythonComboBox.Items.RemoveAt(itemCount - 1);
                    }

                    pythonComboBox.Text = fileName;
                }
            }
            else {
                dicomComboBox.Enabled = true;
            }
            
        }

        List<Image> images = new List<Image>();
        List<Image> detects = new List<Image>();
        private void dicomComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int index = dicomComboBox.SelectedIndex;
            int itemCount = dicomComboBox.Items.Count;
            if (index == 0) {
                if (dicomFolderBrowserDialog.ShowDialog() == DialogResult.OK) {
                    
                    string dcmPath = dicomFolderBrowserDialog.SelectedPath;
                    int dcmNum = getFilesNumber(dcmPath);
                    dicomComboBox.Items.Add(dcmPath);

                    if (itemCount > 1) dicomComboBox.Items.RemoveAt(itemCount - 1);

                    // need to remove images in list when reloading
                    if (images.Count > 0) {
                        imgPictureBox.Image = null;
                        foreach (Bitmap b in images) {
                            b.Dispose();
                        }
                        images.Clear();

                        // reset modules
                        vScrollBar.Maximum = 0;
                        imgPosition.Text = "0/0";
                    }

                    // need to remove detects in list when reloading
                    if (detects.Count > 0) {
                        detectPictureBox.Image = null;
                        foreach (Bitmap b in detects) {
                            b.Dispose();
                        }
                        detects.Clear();
                    }

                    // convert dicom to images
                    if (dcmNum != 0) {
                        dicomComboBox.Text = dcmPath;

                        // activate form2 to run progressbar
                        string pythonCode = string.Format("{0} {1}", "-u", "model/preprocess.py");
                        string args = string.Format("\"{0}\" {1}", dicomComboBox.Text, "--HU");

                        try {
                            Form2 f2 = new Form2(pythonComboBox.Text, pythonCode, args, dcmNum);
                            f2.ShowDialog();

                            // check if user clicked the "X"
                            if (f2.exception != null) throw f2.exception;

                            // load image into imagelist and display on picturebox
                            // if process success run
                            bool run = f2.hasProcessSuccessRun();
                            if (run) {
                                string[] files = Directory.GetFiles("temp/images");
                                foreach (string img in files) {
                                    images.Add(new Bitmap(img));
                                }

                                imgPictureBox.Image = images[0];
                                imgPosition.Text = "1/" + dcmNum;

                                // set vScrollBar and button visibility
                                vScrollBar.Maximum = dcmNum - 1;
                                DetectButton.Enabled = true;
                            }
                            else throw new Exception("Process Failed");
                        }
                        catch (Exception ex){
                            MessageBox.Show(ex.Message, "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DetectButton.Enabled = false;
                        } 
                        
                    }
                    else MessageBox.Show("No dicom files", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void imgPictureBox_MouseWheel(object sender, MouseEventArgs e) {
            int position = images.IndexOf(imgPictureBox.Image);
            if (e.Delta < 0) {
                if (position + 1 < images.Count) {
                    if (detects.Count > 0) detectPictureBox.Image = detects[position + 1];
                    imgPictureBox.Image = images[position + 1];
                    vScrollBar.Value = vScrollBar.Value + 1;
                    imgPosition.Text = position + 2 + "/" + images.Count;
                    
                }
            }
            else {
                if (position - 1 >= 0) {
                    if (detects.Count > 0) detectPictureBox.Image = detects[position - 1];
                    imgPictureBox.Image = images[position - 1];
                    vScrollBar.Value = vScrollBar.Value - 1;
                    imgPosition.Text = position + "/" + images.Count;
                }
            }
        }

        private void DetectPictureBox_MouseWheel(object sender, MouseEventArgs e) {
            int position = images.IndexOf(imgPictureBox.Image);
            if (e.Delta < 0) {
                if (position + 1 < images.Count) {
                    if (detects.Count > 0) detectPictureBox.Image = detects[position + 1];
                    imgPictureBox.Image = images[position + 1];
                    vScrollBar.Value = vScrollBar.Value + 1;
                    imgPosition.Text = position + 2 + "/" + images.Count;
                }
            }
            else {
                if (position - 1 >= 0) {
                    if (detects.Count > 0) detectPictureBox.Image = detects[position - 1];
                    imgPictureBox.Image = images[position - 1];
                    vScrollBar.Value = vScrollBar.Value - 1;
                    imgPosition.Text = position + "/" + images.Count;
                }
            }
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e) {
            if (images.Count > 0) {
                if (detects.Count > 0) detectPictureBox.Image = detects[e.NewValue];
                imgPictureBox.Image = images[e.NewValue];
                imgPosition.Text = (e.NewValue + 1) + "/" + images.Count;
            }
        }

        public int getFilesNumber(string path) {
            string[] files = Directory.GetFiles(path, "*.dcm");
            return files.Length;
        }

        private void DetectButton_Click(object sender, EventArgs e) {
            

            DetectButton.Enabled = false;

            // need to remove images in list when reloading
            if (detects.Count > 0) {
                detectPictureBox.Image = null;
                foreach (Bitmap b in detects) {
                    b.Dispose();
                }
                detects.Clear();
            }

            // call python to run detect
            string pythonCode = string.Format("{0} {1}", "-u", "model/detection.py");
            string args = string.Format("{0} \"{1}\" {2}", "--dicoms", dicomComboBox.Text, "--agnostic-nms");

            try {
                Form2 f2 = new Form2(pythonComboBox.Text, pythonCode, args, images.Count);
                f2.ShowDialog();

                // check if user clicked the "X"
                if (f2.exception != null) throw f2.exception;

                // get detect images and set pitcurebox
                // if process success run
                bool run = f2.hasProcessSuccessRun();
                if (run) {
                    string[] files = Directory.GetFiles("temp/detect/images");
                    Debug.Assert(files.Length > 0);
                    foreach (string detect in files) {
                        detects.Add(new Bitmap(detect));
                    }

                    // set vScrollBar
                    int position = vScrollBar.Value;
                    detectPictureBox.Image = detects[position];
                }
                else throw new Exception("Process Failed");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally {
                DetectButton.Enabled = true;
            }
        }
    }
}
