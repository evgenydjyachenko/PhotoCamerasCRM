namespace CamerasDb.View.QueryView
{
    partial class Query8Form
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
            this.label5 = new System.Windows.Forms.Label();
            this.Query8_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // manufacturer_ComboBox
            // 
            this.manufacturer_ComboBox.FormattingEnabled = true;
            this.manufacturer_ComboBox.Location = new System.Drawing.Point(248, 181);
            this.manufacturer_ComboBox.Name = "manufacturer_ComboBox";
            this.manufacturer_ComboBox.Size = new System.Drawing.Size(289, 28);
            this.manufacturer_ComboBox.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(248, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 32);
            this.label5.TabIndex = 42;
            this.label5.Text = "Выберите производителя";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Query8_Button
            // 
            this.Query8_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Query8_Button.Location = new System.Drawing.Point(248, 225);
            this.Query8_Button.Name = "Query8_Button";
            this.Query8_Button.Size = new System.Drawing.Size(289, 66);
            this.Query8_Button.TabIndex = 41;
            this.Query8_Button.Text = "Выполнить запрос";
            this.Query8_Button.UseVisualStyleBackColor = true;
            this.Query8_Button.Click += new System.EventHandler(this.Query8_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-3, -27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 505);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // Query8Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.manufacturer_ComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Query8_Button);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Query8Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query8Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox manufacturer_ComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Query8_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}