namespace KursOragnisation
{
	partial class TypeForm
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
			this.typeText = new System.Windows.Forms.TextBox();
			this.button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(33, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 18);
			this.label2.TabIndex = 11;
			this.label2.Text = "Тип:";
			// 
			// typeText
			// 
			this.typeText.Location = new System.Drawing.Point(72, 27);
			this.typeText.Name = "typeText";
			this.typeText.Size = new System.Drawing.Size(219, 20);
			this.typeText.TabIndex = 12;
			// 
			// button
			// 
			this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button.Location = new System.Drawing.Point(52, 66);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(224, 33);
			this.button.TabIndex = 14;
			this.button.Text = "Добавить";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.Button_Click);
			// 
			// TypeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(335, 126);
			this.Controls.Add(this.button);
			this.Controls.Add(this.typeText);
			this.Controls.Add(this.label2);
			this.Name = "TypeForm";
			this.Text = "TypeForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TypeForm_FormClosing);
			this.Load += new System.EventHandler(this.TypeForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox typeText;
		private System.Windows.Forms.Button button;
	}
}