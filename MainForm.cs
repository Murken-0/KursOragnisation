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

		SqlConnection connection;
		TableEnum currentTable;
		DataTable currentData = new DataTable();
		SqlDataAdapter adapter = new SqlDataAdapter();
		SqlCommand lastSelect;

		public MainForm()
		{
			InitializeComponent();
			connection = new SqlConnection(@"Data Source=VLAD-PC\SQLEXPRESS;Initial Catalog=kursa4;User ID=Admin;Password=root");
			connection.Open();
			dataView.DataSource = currentData;
		}

		public MainForm(LoginForm f, SqlConnection connection)
		{
			InitializeComponent();
			loginForm = f;
			this.connection = connection;
			connection.Open();
			dataView.DataSource = currentData;
		}

		public void UpdateView()
		{
			try
			{
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}
				currentData.Clear();
				adapter.SelectCommand = lastSelect;
				adapter.Fill(currentData);
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message);
			}
		}

		private void ExecSelect(SqlCommand command)
		{
			currentData.Clear();
			currentData.Columns.Clear();
			try
			{
				adapter.SelectCommand = command;
				adapter.Fill(currentData);
				lastSelect = command;

				foreach (DataGridViewColumn column in dataView.Columns)
				{
					column.SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message);
			}
		}

		private void DiskTool_Click(object sender, EventArgs e)
		{
			SqlCommand disks = new SqlCommand(@"SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d", connection);
			currentTable = TableEnum.Disk;
			ExecSelect(disks);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["type_id"].Visible = false;
			dataView.Columns["manufacturer_id"].Visible = false;
			dataView.Columns["Средняя цена"].DefaultCellStyle.Format = "c";
		}
		private void ReviewTool_Click(object sender, EventArgs e)
		{
			SqlCommand reviews = new SqlCommand("SELECT id, disk_id, (SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, d.copacity) FROM Disk d WHERE d.id = r.disk_id) as 'Носитель информации', rating as 'Оценка', comment as 'Коментарий' FROM Review r", connection);
			currentTable = TableEnum.Review;
			ExecSelect(reviews);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["disk_id"].Visible = false;
		}
		private void OfferTool_Click(object sender, EventArgs e)
		{
			SqlCommand offers = new SqlCommand("SELECT id, disk_id, (SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, d.copacity) FROM Disk d WHERE d.id = o.disk_id) as 'Носитель информации', shop as 'Магазин', price as 'Цена', url as 'Ссылка' FROM Offer o", connection);
			currentTable = TableEnum.Offer;
			ExecSelect(offers);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["disk_id"].Visible = false;
			dataView.Columns["Цена"].DefaultCellStyle.Format = "c";
		}
		private void ManufacturerTool_Click(object sender, EventArgs e)
		{
			SqlCommand manufs = new SqlCommand("SELECT id, name as 'Название', founding_date as 'Дата создания', country as 'Страна', founder as 'Основатели' FROM Manufacturer", connection);
			currentTable = TableEnum.Manufacturer;
			ExecSelect(manufs);

			dataView.Columns["id"].Visible = false;
		}
		private void TypeTool_Click(object sender, EventArgs e)
		{
			SqlCommand diskType = new SqlCommand("SELECT id, type as 'Тип' FROM Disk_type", connection);
			currentTable = TableEnum.DiskType;
			ExecSelect(diskType);

			dataView.Columns["id"].Visible = false;
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			SqlCommand disks = new SqlCommand(@"SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d", connection);
			currentTable = TableEnum.Disk;
			ExecSelect(disks);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["type_id"].Visible = false;
			dataView.Columns["manufacturer_id"].Visible = false;
			dataView.Columns["Средняя цена"].DefaultCellStyle.Format = "c";
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			//loginForm.Show();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			connection.Close();

			switch (currentTable)
			{
				case TableEnum.Disk:
					DiskForm addDisk = new DiskForm(this, connection);
					addDisk.Show();
					break;
				case TableEnum.Review:
					ReviewForm addReview = new ReviewForm(this, connection);
					addReview.Show();
					break;
				case TableEnum.Offer:
					OfferForm addOffer = new OfferForm(this, connection);
					addOffer.Show();
					break;
				case TableEnum.DiskType:
					TypeForm addType = new TypeForm(this, connection);
					addType.Show();
					break;
				case TableEnum.Manufacturer:
					ManufacturerForm addManufacturer = new ManufacturerForm(this, connection);
					addManufacturer.Show();
					break;
				case TableEnum.OtherSelection:
					MessageBox.Show("Нельзя редактировать выборку");
					break;
				default:
					throw new ArgumentException("В свич пришла какая-то фигня");
			}
		}
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			connection.Close();

			if (dataView.SelectedRows.Count != 1)
			{
				MessageBox.Show("Для удаления необходимо выбрать только одну строку");
				return;
			}
			if (currentTable == TableEnum.OtherSelection)
			{
				MessageBox.Show("Нельзя удалить данные из выборки");
				return;
			}

			int id = Convert.ToInt32(currentData.Rows[dataView.SelectedRows[0].Index]["id"]);

			switch (currentTable)
			{
				case TableEnum.Disk:
					DiskForm addDisk = new DiskForm(this, connection, id);
					addDisk.Show();
					break;
				case TableEnum.Review:
					ReviewForm addReview = new ReviewForm(this, connection, id);
					addReview.Show();
					break;
				case TableEnum.Offer:
					OfferForm addOffer = new OfferForm(this, connection, id);
					addOffer.Show();
					break;
				case TableEnum.DiskType:
					TypeForm addType = new TypeForm(this, connection, id);
					addType.Show();
					break;
				case TableEnum.Manufacturer:
					ManufacturerForm addManufacturer = new ManufacturerForm(this, connection, id);
					addManufacturer.Show();
					break;
				case TableEnum.OtherSelection:
					MessageBox.Show("Нельзя редактировать выборку");
					break;
				default:
					throw new ArgumentException("В свич пришла какая-то фигня");
			}
		}
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (dataView.SelectedRows.Count != 1)
			{
				MessageBox.Show("Для удаления необходимо выбрать только одну строку");
				return;
			}
			if (currentTable == TableEnum.OtherSelection)
			{
				MessageBox.Show("Нельзя удалить данные из выборки");
				return;
			}

			int selectedRowId = Convert.ToInt32(currentData.Rows[dataView.SelectedRows[0].Index]["id"]);
			SqlCommand delete = new SqlCommand("EXECUTE dbo.delete" + currentTable.ToString() + " @id", connection);
			delete.Parameters.AddWithValue("@id", selectedRowId);

			try
			{
				delete.ExecuteNonQuery();
				UpdateView();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error: " + exc.Message);
			}
		}
	}
}
