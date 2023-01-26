namespace Validation
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
        /// </summary>
       
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.viewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewPressCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath = new System.Windows.Forms.TextBox();
            this.minTimeEnter = new System.Windows.Forms.Label();
            this.avgTimeEnter = new System.Windows.Forms.Label();
            this.maxTimeEnter = new System.Windows.Forms.Label();
            this.numberRecords = new System.Windows.Forms.Label();
            this.minTimeFinish = new System.Windows.Forms.Label();
            this.avgTimeFinish = new System.Windows.Forms.Label();
            this.maxTimeFinish = new System.Windows.Forms.Label();
            this.totalTime = new System.Windows.Forms.Label();
            this.numberPress = new System.Windows.Forms.Label();
            this.evaluation = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.textRecords = new System.Windows.Forms.TextBox();
            this.textMinEnter = new System.Windows.Forms.TextBox();
            this.textAvgEnter = new System.Windows.Forms.TextBox();
            this.textMaxEnter = new System.Windows.Forms.TextBox();
            this.textMinFinish = new System.Windows.Forms.TextBox();
            this.textAvgFinish = new System.Windows.Forms.TextBox();
            this.textMaxFinish = new System.Windows.Forms.TextBox();
            this.textTotalTime = new System.Windows.Forms.TextBox();
            this.textNumberPress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rebate Evaluate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Path:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.viewName,
            this.viewTime,
            this.viewPressCount});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(24, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(314, 344);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.viewName.Text = "Full Name";
            this.viewTime.Text = "Time Taken";
            this.viewPressCount.Text = "Press Count";
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(85, 44);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(384, 20);
            this.filePath.TabIndex = 3;
            // 
            // minTimeEnter
            // 
            this.minTimeEnter.AutoSize = true;
            this.minTimeEnter.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTimeEnter.Location = new System.Drawing.Point(362, 115);
            this.minTimeEnter.Name = "minTimeEnter";
            this.minTimeEnter.Size = new System.Drawing.Size(92, 17);
            this.minTimeEnter.TabIndex = 4;
            this.minTimeEnter.Text = "MinTimeEnter";
            // 
            // avgTimeEnter
            // 
            this.avgTimeEnter.AutoSize = true;
            this.avgTimeEnter.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgTimeEnter.Location = new System.Drawing.Point(362, 148);
            this.avgTimeEnter.Name = "avgTimeEnter";
            this.avgTimeEnter.Size = new System.Drawing.Size(93, 17);
            this.avgTimeEnter.TabIndex = 5;
            this.avgTimeEnter.Text = "AvgTimeEnter";
            // 
            // maxTimeEnter
            // 
            this.maxTimeEnter.AutoSize = true;
            this.maxTimeEnter.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxTimeEnter.Location = new System.Drawing.Point(362, 181);
            this.maxTimeEnter.Name = "maxTimeEnter";
            this.maxTimeEnter.Size = new System.Drawing.Size(96, 17);
            this.maxTimeEnter.TabIndex = 6;
            this.maxTimeEnter.Text = "MaxTimeEnter";
            // 
            // numberRecords
            // 
            this.numberRecords.AutoSize = true;
            this.numberRecords.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberRecords.Location = new System.Drawing.Point(362, 86);
            this.numberRecords.Name = "numberRecords";
            this.numberRecords.Size = new System.Drawing.Size(105, 17);
            this.numberRecords.TabIndex = 7;
            this.numberRecords.Text = "NumberRecords";
            // 
            // minTimeFinish
            // 
            this.minTimeFinish.AutoSize = true;
            this.minTimeFinish.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTimeFinish.Location = new System.Drawing.Point(362, 217);
            this.minTimeFinish.Name = "minTimeFinish";
            this.minTimeFinish.Size = new System.Drawing.Size(113, 17);
            this.minTimeFinish.TabIndex = 8;
            this.minTimeFinish.Text = "MinTimeBetween";
            // 
            // avgTimeFinish
            // 
            this.avgTimeFinish.AutoSize = true;
            this.avgTimeFinish.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgTimeFinish.Location = new System.Drawing.Point(361, 255);
            this.avgTimeFinish.Name = "avgTimeFinish";
            this.avgTimeFinish.Size = new System.Drawing.Size(114, 17);
            this.avgTimeFinish.TabIndex = 9;
            this.avgTimeFinish.Text = "AvgTimeBetween";
            // 
            // maxTimeFinish
            // 
            this.maxTimeFinish.AutoSize = true;
            this.maxTimeFinish.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxTimeFinish.Location = new System.Drawing.Point(361, 293);
            this.maxTimeFinish.Name = "maxTimeFinish";
            this.maxTimeFinish.Size = new System.Drawing.Size(117, 17);
            this.maxTimeFinish.TabIndex = 10;
            this.maxTimeFinish.Text = "MaxTimeBetween";
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTime.Location = new System.Drawing.Point(362, 329);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(66, 17);
            this.totalTime.TabIndex = 11;
            this.totalTime.Text = "TotalTime";
            // 
            // numberPress
            // 
            this.numberPress.AutoSize = true;
            this.numberPress.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberPress.Location = new System.Drawing.Point(361, 364);
            this.numberPress.Name = "numberPress";
            this.numberPress.Size = new System.Drawing.Size(89, 17);
            this.numberPress.TabIndex = 12;
            this.numberPress.Text = "NumberPress";
            // 
            // evaluation
            // 
            this.evaluation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluation.Location = new System.Drawing.Point(365, 407);
            this.evaluation.Name = "evaluation";
            this.evaluation.Size = new System.Drawing.Size(85, 23);
            this.evaluation.TabIndex = 13;
            this.evaluation.Text = "Evaluation";
            this.evaluation.UseVisualStyleBackColor = true;
            this.evaluation.Click += new System.EventHandler(this.evaluation_Click);
            // 
            // clear
            // 
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.Location = new System.Drawing.Point(486, 407);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 14;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // browse
            // 
            this.browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse.Location = new System.Drawing.Point(486, 44);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(89, 23);
            this.browse.TabIndex = 15;
            this.browse.Text = "Browse...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // textRecords
            // 
            this.textRecords.Location = new System.Drawing.Point(486, 83);
            this.textRecords.Name = "textRecords";
            this.textRecords.Size = new System.Drawing.Size(89, 20);
            this.textRecords.TabIndex = 16;
            // 
            // textMinEnter
            // 
            this.textMinEnter.Location = new System.Drawing.Point(486, 114);
            this.textMinEnter.Name = "textMinEnter";
            this.textMinEnter.Size = new System.Drawing.Size(89, 20);
            this.textMinEnter.TabIndex = 17;
            // 
            // textAvgEnter
            // 
            this.textAvgEnter.Location = new System.Drawing.Point(486, 145);
            this.textAvgEnter.Name = "textAvgEnter";
            this.textAvgEnter.Size = new System.Drawing.Size(89, 20);
            this.textAvgEnter.TabIndex = 18;
            // 
            // textMaxEnter
            // 
            this.textMaxEnter.Location = new System.Drawing.Point(486, 178);
            this.textMaxEnter.Name = "textMaxEnter";
            this.textMaxEnter.Size = new System.Drawing.Size(89, 20);
            this.textMaxEnter.TabIndex = 19;
            // 
            // textMinFinish
            // 
            this.textMinFinish.Location = new System.Drawing.Point(486, 214);
            this.textMinFinish.Name = "textMinFinish";
            this.textMinFinish.Size = new System.Drawing.Size(89, 20);
            this.textMinFinish.TabIndex = 20;
            // 
            // textAvgFinish
            // 
            this.textAvgFinish.Location = new System.Drawing.Point(486, 252);
            this.textAvgFinish.Name = "textAvgFinish";
            this.textAvgFinish.Size = new System.Drawing.Size(89, 20);
            this.textAvgFinish.TabIndex = 21;
            // 
            // textMaxFinish
            // 
            this.textMaxFinish.Location = new System.Drawing.Point(486, 290);
            this.textMaxFinish.Name = "textMaxFinish";
            this.textMaxFinish.Size = new System.Drawing.Size(89, 20);
            this.textMaxFinish.TabIndex = 22;
            // 
            // textTotalTime
            // 
            this.textTotalTime.Location = new System.Drawing.Point(486, 326);
            this.textTotalTime.Name = "textTotalTime";
            this.textTotalTime.Size = new System.Drawing.Size(89, 20);
            this.textTotalTime.TabIndex = 23;
            // 
            // textNumberPress
            // 
            this.textNumberPress.Location = new System.Drawing.Point(486, 361);
            this.textNumberPress.Name = "textNumberPress";
            this.textNumberPress.Size = new System.Drawing.Size(89, 20);
            this.textNumberPress.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 451);
            this.Controls.Add(this.textNumberPress);
            this.Controls.Add(this.textTotalTime);
            this.Controls.Add(this.textMaxFinish);
            this.Controls.Add(this.textAvgFinish);
            this.Controls.Add(this.textMinFinish);
            this.Controls.Add(this.textMaxEnter);
            this.Controls.Add(this.textAvgEnter);
            this.Controls.Add(this.textMinEnter);
            this.Controls.Add(this.textRecords);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.evaluation);
            this.Controls.Add(this.numberPress);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.maxTimeFinish);
            this.Controls.Add(this.avgTimeFinish);
            this.Controls.Add(this.minTimeFinish);
            this.Controls.Add(this.numberRecords);
            this.Controls.Add(this.maxTimeEnter);
            this.Controls.Add(this.avgTimeEnter);
            this.Controls.Add(this.minTimeEnter);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Label minTimeEnter;
        private System.Windows.Forms.Label avgTimeEnter;
        private System.Windows.Forms.Label maxTimeEnter;
        private System.Windows.Forms.Label numberRecords;
        private System.Windows.Forms.Label minTimeFinish;
        private System.Windows.Forms.Label avgTimeFinish;
        private System.Windows.Forms.Label maxTimeFinish;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.Label numberPress;
        private System.Windows.Forms.Button evaluation;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox textRecords;
        private System.Windows.Forms.TextBox textMinEnter;
        private System.Windows.Forms.TextBox textAvgEnter;
        private System.Windows.Forms.TextBox textMaxEnter;
        private System.Windows.Forms.TextBox textMinFinish;
        private System.Windows.Forms.TextBox textAvgFinish;
        private System.Windows.Forms.TextBox textMaxFinish;
        private System.Windows.Forms.TextBox textTotalTime;
        private System.Windows.Forms.TextBox textNumberPress;
        private System.Windows.Forms.ColumnHeader viewName;
        private System.Windows.Forms.ColumnHeader viewTime;
        private System.Windows.Forms.ColumnHeader viewPressCount;
    } 
}

