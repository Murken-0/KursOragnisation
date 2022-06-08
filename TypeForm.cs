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

		bool isUpdating = false;
		int updatingId = 0;
		DataRow updatingRow;
		DataTable rows = new DataTable();

		public TypeForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			Text = "Добавить тип";
			button.Text = "Добавить";
		}
		public TypeForm(MainForm mainForm, SqlConnection connection, int id)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			isUpdating = true;
			updatingId = id;
			Text = "Изменить информацию о типе";
			button.Text = "Изменить";
		}
		private void TypeForm_Load(object sender, EventArgs e)
		{
			if (isUpdating == true)
			{
				SqlCommand getRow = new SqlCommand("SELECT type FROM Disk_type WHERE id = @id ", connection);
				getRow.Parameters.AddWithValue("@id", updatingId);
				adapter.SelectCommand = getRow;
				adapter.Fill(rows);
				updatingRow = rows.Rows[0];

				typeText.Text = updatingRow["type"].ToString();
			}
		}

		private void Button_Click(object sender, EventArgs e)
		{
			try
			{
				connection.Open();

				string type = typeText.Text;

				if (type == string.Empty)
					throw new ArgumentException("Данные введены неверно");

				if (isUpdating == true)
				{
					SqlCommand update = new SqlCommand("EXECUTE dbo.updateDiskType @id, @type", connection);
					update.Parameters.AddWithValue("@id", updatingId);
					update.Parameters.AddWithValue("@type", type);

					update.ExecuteNonQuery();
				}
				else
				{
					SqlCommand insert = new SqlCommand("EXECUTE dbo.insertDiskType @type", connection);
					insert.Parameters.AddWithValue("@type", type);

					insert.ExecuteNonQuery();
				}
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
