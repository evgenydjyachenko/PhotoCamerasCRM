namespace CamerasDb.View.ManagerView
{
    partial class UserStatisticForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserStatisticForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.managerMenu_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.openedOrders_ListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.closedOrders_ListBox = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.overdueOrders_ListBox = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cancelledOrders_ListBox = new System.Windows.Forms.ListBox();
            this.allWorkerOrdersAmount_Label = new System.Windows.Forms.Label();
            this.user_Label = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1076, 80);
            this.toolStrip1.TabIndex = 11;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 150);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 655);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.openedOrders_ListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1056, 622);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "В работе";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // openedOrders_ListBox
            // 
            this.openedOrders_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openedOrders_ListBox.FormattingEnabled = true;
            this.openedOrders_ListBox.ItemHeight = 20;
            this.openedOrders_ListBox.Location = new System.Drawing.Point(3, 3);
            this.openedOrders_ListBox.Name = "openedOrders_ListBox";
            this.openedOrders_ListBox.Size = new System.Drawing.Size(1050, 616);
            this.openedOrders_ListBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.closedOrders_ListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1056, 622);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Выполнены";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // closedOrders_ListBox
            // 
            this.closedOrders_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closedOrders_ListBox.FormattingEnabled = true;
            this.closedOrders_ListBox.ItemHeight = 20;
            this.closedOrders_ListBox.Location = new System.Drawing.Point(3, 3);
            this.closedOrders_ListBox.Name = "closedOrders_ListBox";
            this.closedOrders_ListBox.Size = new System.Drawing.Size(1050, 616);
            this.closedOrders_ListBox.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.overdueOrders_ListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1056, 622);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Просрочены";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // overdueOrders_ListBox
            // 
            this.overdueOrders_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overdueOrders_ListBox.FormattingEnabled = true;
            this.overdueOrders_ListBox.ItemHeight = 20;
            this.overdueOrders_ListBox.Location = new System.Drawing.Point(0, 0);
            this.overdueOrders_ListBox.Name = "overdueOrders_ListBox";
            this.overdueOrders_ListBox.Size = new System.Drawing.Size(1056, 622);
            this.overdueOrders_ListBox.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cancelledOrders_ListBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1056, 622);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Отменены";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cancelledOrders_ListBox
            // 
            this.cancelledOrders_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelledOrders_ListBox.FormattingEnabled = true;
            this.cancelledOrders_ListBox.ItemHeight = 20;
            this.cancelledOrders_ListBox.Location = new System.Drawing.Point(0, 0);
            this.cancelledOrders_ListBox.Name = "cancelledOrders_ListBox";
            this.cancelledOrders_ListBox.Size = new System.Drawing.Size(1056, 622);
            this.cancelledOrders_ListBox.TabIndex = 1;
            // 
            // allWorkerOrdersAmount_Label
            // 
            this.allWorkerOrdersAmount_Label.AutoSize = true;
            this.allWorkerOrdersAmount_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allWorkerOrdersAmount_Label.Location = new System.Drawing.Point(14, 118);
            this.allWorkerOrdersAmount_Label.Name = "allWorkerOrdersAmount_Label";
            this.allWorkerOrdersAmount_Label.Size = new System.Drawing.Size(197, 29);
            this.allWorkerOrdersAmount_Label.TabIndex = 13;
            this.allWorkerOrdersAmount_Label.Text = "Всего заказов:";
            // 
            // user_Label
            // 
            this.user_Label.AutoSize = true;
            this.user_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.user_Label.Location = new System.Drawing.Point(12, 80);
            this.user_Label.Name = "user_Label";
            this.user_Label.Size = new System.Drawing.Size(27, 29);
            this.user_Label.TabIndex = 13;
            this.user_Label.Text = "1";
            // 
            // UserStatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 807);
            this.Controls.Add(this.user_Label);
            this.Controls.Add(this.allWorkerOrdersAmount_Label);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UserStatisticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о сотрудниках";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton managerMenu_ToolStripButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label allWorkerOrdersAmount_Label;
        private System.Windows.Forms.ListBox openedOrders_ListBox;
        private System.Windows.Forms.ListBox closedOrders_ListBox;
        private System.Windows.Forms.ListBox overdueOrders_ListBox;
        private System.Windows.Forms.Label user_Label;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox cancelledOrders_ListBox;
    }
}