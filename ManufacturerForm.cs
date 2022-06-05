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

		bool isUpdating = false;
		int updatingId = 0;
		DataRow updatingRow;
		DataTable rows = new DataTable();

		public ManufacturerForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			Text = "Добавить производителя";
			button.Text = "Добавить";
		}
		public ManufacturerForm(MainForm mainForm, SqlConnection connection, int id)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			isUpdating = true;
			updatingId = id;
			Text = "Изменить информацию о производителе";
			button.Text = "Изменить";
		}

		private void ManufacturerForm_Load(object sender, EventArgs e)
		{
			SqlCommand getRow = new SqlCommand("SELECT name, founding_date, country, founder FROM Manufacturer WHERE id = @id", connection);
			getRow.Parameters.AddWithValue("@id", updatingId);
			adapter.SelectCommand = getRow;
			adapter.Fill(rows);
			updatingRow = rows.Rows[0];

			nameText.Text = updatingRow["name"].ToString();
			countryText.Text = updatingRow["country"].ToString();
			founderText.Text = updatingRow["founder"].ToString();
			datePicker.Value = Convert.ToDateTime(updatingRow["founding_date"]);
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

				if (isUpdating == true)
				{
					SqlCommand update = new SqlCommand("EXECUTE dbo.updateManufacturer @id, @name, @founding_date, @country, @founder", connection);
					update.Parameters.AddWithValue("@id", updatingId);
					update.Parameters.AddWithValue("@name", name);
					update.Parameters.AddWithValue("@founding_date", founding_date);
					update.Parameters.AddWithValue("@country", country);
					update.Parameters.AddWithValue("@founder", founder);

					update.ExecuteNonQuery();
				}
				else
				{
					SqlCommand insert = new SqlCommand("EXECUTE dbo.insertManufacturer @name, @founding_date, @country, @founder", connection);
					insert.Parameters.AddWithValue("@name", name);
					insert.Parameters.AddWithValue("@founding_date", founding_date);
					insert.Parameters.AddWithValue("@country", country);
					insert.Parameters.AddWithValue("@founder", founder);

					insert.ExecuteNonQuery();
				}
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
