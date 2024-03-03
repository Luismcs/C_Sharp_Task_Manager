namespace WindowsFormsApp1
{
    partial class Form3
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
            this.Form3lbl1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Form3_lbl1 = new System.Windows.Forms.Label();
            this.Form3_dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Form3_dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form3lbl1
            // 
            this.Form3lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Form3lbl1.Location = new System.Drawing.Point(200, 419);
            this.Form3lbl1.Margin = new System.Windows.Forms.Padding(4);
            this.Form3lbl1.Name = "Form3lbl1";
            this.Form3lbl1.Size = new System.Drawing.Size(132, 30);
            this.Form3lbl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(381, 415);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update State";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3_lbl1
            // 
            this.Form3_lbl1.AutoSize = true;
            this.Form3_lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Form3_lbl1.Location = new System.Drawing.Point(94, 422);
            this.Form3_lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Form3_lbl1.Name = "Form3_lbl1";
            this.Form3_lbl1.Size = new System.Drawing.Size(86, 25);
            this.Form3_lbl1.TabIndex = 3;
            this.Form3_lbl1.Text = "Task ID:";
            // 
            // Form3_dataGridView1
            // 
            this.Form3_dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Form3_dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.Form3_dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Form3_dataGridView1.Location = new System.Drawing.Point(99, 49);
            this.Form3_dataGridView1.Name = "Form3_dataGridView1";
            this.Form3_dataGridView1.RowHeadersWidth = 51;
            this.Form3_dataGridView1.RowTemplate.Height = 24;
            this.Form3_dataGridView1.Size = new System.Drawing.Size(693, 322);
            this.Form3_dataGridView1.TabIndex = 4;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(122)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Form3_dataGridView1);
            this.Controls.Add(this.Form3_lbl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Form3lbl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.Form3_dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Form3lbl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Form3_lbl1;
        private System.Windows.Forms.DataGridView Form3_dataGridView1;
    }
}