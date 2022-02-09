
namespace RSI_test
{
    partial class Form2
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
            this.checkBoxOnoffBuy = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonTestapi = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.labelkey = new System.Windows.Forms.Label();
            this.labelsecret = new System.Windows.Forms.Label();
            this.comboBoxObdateBalans = new System.Windows.Forms.ComboBox();
            this.labelobdatebalans = new System.Windows.Forms.Label();
            this.textBoxPair = new System.Windows.Forms.TextBox();
            this.labelPair = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxOnoffBuy
            // 
            this.checkBoxOnoffBuy.AutoSize = true;
            this.checkBoxOnoffBuy.Location = new System.Drawing.Point(248, 12);
            this.checkBoxOnoffBuy.Name = "checkBoxOnoffBuy";
            this.checkBoxOnoffBuy.Size = new System.Drawing.Size(92, 17);
            this.checkBoxOnoffBuy.TabIndex = 0;
            this.checkBoxOnoffBuy.Text = "ON/OFF BUY";
            this.checkBoxOnoffBuy.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(688, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 426);
            this.panel1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(688, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // buttonTestapi
            // 
            this.buttonTestapi.Location = new System.Drawing.Point(713, 64);
            this.buttonTestapi.Name = "buttonTestapi";
            this.buttonTestapi.Size = new System.Drawing.Size(75, 23);
            this.buttonTestapi.TabIndex = 6;
            this.buttonTestapi.Text = "Test API";
            this.buttonTestapi.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(200, 426);
            this.dataGridView2.TabIndex = 0;
            // 
            // labelkey
            // 
            this.labelkey.AutoSize = true;
            this.labelkey.Location = new System.Drawing.Point(632, 19);
            this.labelkey.Name = "labelkey";
            this.labelkey.Size = new System.Drawing.Size(28, 13);
            this.labelkey.TabIndex = 7;
            this.labelkey.Text = "KEY";
            // 
            // labelsecret
            // 
            this.labelsecret.AutoSize = true;
            this.labelsecret.Location = new System.Drawing.Point(632, 45);
            this.labelsecret.Name = "labelsecret";
            this.labelsecret.Size = new System.Drawing.Size(50, 13);
            this.labelsecret.TabIndex = 8;
            this.labelsecret.Text = "SECRET";
            // 
            // comboBoxObdateBalans
            // 
            this.comboBoxObdateBalans.FormattingEnabled = true;
            this.comboBoxObdateBalans.Items.AddRange(new object[] {
            "1m",
            "5m",
            "15m"});
            this.comboBoxObdateBalans.Location = new System.Drawing.Point(734, 117);
            this.comboBoxObdateBalans.Name = "comboBoxObdateBalans";
            this.comboBoxObdateBalans.Size = new System.Drawing.Size(54, 21);
            this.comboBoxObdateBalans.TabIndex = 9;
            // 
            // labelobdatebalans
            // 
            this.labelobdatebalans.AutoSize = true;
            this.labelobdatebalans.Location = new System.Drawing.Point(632, 125);
            this.labelobdatebalans.Name = "labelobdatebalans";
            this.labelobdatebalans.Size = new System.Drawing.Size(96, 13);
            this.labelobdatebalans.TabIndex = 10;
            this.labelobdatebalans.Text = "OBDATE BALANS";
            // 
            // textBoxPair
            // 
            this.textBoxPair.Location = new System.Drawing.Point(238, 67);
            this.textBoxPair.Name = "textBoxPair";
            this.textBoxPair.Size = new System.Drawing.Size(92, 20);
            this.textBoxPair.TabIndex = 11;
            // 
            // labelPair
            // 
            this.labelPair.AutoSize = true;
            this.labelPair.Location = new System.Drawing.Point(268, 45);
            this.labelPair.Name = "labelPair";
            this.labelPair.Size = new System.Drawing.Size(32, 13);
            this.labelPair.TabIndex = 12;
            this.labelPair.Text = "PAIR";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Price";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Buy coin";
            this.Column2.Name = "Column2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelPair);
            this.Controls.Add(this.textBoxPair);
            this.Controls.Add(this.labelobdatebalans);
            this.Controls.Add(this.comboBoxObdateBalans);
            this.Controls.Add(this.labelsecret);
            this.Controls.Add(this.labelkey);
            this.Controls.Add(this.buttonTestapi);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxOnoffBuy);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOnoffBuy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonTestapi;
        private System.Windows.Forms.Label labelkey;
        private System.Windows.Forms.Label labelsecret;
        private System.Windows.Forms.ComboBox comboBoxObdateBalans;
        private System.Windows.Forms.Label labelobdatebalans;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textBoxPair;
        private System.Windows.Forms.Label labelPair;
    }
}