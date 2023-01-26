using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//For CultureInfo.InvariantCulture -- Gloalization
//File IO --  IO
using System.Globalization;
using System.IO;

namespace Validation
{
    public partial class Form1 : Form
    {
        // 5 parts of analysis
        int totalRecords;

        double minEnter = 0;
        double avgEnter = 0;
        double maxEnter = 0;

        double minBetween = 0;
        double avgBetween = 0;
        double maxBetween = 0;

        double totalUseTime = 0;
        double totalPress = 0;

        // Assign time value in global
        DateTime[] singleRecordStart = new DateTime[10];
        DateTime[] singleRecordFinish = new DateTime[10];
        double[] singleRecordTotalTime = new double[10];
        double[] timeBetween = new double[10];

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;  //List view grid line setting.
        }

        // Browse file function click
        private void browse_Click(object sender, EventArgs e) 
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.InitialDirectory = @"C:\"; //By default to C: folder

            // Only txt file
            browseFile.Title = "SELECT ANY .txt File";
            //openFileDialog1.Filter = "Access files (*.accdb)|*.accdb|Old Access files (*.mdb)|*.mdb"
            browseFile.Filter = "TEXT Files|*.txt";
            browseFile.FilterIndex = 2;
            browseFile.RestoreDirectory = true;
            if (browseFile.ShowDialog() == DialogResult.OK)
                filePath.Text = browseFile.FileName; //show in txtbox
        }

        // Evaluation function on click
        private void evaluation_Click(object sender, EventArgs e)
        {
            cleanView();
            readFile(filePath.Text);

            singleRecordTimeCal();
            singleRecordBetweenTimeCal();

            showListView(filePath.Text);
            showTxtBox();

            storeIn_File();
        }


        // Clear the form on button click
        private void clear_Click(object sender, EventArgs e)
        {
            cleanView();
            cleanForm(this);
        }

        // Clear the list view
        private void cleanView()
        {
            minEnter = 0;
            maxEnter = 0;
            minBetween = 0;
            maxBetween = 0;
            avgEnter = 0;
            avgBetween = 0;
            totalUseTime = 0;
            totalPress = 0;
            totalRecords = 0;

            // Clear Array
            Array.Clear(singleRecordTotalTime, 0, singleRecordTotalTime.Length);
            Array.Clear(timeBetween, 0, timeBetween.Length);
            Array.Clear(singleRecordStart, 0, singleRecordStart.Length);
            Array.Clear(singleRecordFinish, 0, singleRecordFinish.Length);

            listView1.Items.Clear();
        }

        // Clean the form
        private void cleanForm(Control control)
        {
            foreach (Control i in control.Controls)
            {
                if (i is TextBox)
                    ((TextBox)i).Clear();
                else
                    cleanForm(i);
            }
        }


        // Calculate time sum
        double sumTime (double[] time)
        {
            double sum = 0;
            for (int i = 0; i < time.Length; i++)
                sum += time[i];
            return sum;
        }

        // Calculate time average
        double avgTime (double[] time)
        {
            double sum = sumTime(time);
            double i = sum / time.Length;
            return i;
        }

        // Calculate enter time by a record
        void singleRecordTimeCal()
        {
            int i = 0;
            while ((i < totalRecords) && (i < singleRecordStart.Length))
            {
                //Substract between time in single record
                singleRecordTotalTime[i] = singleRecordFinish[i].Subtract(singleRecordStart[i]).TotalSeconds;
                totalUseTime = totalUseTime+singleRecordTotalTime[i];
                i++;
            }
            // Store each values
            maxEnter = singleRecordTotalTime.Max();
            minEnter = singleRecordTotalTime.Min();
            avgEnter = avgTime(singleRecordTotalTime);
        }

        // Calculate between time by a record
        void singleRecordBetweenTimeCal()
        {
            int i = 0;

            while ((i < totalRecords) && (i < (singleRecordStart.Length - 1)))
            {
                //substract time between, for example record 1 finish time and record 2 start time
                timeBetween[i] = singleRecordStart[i + 1].Subtract(singleRecordFinish[i]).TotalSeconds;
                totalUseTime = totalUseTime+timeBetween[i];
                i++;
            }
            // Store each values
            maxBetween = timeBetween.Max();
            minBetween = timeBetween.Min();
            avgBetween = avgTime(timeBetween);
        }

        // read file
        private void readFile(string a2File)
        {
            try
            {
                StreamReader fileContent = new StreamReader(a2File, true);
                int i = 0;
                string info;

                // loop through each file content and store in different array.
                while ((info = fileContent.ReadLine()) != null)
                {
                    string[] bucket = info.Split('\t');
                    DateTime startTime = DateTime.ParseExact(bucket[14], "HH:mm:ss", CultureInfo.InvariantCulture); //mm:ss format
                    DateTime endTime = DateTime.ParseExact(bucket[15], "HH:mm:ss", CultureInfo.InvariantCulture);

                    singleRecordStart[i] = startTime;
                    singleRecordFinish[i] = endTime;
                    totalPress += Convert.ToInt32(bucket[16]);
                    i++; //record counts from 0
                }
                fileContent.Close();
                totalRecords = i;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);  //Return sepecific reason for invalid values
            }
        }

        // show grid area in list view
        private void showListView(string a2File)
        {
            if (File.Exists(a2File))
            {
                StreamReader fileContent= new StreamReader(a2File, true);
                int i = 0;
                string info;

                while ((info = fileContent.ReadLine()) != null)
                {
                    try
                    {
                        string[] bucket = info.Split('\t');
                        string[] listArray = new string[3];

                        // Display name,time and press count on listview
                        listArray[0] = bucket[1] + " " + bucket[3] + " " + bucket[2];
                        listArray[1] = TimeSpan.FromSeconds(singleRecordTotalTime[i]).ToString(@"mm\:ss");
                        listArray[2] = bucket[16];

                        ListViewItem list = new ListViewItem(listArray);
                        list.Tag = bucket[0];
                        listView1.Items.Add(list);
                        i++;
                    }
                    catch (Exception e)
                    {
                        fileContent.Close();
                        MessageBox.Show(e.Message); // Show specific error if file content or type wrong.
                        return;
                    }
                }
                fileContent.Close();
            }
        }

        // show values in textbox for each measure values
        private void showTxtBox()
        {
            textRecords.Text = Convert.ToString(totalRecords);

            textMinEnter.Text = TimeSpan.FromSeconds(minEnter).ToString(@"mm\:ss");
            textAvgEnter.Text = TimeSpan.FromSeconds(avgEnter).ToString(@"mm\:ss");
            textMaxEnter.Text = TimeSpan.FromSeconds(maxEnter).ToString(@"mm\:ss");

            textMinFinish.Text = TimeSpan.FromSeconds(minBetween).ToString(@"mm\:ss");
            textAvgFinish.Text = TimeSpan.FromSeconds(avgBetween).ToString(@"mm\:ss");
            textMaxFinish.Text = TimeSpan.FromSeconds(maxBetween).ToString(@"mm\:ss");
            
            textTotalTime.Text = TimeSpan.FromSeconds(totalUseTime).ToString(@"mm\:ss");
            textNumberPress.Text = Convert.ToString(totalPress);
        }

        // write results to file.
        private void storeIn_File()
        {
            StreamWriter writeFile = new System.IO.StreamWriter("CS6326Asg3.txt", false);
            writeFile.WriteLine("Number of records: " + textRecords.Text);

            writeFile.WriteLine("Minimum entry time: " + textMinEnter.Text);
            writeFile.WriteLine("Maximum entry time: " + textMaxEnter.Text);
            writeFile.WriteLine("Average entry time: " + textAvgEnter.Text);

            writeFile.WriteLine("Minimum inter-record time: " + textMinFinish.Text);
            writeFile.WriteLine("Maximum inter-record time: " + textMaxFinish.Text);
            writeFile.WriteLine("Average inter-record time: " + textAvgFinish.Text);

            writeFile.WriteLine("Total time: " + textTotalTime.Text);
            writeFile.WriteLine("Backspace Count: " + textNumberPress.Text);
            writeFile.Close();
        }
    }
}
