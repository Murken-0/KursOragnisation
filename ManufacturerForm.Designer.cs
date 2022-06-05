namespace KursOragnisation
{
	partial class ManufacturerForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.nameText = new System.Windows.Forms.TextBox();
			this.datePicker = new System.Windows.Forms.DateTimePicker();
			this.countryText = new System.Windows.Forms.TextBox();
			this.founderText = new System.Windows.Forms.TextBox();
			this.button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(45, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 18);
			this.label2.TabIndex = 12;
			this.label2.Text = "Название:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(27, 125);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 18);
			this.label3.TabIndex = 14;
			this.label3.Text = "Основатели:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(62, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 18);
			this.label4.TabIndex = 15;
			this.label4.Text = "Страна:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(38, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 36);
			this.label5.TabIndex = 16;
			this.label5.Text = "Дата\r\nоснования:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nameText
			// 
			this.nameText.Location = new System.Drawing.Point(130, 22);
			this.nameText.Name = "nameText";
			this.nameText.Size = new System.Drawing.Size(200, 20);
			this.nameText.TabIndex = 17;
			// 
			// datePicker
			// 
			this.datePicker.Location = new System.Drawing.Point(130, 58);
			this.datePicker.Name = "datePicker";
			this.datePicker.Size = new System.Drawing.Size(200, 20);
			this.datePicker.TabIndex = 18;
			// 
			// countryText
			// 
			this.countryText.Location = new System.Drawing.Point(130, 92);
			this.countryText.Name = "countryText";
			this.countryText.Size = new System.Drawing.Size(200, 20);
			this.countryText.TabIndex = 19;
			// 
			// founderText
			// 
			this.founderText.Location = new System.Drawing.Point(130, 127);
			this.founderText.Name = "founderText";
			this.founderText.Size = new System.Drawing.Size(200, 20);
			this.founderText.TabIndex = 20;
			// 
			// button
			// 
			this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button.Location = new System.Drawing.Point(66, 166);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(224, 33);
			this.button.TabIndex = 21;
			this.button.Text = "Добавить";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// ManufacturerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 220);
			this.Controls.Add(this.button);
			this.Controls.Add(this.founderText);
			this.Controls.Add(this.countryText);
			this.Controls.Add(this.datePicker);
			this.Controls.Add(this.nameText);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ManufacturerForm";
			this.Text = "ManufacturerForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManufacturerForm_FormClosing);
			this.Load += new System.EventHandler(this.ManufacturerForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox nameText;
		private System.Windows.Forms.DateTimePicker datePicker;
		private System.Windows.Forms.TextBox countryText;
		private System.Windows.Forms.TextBox founderText;
		private System.Windows.Forms.Button button;
	}
}