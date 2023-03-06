namespace CamerasDb.View.Admin
{
    partial class DistributeWorkerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributeWorkerForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.adminMenu_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.managers_ListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.workersAmount_Label = new System.Windows.Forms.Label();
            this.manager_TreeView = new System.Windows.Forms.TreeView();
            this.unallocatedWorkers_ListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.allocateWorker_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1317, 785);
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
            this.toolStrip1.Size = new System.Drawing.Size(1230, 80);
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
            // managers_ListBox
            // 
            this.managers_ListBox.FormattingEnabled = true;
            this.managers_ListBox.ItemHeight = 20;
            this.managers_ListBox.Location = new System.Drawing.Point(13, 125);
            this.managers_ListBox.Name = "managers_ListBox";
            this.managers_ListBox.Size = new System.Drawing.Size(597, 424);
            this.managers_ListBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 29);
            this.label2.TabIndex = 22;
            this.label2.Text = "Список менеджеров";
            // 
            // workersAmount_Label
            // 
            this.workersAmount_Label.AutoSize = true;
            this.workersAmount_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workersAmount_Label.Location = new System.Drawing.Point(611, 93);
            this.workersAmount_Label.Name = "workersAmount_Label";
            this.workersAmount_Label.Size = new System.Drawing.Size(352, 29);
            this.workersAmount_Label.TabIndex = 22;
            this.workersAmount_Label.Text = "Работников в подчинении:";
            // 
            // manager_TreeView
            // 
            this.manager_TreeView.Location = new System.Drawing.Point(616, 126);
            this.manager_TreeView.Name = "manager_TreeView";
            this.manager_TreeView.Size = new System.Drawing.Size(602, 423);
            this.manager_TreeView.TabIndex = 23;
            // 
            // unallocatedWorkers_ListBox
            // 
            this.unallocatedWorkers_ListBox.FormattingEnabled = true;
            this.unallocatedWorkers_ListBox.ItemHeight = 20;
            this.unallocatedWorkers_ListBox.Location = new System.Drawing.Point(12, 594);
            this.unallocatedWorkers_ListBox.Name = "unallocatedWorkers_ListBox";
            this.unallocatedWorkers_ListBox.Size = new System.Drawing.Size(1206, 164);
            this.unallocatedWorkers_ListBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 562);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "Нераспределенные работники";
            // 
            // allocateWorker_Button
            // 
            this.allocateWorker_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allocateWorker_Button.Location = new System.Drawing.Point(13, 765);
            this.allocateWorker_Button.Name = "allocateWorker_Button";
            this.allocateWorker_Button.Size = new System.Drawing.Size(1205, 88);
            this.allocateWorker_Button.TabIndex = 25;
            this.allocateWorker_Button.Text = "Распределить работника";
            this.allocateWorker_Button.UseVisualStyleBackColor = true;
            this.allocateWorker_Button.Click += new System.EventHandler(this.allocateWorker_Button_Click);
            // 
            // DistributeWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 881);
            this.Controls.Add(this.allocateWorker_Button);
            this.Controls.Add(this.unallocatedWorkers_ListBox);
            this.Controls.Add(this.manager_TreeView);
            this.Controls.Add(this.workersAmount_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.managers_ListBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DistributeWorkerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распределение работников";
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
        private System.Windows.Forms.ListBox managers_ListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label workersAmount_Label;
        private System.Windows.Forms.TreeView manager_TreeView;
        private System.Windows.Forms.ListBox unallocatedWorkers_ListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button allocateWorker_Button;
    }
}