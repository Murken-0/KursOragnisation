namespace KursOragnisation
{
	partial class OfferForm
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
			this.diskCombo = new System.Windows.Forms.ComboBox();
			this.shopText = new System.Windows.Forms.TextBox();
			this.urlText = new System.Windows.Forms.TextBox();
			this.priceText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// diskCombo
			// 
			this.diskCombo.FormattingEnabled = true;
			this.diskCombo.Location = new System.Drawing.Point(128, 35);
			this.diskCombo.Name = "diskCombo";
			this.diskCombo.Size = new System.Drawing.Size(219, 21);
			this.diskCombo.TabIndex = 0;
			// 
			// shopText
			// 
			this.shopText.Location = new System.Drawing.Point(128, 75);
			this.shopText.Name = "shopText";
			this.shopText.Size = new System.Drawing.Size(219, 20);
			this.shopText.TabIndex = 1;
			// 
			// urlText
			// 
			this.urlText.Location = new System.Drawing.Point(128, 115);
			this.urlText.Name = "urlText";
			this.urlText.Size = new System.Drawing.Size(219, 20);
			this.urlText.TabIndex = 2;
			// 
			// priceText
			// 
			this.priceText.Location = new System.Drawing.Point(128, 152);
			this.priceText.Name = "priceText";
			this.priceText.Size = new System.Drawing.Size(219, 20);
			this.priceText.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(79, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 18);
			this.label4.TabIndex = 12;
			this.label4.Text = "Цена:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(84, 115);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 18);
			this.label3.TabIndex = 11;
			this.label3.Text = "URL:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(55, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 18);
			this.label2.TabIndex = 10;
			this.label2.Text = "Магазин:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(25, 25);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(101, 36);
			this.label7.TabIndex = 9;
			this.label7.Text = "Носитель\r\nинформации:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button
			// 
			this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button.Location = new System.Drawing.Point(82, 193);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(224, 33);
			this.button.TabIndex = 13;
			this.button.Text = "Добавить";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.Button_Click);
			// 
			// OfferForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(385, 256);
			this.Controls.Add(this.button);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.priceText);
			this.Controls.Add(this.urlText);
			this.Controls.Add(this.shopText);
			this.Controls.Add(this.diskCombo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "OfferForm";
			this.Text = "OfferForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OfferForm_FormClosing);
			this.Load += new System.EventHandler(this.OfferForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox diskCombo;
		private System.Windows.Forms.TextBox shopText;
		private System.Windows.Forms.TextBox urlText;
		private System.Windows.Forms.TextBox priceText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button;
	}
}