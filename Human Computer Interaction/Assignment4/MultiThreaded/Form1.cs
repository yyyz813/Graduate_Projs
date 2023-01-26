using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Additional import
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace MultiThreaded
{
    public partial class Form1 : Form
    {
        // 2 strings in use: filename and search phase
        string txtSearch;
        string NameOfFile;

        public Form1()
        {
            InitializeComponent();
            toolLabel.Text = "Hello,please choose the file.";
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Multiselect = false,
                CheckFileExists = true,  //default setting
                CheckPathExists = true,
                DefaultExt = "txt", //Only txt is valid
                Filter = "txt files (*.txt)|*.txt",  
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                txtFileName.Text = file;
            }
        }

        private StreamReader CheckFileExists(string fileName)
        {

            try
            {
                using (StreamReader file = File.OpenText(fileName))
                {
                    return (new StreamReader(fileName));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);  //Return sepecific reason for invalid values
                return null;
            }

        }

        private void fileNameExist(object sender, EventArgs e)
        {
            if (txtInSearch.TextLength > 0 && txtFileName.TextLength > 0)  // if both search and filename not empty, enable search.
            {
                search.Enabled = true;
            }
            else
            {
                search.Enabled = false;
            }
        }

        private void searchTextExist(object sender, EventArgs e)
        {
            if (txtInSearch.TextLength > 0 && txtFileName.TextLength > 0)  //Same to the fileNameExist
            {
                search.Enabled = true;
            }
            else
            {
                search.Enabled = false;
            }
        }

        // Search file for what is in search textbox
        private void search_Click(object sender, EventArgs e)
        {
            // If user clicks on search button, begin search
            if (!bgWorker.IsBusy && search.Text == "Search")
            {
                txtSearch = txtInSearch.Text;
                NameOfFile = txtFileName.Text;
                toolLabel.Text = "Searching for the phase.";

                listView1.Items.Clear();
                bgWorker.RunWorkerAsync();

                search.Text = "Cancel";  // Change the button name to Cancel.User could use it to cancel the search later.
            }

            // If user clicks on cancel button, cancel search
            else if (bgWorker.IsBusy && search.Text == "Cancel")
            {
                toolLabel.Text = "File searching is canceled";
                result.Text = result.Text + " Search canceled.";

                bgWorker.CancelAsync();
                search.Text = "Search";
            }
        }

        //start an asynchronous operation.
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWorker.ReportProgress(0); // The percentage, from 0 

            int count = 0;
            int txtmatched = 0;
            float progress = 0;
            string txtlines;
            var file = CheckFileExists(NameOfFile); // If file not exist,notificate user.
            

            if (file is null)
            {
                MessageBox.Show("Please provide a correct file path.");
                return;
            }

            float sizeOfFile = (new FileInfo(NameOfFile)).Length;
            while ((txtlines = file.ReadLine()) != null) // read each line
            {
                count++;
                Thread.Sleep(1); //put in a pause of 1 millisecond every time you read a line

                bool match = Regex.IsMatch(txtlines, txtSearch, RegexOptions.IgnoreCase); // check match use RE

                if (match)
                {
                    if (listView1.InvokeRequired) //Display in listView
                    {
                        listView1.Invoke((MethodInvoker)delegate ()  //The delegate provides a template defining each item instantiated by the view.
                        {
                            ListViewItem x = new ListViewItem(count.ToString());
                            x.SubItems.Add(txtlines.Trim());
                            listView1.Items.Add(x);
                            listView1.TopItem = listView1.Items[listView1.Items.Count - 1]; // scrolling avaliable.
                        });
                    }
                  
                    // return true if the control handle has created on different thread.
                    if (result.InvokeRequired)  // Update count in result label
                    {
                        result.Invoke((MethodInvoker)delegate ()
                        {
                            txtmatched++;
                            result.Text = txtmatched + " phases found in the file.";
                        });
                    }
                }

                // https://stackoverflow.com/questions/35229751/how-can-i-calculate-percentages-and-report-them-to-backgroundworker
                // progress in backgroundworker is associated to the file size.

                progress = progress + txtlines.Length;
                bgWorker.ReportProgress((int)((progress / sizeOfFile) * 100));

                if (bgWorker.CancellationPending) // If user cancel, then set cancel to True.
                {
                    bgWorker.ReportProgress(0);
                    e.Cancel = true;
                    return;
                }
            }

            bgWorker.ReportProgress(100);  // Otherwise search completed
            file.Close();
        }

        //report the progress of an asynchronous operation to the user.
        private void bgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        //Occurs when the background operation has completed, has been canceled, or has raised an exception.
        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolLabel.Text = "Search Cancelled.";
            }
            else if (e.Error != null)
            {
                toolLabel.Text = e.Error.Message;
            }
            else
            {
                toolLabel.Text = "Searching is completed.";
                search.Text = "Search";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
