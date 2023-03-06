namespace CamerasDb.View.QueryView
{
    partial class Query5Form
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
            this.label5 = new System.Windows.Forms.Label();
            this.Query5_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.manufacturer_ComboBox = new System.Windows.Forms.ComboBox();
            this.products_ComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(248, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 32);
            this.label3.TabIndex = 28;
            this.label3.Text = "Выберите фотоаппарат";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(248, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 32);
            this.label5.TabIndex = 30;
            this.label5.Text = "Выберите производителя";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Query5_Button
            // 
            this.Query5_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Query5_Button.Location = new System.Drawing.Point(248, 265);
            this.Query5_Button.Name = "Query5_Button";
            this.Query5_Button.Size = new System.Drawing.Size(289, 66);
            this.Query5_Button.TabIndex = 27;
            this.Query5_Button.Text = "Выполнить запрос";
            this.Query5_Button.UseVisualStyleBackColor = true;
            this.Query5_Button.Click += new System.EventHandler(this.Query5_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-3, -27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 505);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // manufacturer_ComboBox
            // 
            this.manufacturer_ComboBox.FormattingEnabled = true;
            this.manufacturer_ComboBox.Location = new System.Drawing.Point(248, 136);
            this.manufacturer_ComboBox.Name = "manufacturer_ComboBox";
            this.manufacturer_ComboBox.Size = new System.Drawing.Size(289, 28);
            this.manufacturer_ComboBox.TabIndex = 33;
            // 
            // products_ComboBox
            // 
            this.products_ComboBox.FormattingEnabled = true;
            this.products_ComboBox.Location = new System.Drawing.Point(248, 219);
            this.products_ComboBox.Name = "products_ComboBox";
            this.products_ComboBox.Size = new System.Drawing.Size(289, 28);
            this.products_ComboBox.TabIndex = 33;
            // 
            // Query5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.products_ComboBox);
            this.Controls.Add(this.manufacturer_ComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Query5_Button);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Query5Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query4Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Query5_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox manufacturer_ComboBox;
        public System.Windows.Forms.ComboBox products_ComboBox;
    }
}