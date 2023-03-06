namespace CamerasDb.View.ManagerView
{
    partial class ManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.showWorker_Button = new System.Windows.Forms.Button();
            this.openDb_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.workersList_Label = new System.Windows.Forms.Label();
            this.db_Label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dbToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.userToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.главнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фотоаппаратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workers_ListBox = new System.Windows.Forms.ListBox();
            this.unallocatedOrders_ListBox = new System.Windows.Forms.ListBox();
            this.unallocatedOrders_Label = new System.Windows.Forms.Label();
            this.distributeOrder_Button = new System.Windows.Forms.Button();
            this.onlineUser_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showWorker_Button
            // 
            this.showWorker_Button.BackColor = System.Drawing.Color.SteelBlue;
            this.showWorker_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showWorker_Button.Location = new System.Drawing.Point(669, 654);
            this.showWorker_Button.Name = "showWorker_Button";
            this.showWorker_Button.Size = new System.Drawing.Size(604, 66);
            this.showWorker_Button.TabIndex = 16;
            this.showWorker_Button.Text = "Выбрать работника";
            this.showWorker_Button.UseVisualStyleBackColor = false;
            this.showWorker_Button.Click += new System.EventHandler(this.showWorker_Button_Click);
            // 
            // openDb_Button
            // 
            this.openDb_Button.BackColor = System.Drawing.Color.SteelBlue;
            this.openDb_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openDb_Button.Location = new System.Drawing.Point(6, 654);
            this.openDb_Button.Name = "openDb_Button";
            this.openDb_Button.Size = new System.Drawing.Size(593, 66);
            this.openDb_Button.TabIndex = 17;
            this.openDb_Button.Text = "Открыть БД";
            this.openDb_Button.UseVisualStyleBackColor = false;
            this.openDb_Button.Click += new System.EventHandler(this.openDb_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InfoText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(362, 29);
            this.label4.TabIndex = 14;
            this.label4.Text = "Информация о базе данных";
            // 
            // workersList_Label
            // 
            this.workersList_Label.AutoSize = true;
            this.workersList_Label.BackColor = System.Drawing.SystemColors.InfoText;
            this.workersList_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workersList_Label.ForeColor = System.Drawing.Color.Transparent;
            this.workersList_Label.Location = new System.Drawing.Point(664, 136);
            this.workersList_Label.Name = "workersList_Label";
            this.workersList_Label.Size = new System.Drawing.Size(281, 29);
            this.workersList_Label.TabIndex = 15;
            this.workersList_Label.Text = "Список подчиненных";
            // 
            // db_Label
            // 
            this.db_Label.BackColor = System.Drawing.SystemColors.Menu;
            this.db_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.db_Label.Location = new System.Drawing.Point(6, 179);
            this.db_Label.Name = "db_Label";
            this.db_Label.Size = new System.Drawing.Size(593, 457);
            this.db_Label.TabIndex = 12;
            this.db_Label.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-6, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2150, 659);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(70, 70);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbToolStripButton,
            this.userToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 36);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(2156, 80);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dbToolStripButton
            // 
            this.dbToolStripButton.AutoSize = false;
            this.dbToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dbToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("dbToolStripButton.Image")));
            this.dbToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dbToolStripButton.Margin = new System.Windows.Forms.Padding(0, 2, 15, 3);
            this.dbToolStripButton.Name = "dbToolStripButton";
            this.dbToolStripButton.Size = new System.Drawing.Size(60, 45);
            this.dbToolStripButton.Text = "Управление БД";
            this.dbToolStripButton.Click += new System.EventHandler(this.dbToolStripButton_Click);
            // 
            // userToolStripButton
            // 
            this.userToolStripButton.AutoSize = false;
            this.userToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.userToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("userToolStripButton.Image")));
            this.userToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userToolStripButton.Margin = new System.Windows.Forms.Padding(0, 2, 15, 3);
            this.userToolStripButton.Name = "userToolStripButton";
            this.userToolStripButton.Size = new System.Drawing.Size(80, 50);
            this.userToolStripButton.Text = "Информация о работниках";
            this.userToolStripButton.Click += new System.EventHandler(this.userToolStripButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главнаяToolStripMenuItem,
            this.видToolStripMenuItem,
            this.пользователиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2156, 36);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            this.главнаяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            this.главнаяToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.главнаяToolStripMenuItem.Text = "Главная";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(166, 34);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фотоаппаратыToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.видToolStripMenuItem.Text = "Базы данных";
            // 
            // фотоаппаратыToolStripMenuItem
            // 
            this.фотоаппаратыToolStripMenuItem.Name = "фотоаппаратыToolStripMenuItem";
            this.фотоаппаратыToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.фотоаппаратыToolStripMenuItem.Text = "CamerasDb";
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(143, 29);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem1});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.оПрограммеToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem1
            // 
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            this.оПрограммеToolStripMenuItem1.Size = new System.Drawing.Size(227, 34);
            this.оПрограммеToolStripMenuItem1.Text = "О программе";
            // 
            // workers_ListBox
            // 
            this.workers_ListBox.FormattingEnabled = true;
            this.workers_ListBox.ItemHeight = 20;
            this.workers_ListBox.Location = new System.Drawing.Point(669, 179);
            this.workers_ListBox.Name = "workers_ListBox";
            this.workers_ListBox.Size = new System.Drawing.Size(604, 464);
            this.workers_ListBox.TabIndex = 18;
            // 
            // unallocatedOrders_ListBox
            // 
            this.unallocatedOrders_ListBox.FormattingEnabled = true;
            this.unallocatedOrders_ListBox.ItemHeight = 20;
            this.unallocatedOrders_ListBox.Location = new System.Drawing.Point(1340, 179);
            this.unallocatedOrders_ListBox.Name = "unallocatedOrders_ListBox";
            this.unallocatedOrders_ListBox.Size = new System.Drawing.Size(765, 464);
            this.unallocatedOrders_ListBox.TabIndex = 18;
            // 
            // unallocatedOrders_Label
            // 
            this.unallocatedOrders_Label.AutoSize = true;
            this.unallocatedOrders_Label.BackColor = System.Drawing.SystemColors.InfoText;
            this.unallocatedOrders_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unallocatedOrders_Label.ForeColor = System.Drawing.Color.Transparent;
            this.unallocatedOrders_Label.Location = new System.Drawing.Point(1335, 136);
            this.unallocatedOrders_Label.Name = "unallocatedOrders_Label";
            this.unallocatedOrders_Label.Size = new System.Drawing.Size(362, 29);
            this.unallocatedOrders_Label.TabIndex = 15;
            this.unallocatedOrders_Label.Text = "Нераспределенных заказов";
            // 
            // distributeOrder_Button
            // 
            this.distributeOrder_Button.BackColor = System.Drawing.Color.SteelBlue;
            this.distributeOrder_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distributeOrder_Button.Location = new System.Drawing.Point(1340, 654);
            this.distributeOrder_Button.Name = "distributeOrder_Button";
            this.distributeOrder_Button.Size = new System.Drawing.Size(765, 66);
            this.distributeOrder_Button.TabIndex = 19;
            this.distributeOrder_Button.Text = "Распределить заказ";
            this.distributeOrder_Button.UseVisualStyleBackColor = false;
            this.distributeOrder_Button.Click += new System.EventHandler(this.openOrder_Button_Click);
            // 
            // onlineUser_Label
            // 
            this.onlineUser_Label.AutoSize = true;
            this.onlineUser_Label.BackColor = System.Drawing.SystemColors.Highlight;
            this.onlineUser_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onlineUser_Label.ForeColor = System.Drawing.Color.Transparent;
            this.onlineUser_Label.Location = new System.Drawing.Point(1656, 80);
            this.onlineUser_Label.Name = "onlineUser_Label";
            this.onlineUser_Label.Size = new System.Drawing.Size(101, 29);
            this.onlineUser_Label.TabIndex = 22;
            this.onlineUser_Label.Text = "В сети;";
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2156, 767);
            this.Controls.Add(this.onlineUser_Label);
            this.Controls.Add(this.distributeOrder_Button);
            this.Controls.Add(this.unallocatedOrders_ListBox);
            this.Controls.Add(this.workers_ListBox);
            this.Controls.Add(this.showWorker_Button);
            this.Controls.Add(this.openDb_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unallocatedOrders_Label);
            this.Controls.Add(this.workersList_Label);
            this.Controls.Add(this.db_Label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню менеджера";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showWorker_Button;
        private System.Windows.Forms.Button openDb_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label workersList_Label;
        private System.Windows.Forms.Label db_Label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton dbToolStripButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem главнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фотоаппаратыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.ListBox workers_ListBox;
        private System.Windows.Forms.ListBox unallocatedOrders_ListBox;
        private System.Windows.Forms.Label unallocatedOrders_Label;
        private System.Windows.Forms.Button distributeOrder_Button;
        private System.Windows.Forms.ToolStripButton userToolStripButton;
        private System.Windows.Forms.Label onlineUser_Label;
    }
}