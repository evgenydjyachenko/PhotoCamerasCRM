namespace CamerasDb.View.ManagerView
{
    partial class OrderInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderInfoForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.workers_Listbox = new System.Windows.Forms.ListBox();
            this.distribute_Button = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.managerMenu_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.workerId_TextBox = new System.Windows.Forms.TextBox();
            this.orderInfo_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-8, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1499, 836);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // workers_Listbox
            // 
            this.workers_Listbox.FormattingEnabled = true;
            this.workers_Listbox.ItemHeight = 20;
            this.workers_Listbox.Location = new System.Drawing.Point(45, 405);
            this.workers_Listbox.Name = "workers_Listbox";
            this.workers_Listbox.Size = new System.Drawing.Size(1303, 444);
            this.workers_Listbox.TabIndex = 1;
            // 
            // distribute_Button
            // 
            this.distribute_Button.BackColor = System.Drawing.Color.SteelBlue;
            this.distribute_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distribute_Button.Image = ((System.Drawing.Image)(resources.GetObject("distribute_Button.Image")));
            this.distribute_Button.Location = new System.Drawing.Point(583, 244);
            this.distribute_Button.Name = "distribute_Button";
            this.distribute_Button.Size = new System.Drawing.Size(226, 158);
            this.distribute_Button.TabIndex = 2;
            this.distribute_Button.UseVisualStyleBackColor = false;
            this.distribute_Button.Click += new System.EventHandler(this.distribute_Button_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(70, 70);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managerMenu_ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1397, 80);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // managerMenu_ToolStripButton
            // 
            this.managerMenu_ToolStripButton.AutoSize = false;
            this.managerMenu_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.managerMenu_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("managerMenu_ToolStripButton.Image")));
            this.managerMenu_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.managerMenu_ToolStripButton.Margin = new System.Windows.Forms.Padding(0, 2, 15, 3);
            this.managerMenu_ToolStripButton.Name = "managerMenu_ToolStripButton";
            this.managerMenu_ToolStripButton.Size = new System.Drawing.Size(70, 45);
            this.managerMenu_ToolStripButton.Text = "Назад";
            this.managerMenu_ToolStripButton.Click += new System.EventHandler(this.managerMenu_ToolStripButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(40, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Информация о заказе";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Список работников";
            // 
            // workerId_TextBox
            // 
            this.workerId_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workerId_TextBox.Location = new System.Drawing.Point(888, 364);
            this.workerId_TextBox.Name = "workerId_TextBox";
            this.workerId_TextBox.Size = new System.Drawing.Size(460, 35);
            this.workerId_TextBox.TabIndex = 16;
            this.workerId_TextBox.Text = "Введите имя или фамилию работника";
            this.workerId_TextBox.TextChanged += new System.EventHandler(this.workerId_TextBox_TextChanged);
            // 
            // orderInfo_Label
            // 
            this.orderInfo_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orderInfo_Label.Location = new System.Drawing.Point(45, 134);
            this.orderInfo_Label.Name = "orderInfo_Label";
            this.orderInfo_Label.Size = new System.Drawing.Size(1303, 107);
            this.orderInfo_Label.TabIndex = 17;
            this.orderInfo_Label.Text = "label3";
            // 
            // OrderInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 888);
            this.Controls.Add(this.orderInfo_Label);
            this.Controls.Add(this.workerId_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.distribute_Button);
            this.Controls.Add(this.workers_Listbox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OrderInfoForm";
            this.Text = "OrderInfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox workers_Listbox;
        private System.Windows.Forms.Button distribute_Button;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton managerMenu_ToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox workerId_TextBox;
        private System.Windows.Forms.Label orderInfo_Label;
    }
}