using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Add RE configuration.
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

namespace Asg2_yxz157830
{
    public partial class Form1 : Form
    {
        int lineCount = 1;
        int columnSort = -1;
        int bKeyPress = 0; 

        public Form1()
        {
            //InitializeDates();
            InitializeComponent();
            this.Load += Form1_Load;
            
        }

        /*
        public void InitializeDates()  // Start Time Showing
        {
            var today = DateTime.Today.ToString("dd/MM/yyyy");
            startTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        */

        // Icomparer reference -microsoft.com
        class ListViewItemComparer : IComparer
        {
            private int column;
            private SortOrder sort;

            public ListViewItemComparer()
            {
                column = 0;
                sort = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                this.column = column;
                this.sort = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal;
                returnVal = String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
                if (sort == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //To be displayed on form load
            Add.Enabled = false;

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("ID", 0);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Phone", 100);

            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "MM/dd/yyyy";
            timePicker.Value = DateTime.Today;

            // Select date within the range. 5 days
            timePicker.MinDate = DateTime.Today.AddDays(-2);
            timePicker.MaxDate = DateTime.Today.AddDays(2);

            reStartForm();

        }

        // Validating the inputs
        void validate()
        {
            // emial check.
            Regex reg = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            // AddressLine2 and Initial are not required.
            if (!string.IsNullOrEmpty(firstName.Text) && !string.IsNullOrEmpty(lastName.Text) && !string.IsNullOrEmpty(richAddress1.Text) && !string.IsNullOrEmpty(ct.Text) && !string.IsNullOrEmpty(st.Text) && !string.IsNullOrEmpty(zip.Text) && !string.IsNullOrEmpty(gender.Text) && !string.IsNullOrEmpty(phone.Text) && !string.IsNullOrEmpty(email.Text) && reg.IsMatch(email.Text) && (yes.Checked || no.Checked))
            {
                Add.Enabled = true;
            }
            else
                Add.Enabled = false;

        }


        private void firstName_TextChanged(object sender, EventArgs e)
        {
            // start time to fill the form.
            startTime.Text = DateTime.Now.ToString("HH:mm:ss");
            validate();

        }

        private void lastName_TextChanged(object sender, EventArgs e)
        {
            
            validate();
        }

        private void richAddress1_TextChanged(object sender, EventArgs e) // Address2 can be add or ignored.
        {    
            validate();
        }

        private void ct_TextChanged(object sender, EventArgs e)
        {
            
            validate();
        }

        private void st_TextChanged(object sender, EventArgs e)
        {
            
            validate();
        }

        private void zip_TextChanged(object sender, EventArgs e)
        {
            validate();
            if ((zip.Text.Length < 10))
                errZip.Clear();
            else
                errZip.SetError(zip, "9 Digits Zip");
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {    
            validate();
        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
            validate();
            Regex reg = new Regex(@"^(\+[0-9])$");  // Rex phone number validation.

            if ((phone.Text.Length > 6))
            {  
                if (Regex.Match(phone.Text, @"^(\+?[0-9]*)$").Success)
                    errPhone.Clear();
                else
                    errPhone.SetError(phone, "Wrong Phone Format");
            }
            else
                errPhone.SetError(phone, " 10 digits Phone Number.");
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            validate();
            Regex reg = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

            if ((email.Text.Length < 60))
            {
                if (Regex.Match(email.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$").Success)
                    errEmail.Clear();
                else
                    errEmail.SetError(email, "Invalid Email Address.");
            }
            else
                errEmail.SetError(email, "Excess The Total Length.");

        }

        private void yes_CheckedChanged(object sender, EventArgs e)
        {
            
            validate();
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
           
            validate();
        }

        // KeyStroke Event Counts, BackSpace Related
        private void firstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) // When press backspace
                bKeyPress = bKeyPress+1;
        }

        private void initial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }
        private void lastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }

        private void richAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }

        private void richAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }

