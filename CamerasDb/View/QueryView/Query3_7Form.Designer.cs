namespace CamerasDb.View.QueryView
{
    partial class Query3_7Form
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Query3_7_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.date1_DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.date2_DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(249, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "до";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(249, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 32);
            this.label2.TabIndex = 22;
            this.label2.Text = "от";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(189, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(416, 32);
            this.label5.TabIndex = 24;
            this.label5.Text = "Введите период времени продаж";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Query3_7_Button
            // 
            this.Query3_7_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Query3_7_Button.Location = new System.Drawing.Point(249, 311);
            this.Query3_7_Button.Name = "Query3_7_Button";
            this.Query3_7_Button.Size = new System.Drawing.Size(289, 66);
            this.Query3_7_Button.TabIndex = 20;
            this.Query3_7_Button.Text = "Выполнить запрос";
            this.Query3_7_Button.UseVisualStyleBackColor = true;
            this.Query3_7_Button.Click += new System.EventHandler(this.Query3_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-3, -27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 505);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // date1_DateTimePicker1
            // 
            this.date1_DateTimePicker1.Location = new System.Drawing.Point(249, 175);
            this.date1_DateTimePicker1.Name = "date1_DateTimePicker1";
            this.date1_DateTimePicker1.Size = new System.Drawing.Size(289, 26);
            this.date1_DateTimePicker1.TabIndex = 25;
            // 
            // date2_DateTimePicker2
            // 
            this.date2_DateTimePicker2.Location = new System.Drawing.Point(249, 268);
            this.date2_DateTimePicker2.Name = "date2_DateTimePicker2";
            this.date2_DateTimePicker2.Size = new System.Drawing.Size(289, 26);
            this.date2_DateTimePicker2.TabIndex = 25;
            // 
            // Query3_7Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.date2_DateTimePicker2);
            this.Controls.Add(this.date1_DateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Query3_7_Button);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Query3_7Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query3Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Query3_7_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.DateTimePicker date1_DateTimePicker1;
        public System.Windows.Forms.DateTimePicker date2_DateTimePicker2;
    }
}