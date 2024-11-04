using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Webphotos
{
    public partial class Form1 : Form
    {
        private IContainer components = null;
        private OpenFileDialog OpenFileDialog1;
        private ProgressBar ProgressBar1;
        private Button Button6;
        private GroupBox GroupBox1;
        private Label Label1;
        private Label Label3;
        private Label Label5;
        private MaskedTextBox MaskedTextBox2;
        private Label Label2;
        private ListBox ListBox1;
        private Button Button1;
        private Button Button7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            OpenFileDialog1 = new OpenFileDialog();
            ProgressBar1 = new ProgressBar();
            Button6 = new Button();
            GroupBox1 = new GroupBox();
            Label1 = new Label();
            Label3 = new Label();
            Label5 = new Label();
            MaskedTextBox2 = new MaskedTextBox();
            Label2 = new Label();
            ListBox1 = new ListBox();
            Button1 = new Button();
            Button7 = new Button();
            Button3 = new Button();
            GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName = "OpenFileDialog1";
            OpenFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.TIF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIF";
            OpenFileDialog1.Multiselect = true;
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new Point(5, 177);
            ProgressBar1.Maximum = 1500;
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(434, 23);
            ProgressBar1.TabIndex = 8;
            // 
            // Button6
            // 
            Button6.BackColor = Color.FromArgb(0, 192, 0);
            Button6.Location = new Point(325, 206);
            Button6.Name = "Button6";
            Button6.Size = new Size(75, 23);
            Button6.TabIndex = 11;
            Button6.Text = "Кхи д1а...";
            Button6.UseVisualStyleBackColor = false;
            // 
            // GroupBox1
            // 
            GroupBox1.BackColor = Color.Transparent;
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Controls.Add(Label5);
            GroupBox1.Controls.Add(MaskedTextBox2);
            GroupBox1.Location = new Point(5, 9);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(141, 152);
            GroupBox1.TabIndex = 16;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Барам";
            // 
            // Label1
            // 
            Label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            Label1.Location = new Point(-3, 45);
            Label1.Name = "Label1";
            Label1.Size = new Size(116, 51);
            Label1.TabIndex = 18;
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Label3.Location = new Point(87, 121);
            Label3.Name = "Label3";
            Label3.Size = new Size(60, 27);
            Label3.TabIndex = 17;
            Label3.Text = "Байт";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(-1, 100);
            Label5.Name = "Label5";
            Label5.Size = new Size(65, 20);
            Label5.TabIndex = 16;
            Label5.Text = "Бараме:";
            // 
            // MaskedTextBox2
            // 
            MaskedTextBox2.Location = new Point(2, 120);
            MaskedTextBox2.Mask = "999 999 999 999 999 ";
            MaskedTextBox2.Name = "MaskedTextBox2";
            MaskedTextBox2.PromptChar = ' ';
            MaskedTextBox2.Size = new Size(79, 27);
            MaskedTextBox2.TabIndex = 15;
            MaskedTextBox2.Text = "500000";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(350, 3);
            Label2.Name = "Label2";
            Label2.Size = new Size(68, 20);
            Label2.TabIndex = 16;
            Label2.Text = "Суьрташ";
            // 
            // ListBox1
            // 
            ListBox1.BackColor = Color.FromArgb(255, 255, 192);
            ListBox1.FormattingEnabled = true;
            ListBox1.Location = new Point(211, 28);
            ListBox1.Name = "ListBox1";
            ListBox1.SelectionMode = SelectionMode.MultiExtended;
            ListBox1.Size = new Size(228, 124);
            ListBox1.TabIndex = 1;
            ListBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            // 
            // Button1
            // 
            Button1.BackColor = Color.FromArgb(255, 255, 192);
            Button1.Location = new Point(5, 226);
            Button1.Name = "Button1";
            Button1.Size = new Size(98, 30);
            Button1.TabIndex = 0;
            Button1.Text = "Т1етоха";
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click;
            // 
            // Button7
            // 
            Button7.BackColor = Color.FromArgb(255, 255, 192);
            Button7.Location = new Point(214, 227);
            Button7.Name = "Button7";
            Button7.Size = new Size(100, 30);
            Button7.TabIndex = 19;
            Button7.Text = "Ц1анйе";
            Button7.UseVisualStyleBackColor = false;
            Button7.Click += Button7_Click;
            // 
            // Button3
            // 
            Button3.BackColor = SystemColors.Info;
            Button3.ForeColor = Color.Black;
            Button3.Location = new Point(345, 227);
            Button3.Name = "Button3";
            Button3.Size = new Size(94, 29);
            Button3.TabIndex = 21;
            Button3.Text = "Start";
            Button3.UseVisualStyleBackColor = false;
            Button3.Click += Button3_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(451, 259);
            Controls.Add(Button3);
            Controls.Add(Button7);
            Controls.Add(ProgressBar1);
            Controls.Add(GroupBox1);
            Controls.Add(ListBox1);
            Controls.Add(Label2);
            Controls.Add(Button1);
            Name = "Form1";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button Button3;
    }
}
