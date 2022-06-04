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
		public ReviewForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
		}

		private void AddReviewForm_Load(object sender, EventArgs e)
		{
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

		private void addButton_Click(object sender, EventArgs e)
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

				SqlCommand insert = new SqlCommand("EXECUTE dbo.insertReview @disk_id, @rating, @text", connection);
				insert.Parameters.AddWithValue("@disk_id", disk_id);
				insert.Parameters.AddWithValue("@rating", rating);
				insert.Parameters.AddWithValue("@text", text);

				insert.ExecuteNonQuery();

				Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error: " + exc.Message);
			}
		}

		private void AddReviewForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			mainForm.UpdateView();
		}
	}
}
