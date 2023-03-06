namespace CamerasDb.View.QueryView
{
    partial class Query2Form
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Query2_Button = new System.Windows.Forms.Button();
            this.Price2_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Price1_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.manufacturer_ComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price2_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price1_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-18, -28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(825, 517);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(249, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "до";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(249, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "от";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(249, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Введите стоимость";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(249, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 32);
            this.label5.TabIndex = 15;
            this.label5.Text = "Выберите производителя";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Query2_Button
            // 
            this.Query2_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Query2_Button.Location = new System.Drawing.Point(249, 331);
            this.Query2_Button.Name = "Query2_Button";
            this.Query2_Button.Size = new System.Drawing.Size(289, 66);
            this.Query2_Button.TabIndex = 11;
            this.Query2_Button.Text = "Выполнить запрос";
            this.Query2_Button.UseVisualStyleBackColor = true;
            this.Query2_Button.Click += new System.EventHandler(this.Query2_Button_Click_1);
            // 
            // Price2_NumericUpDown
            // 
            this.Price2_NumericUpDown.Location = new System.Drawing.Point(249, 299);
            this.Price2_NumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Price2_NumericUpDown.Name = "Price2_NumericUpDown";
            this.Price2_NumericUpDown.Size = new System.Drawing.Size(289, 26);
            this.Price2_NumericUpDown.TabIndex = 10;
            // 
            // Price1_NumericUpDown
            // 
            this.Price1_NumericUpDown.Location = new System.Drawing.Point(249, 222);
            this.Price1_NumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Price1_NumericUpDown.Name = "Price1_NumericUpDown";
            this.Price1_NumericUpDown.Size = new System.Drawing.Size(289, 26);
            this.Price1_NumericUpDown.TabIndex = 9;
            // 
            // manufacturer_ComboBox
            // 
            this.manufacturer_ComboBox.FormattingEnabled = true;
            this.manufacturer_ComboBox.Location = new System.Drawing.Point(249, 102);
            this.manufacturer_ComboBox.Name = "manufacturer_ComboBox";
            this.manufacturer_ComboBox.Size = new System.Drawing.Size(289, 28);
            this.manufacturer_ComboBox.TabIndex = 8;
            // 
            // Query2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Query2_Button);
            this.Controls.Add(this.Price2_NumericUpDown);
            this.Controls.Add(this.Price1_NumericUpDown);
            this.Controls.Add(this.manufacturer_ComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Query2Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query2Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price2_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price1_NumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Query2_Button;
        public System.Windows.Forms.NumericUpDown Price2_NumericUpDown;
        public System.Windows.Forms.NumericUpDown Price1_NumericUpDown;
        public System.Windows.Forms.ComboBox manufacturer_ComboBox;
    }
}