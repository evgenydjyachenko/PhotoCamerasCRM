namespace CamerasDb.View
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.sendToEmail_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.email_TextBox = new System.Windows.Forms.TextBox();
            this.access_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userName_TextBox = new System.Windows.Forms.TextBox();
            this.userSureName_TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-8, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(823, 493);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(247, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите доступ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sendToEmail_Button
            // 
            this.sendToEmail_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendToEmail_Button.Location = new System.Drawing.Point(247, 338);
            this.sendToEmail_Button.Name = "sendToEmail_Button";
            this.sendToEmail_Button.Size = new System.Drawing.Size(291, 76);
            this.sendToEmail_Button.TabIndex = 3;
            this.sendToEmail_Button.Text = "Зарегистрироваться";
            this.sendToEmail_Button.UseVisualStyleBackColor = true;
            this.sendToEmail_Button.Click += new System.EventHandler(this.sendToEmail_Button_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(247, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите адрес.эл почты";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // email_TextBox
            // 
            this.email_TextBox.Location = new System.Drawing.Point(247, 294);
            this.email_TextBox.Name = "email_TextBox";
            this.email_TextBox.Size = new System.Drawing.Size(291, 26);
            this.email_TextBox.TabIndex = 2;
            // 
            // access_ComboBox
            // 
            this.access_ComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Работник,",
            "Менеджер,",
            "Администратор"});
            this.access_ComboBox.FormattingEnabled = true;
            this.access_ComboBox.Items.AddRange(new object[] {
            "Работник",
            "Менеджер",
            "Администратор"});
            this.access_ComboBox.Location = new System.Drawing.Point(247, 215);
            this.access_ComboBox.Name = "access_ComboBox";
            this.access_ComboBox.Size = new System.Drawing.Size(291, 28);
            this.access_ComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(247, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Введите имя";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(247, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Введите фамилию";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userName_TextBox
            // 
            this.userName_TextBox.Location = new System.Drawing.Point(247, 64);
            this.userName_TextBox.Name = "userName_TextBox";
            this.userName_TextBox.Size = new System.Drawing.Size(291, 26);
            this.userName_TextBox.TabIndex = 2;
            // 
            // userSureName_TextBox
            // 
            this.userSureName_TextBox.Location = new System.Drawing.Point(247, 140);
            this.userSureName_TextBox.Name = "userSureName_TextBox";
            this.userSureName_TextBox.Size = new System.Drawing.Size(291, 26);
            this.userSureName_TextBox.TabIndex = 2;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.access_ComboBox);
            this.Controls.Add(this.sendToEmail_Button);
            this.Controls.Add(this.userName_TextBox);
            this.Controls.Add(this.userSureName_TextBox);
            this.Controls.Add(this.email_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendToEmail_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox email_TextBox;
        private System.Windows.Forms.ComboBox access_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userName_TextBox;
        private System.Windows.Forms.TextBox userSureName_TextBox;
    }
}