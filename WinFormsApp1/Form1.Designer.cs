using System.Xml.Linq;
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameBox = new System.Windows.Forms.ComboBox();
            this.facultyBox = new System.Windows.Forms.ComboBox();
            this.cathedraBox = new System.Windows.Forms.ComboBox();
            this.nameCheckBox = new System.Windows.Forms.CheckBox();
            this.facultyCheckBox = new System.Windows.Forms.CheckBox();
            this.cathedraСheckBox = new System.Windows.Forms.CheckBox();
            this.courseCheckBox = new System.Windows.Forms.CheckBox();
            this.courseBox = new System.Windows.Forms.ComboBox();
            this.dataBox = new System.Windows.Forms.ComboBox();
            this.dataCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButtonLINQ = new System.Windows.Forms.RadioButton();
            this.radioButtonSAX = new System.Windows.Forms.RadioButton();
            this.radioButtonDOM = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.FormattingEnabled = true;
            this.nameBox.Location = new System.Drawing.Point(124, 14);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(220, 28);
            this.nameBox.TabIndex = 0;
            this.nameBox.Click += new System.EventHandler(this.nameBox_Click);
            // 
            // facultyBox
            // 
            this.facultyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.facultyBox.FormattingEnabled = true;
            this.facultyBox.Location = new System.Drawing.Point(124, 70);
            this.facultyBox.Name = "facultyBox";
            this.facultyBox.Size = new System.Drawing.Size(220, 28);
            this.facultyBox.TabIndex = 1;
            this.facultyBox.Click += new System.EventHandler(this.faculty_Click);
            // 
            // cathedraBox
            // 
            this.cathedraBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cathedraBox.FormattingEnabled = true;
            this.cathedraBox.Location = new System.Drawing.Point(124, 126);
            this.cathedraBox.Name = "cathedraBox";
            this.cathedraBox.Size = new System.Drawing.Size(220, 28);
            this.cathedraBox.TabIndex = 2;
            this.cathedraBox.Click += new System.EventHandler(this.cathedra_Click);
            // 
            // nameCheckBox
            // 
            this.nameCheckBox.AutoSize = true;
            this.nameCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameCheckBox.Location = new System.Drawing.Point(3, 3);
            this.nameCheckBox.Name = "nameCheckBox";
            this.nameCheckBox.Size = new System.Drawing.Size(115, 50);
            this.nameCheckBox.TabIndex = 3;
            this.nameCheckBox.Text = "Ім\'я";
            this.nameCheckBox.UseVisualStyleBackColor = true;
            this.nameCheckBox.CheckedChanged += new System.EventHandler(this.nameCheckBox_CheckedChanged);
            // 
            // facultyCheckBox
            // 
            this.facultyCheckBox.AutoSize = true;
            this.facultyCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.facultyCheckBox.Location = new System.Drawing.Point(3, 59);
            this.facultyCheckBox.Name = "facultyCheckBox";
            this.facultyCheckBox.Size = new System.Drawing.Size(115, 50);
            this.facultyCheckBox.TabIndex = 4;
            this.facultyCheckBox.Text = "Факультет";
            this.facultyCheckBox.UseVisualStyleBackColor = true;
            this.facultyCheckBox.CheckedChanged += new System.EventHandler(this.facultyCheckBox_CheckedChanged);
            // 
            // cathedraСheckBox
            // 
            this.cathedraСheckBox.AutoSize = true;
            this.cathedraСheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cathedraСheckBox.Location = new System.Drawing.Point(3, 115);
            this.cathedraСheckBox.Name = "cathedraСheckBox";
            this.cathedraСheckBox.Size = new System.Drawing.Size(115, 50);
            this.cathedraСheckBox.TabIndex = 5;
            this.cathedraСheckBox.Text = "Кафедра";
            this.cathedraСheckBox.UseVisualStyleBackColor = true;
            this.cathedraСheckBox.CheckedChanged += new System.EventHandler(this.cathedraСheckBox_CheckedChanged);
            // 
            // courseCheckBox
            // 
            this.courseCheckBox.AutoSize = true;
            this.courseCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseCheckBox.Location = new System.Drawing.Point(3, 171);
            this.courseCheckBox.Name = "courseCheckBox";
            this.courseCheckBox.Size = new System.Drawing.Size(115, 50);
            this.courseCheckBox.TabIndex = 6;
            this.courseCheckBox.Text = "Курс";
            this.courseCheckBox.UseVisualStyleBackColor = true;
            this.courseCheckBox.CheckedChanged += new System.EventHandler(this.courseCheckBox_CheckedChanged);
            // 
            // courseBox
            // 
            this.courseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.courseBox.FormattingEnabled = true;
            this.courseBox.Location = new System.Drawing.Point(124, 182);
            this.courseBox.Name = "courseBox";
            this.courseBox.Size = new System.Drawing.Size(220, 28);
            this.courseBox.TabIndex = 7;
            this.courseBox.Click += new System.EventHandler(this.course_Click);
            // 
            // dataBox
            // 
            this.dataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBox.FormattingEnabled = true;
            this.dataBox.Location = new System.Drawing.Point(124, 239);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(220, 28);
            this.dataBox.TabIndex = 8;
            this.dataBox.Click += new System.EventHandler(this.data_Click);
            // 
            // dataCheckBox
            // 
            this.dataCheckBox.AutoSize = true;
            this.dataCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataCheckBox.Location = new System.Drawing.Point(3, 227);
            this.dataCheckBox.Name = "dataCheckBox";
            this.dataCheckBox.Size = new System.Drawing.Size(115, 52);
            this.dataCheckBox.TabIndex = 9;
            this.dataCheckBox.Text = "Дата";
            this.dataCheckBox.UseVisualStyleBackColor = true;
            this.dataCheckBox.CheckedChanged += new System.EventHandler(this.dataCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.nameCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.courseBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.facultyCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cathedraBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cathedraСheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.facultyBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.courseCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nameBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 282);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(365, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(423, 432);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Пошук";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "Трансформувати ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButtonLINQ
            // 
            this.radioButtonLINQ.AutoSize = true;
            this.radioButtonLINQ.Location = new System.Drawing.Point(3, 314);
            this.radioButtonLINQ.Name = "radioButtonLINQ";
            this.radioButtonLINQ.Size = new System.Drawing.Size(63, 24);
            this.radioButtonLINQ.TabIndex = 14;
            this.radioButtonLINQ.TabStop = true;
            this.radioButtonLINQ.Text = "LINQ";
            this.radioButtonLINQ.UseVisualStyleBackColor = true;
            this.radioButtonLINQ.CheckedChanged += new System.EventHandler(this.radioButtonLINQ_CheckedChanged);
            // 
            // radioButtonSAX
            // 
            this.radioButtonSAX.AutoSize = true;
            this.radioButtonSAX.Location = new System.Drawing.Point(126, 314);
            this.radioButtonSAX.Name = "radioButtonSAX";
            this.radioButtonSAX.Size = new System.Drawing.Size(57, 24);
            this.radioButtonSAX.TabIndex = 15;
            this.radioButtonSAX.TabStop = true;
            this.radioButtonSAX.Text = "SAX";
            this.radioButtonSAX.UseVisualStyleBackColor = true;
            this.radioButtonSAX.CheckedChanged += new System.EventHandler(this.radioButtonSAX_CheckedChanged);
            // 
            // radioButtonDOM
            // 
            this.radioButtonDOM.AutoSize = true;
            this.radioButtonDOM.Location = new System.Drawing.Point(242, 314);
            this.radioButtonDOM.Name = "radioButtonDOM";
            this.radioButtonDOM.Size = new System.Drawing.Size(65, 24);
            this.radioButtonDOM.TabIndex = 16;
            this.radioButtonDOM.TabStop = true;
            this.radioButtonDOM.Text = "DOM";
            this.radioButtonDOM.UseVisualStyleBackColor = true;
            this.radioButtonDOM.CheckedChanged += new System.EventHandler(this.radioButtonDOM_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioButtonDOM);
            this.Controls.Add(this.radioButtonSAX);
            this.Controls.Add(this.radioButtonLINQ);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "XML";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private  System.Windows.Forms.ComboBox nameBox;
        private System.Windows.Forms.ComboBox facultyBox;
        private System.Windows.Forms.ComboBox cathedraBox;
        private System.Windows.Forms.CheckBox nameCheckBox;
        private System.Windows.Forms.CheckBox facultyCheckBox;
        private System.Windows.Forms.CheckBox cathedraСheckBox;
        private System.Windows.Forms.CheckBox courseCheckBox;
        private System.Windows.Forms.ComboBox courseBox;
        private System.Windows.Forms.ComboBox dataBox;
        private System.Windows.Forms.CheckBox dataCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButtonLINQ;
        private System.Windows.Forms.RadioButton radioButtonSAX;
        private System.Windows.Forms.RadioButton radioButtonDOM;
    }
}

