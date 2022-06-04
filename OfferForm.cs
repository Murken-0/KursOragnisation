using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace KursOragnisation
{
	public partial class OfferForm : Form
	{
		MainForm mainForm;
		SqlConnection connection;
		SqlDataAdapter adapter = new SqlDataAdapter();

		DataTable disks = new DataTable();
		public OfferForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
		}

		private void OfferForm_Load(object sender, EventArgs e)
		{
			SqlCommand getTypes = new SqlCommand("SELECT id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', copacity) as 'disk' FROM Disk d", connection);
			adapter.SelectCommand = getTypes;
			adapter.Fill(disks);

			foreach (DataRow disk in disks.Rows)
			{
				diskCombo.Items.Add(disk["disk"]);
			}
		}
		private void AddButton_Click(object sender, EventArgs e)
		{
			try
			{
				connection.Open();

				string shop = shopText.Text;
				string url = urlText.Text;
				int price = Convert.ToInt32(priceText.Text);

				int disk_id = 0;
				foreach (DataRow disk in disks.Rows)
				{
					if (disk["disk"].ToString() == diskCombo.Text)
					{
						disk_id = Convert.ToInt32(disk["id"]);
					}
				}

				if (price <= 0 || url == string.Empty || disk_id == 0 || shop == string.Empty)
					throw new ArgumentException("Данные введены неверно");

				SqlCommand insert = new SqlCommand("EXECUTE dbo.insertOffer @disk_id, @shop, @url, @price", connection);
				insert.Parameters.AddWithValue("@disk_id", disk_id);
				insert.Parameters.AddWithValue("@shop", shop);
				insert.Parameters.AddWithValue("@url", url);
				insert.Parameters.AddWithValue("@price", price);

				insert.ExecuteNonQuery();

				Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error: " + exc.Message);
			}
		}

		private void OfferForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			mainForm.UpdateView();
		}
	}
}
