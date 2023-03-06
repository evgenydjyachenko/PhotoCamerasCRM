namespace CamerasDb.View.Admin
{
    partial class AddUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.adminMenu_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.access_ComboBox = new System.Windows.Forms.ComboBox();
            this.addUser_Button = new System.Windows.Forms.Button();
            this.userName_TextBox = new System.Windows.Forms.TextBox();
            this.userSureName_TextBox = new System.Windows.Forms.TextBox();
            this.email_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(858, 449);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(70, 70);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminMenu_ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(858, 80);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // adminMenu_ToolStripButton
            // 
            this.adminMenu_ToolStripButton.AutoSize = false;
            this.adminMenu_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.adminMenu_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("adminMenu_ToolStripButton.Image")));
            this.adminMenu_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adminMenu_ToolStripButton.Margin = new System.Windows.Forms.Padding(0, 2, 15, 3);
            this.adminMenu_ToolStripButton.Name = "adminMenu_ToolStripButton";
            this.adminMenu_ToolStripButton.Size = new System.Drawing.Size(70, 45);
            this.adminMenu_ToolStripButton.Text = "Назад";
            this.adminMenu_ToolStripButton.Click += new System.EventHandler(this.adminMenu_ToolStripButton_Click);
            // 
            // access_ComboBox
            // 
            this.access_ComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Работник,",
            "Менеджер,",
            "Администратор"});
            this.access_ComboBox.FormattingEnabled = true;
            this.access_ComboBox.Location = new System.Drawing.Point(270, 293);
            this.access_ComboBox.Name = "access_ComboBox";
            this.access_ComboBox.Size = new System.Drawing.Size(291, 28);
            this.access_ComboBox.TabIndex = 22;
            // 
            // addUser_Button
            // 
            this.addUser_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUser_Button.Location = new System.Drawing.Point(270, 416);
            this.addUser_Button.Name = "addUser_Button";
            this.addUser_Button.Size = new System.Drawing.Size(291, 76);
            this.addUser_Button.TabIndex = 21;
            this.addUser_Button.Text = "Добавить пользователя";
            this.addUser_Button.UseVisualStyleBackColor = true;
            this.addUser_Button.Click += new System.EventHandler(this.addUser_Button_Click);
            // 
            // userName_TextBox
            // 
            this.userName_TextBox.Location = new System.Drawing.Point(270, 142);
            this.userName_TextBox.Name = "userName_TextBox";
            this.userName_TextBox.Size = new System.Drawing.Size(291, 26);
            this.userName_TextBox.TabIndex = 18;
            // 
            // userSureName_TextBox
            // 
            this.userSureName_TextBox.Location = new System.Drawing.Point(270, 218);
            this.userSureName_TextBox.Name = "userSureName_TextBox";
            this.userSureName_TextBox.Size = new System.Drawing.Size(291, 26);
            this.userSureName_TextBox.TabIndex = 19;
            // 
            // email_TextBox
            // 
            this.email_TextBox.Location = new System.Drawing.Point(270, 372);
            this.email_TextBox.Name = "email_TextBox";
            this.email_TextBox.Size = new System.Drawing.Size(291, 26);
            this.email_TextBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(270, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Адрес.эл почты сотрудника";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(270, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Имя сотрудника";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(270, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "Фамилия сотрудника";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(270, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Доступ сотрудника";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 524);
            this.Controls.Add(this.access_ComboBox);
            this.Controls.Add(this.addUser_Button);
            this.Controls.Add(this.userName_TextBox);
            this.Controls.Add(this.userSureName_TextBox);
            this.Controls.Add(this.email_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton adminMenu_ToolStripButton;
        private System.Windows.Forms.ComboBox access_ComboBox;
        private System.Windows.Forms.Button addUser_Button;
        private System.Windows.Forms.TextBox userName_TextBox;
        private System.Windows.Forms.TextBox userSureName_TextBox;
        private System.Windows.Forms.TextBox email_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}