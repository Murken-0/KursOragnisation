using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace KursOragnisation
{
	public partial class ReviewForm : Form
	{
		MainForm mainForm;
		SqlConnection connection;
		SqlDataAdapter adapter = new SqlDataAdapter();

		DataTable disks = new DataTable();

		bool isUpdating = false;
		int updatingId = 0;
		DataRow updatingRow;
		public ReviewForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			Text = "Добавить отзыв";
			button.Text = "Добавить";
		}

		public ReviewForm(MainForm mainForm, SqlConnection connection, int id)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			isUpdating = true;
			updatingId = id;
			Text = "Изменить информацию об отзыве";
			button.Text = "Изменить";
		}

		private void ReviewForm_Load(object sender, EventArgs e)
		{
			if (isUpdating)
			{
				SqlCommand getRow = new SqlCommand("SELECT (SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', copacity) as 'disk' FROM Disk d) as disk, rating, comment FROM Review r WHERE id = @id", connection);
				getRow.Parameters.AddWithValue("@id", updatingId);
				adapter.SelectCommand = getRow;
				adapter.Fill(disks);
				updatingRow = disks.Rows[0];

				diskCombo.Text = updatingRow["disk"].ToString();
				ratingCombo.Text = updatingRow["rating"].ToString();
				textTextBox.Text = updatingRow["comment"].ToString();
			}

			disks.Clear();
			SqlCommand getTypes = new SqlCommand("SELECT id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', copacity) as 'disk' FROM Disk d", connection);
			adapter.SelectCommand = getTypes;
			adapter.Fill(disks);


			foreach (DataRow disk in disks.Rows)
			{
				diskCombo.Items.Add(disk["disk"]);
			}

			for (int i = 2; i <= 5; i++)
			{
				ratingCombo.Items.Add(i.ToString());
			}
		}

		private void Button_Click(object sender, EventArgs e)
		{
			try
			{
				connection.Open();

				string text = textTextBox.Text;
				int rating = Convert.ToInt32(ratingCombo.Text);

				int disk_id = 0;
				foreach (DataRow disk in disks.Rows)
				{
					if (disk["disk"].ToString() == diskCombo.Text)
					{
						disk_id = Convert.ToInt32(disk["id"]);
					}
				}

				if (rating < 2 || rating > 5 || disk_id == 0 || text == string.Empty)
					throw new ArgumentException("Данные введены неверно");

				if (isUpdating == true)
				{
					SqlCommand update = new SqlCommand("EXECUTE dbo.updateReview @id, @disk_id, @rating, @text", connection);
					update.Parameters.AddWithValue("@id", updatingId);
					update.Parameters.AddWithValue("@disk_id", disk_id);
					update.Parameters.AddWithValue("@rating", rating);
					update.Parameters.AddWithValue("@text", text);

					update.ExecuteNonQuery();
				}
				else
				{
					SqlCommand insert = new SqlCommand("EXECUTE dbo.insertReview @disk_id, @rating, @text", connection);
					insert.Parameters.AddWithValue("@disk_id", disk_id);
					insert.Parameters.AddWithValue("@rating", rating);
					insert.Parameters.AddWithValue("@text", text);

					insert.ExecuteNonQuery();
				}

				Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error: " + exc.Message);
			}
		}

		private void ReviewForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			mainForm.UpdateView();
		}
	}
}
