﻿namespace KursOragnisation
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataView = new System.Windows.Forms.DataGridView();
			this.addButton = new System.Windows.Forms.Button();
			this.updateButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.trunkButton = new System.Windows.Forms.Button();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.diskTool = new System.Windows.Forms.ToolStripMenuItem();
			this.reviewTool = new System.Windows.Forms.ToolStripMenuItem();
			this.offerTool = new System.Windows.Forms.ToolStripMenuItem();
			this.manufacturerTool = new System.Windows.Forms.ToolStripMenuItem();
			this.typeTool = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.выборкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reviewCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.avgratingAfter2019ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.поздапросВWHEREToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выводVIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findButton = new System.Windows.Forms.Button();
			this.findingValueText = new System.Windows.Forms.TextBox();
			this.paramsForFindingCombo = new System.Windows.Forms.ComboBox();
			this.disksCombo = new System.Windows.Forms.ComboBox();
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
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.MistyRose;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataView.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataView.Location = new System.Drawing.Point(13, 70);
			this.dataView.MultiSelect = false;
			this.dataView.Name = "dataView";
			this.dataView.ReadOnly = true;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PapayaWhip;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
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
			// trunkButton
			// 
			this.trunkButton.Location = new System.Drawing.Point(609, 30);
			this.trunkButton.Name = "trunkButton";
			this.trunkButton.Size = new System.Drawing.Size(179, 34);
			this.trunkButton.TabIndex = 6;
			this.trunkButton.Text = "Очистить таблицу";
			this.trunkButton.UseVisualStyleBackColor = true;
			this.trunkButton.Click += new System.EventHandler(this.TrunkButton_Click);
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
            this.toolStripMenuItem1,
            this.выборкиToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// выборкиToolStripMenuItem
			// 
			this.выборкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reviewCountToolStripMenuItem,
            this.avgratingAfter2019ToolStripMenuItem,
            this.поздапросВWHEREToolStripMenuItem,
            this.выводVIEWToolStripMenuItem});
			this.выборкиToolStripMenuItem.Name = "выборкиToolStripMenuItem";
			this.выборкиToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
			this.выборкиToolStripMenuItem.Text = "Выборки";
			// 
			// reviewCountToolStripMenuItem
			// 
			this.reviewCountToolStripMenuItem.Name = "reviewCountToolStripMenuItem";
			this.reviewCountToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.reviewCountToolStripMenuItem.Text = "Группировка";
			this.reviewCountToolStripMenuItem.Click += new System.EventHandler(this.ReviewCountToolStripMenuItem_Click);
			// 
			// avgratingAfter2019ToolStripMenuItem
			// 
			this.avgratingAfter2019ToolStripMenuItem.Name = "avgratingAfter2019ToolStripMenuItem";
			this.avgratingAfter2019ToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.avgratingAfter2019ToolStripMenuItem.Text = "Подзапрос в FROM";
			this.avgratingAfter2019ToolStripMenuItem.Click += new System.EventHandler(this.AvgratingAfter2019ToolStripMenuItem_Click);
			// 
			// поздапросВWHEREToolStripMenuItem
			// 
			this.поздапросВWHEREToolStripMenuItem.Name = "поздапросВWHEREToolStripMenuItem";
			this.поздапросВWHEREToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.поздапросВWHEREToolStripMenuItem.Text = "Поздапрос в SELECT и WHERE + ANY";
			this.поздапросВWHEREToolStripMenuItem.Click += new System.EventHandler(this.AllSSDToolStripMenuItem_Click);
			// 
			// выводVIEWToolStripMenuItem
			// 
			this.выводVIEWToolStripMenuItem.Name = "выводVIEWToolStripMenuItem";
			this.выводVIEWToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.выводVIEWToolStripMenuItem.Text = "Вывод VIEW";
			this.выводVIEWToolStripMenuItem.Click += new System.EventHandler(this.ViewToolStripMenuItem_Click);
			// 
			// findButton
			// 
			this.findButton.Location = new System.Drawing.Point(713, 444);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(75, 23);
			this.findButton.TabIndex = 7;
			this.findButton.Text = "Найти";
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.FindButton_Click);
			// 
			// findingValueText
			// 
			this.findingValueText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.findingValueText.Location = new System.Drawing.Point(576, 445);
			this.findingValueText.Name = "findingValueText";
			this.findingValueText.Size = new System.Drawing.Size(133, 21);
			this.findingValueText.TabIndex = 8;
			// 
			// paramsForFindingCombo
			// 
			this.paramsForFindingCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.paramsForFindingCombo.FormattingEnabled = true;
			this.paramsForFindingCombo.Items.AddRange(new object[] {
            "Средняя цена выше, чем:",
            "Средняя цена ниже, чем:",
            "Рейтинг выше, чем:",
            "Рейтинг ниже, чем:"});
			this.paramsForFindingCombo.Location = new System.Drawing.Point(413, 445);
			this.paramsForFindingCombo.Name = "paramsForFindingCombo";
			this.paramsForFindingCombo.Size = new System.Drawing.Size(159, 21);
			this.paramsForFindingCombo.TabIndex = 9;
			this.paramsForFindingCombo.Text = "Параметры для поиска";
			// 
			// disksCombo
			// 
			this.disksCombo.FormattingEnabled = true;
			this.disksCombo.Location = new System.Drawing.Point(576, 445);
			this.disksCombo.Name = "disksCombo";
			this.disksCombo.Size = new System.Drawing.Size(134, 21);
			this.disksCombo.TabIndex = 10;
			this.disksCombo.Text = "Диск";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 473);
			this.Controls.Add(this.disksCombo);
			this.Controls.Add(this.paramsForFindingCombo);
			this.Controls.Add(this.findingValueText);
			this.Controls.Add(this.findButton);
			this.Controls.Add(this.trunkButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.dataView);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Муравьев БСБО-01-20 Вариант 37";
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
		private System.Windows.Forms.Button trunkButton;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem diskTool;
		private System.Windows.Forms.ToolStripMenuItem reviewTool;
		private System.Windows.Forms.ToolStripMenuItem offerTool;
		private System.Windows.Forms.ToolStripMenuItem manufacturerTool;
		private System.Windows.Forms.ToolStripMenuItem typeTool;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.TextBox findingValueText;
		private System.Windows.Forms.ComboBox paramsForFindingCombo;
		private System.Windows.Forms.ComboBox disksCombo;
		private System.Windows.Forms.ToolStripMenuItem выборкиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reviewCountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem avgratingAfter2019ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem поздапросВWHEREToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выводVIEWToolStripMenuItem;
	}
}