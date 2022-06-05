namespace KursOragnisation
{
	partial class MainForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataView = new System.Windows.Forms.DataGridView();
			this.addButton = new System.Windows.Forms.Button();
			this.updateButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.diskTool = new System.Windows.Forms.ToolStripMenuItem();
			this.reviewTool = new System.Windows.Forms.ToolStripMenuItem();
			this.offerTool = new System.Windows.Forms.ToolStripMenuItem();
			this.manufacturerTool = new System.Windows.Forms.ToolStripMenuItem();
			this.typeTool = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataView
			// 
			this.dataView.AllowUserToAddRows = false;
			this.dataView.AllowUserToDeleteRows = false;
			this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			this.dataView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
			this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MistyRose;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataView.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataView.Location = new System.Drawing.Point(13, 70);
			this.dataView.MultiSelect = false;
			this.dataView.Name = "dataView";
			this.dataView.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PapayaWhip;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataView.Size = new System.Drawing.Size(775, 368);
			this.dataView.TabIndex = 2;
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(13, 30);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(179, 34);
			this.addButton.TabIndex = 3;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(211, 30);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(179, 34);
			this.updateButton.TabIndex = 4;
			this.updateButton.Text = "Изменить";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(410, 30);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(179, 34);
			this.deleteButton.TabIndex = 5;
			this.deleteButton.Text = "Удалить";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(609, 30);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(179, 34);
			this.button4.TabIndex = 6;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diskTool,
            this.reviewTool,
            this.offerTool,
            this.manufacturerTool,
            this.typeTool});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 20);
			this.toolStripMenuItem1.Text = "Таблицы";
			// 
			// diskTool
			// 
			this.diskTool.Name = "diskTool";
			this.diskTool.Size = new System.Drawing.Size(204, 22);
			this.diskTool.Text = "Носители информации";
			this.diskTool.Click += new System.EventHandler(this.DiskTool_Click);
			// 
			// reviewTool
			// 
			this.reviewTool.Name = "reviewTool";
			this.reviewTool.Size = new System.Drawing.Size(204, 22);
			this.reviewTool.Text = "Отзывы";
			this.reviewTool.Click += new System.EventHandler(this.ReviewTool_Click);
			// 
			// offerTool
			// 
			this.offerTool.Name = "offerTool";
			this.offerTool.Size = new System.Drawing.Size(204, 22);
			this.offerTool.Text = "Предложения";
			this.offerTool.Click += new System.EventHandler(this.OfferTool_Click);
			// 
			// manufacturerTool
			// 
			this.manufacturerTool.Name = "manufacturerTool";
			this.manufacturerTool.Size = new System.Drawing.Size(204, 22);
			this.manufacturerTool.Text = "Производители";
			this.manufacturerTool.Click += new System.EventHandler(this.ManufacturerTool_Click);
			// 
			// typeTool
			// 
			this.typeTool.Name = "typeTool";
			this.typeTool.Size = new System.Drawing.Size(204, 22);
			this.typeTool.Text = "Типы носителей";
			this.typeTool.Click += new System.EventHandler(this.TypeTool_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.dataView);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(816, 489);
			this.MinimumSize = new System.Drawing.Size(816, 489);
			this.Name = "MainForm";
			this.Text = "отк";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView dataView;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem diskTool;
		private System.Windows.Forms.ToolStripMenuItem reviewTool;
		private System.Windows.Forms.ToolStripMenuItem offerTool;
		private System.Windows.Forms.ToolStripMenuItem manufacturerTool;
		private System.Windows.Forms.ToolStripMenuItem typeTool;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}