        private void ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }

        private void st_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }

        private void zip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // zipCode only with digits
            {
                e.Handled = true;
            }
        }

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }

        private void email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                bKeyPress = bKeyPress + 1;
        }

        // Add Button Function
        private void Add_Click(object sender, EventArgs e)
        {
            string data;
            int FLAG = 0;
            string fileName = "CS6326Asg2.txt"; // first load last saved file.
               
            if (System.IO.File.Exists(fileName)) // file no exist then create one.
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName); // Open file and generate string infomation.
                string fullName = firstName.Text + " " + initial.Text + " " + lastName.Text;
                string phoneNo = phone.Text;
      
                while ((data = file.ReadLine()) != null)
                {
                    string[] items = data.Split('\t');
                    string entireName = items[1] + " " + items[3] + " " + items[2];
                    string phone= items[10]; // phone exist array at place 10
                    FLAG = dataCompare(entireName, fullName, phone, phoneNo); // Comapre with exist infomation.
                    if (FLAG == 1) break;   
                }
                file.Close();
            }

            if (FLAG == 1 && (toolStrip1.Text.Equals("NewForm")))
            {   
                Add.Enabled = false;
            }
        
            else if ((listView1.SelectedItems.Count > 0))  // Modify if select one, mutiple selections are avaliable.
            {
                errName.Clear();
                errPhone.Clear();
                errEmail.Clear();
                errZip.Clear();
                
                string selected = listView1.SelectedItems[0].Tag.ToString(); // Selcet on item in ListView to modify
                string[] lines = File.ReadAllLines(fileName); // Read file by lines.
                int noLines = lines.Length;

                // this loop processes each line of the file
                for (int i = 0; i < noLines; ++i)
                {
                    string splitLine = lines[i];
                    string[] ArrayOfLine = splitLine.Split('\t');
                    
                    if (selected == ArrayOfLine[0])  // Get the line in the first of the array
                    {
                        lineCount = Convert.ToInt32(selected);
                        modifyFile(Convert.ToInt32(selected));
                    }
                }

                toolStrip1.Text = "NewForm"; //Display the mode
                statusStrip1.Refresh();
                reStartForm();
                clearForm(this);
                timePicker.Value = DateTime.Now;  //Mark the time

            }

            else // Enter new data
            {
                errName.Clear();  
                string proof;
                
                if (yes.Checked)
                    proof = "YES";
                else
                    proof = "NO";

                string mName = " ";
                if (!string.IsNullOrWhiteSpace(initial.Text))
                    mName = initial.Text;
                string Address_line_2 = "null";
                if (!string.IsNullOrWhiteSpace(richAddress2.Text))
                    Address_line_2 = richAddress2.Text;
                string inputDate = timePicker.Value.ToShortDateString();

                //Write when input finished and join all the information append to the file.
                endTime.Text = DateTime.Now.ToString("HH:mm:ss tt"); 
                string info = String.Join("\t", lineCount, firstName.Text, lastName.Text, mName, richAddress1.Text, Address_line_2, ct.Text, st.Text, zip.Text, gender.Text, phone.Text, email.Text, proof, inputDate, startTime.Text, DateTime.Now.ToString("HH:mm:ss"), bKeyPress);
                System.IO.StreamWriter file_write = new System.IO.StreamWriter(fileName, true);

                file_write.WriteLine(info);
                file_write.Close();
    
                timePicker.Value = DateTime.Today; // Received time
                reStartForm();
                clearForm(this);
            }
        }

        //Modify Files
        private void modifyFile(int add)
        {
            //Count lines in file
            string fileName = "CS6326Asg2.txt";
            string[] lines = File.ReadAllLines(fileName);
            string phoneNumber = phone.Text;
            string fullName = firstName.Text + " " + initial.Text + " " + lastName.Text;

            int numberOfLines = lines.Length;
            int endFile = 0;
            int FLAG = 0;

            for (int i = 0; i < numberOfLines; i++)  // loop through file
            {
                string lineToSplit = lines[i];
                string[] line = lineToSplit.Split('\t');
                string name = line[1] + " " + line[3] + " " + line[2]; //Information stored in array placed in order.
                string phone = line[10];

                startTime.Text = line[14];
                endTime.Text = line[15];
                bKeyPress = Convert.ToInt32(line[16]);

                if (add!= Convert.ToInt32(line[0]))
                {   // validate a few of the input information
                    FLAG = dataCompare(name, fullName, phone, phoneNumber);
                    if (FLAG == 1) break;
                }
                else if (add == Convert.ToInt32(line[0]))
                    endFile = i;
            }
            if (FLAG == 0)
            {   
                lines[endFile] = replace(add); //Save avaliable when all infomation are correct
                Add.Enabled = true;
                errName.Clear();
                errPhone.Clear();
                errEmail.Clear();
                errZip.Clear();
            }
            else
            {   
                Add.Enabled = false;
                errName.Clear();
                errPhone.Clear();
                errEmail.Clear();
                errZip.Clear();             
                MessageBox.Show(" Please enter new name or phone number");
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false);
            // write updated information to file
            for (int i = 0; i < numberOfLines; i++)
            {
                string temp = lines[i];
                string[] splitLine = temp.Split('\t');
                string lineToInsert = String.Join("\t", splitLine[0], splitLine[1], splitLine[2], splitLine[3], splitLine[4], splitLine[5], splitLine[6], splitLine[7], splitLine[8], splitLine[9], splitLine[10], splitLine[11], splitLine[12], splitLine[13], splitLine[14], splitLine[15], bKeyPress); // Inorder information insert.
                file.WriteLine(lineToInsert);
            }
            file.Close();
        }
  
        private string replace(int insertLine)
        {
            string proof;
            if (yes.Checked)
                proof = "YES";
            else
                proof = "NO";

            string inputDate = timePicker.Value.ToShortDateString();
            string data = String.Join("\t", lineCount, firstName.Text, lastName.Text, initial.Text, richAddress1.Text, richAddress2.Text, ct.Text, st.Text, zip.Text, gender.Text, phone.Text, email.Text, proof, inputDate, startTime.Text, endTime.Text, bKeyPress);
            return data;
        }


        private void reStartForm()  // restart the form 
        {
            listView1.Items.Clear();
            bKeyPress = 0;
            yes.Checked = false;
            no.Checked = false;

            errName.Clear();
            errPhone.Clear();
            errEmail.Clear();
            errZip.Clear();

            string path = "CS6326Asg2.txt";
            lineCount = 0;

            if (System.IO.File.Exists(path))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                string temp;
                while ((temp = file.ReadLine()) != null)
                {
                    string[] items = temp.Split('\t');
                    string[] items2 = { items[0], items[1] + " " + items[3] + " " + items[2], items[10] };

                    ListViewItem lv = new ListViewItem(items2);
                    lv.Tag = items[0];
                    listView1.Items.Add(lv);
                    lineCount = Convert.ToInt32(items[0]);
                }

                lineCount++;
                file.Close();
            }
        }

        //Reset reference -Micosoft.com
        private void clearForm(Control control)
        {
            foreach (Control con in control.Controls)
            {
                if (con is TextBox)
                    ((TextBox)con).Clear();
                else if (con is RichTextBox)
                    ((RichTextBox)con).Clear();
                else
                    clearForm(con);
            }

            gender.Text = " ";  //Set default
            yes.Checked = false;
            no.Checked = false;

            errName.Clear();
            errPhone.Clear();
            errEmail.Clear();
            errZip.Clear();

        }
 
        private void modify_Click(object sender, EventArgs e) // When modify button clicked
        {
            toolStrip1.Text = "NewForm";
            timePicker.Value = DateTime.Today; 

            clearForm(this);  //Reset 
            errPhone.Clear();
            errEmail.Clear();
            errZip.Clear();  
            statusStrip1.Refresh();
        }

        private void delete_Click(object sender, EventArgs e) //When delete button clicked
        {
            string compare = listView1.SelectedItems[0].Tag.ToString();
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            string path = "CS6326Asg2.txt";
            string[] lines = File.ReadAllLines(path);
            int noLines = lines.Length;

            for (int i = 0; i < noLines - 1; ++i)  // Loop through the file and delete for both file and listview.
            {
                string fileLines = lines[i];
                string[] line = fileLines.Split('\t');
                int temp = i + 1;

                if (compare == line[0])
                {
                    int Add = i + 1;
                    int Current = i;

                    while (Current < noLines - 1)
                    {
                        lines[Current] = lines[Add];
                        Add++;
                        Current++;
                    }
                    break;
                }
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(path, false); // Write to file.
            for (int i = 0; i < noLines - 1; ++i)
            {
                string fileLines = lines[i];
                string[] line = fileLines.Split('\t');
                string insert = String.Join("\t", line[0], line[1], line[2], line[3], line[4], line[5], line[6], line[7], line[8], line[9], line[10], line[11], line[12], line[13], startTime.Text, endTime.Text, bKeyPress);
                file.WriteLine(insert);
            }

            file.Close();
            toolStrip1.Text = "NewForm";
            statusStrip1.Refresh();
            clearForm(this);
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) // List view setting.
        {
            string filePath = "CS6326Asg2.txt";

            if (listView1.SelectedItems.Count > 0) //If selected on tag
            {
                toolStrip1.Text = "Modify Mode";
                statusStrip1.Refresh();
                string select;

                ListViewItem lv = listView1.SelectedItems[0];
                select = Regex.Match(lv.SubItems[0].ToString(), @"\d+").Value;
                firstName.Text = select;

                statusStrip1.Text = "Modify Mode";
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                string line;

                while ((line = file.ReadLine()) != null) // Read file infos to display in ListView.
                {
                    string[] tag = line.Split('\t'); // Inorder tag
                    if (select == tag[0])
                    {
                        firstName.Text = tag[1];
                        email.Text = tag[11];
                        lastName.Text = tag[2];

                        if (tag[3] == "null")
                        {
                            initial.Clear();
                        }

                        else
                            initial.Text = tag[3];
                        richAddress1.Text = tag[4];

                        if (tag[5] == "null")
                        {
                            richAddress2.Clear();
                        }

                        else
                            richAddress2.Text = tag[5];

                        st.Text = tag[6];
                        ct.Text = tag[7];
                        zip.Text = tag[8];
                        gender.Text = tag[9];
                        phone.Text = tag[10];

                        if (tag[12] == "Yes")
                            yes.Checked = true;
                        else
                            no.Checked = true;

                        timePicker.Value = DateTime.Parse(tag[13]);
                        break;
                    }
                }

                file.Close();
            }
        }

        // Compare file records with the new entry to see if the infomation is already exist.
        private int dataCompare(string name, string fullName, string storedPhone, string phoneNo)
        {
            int Flag = 0;
            errName.Clear(); // remove error identification mark
            errPhone.Clear();
            errEmail.Clear();
            errZip.Clear();

            if ((String.Compare(name, fullName, StringComparison.OrdinalIgnoreCase) == 0) && (String.Compare(storedPhone, phoneNo, StringComparison.OrdinalIgnoreCase) == 0))
            {
                errPhone.SetError(phone, "Exsit Phone Number.");
                errName.SetError(firstName, "Exsit Name.");
                Flag = 1;

            }
            else if (String.Compare(storedPhone, phoneNo, StringComparison.OrdinalIgnoreCase) == 0)
            {
                errPhone.SetError(phone, "Exsit Phone Number.");
                Flag = 1;
            }
            return Flag;
        }

        //when click column the list will sort, reference -microsoft.com
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != columnSort)
            {
                columnSort = e.Column;
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;

            }
            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.Sorting);
        }

        // Redundent 

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void City_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

    }
}
