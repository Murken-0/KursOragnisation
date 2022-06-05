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

		bool isUpdating = false;
		int updatingId = 0;
		DataRow updatingRow;

		public DiskForm(MainForm mainForm, SqlConnection connection)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			Text = "Добавить диск";
			button.Text = "Добавить";
		}

		public DiskForm(MainForm mainForm, SqlConnection connection, int id)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.connection = connection;
			isUpdating = true;
			updatingId = id;
			Text = "Изменить информацию о диске";
			button.Text = "Изменить";
		}

		private void AddDiskForm_Load(object sender, EventArgs e)
		{
			if (isUpdating)
			{
				DataTable disk = new DataTable();
				SqlCommand getRow = new SqlCommand("SELECT (SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id) as 'man', name, copacity, (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'type', reading_speed as 'rs', writing_speed as 'ws'FROM Disk d WHERE id = @id", connection);
				getRow.Parameters.AddWithValue("@id", updatingId);
				adapter.SelectCommand = getRow;
				adapter.Fill(disk);
				updatingRow = disk.Rows[0];

				manufacturerCombo.Text = updatingRow["man"].ToString();
				nameText.Text = updatingRow["name"].ToString();
				copacityText.Text = updatingRow["copacity"].ToString();
				typeCombo.Text = updatingRow["type"].ToString();
				rSpeedText.Text = updatingRow["rs"].ToString();
				wSpeedText.Text = updatingRow["ws"].ToString();
			}

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

		private void Button_Click(object sender, EventArgs e)
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

				if (isUpdating == true)
				{
					SqlCommand update = new SqlCommand("EXECUTE dbo.updateDisk @id, @name, @type_id, @copacity, @maunfacturer_id, @rSpeed, @wSpeed", connection);
					update.Parameters.AddWithValue("@id", updatingId);
					update.Parameters.AddWithValue("@name", name);
					update.Parameters.AddWithValue("@type_id", type_id);
					update.Parameters.AddWithValue("@copacity", copacity);
					update.Parameters.AddWithValue("@maunfacturer_id", manuf_id);
					update.Parameters.AddWithValue("@rSpeed", rSpeed);
					update.Parameters.AddWithValue("@wSpeed", wSpeed);

					update.ExecuteNonQuery();
				}
				else
				{
					SqlCommand insert = new SqlCommand("EXECUTE dbo.insertDisk @name, @type_id, @copacity, @maunfacturer_id, @rSpeed, @wSpeed", connection);
					insert.Parameters.AddWithValue("@name", name);
					insert.Parameters.AddWithValue("@type_id", type_id);
					insert.Parameters.AddWithValue("@copacity", copacity);
					insert.Parameters.AddWithValue("@maunfacturer_id", manuf_id);
					insert.Parameters.AddWithValue("@rSpeed", rSpeed);
					insert.Parameters.AddWithValue("@wSpeed", wSpeed);

					insert.ExecuteNonQuery();
				}
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
