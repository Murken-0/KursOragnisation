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
			this.dataView = new System.Windows.Forms.DataGridView();
			this.addButton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
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
			this.dataView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
			this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataView.Location = new System.Drawing.Point(13, 70);
			this.dataView.MultiSelect = false;
			this.dataView.Name = "dataView";
			this.dataView.ReadOnly = true;
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
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(211, 30);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(179, 34);
			this.button2.TabIndex = 4;
			this.button2.Text = "Изменить";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(410, 30);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(179, 34);
			this.button3.TabIndex = 5;
			this.button3.Text = "Удалить";
			this.button3.UseVisualStyleBackColor = true;
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
			this.diskTool.Click += new System.EventHandler(this.diskTool_Click);
			// 
			// reviewTool
			// 
			this.reviewTool.Name = "reviewTool";
			this.reviewTool.Size = new System.Drawing.Size(204, 22);
			this.reviewTool.Text = "Отзывы";
			// 
			// offerTool
			// 
			this.offerTool.Name = "offerTool";
			this.offerTool.Size = new System.Drawing.Size(204, 22);
			this.offerTool.Text = "Предложения";
			// 
			// manufacturerTool
			// 
			this.manufacturerTool.Name = "manufacturerTool";
			this.manufacturerTool.Size = new System.Drawing.Size(204, 22);
			this.manufacturerTool.Text = "Производители";
			// 
			// typeTool
			// 
			this.typeTool.Name = "typeTool";
			this.typeTool.Size = new System.Drawing.Size(204, 22);
			this.typeTool.Text = "Типы носителей";
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
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.dataView);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(816, 489);
			this.MinimumSize = new System.Drawing.Size(816, 489);
			this.Name = "MainForm";
			this.Text = "MainForm";
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
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