using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace KursOragnisation
{
	public partial class DiskForm : Form
	{
		MainForm mainForm;
		SqlConnection connection;
		SqlDataAdapter adapter = new SqlDataAdapter();

		DataTable types = new DataTable();
		DataTable manufs = new DataTable();
		public DiskForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
		}

		private void AddDiskForm_Load(object sender, EventArgs e)
		{
			SqlCommand getTypes = new SqlCommand("SELECT * FROM Disk_type", connection);
			adapter.SelectCommand = getTypes;
			adapter.Fill(types);

			SqlCommand getManufs = new SqlCommand("SELECT id, name FROM Manufacturer", connection);
			adapter.SelectCommand = getManufs;
			adapter.Fill(manufs);

			foreach (DataRow type in types.Rows)
			{
				typeCombo.Items.Add(type["type"]);
			}

			foreach (DataRow manuf in manufs.Rows)
			{
				manufacturerCombo.Items.Add(manuf["name"]);
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			try
			{
				connection.Open();

				string name = nameText.Text;
				int copacity = Convert.ToInt32(copacityText.Text);
				int rSpeed = Convert.ToInt32(rSpeedText.Text);
				int wSpeed = Convert.ToInt32(wSpeedText.Text);

				int type_id = 0;
				foreach (DataRow type in types.Rows)
				{
					if (type["type"].ToString() == typeCombo.Text)
					{
						type_id = Convert.ToInt32(type["id"]);
					}
				}

				int manuf_id = 0;
				foreach (DataRow manuf in manufs.Rows)
				{
					if (manuf["name"].ToString() == manufacturerCombo.Text)
					{
						manuf_id = Convert.ToInt32(manuf["id"]);
					}
				}

				if (copacity <= 0 || rSpeed <= 0 || wSpeed <= 0 || type_id == 0 || manuf_id == 0 || name == string.Empty)
					throw new ArgumentException("Данные введены неверно");

				SqlCommand insert = new SqlCommand("EXECUTE dbo.insertDisk @name, @type_id, @copacity, @maunfacturer_id, @rSpeed, @wSpeed", connection);
				insert.Parameters.AddWithValue("@name", name);
				insert.Parameters.AddWithValue("@type_id", type_id);
				insert.Parameters.AddWithValue("@copacity", copacity);
				insert.Parameters.AddWithValue("@maunfacturer_id", manuf_id);
				insert.Parameters.AddWithValue("@rSpeed", rSpeed);
				insert.Parameters.AddWithValue("@wSpeed", wSpeed);

				insert.ExecuteNonQuery();

				Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error: " + exc.Message);
			}
		}

		private void AddDiskForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			mainForm.UpdateView();
		}
	}
}
