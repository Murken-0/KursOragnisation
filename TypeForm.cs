using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace KursOragnisation
{
	public partial class TypeForm : Form
	{
		MainForm mainForm;
		SqlConnection connection;
		SqlDataAdapter adapter = new SqlDataAdapter();

		public TypeForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			try
			{
				connection.Open();

				string type = typeText.Text;

				if (type == string.Empty)
					throw new ArgumentException("Данные введены неверно");

				SqlCommand insert = new SqlCommand("EXECUTE dbo.insertDiskType @type", connection);
				insert.Parameters.AddWithValue("@type", type);

				insert.ExecuteNonQuery();

				Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error: " + exc.Message);
			}
		}

		private void TypeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			mainForm.UpdateView();
		}
	}
}
