namespace Життя
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pctr1 = new System.Windows.Forms.PictureBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.grpBx1 = new System.Windows.Forms.GroupBox();
            this.rdBtn2 = new System.Windows.Forms.RadioButton();
            this.rdBtn1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkbx1 = new System.Windows.Forms.CheckBox();
            this.txtBx1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdBtn7 = new System.Windows.Forms.RadioButton();
            this.rdBtn4 = new System.Windows.Forms.RadioButton();
            this.rdBtn5 = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn4 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.txtBx2 = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.pctr2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkEntering = new System.Windows.Forms.CheckBox();
            this.timerEntering = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pctr1)).BeginInit();
            this.grpBx1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctr2)).BeginInit();
            this.SuspendLayout();
            // 
            // pctr1
            // 
            this.pctr1.Location = new System.Drawing.Point(12, 12);
            this.pctr1.Name = "pctr1";
            this.pctr1.Size = new System.Drawing.Size(701, 701);
            this.pctr1.TabIndex = 0;
            this.pctr1.TabStop = false;
            this.pctr1.Click += new System.EventHandler(this.pctr1_Click);
            this.pctr1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctr1_MouseDown);
            this.pctr1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctr1_MouseUp);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(719, 59);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(125, 44);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "Start";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Visible = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(719, 12);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(125, 41);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "Load";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(719, 109);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(104, 44);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "Pause";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Visible = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(790, 512);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(0, 20);
            this.lbl1.TabIndex = 4;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(813, 532);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(0, 20);
            this.lbl2.TabIndex = 5;
            // 
            // grpBx1
            // 
            this.grpBx1.Controls.Add(this.rdBtn2);
            this.grpBx1.Controls.Add(this.rdBtn1);
            this.grpBx1.Location = new System.Drawing.Point(719, 420);
            this.grpBx1.Name = "grpBx1";
            this.grpBx1.Size = new System.Drawing.Size(185, 89);
            this.grpBx1.TabIndex = 6;
            this.grpBx1.TabStop = false;
            this.grpBx1.Text = "Colour:";
            this.grpBx1.Enter += new System.EventHandler(this.grpBx1_Enter);
            // 
            // rdBtn2
            // 
            this.rdBtn2.AutoSize = true;
            this.rdBtn2.Enabled = false;
            this.rdBtn2.Location = new System.Drawing.Point(6, 55);
            this.rdBtn2.Name = "rdBtn2";
            this.rdBtn2.Size = new System.Drawing.Size(57, 24);
            this.rdBtn2.TabIndex = 1;
            this.rdBtn2.TabStop = true;
            this.rdBtn2.Text = "Red";
            this.rdBtn2.UseVisualStyleBackColor = true;
            // 
            // rdBtn1
            // 
            this.rdBtn1.AutoSize = true;
            this.rdBtn1.Checked = true;
            this.rdBtn1.Location = new System.Drawing.Point(6, 25);
            this.rdBtn1.Name = "rdBtn1";
            this.rdBtn1.Size = new System.Drawing.Size(59, 24);
            this.rdBtn1.TabIndex = 0;
            this.rdBtn1.TabStop = true;
            this.rdBtn1.Text = "Blue";
            this.rdBtn1.UseVisualStyleBackColor = true;
            this.rdBtn1.CheckedChanged += new System.EventHandler(this.rdBtn1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkbx1);
            this.groupBox1.Controls.Add(this.txtBx1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdBtn7);
            this.groupBox1.Controls.Add(this.rdBtn4);
            this.groupBox1.Controls.Add(this.rdBtn5);
            this.groupBox1.Location = new System.Drawing.Point(719, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 205);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number of colours:";
            // 
            // chkbx1
            // 
            this.chkbx1.AutoSize = true;
            this.chkbx1.Location = new System.Drawing.Point(7, 167);
            this.chkbx1.Name = "chkbx1";
            this.chkbx1.Size = new System.Drawing.Size(78, 24);
            this.chkbx1.TabIndex = 9;
            this.chkbx1.Text = "Moving";
            this.chkbx1.UseVisualStyleBackColor = true;
            this.chkbx1.CheckedChanged += new System.EventHandler(this.chkbx1_CheckedChanged);
            // 
            // txtBx1
            // 
            this.txtBx1.Location = new System.Drawing.Point(10, 135);
            this.txtBx1.Name = "txtBx1";
            this.txtBx1.Size = new System.Drawing.Size(98, 26);
            this.txtBx1.TabIndex = 8;
            this.txtBx1.Text = "3";
            this.txtBx1.Visible = false;
            this.txtBx1.TextChanged += new System.EventHandler(this.txtBx1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Neighbors to stay alive:";
            // 
            // rdBtn7
            // 
            this.rdBtn7.AutoSize = true;
            this.rdBtn7.Location = new System.Drawing.Point(7, 85);
            this.rdBtn7.Name = "rdBtn7";
            this.rdBtn7.Size = new System.Drawing.Size(59, 24);
            this.rdBtn7.TabIndex = 6;
            this.rdBtn7.Text = "Nine";
            this.rdBtn7.UseVisualStyleBackColor = true;
            this.rdBtn7.CheckedChanged += new System.EventHandler(this.rdBtn7_CheckedChanged);
            // 
            // rdBtn4
            // 
            this.rdBtn4.AutoSize = true;
            this.rdBtn4.Checked = true;
            this.rdBtn4.Location = new System.Drawing.Point(7, 25);
            this.rdBtn4.Name = "rdBtn4";
            this.rdBtn4.Size = new System.Drawing.Size(57, 24);
            this.rdBtn4.TabIndex = 5;
            this.rdBtn4.TabStop = true;
            this.rdBtn4.Text = "One";
            this.rdBtn4.UseVisualStyleBackColor = true;
            this.rdBtn4.CheckedChanged += new System.EventHandler(this.rdBtn4_CheckedChanged_1);
            // 
            // rdBtn5
            // 
            this.rdBtn5.AutoSize = true;
            this.rdBtn5.Location = new System.Drawing.Point(7, 55);
            this.rdBtn5.Name = "rdBtn5";
            this.rdBtn5.Size = new System.Drawing.Size(56, 24);
            this.rdBtn5.TabIndex = 4;
            this.rdBtn5.Text = "Two";
            this.rdBtn5.UseVisualStyleBackColor = true;
            this.rdBtn5.CheckedChanged += new System.EventHandler(this.rdBtn4_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(719, 159);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(104, 44);
            this.btn4.TabIndex = 8;
            this.btn4.Text = "Save";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(729, 575);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(104, 44);
            this.btn5.TabIndex = 9;
            this.btn5.Text = "Exit";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(829, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Щільність (%):";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(850, 12);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(104, 41);
            this.btn6.TabIndex = 11;
            this.btn6.Text = "Clear";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(850, 59);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(104, 44);
            this.btn7.TabIndex = 12;
            this.btn7.Text = "Random";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // txtBx2
            // 
            this.txtBx2.Location = new System.Drawing.Point(833, 132);
            this.txtBx2.Name = "txtBx2";
            this.txtBx2.Size = new System.Drawing.Size(100, 26);
            this.txtBx2.TabIndex = 13;
            this.txtBx2.Text = "20";
            this.txtBx2.TextChanged += new System.EventHandler(this.txtBx2_TextChanged);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(825, 552);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(0, 20);
            this.lbl3.TabIndex = 14;
            // 
            // pctr2
            // 
            this.pctr2.Location = new System.Drawing.Point(936, 683);
            this.pctr2.Name = "pctr2";
            this.pctr2.Size = new System.Drawing.Size(701, 701);
            this.pctr2.TabIndex = 15;
            this.pctr2.TabStop = false;
            this.pctr2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(725, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Dencity (%):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(725, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Cells alive:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(725, 512);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cycles:";
            // 
            // checkEntering
            // 
            this.checkEntering.Location = new System.Drawing.Point(829, 164);
            this.checkEntering.Name = "checkEntering";
            this.checkEntering.Size = new System.Drawing.Size(129, 51);
            this.checkEntering.TabIndex = 19;
            this.checkEntering.Text = "Сontinuous entering";
            this.checkEntering.UseVisualStyleBackColor = true;
            this.checkEntering.Visible = false;
            // 
            // timerEntering
            // 
            this.timerEntering.Interval = 1;
            this.timerEntering.Tick += new System.EventHandler(this.timerEntering_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 725);
            this.Controls.Add(this.checkEntering);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pctr2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtBx2);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBx1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.pctr1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Життя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Frm1_Load);
            this.LocationChanged += new System.EventHandler(this.Frm1_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pctr1)).EndInit();
            this.grpBx1.ResumeLayout(false);
            this.grpBx1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctr2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctr1;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.GroupBox grpBx1;
        private System.Windows.Forms.RadioButton rdBtn2;
        private System.Windows.Forms.RadioButton rdBtn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtn5;
        private System.Windows.Forms.RadioButton rdBtn4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.TextBox txtBx1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdBtn7;
        private System.Windows.Forms.CheckBox chkbx1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.TextBox txtBx2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.PictureBox pctr2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkEntering;
        private System.Windows.Forms.Timer timerEntering;
    }
}

