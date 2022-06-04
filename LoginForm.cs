using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KursOragnisation
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{

		}

		private void enterButton_Click(object sender, EventArgs e)
		{
			string connString = @"Data Source=" + @"VLAD-PC\SQLEXPRESS" + ";Initial Catalog="+ "kursa4"
				+ ";User ID=" + loginTextBox.Text + ";Password=" + passwordTextBox.Text;

			using (SqlConnection sqlConnection = new SqlConnection(connString))
			{
				try
				{
					sqlConnection.Open();
					sqlConnection.Close();
					MainForm mainForm = new MainForm(this, sqlConnection);
					Hide();
					mainForm.ShowDialog();
				}
				catch (Exception ecx)
				{
					MessageBox.Show("Error: " + ecx.Message);
				}
			}
		}
	}
}
