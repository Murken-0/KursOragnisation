using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace KursOragnisation
{
	public partial class ManufacturerForm : Form
	{
		MainForm mainForm;
		SqlConnection connection;
		SqlDataAdapter adapter = new SqlDataAdapter();

		public ManufacturerForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			try
			{
				connection.Open();

				string name = nameText.Text;
				string country = countryText.Text;
				string founder = founderText.Text;
				string founding_date = datePicker.Value.Year.ToString() + "-" + datePicker.Value.Month.ToString() + "-" + datePicker.Value.Day.ToString();

				if (name == string.Empty || country == string.Empty || founder == string.Empty || founding_date == string.Empty)
					throw new ArgumentException("Данные введены неверно");

				SqlCommand insert = new SqlCommand("EXECUTE dbo.insertManufacturer @name, @founding_date, @country, @founder", connection);
				insert.Parameters.AddWithValue("@name", name);
				insert.Parameters.AddWithValue("@founding_date", founding_date);
				insert.Parameters.AddWithValue("@country", country);
				insert.Parameters.AddWithValue("@founder", founder);

				insert.ExecuteNonQuery();

				Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error: " + exc.Message);
			}
		}

		private void ManufacturerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			mainForm.UpdateView();
		}
	}
}
