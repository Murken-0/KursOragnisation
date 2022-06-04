using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace KursOragnisation
{
	public partial class MainForm : Form
	{
		LoginForm loginForm;

		private SqlConnection connection;
		private TableEnum currentTable;
		private DataTable currentData = new DataTable();
		private SqlDataAdapter adapter = new SqlDataAdapter();
		private SqlCommand lastCommand;
		public MainForm(LoginForm f, SqlConnection connection)
		{
			InitializeComponent();
			loginForm = f;
			this.connection = connection;
			connection.Open();
			dataView.DataSource = currentData;
		}

		public void execLastCommand(SqlCommand command)
		{
			try
			{
				currentData.Clear();
				adapter.SelectCommand = lastCommand;
				adapter.Fill(currentData);
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message);
			}
		}

		private void execCommand(SqlCommand command)
		{
			try
			{
				currentData.Clear();
				adapter.SelectCommand = command;
				adapter.Fill(currentData);
				lastCommand = command;
			}
			catch(Exception e)
			{
				MessageBox.Show("Error: " + e.Message);
			}
		}


		private void diskTool_Click(object sender, EventArgs e)
		{

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SqlCommand sql = new SqlCommand(@"SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d", connection);
			currentTable = TableEnum.Disk;
			execCommand(sql);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["type_id"].Visible = false;
			dataView.Columns["manufacturer_id"].Visible = false;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			loginForm.Show();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			AddDiskForm add = new AddDiskForm(this, connection);
			add.Show();
		}
	}
}
