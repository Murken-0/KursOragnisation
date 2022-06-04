using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace KursOragnisation
{
	public partial class AddDiskForm : Form
	{
		MainForm mainForm;
		SqlConnection connection;
		SqlDataAdapter adapter = new SqlDataAdapter();

		DataTable types = new DataTable();
		DataTable manufs = new DataTable();
		public AddDiskForm(MainForm mainForm, SqlConnection connection)
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
				typeCombo.Items.Add(manuf["name"]);
			}
		}
	}
}
