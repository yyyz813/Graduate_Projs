
namespace Asg2_yxz157830
{
    partial class Form1
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
        /// Some of the redundance values causes by the 1st of the design, which can be ignored.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.initial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.TextBox();
            this.ct = new System.Windows.Forms.TextBox();
            this.zip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.modify = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.richAddress1 = new System.Windows.Forms.RichTextBox();
            this.richAddress2 = new System.Windows.Forms.RichTextBox();
            this.st = new System.Windows.Forms.TextBox();
            this.gender = new System.Windows.Forms.ComboBox();
            this.yes = new System.Windows.Forms.RadioButton();
            this.no = new System.Windows.Forms.RadioButton();
            this.errName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.startTime = new System.Windows.Forms.TextBox();
            this.endTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backSpace = new System.Windows.Forms.TextBox();
            this.errEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.errZip = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPhone)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errZip)).BeginInit();
            this.SuspendLayout();
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(49, 37);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(111, 20);
            this.firstName.TabIndex = 0;
            this.firstName.TextChanged += new System.EventHandler(this.firstName_TextChanged);
            this.firstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(212, 37);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(100, 20);
            this.lastName.TabIndex = 3;
            this.lastName.TextChanged += new System.EventHandler(this.lastName_TextChanged);
            this.lastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lastName_KeyPress);
            // 
            // initial
            // 
            this.initial.Location = new System.Drawing.Point(166, 37);
            this.initial.Name = "initial";
            this.initial.Size = new System.Drawing.Size(39, 20);
            this.initial.TabIndex = 4;
            this.initial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.initial_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Initial";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address Line 1";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Address Line 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "City";
            this.label6.Click += new System.EventHandler(this.City_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "State";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Zip Code";
            // 
            // city
            // 
            this.city.Location = new System.Drawing.Point(49, 186);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(56, 20);
            this.city.TabIndex = 13;
            // 
            // ct
            // 
            this.ct.Location = new System.Drawing.Point(49, 186);
            this.ct.Name = "ct";
            this.ct.Size = new System.Drawing.Size(57, 20);
            this.ct.TabIndex = 14;
            this.ct.TextChanged += new System.EventHandler(this.ct_TextChanged);
            this.ct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ct_KeyPress);
            // 
            // zip
            // 
            this.zip.Location = new System.Drawing.Point(201, 186);
            this.zip.Name = "zip";
            this.zip.Size = new System.Drawing.Size(111, 20);
            this.zip.TabIndex = 15;
            this.zip.TextChanged += new System.EventHandler(this.zip_TextChanged);
            this.zip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zip_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Gender";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Phone Number";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(122, 239);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(190, 20);
            this.phone.TabIndex = 19;
            this.phone.TextChanged += new System.EventHandler(this.phone_TextChanged);
            this.phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "E-mail";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(49, 292);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(263, 20);
            this.email.TabIndex = 21;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            this.email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.email_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(119, 326);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Proof of purchased";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(51, 360);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(65, 28);
            this.Add.TabIndex = 23;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // modify
            // 
            this.modify.Location = new System.Drawing.Point(142, 360);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(63, 28);
            this.modify.TabIndex = 26;
            this.modify.Text = "Modify";
            this.modify.UseVisualStyleBackColor = true;
            this.modify.Click += new System.EventHandler(this.modify_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(233, 360);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(69, 28);
            this.delete.TabIndex = 27;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // timePicker
            // 
            this.timePicker.Location = new System.Drawing.Point(336, 37);
            this.timePicker.MaxDate = new System.DateTime(2024, 2, 16, 0, 0, 0, 0);
            this.timePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(192, 20);
            this.timePicker.TabIndex = 28;
            this.timePicker.Value = new System.DateTime(2022, 2, 15, 0, 0, 0, 0);
            this.timePicker.ValueChanged += new System.EventHandler(this.timePicker_ValueChanged);
            // 
            // listView1
            // 
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(336, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(192, 325);
            this.listView1.TabIndex = 29;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // richAddress1
            // 
            this.richAddress1.Location = new System.Drawing.Point(49, 85);
            this.richAddress1.Name = "richAddress1";
            this.richAddress1.Size = new System.Drawing.Size(263, 22);
            this.richAddress1.TabIndex = 30;
            this.richAddress1.Text = "";
            this.richAddress1.TextChanged += new System.EventHandler(this.richAddress1_TextChanged);
            this.richAddress1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richAddress1_KeyPress);
            // 
            // richAddress2
            // 
            this.richAddress2.Location = new System.Drawing.Point(49, 136);
            this.richAddress2.Name = "richAddress2";
            this.richAddress2.Size = new System.Drawing.Size(263, 24);
            this.richAddress2.TabIndex = 31;
            this.richAddress2.Text = "";
            this.richAddress2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richAddress2_KeyPress);
            // 
            // st
            // 
            this.st.Location = new System.Drawing.Point(122, 186);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(57, 20);
            this.st.TabIndex = 32;
            this.st.TextChanged += new System.EventHandler(this.st_TextChanged);
            this.st.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.st_KeyPress);
            // 
            // gender
            // 
            this.gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gender.FormattingEnabled = true;
            this.gender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.gender.Location = new System.Drawing.Point(49, 236);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(57, 21);
            this.gender.TabIndex = 33;
            this.gender.SelectedIndexChanged += new System.EventHandler(this.gender_SelectedIndexChanged);
            // 
            // yes
            // 
            this.yes.AutoSize = true;
            this.yes.Location = new System.Drawing.Point(222, 324);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(43, 17);
            this.yes.TabIndex = 34;
            this.yes.TabStop = true;
            this.yes.Text = "Yes";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.CheckedChanged += new System.EventHandler(this.yes_CheckedChanged);
            // 
            // no
            // 
            this.no.AutoSize = true;
            this.no.Location = new System.Drawing.Point(271, 324);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(39, 17);
            this.no.TabIndex = 35;
            this.no.TabStop = true;
            this.no.Text = "No";
            this.no.UseVisualStyleBackColor = true;
            this.no.CheckedChanged += new System.EventHandler(this.no_CheckedChanged);
            // 
            // errName
            // 
            this.errName.ContainerControl = this;
            // 
            // errPhone
            // 
            this.errPhone.ContainerControl = this;
            // 
            // startTime
            // 
            this.startTime.Location = new System.Drawing.Point(460, 8);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(68, 20);
            this.startTime.TabIndex = 36;
            // 
            // endTime
            // 
            this.endTime.Location = new System.Drawing.Point(587, 8);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(68, 20);
            this.endTime.TabIndex = 37;
            this.endTime.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(399, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Start Time";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(57, 17);
            this.toolStrip1.Text = "Welcome";
            // 
            // backSpace
            // 
            this.backSpace.Location = new System.Drawing.Point(661, 8);
            this.backSpace.Name = "backSpace";
            this.backSpace.Size = new System.Drawing.Size(68, 20);
            this.backSpace.TabIndex = 42;
            this.backSpace.Visible = false;
            // 
            // errEmail
            // 
            this.errEmail.ContainerControl = this;
            // 
            // errZip
            // 
            this.errZip.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 426);
            this.Controls.Add(this.backSpace);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.st);
            this.Controls.Add(this.richAddress2);
            this.Controls.Add(this.richAddress1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.modify);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.zip);
            this.Controls.Add(this.ct);
            this.Controls.Add(this.city);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.initial);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstName);
            this.Name = "Form1";
            this.Text = "Rebate Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPhone)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errZip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox initial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.TextBox ct;
        private System.Windows.Forms.TextBox zip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button modify;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RichTextBox richAddress1;
        private System.Windows.Forms.RichTextBox richAddress2;
        private System.Windows.Forms.TextBox st;
        private System.Windows.Forms.ComboBox gender;
        private System.Windows.Forms.RadioButton yes;
        private System.Windows.Forms.RadioButton no;
        private System.Windows.Forms.ErrorProvider errName;
        private System.Windows.Forms.ErrorProvider errPhone;
        private System.Windows.Forms.TextBox endTime;
        private System.Windows.Forms.TextBox startTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip1;
        private System.Windows.Forms.TextBox backSpace;
        private System.Windows.Forms.ErrorProvider errEmail;
        private System.Windows.Forms.ErrorProvider errZip;
    }
}

