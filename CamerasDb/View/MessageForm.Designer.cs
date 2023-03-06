namespace CamerasDb.Services.MailService
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.messageBody_TextBox = new System.Windows.Forms.TextBox();
            this.sendMessage_Button = new System.Windows.Forms.Button();
            this.subjectMessage_TextBox = new System.Windows.Forms.TextBox();
            this.mailAdress_TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-24, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(825, 460);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // messageBody_TextBox
            // 
            this.messageBody_TextBox.Location = new System.Drawing.Point(79, 107);
            this.messageBody_TextBox.Multiline = true;
            this.messageBody_TextBox.Name = "messageBody_TextBox";
            this.messageBody_TextBox.Size = new System.Drawing.Size(656, 260);
            this.messageBody_TextBox.TabIndex = 2;
            this.messageBody_TextBox.Text = "Введите сообщение...";
            // 
            // sendMessage_Button
            // 
            this.sendMessage_Button.Location = new System.Drawing.Point(157, 382);
            this.sendMessage_Button.Name = "sendMessage_Button";
            this.sendMessage_Button.Size = new System.Drawing.Size(492, 56);
            this.sendMessage_Button.TabIndex = 3;
            this.sendMessage_Button.Text = "Отправить сообщение";
            this.sendMessage_Button.UseVisualStyleBackColor = true;
            this.sendMessage_Button.Click += new System.EventHandler(this.sendMessage_Button_Click);
            // 
            // subjectMessage_TextBox
            // 
            this.subjectMessage_TextBox.Location = new System.Drawing.Point(79, 43);
            this.subjectMessage_TextBox.Name = "subjectMessage_TextBox";
            this.subjectMessage_TextBox.Size = new System.Drawing.Size(656, 26);
            this.subjectMessage_TextBox.TabIndex = 4;
            this.subjectMessage_TextBox.Text = "Тема сообщения...";
            // 
            // mailAdress_TextBox
            // 
            this.mailAdress_TextBox.Location = new System.Drawing.Point(79, 75);
            this.mailAdress_TextBox.Name = "mailAdress_TextBox";
            this.mailAdress_TextBox.Size = new System.Drawing.Size(656, 26);
            this.mailAdress_TextBox.TabIndex = 4;
            this.mailAdress_TextBox.Text = "Введите свой адрес эл.почты...";
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.mailAdress_TextBox);
            this.Controls.Add(this.subjectMessage_TextBox);
            this.Controls.Add(this.sendMessage_Button);
            this.Controls.Add(this.messageBody_TextBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Письмо разработчику";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox messageBody_TextBox;
        private System.Windows.Forms.Button sendMessage_Button;
        private System.Windows.Forms.TextBox subjectMessage_TextBox;
        private System.Windows.Forms.TextBox mailAdress_TextBox;
    }
}