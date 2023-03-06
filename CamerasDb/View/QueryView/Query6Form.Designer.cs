namespace CamerasDb.View.QueryView
{
    partial class Query6Form
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
            this.manufacturer_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Query6_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Price_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // manufacturer_ComboBox
            // 
            this.manufacturer_ComboBox.FormattingEnabled = true;
            this.manufacturer_ComboBox.Location = new System.Drawing.Point(248, 136);
            this.manufacturer_ComboBox.Name = "manufacturer_ComboBox";
            this.manufacturer_ComboBox.Size = new System.Drawing.Size(289, 28);
            this.manufacturer_ComboBox.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(248, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 32);
            this.label3.TabIndex = 36;
            this.label3.Text = "Введите стоимость";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(248, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 32);
            this.label5.TabIndex = 37;
            this.label5.Text = "Выберите производителя";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Query6_Button
            // 
            this.Query6_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Query6_Button.Location = new System.Drawing.Point(248, 265);
            this.Query6_Button.Name = "Query6_Button";
            this.Query6_Button.Size = new System.Drawing.Size(289, 66);
            this.Query6_Button.TabIndex = 35;
            this.Query6_Button.Text = "Выполнить запрос";
            this.Query6_Button.UseVisualStyleBackColor = true;
            this.Query6_Button.Click += new System.EventHandler(this.Query6_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-3, -27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 505);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // Price_NumericUpDown
            // 
            this.Price_NumericUpDown.Location = new System.Drawing.Point(248, 219);
            this.Price_NumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Price_NumericUpDown.Name = "Price_NumericUpDown";
            this.Price_NumericUpDown.Size = new System.Drawing.Size(289, 26);
            this.Price_NumericUpDown.TabIndex = 40;
            // 
            // Query6Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Price_NumericUpDown);
            this.Controls.Add(this.manufacturer_ComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Query6_Button);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Query6Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query6Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price_NumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox manufacturer_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Query6_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.NumericUpDown Price_NumericUpDown;
    }
}