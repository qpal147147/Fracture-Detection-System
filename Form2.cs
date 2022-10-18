using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace detectFractureUI {
    public partial class Form2 : Form {
        int dcmNum = 0; // record total of dicom file
        StringBuilder sb_error = new StringBuilder(); // record error messenge
        public Exception exception = null; // accept form exception

        public Form2(string pythonPath, string pythonCode, string args, int total) {
            InitializeComponent();
            runPython(pythonPath, pythonCode, args, total);
        }

        public void runPython(string pythonPath, string pythonCode, string args, int total) {
            dcmNum = total;
            loadProgressBar.Maximum = total;
            loadLabel.Text = "0/" + total;

            // call python to run preprocess
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = pythonCode + " " + args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
            process.OutputDataReceived += new DataReceivedEventHandler(dataReceived);
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_Exited);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        public void process_Exited(object sender, EventArgs e) {
            Thread.Sleep(500);

            string error = sb_error.ToString();
            if (error.IndexOf("Traceback") != -1 && error.Trim() != "") {
                MessageBox.Show(sb_error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // if call invoke after form closed
            try {
                Invoke(new Action(() => Close()));
            }
            catch { }
        }

        void process_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
            sb_error.AppendLine(e.Data);
        }

        public void dataReceived(object sender, DataReceivedEventArgs e) {
            if (e.Data != null) {
                int val = 0;
                bool isNumeric = int.TryParse(e.Data, out val);
                if (isNumeric) {
                    // if call invoke after form closed
                    try {
                        Invoke(new Action(() => setProgressBar(val)));
                        Invoke(new Action(() => setLoadLabel(val, dcmNum)));
                    }
                    catch { }
                }
            }
        }

        public bool hasProcessSuccessRun() {
            string error = sb_error.ToString();
            if (error.Trim() == "" || error.IndexOf("Traceback") == -1) return true;
            else return false;
        }

        public void setProgressBar(int value) {
            loadProgressBar.Value = value;
        }

        public void setLoadLabel(int value, int total) {
            loadLabel.Text = value + "/" + total;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) {
            // Closed by X or Alt+F4
            if (!(new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))) {
                try {
                    throw new Exception("Process Failed");
                }
                catch (Exception ex){
                    exception = ex;
                }
            }
                
        }
    }
}
