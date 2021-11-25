
namespace Data_Structure_Visual
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_dp = new System.Windows.Forms.DataGridView();
            this.button_openfile = new System.Windows.Forms.Button();
            this.comboBox_column = new System.Windows.Forms.ComboBox();
            this.button_sort = new System.Windows.Forms.Button();
            this.comboBox_alg = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_asc = new System.Windows.Forms.RadioButton();
            this.radioButton_desc = new System.Windows.Forms.RadioButton();
            this.button_savefile = new System.Windows.Forms.Button();
            this.textBox_schstr = new System.Windows.Forms.TextBox();
            this.label_sch = new System.Windows.Forms.Label();
            this.button_sch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_sch_alg = new System.Windows.Forms.ComboBox();
            this.button_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_dp
            // 
            this.dataGridView_dp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dp.Location = new System.Drawing.Point(12, 22);
            this.dataGridView_dp.Name = "dataGridView_dp";
            this.dataGridView_dp.RowTemplate.Height = 23;
            this.dataGridView_dp.Size = new System.Drawing.Size(499, 354);
            this.dataGridView_dp.TabIndex = 1;
            // 
            // button_openfile
            // 
            this.button_openfile.Location = new System.Drawing.Point(11, 382);
            this.button_openfile.Name = "button_openfile";
            this.button_openfile.Size = new System.Drawing.Size(111, 90);
            this.button_openfile.TabIndex = 2;
            this.button_openfile.Text = "Open File";
            this.button_openfile.UseVisualStyleBackColor = true;
            this.button_openfile.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_column
            // 
            this.comboBox_column.FormattingEnabled = true;
            this.comboBox_column.Location = new System.Drawing.Point(128, 404);
            this.comboBox_column.Name = "comboBox_column";
            this.comboBox_column.Size = new System.Drawing.Size(121, 20);
            this.comboBox_column.TabIndex = 3;
            // 
            // button_sort
            // 
            this.button_sort.Location = new System.Drawing.Point(376, 382);
            this.button_sort.Name = "button_sort";
            this.button_sort.Size = new System.Drawing.Size(119, 42);
            this.button_sort.TabIndex = 5;
            this.button_sort.Text = "sort!";
            this.button_sort.UseVisualStyleBackColor = true;
            this.button_sort.Click += new System.EventHandler(this.button_sort_Click);
            // 
            // comboBox_alg
            // 
            this.comboBox_alg.FormattingEnabled = true;
            this.comboBox_alg.Location = new System.Drawing.Point(126, 452);
            this.comboBox_alg.Name = "comboBox_alg";
            this.comboBox_alg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_alg.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Column";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sort Algorithm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_asc);
            this.groupBox1.Controls.Add(this.radioButton_desc);
            this.groupBox1.Location = new System.Drawing.Point(255, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 66);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seq select";
            // 
            // radioButton_asc
            // 
            this.radioButton_asc.AutoSize = true;
            this.radioButton_asc.Location = new System.Drawing.Point(27, 44);
            this.radioButton_asc.Name = "radioButton_asc";
            this.radioButton_asc.Size = new System.Drawing.Size(41, 16);
            this.radioButton_asc.TabIndex = 1;
            this.radioButton_asc.TabStop = true;
            this.radioButton_asc.Text = "ASC";
            this.radioButton_asc.UseVisualStyleBackColor = true;
            this.radioButton_asc.CheckedChanged += new System.EventHandler(this.radioButton_asc_CheckedChanged);
            // 
            // radioButton_desc
            // 
            this.radioButton_desc.AutoSize = true;
            this.radioButton_desc.Location = new System.Drawing.Point(27, 21);
            this.radioButton_desc.Name = "radioButton_desc";
            this.radioButton_desc.Size = new System.Drawing.Size(47, 16);
            this.radioButton_desc.TabIndex = 0;
            this.radioButton_desc.TabStop = true;
            this.radioButton_desc.Text = "DESC";
            this.radioButton_desc.UseVisualStyleBackColor = true;
            // 
            // button_savefile
            // 
            this.button_savefile.Location = new System.Drawing.Point(376, 434);
            this.button_savefile.Name = "button_savefile";
            this.button_savefile.Size = new System.Drawing.Size(119, 42);
            this.button_savefile.TabIndex = 10;
            this.button_savefile.Text = "Save File";
            this.button_savefile.UseVisualStyleBackColor = true;
            this.button_savefile.Click += new System.EventHandler(this.button_savefile_Click);
            // 
            // textBox_schstr
            // 
            this.textBox_schstr.Location = new System.Drawing.Point(25, 512);
            this.textBox_schstr.Name = "textBox_schstr";
            this.textBox_schstr.Size = new System.Drawing.Size(137, 21);
            this.textBox_schstr.TabIndex = 11;
            // 
            // label_sch
            // 
            this.label_sch.AutoSize = true;
            this.label_sch.Location = new System.Drawing.Point(25, 494);
            this.label_sch.Name = "label_sch";
            this.label_sch.Size = new System.Drawing.Size(47, 12);
            this.label_sch.TabIndex = 12;
            this.label_sch.Text = "Search:";
            // 
            // button_sch
            // 
            this.button_sch.Location = new System.Drawing.Point(334, 509);
            this.button_sch.Name = "button_sch";
            this.button_sch.Size = new System.Drawing.Size(75, 23);
            this.button_sch.TabIndex = 13;
            this.button_sch.Text = "Search!";
            this.button_sch.UseVisualStyleBackColor = true;
            this.button_sch.Click += new System.EventHandler(this.button_sch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "Search Algorithm";
            // 
            // comboBox_sch_alg
            // 
            this.comboBox_sch_alg.FormattingEnabled = true;
            this.comboBox_sch_alg.Location = new System.Drawing.Point(193, 512);
            this.comboBox_sch_alg.Name = "comboBox_sch_alg";
            this.comboBox_sch_alg.Size = new System.Drawing.Size(121, 20);
            this.comboBox_sch_alg.TabIndex = 15;
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(415, 509);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 23);
            this.button_reset.TabIndex = 16;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 556);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.comboBox_sch_alg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_sch);
            this.Controls.Add(this.label_sch);
            this.Controls.Add(this.textBox_schstr);
            this.Controls.Add(this.button_savefile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_alg);
            this.Controls.Add(this.button_sort);
            this.Controls.Add(this.comboBox_column);
            this.Controls.Add(this.button_openfile);
            this.Controls.Add(this.dataGridView_dp);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_dp;
        private System.Windows.Forms.Button button_openfile;
        private System.Windows.Forms.ComboBox comboBox_column;
        private System.Windows.Forms.Button button_sort;
        private System.Windows.Forms.ComboBox comboBox_alg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_asc;
        private System.Windows.Forms.RadioButton radioButton_desc;
        private System.Windows.Forms.Button button_savefile;
        private System.Windows.Forms.TextBox textBox_schstr;
        private System.Windows.Forms.Label label_sch;
        private System.Windows.Forms.Button button_sch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_sch_alg;
        private System.Windows.Forms.Button button_reset;
    }
}

