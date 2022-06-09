using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace KursOragnisation
{
	public partial class MainForm : Form
	{
		LoginForm loginForm;
		SqlConnection connection;
		SqlDataAdapter adapter = new SqlDataAdapter();

		TableEnum CurrentTable
		{
			get { return _currentTable; }
			set { _currentTable = value; CurrentTableChanged(); }
		}
		TableEnum _currentTable;

		DataTable currentData = new DataTable();
		SqlCommand lastSelect;
		List<Control> searchDiskElements;
		List<Control> searchReviewOrOfferElements;
		List<Control> buttons;
		DataTable disksWithId = new DataTable();

		public MainForm(LoginForm loginForm, SqlConnection connection)
		{
			InitializeComponent();

			this.loginForm = loginForm;
			this.connection = connection;

			connection.Open();

			dataView.DataSource = currentData;

			searchDiskElements = new List<Control>() { paramsForFindingCombo, findingValueText, findButton };
			searchReviewOrOfferElements = new List<Control>() { disksCombo, findButton };
			buttons = new List<Control>() { addButton, deleteButton, updateButton, trunkButton };
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SqlCommand disks = new SqlCommand(@"SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d ORDER BY 'Носитель информации'", connection);
			CurrentTable = TableEnum.Disk;
			ExecSelect(disks);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["type_id"].Visible = false;
			dataView.Columns["manufacturer_id"].Visible = false;
			dataView.Columns["Средняя цена"].DefaultCellStyle.Format = "c";

			foreach (Control item in searchReviewOrOfferElements)
			{
				item.Visible = false;
			}
			foreach (Control item in searchDiskElements)
			{
				item.Visible = true;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			connection.Close();
			loginForm.Show();
		}

		private void CurrentTableChanged()
		{
			if (CurrentTable == TableEnum.Disk)
			{
				Height = 512;

				foreach (Control item in searchReviewOrOfferElements)
					item.Visible = false;

				foreach (Control item in searchDiskElements)
					item.Visible = true;
			}
			else if (CurrentTable == TableEnum.Review || CurrentTable == TableEnum.Offer)
			{
				Height = 512;

				disksCombo.Items.Clear();
				foreach (DataRow disk in disksWithId.Rows)
					disksCombo.Items.Add(disk["disk"]);

				foreach (Control item in searchDiskElements)
					item.Visible = false;

				foreach (Control item in searchReviewOrOfferElements)
					item.Visible = true;
			}
			else
			{
				Height = 486;
				foreach (Control item in searchDiskElements)
					item.Visible = false;

				foreach (Control item in searchReviewOrOfferElements)
					item.Visible = false;
			}

			if (CurrentTable == TableEnum.OtherSelection)
			{
				foreach (Control item in buttons)
					item.BackColor = Color.LightGray;
			}
			else
			{
				foreach (Control item in buttons)
					item.BackColor = Control.DefaultBackColor;
			}
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


		//Вывод таблиц
		private void DiskTool_Click(object sender, EventArgs e)
		{
			SqlCommand disks = new SqlCommand(@"SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d ORDER BY 'Носитель информации'", connection);
			CurrentTable = TableEnum.Disk;
			ExecSelect(disks);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["type_id"].Visible = false;
			dataView.Columns["manufacturer_id"].Visible = false;
			dataView.Columns["Средняя цена"].DefaultCellStyle.Format = "c";
		}

		private void ReviewTool_Click(object sender, EventArgs e)
		{
			SqlCommand reviews = new SqlCommand("SELECT id, disk_id, (SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', d.copacity) FROM Disk d WHERE d.id = r.disk_id) as 'Носитель информации', rating as 'Оценка', comment as 'Коментарий', date as 'Дата' FROM Review r ORDER BY 'Носитель информации'", connection);
			CurrentTable = TableEnum.Review;
			ExecSelect(reviews);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["disk_id"].Visible = false;

			disksWithId.Clear();
			SqlCommand getDisks = new SqlCommand("SELECT id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', copacity) as 'disk' FROM Disk d", connection);
			adapter.SelectCommand = getDisks;
			adapter.Fill(disksWithId);
		}

		private void OfferTool_Click(object sender, EventArgs e)
		{
			SqlCommand offers = new SqlCommand("SELECT id, disk_id, (SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', d.copacity) FROM Disk d WHERE d.id = o.disk_id) as 'Носитель информации', shop as 'Магазин', price as 'Цена', url as 'Ссылка' FROM Offer o ORDER BY 'Носитель информации'", connection);
			CurrentTable = TableEnum.Offer;
			ExecSelect(offers);

			dataView.Columns["id"].Visible = false;
			dataView.Columns["disk_id"].Visible = false;
			dataView.Columns["Цена"].DefaultCellStyle.Format = "c";

			disksWithId.Clear();
			SqlCommand getDisks = new SqlCommand("SELECT id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', copacity) as 'disk' FROM Disk d", connection);
			adapter.SelectCommand = getDisks;
			adapter.Fill(disksWithId);
		}

		private void ManufacturerTool_Click(object sender, EventArgs e)
		{
			SqlCommand manufs = new SqlCommand("SELECT id, name as 'Название', founding_date as 'Дата создания', country as 'Страна', founder as 'Основатели' FROM Manufacturer", connection);
			CurrentTable = TableEnum.Manufacturer;
			ExecSelect(manufs);

			dataView.Columns["id"].Visible = false;

			foreach (Control item in searchDiskElements)
			{
				item.Visible = false;
			}
			foreach (Control item in searchReviewOrOfferElements)
			{
				item.Visible = false;
			}
		}

		private void TypeTool_Click(object sender, EventArgs e)
		{
			SqlCommand diskType = new SqlCommand("SELECT id, type as 'Тип' FROM Disk_type", connection);
			CurrentTable = TableEnum.DiskType;
			ExecSelect(diskType);

			dataView.Columns["id"].Visible = false;

			foreach (Control item in searchDiskElements)
			{
				item.Visible = false;
			}
			foreach (Control item in searchReviewOrOfferElements)
			{
				item.Visible = false;
			}
		}


		//Кнопки
		private void AddButton_Click(object sender, EventArgs e)
		{
			connection.Close();

			switch (CurrentTable)
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
			if (CurrentTable == TableEnum.OtherSelection)
			{
				MessageBox.Show("Нельзя удалить данные из выборки");
				return;
			}

			int id = Convert.ToInt32(currentData.Rows[dataView.SelectedRows[0].Index]["id"]);

			switch (CurrentTable)
			{
				case TableEnum.Disk:
					DiskForm updateDisk = new DiskForm(this, connection, id);
					updateDisk.Show();
					break;
				case TableEnum.Review:
					ReviewForm updateReview = new ReviewForm(this, connection, id);
					updateReview.Show();
					break;
				case TableEnum.Offer:
					OfferForm updateOffer = new OfferForm(this, connection, id);
					updateOffer.Show();
					break;
				case TableEnum.DiskType:
					TypeForm updateType = new TypeForm(this, connection, id);
					updateType.Show();
					break;
				case TableEnum.Manufacturer:
					ManufacturerForm updateManufacturer = new ManufacturerForm(this, connection, id);
					updateManufacturer.Show();
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
			if (CurrentTable == TableEnum.OtherSelection)
			{
				MessageBox.Show("Нельзя удалить данные из выборки");
				return;
			}
			if (dataView.SelectedRows.Count != 1)
			{
				MessageBox.Show("Для удаления необходимо выбрать только одну строку");
				return;
			}

			int selectedRowId = Convert.ToInt32(currentData.Rows[dataView.SelectedRows[0].Index]["id"]);
			SqlCommand delete = new SqlCommand("EXECUTE dbo.delete" + CurrentTable.ToString() + " @id", connection);
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

		private void TrunkButton_Click(object sender, EventArgs e)
		{
			if (CurrentTable == TableEnum.OtherSelection)
			{
				MessageBox.Show("Нельзя удалить данные из выборки");
				return;
			}

			DialogResult result = MessageBox.Show(
				"Для обеспечения ссылочной целостности, очистка таблицы приведет удалению всех значений, которые ссылаются на эту таблицу",
				"Вы уверены?",
				MessageBoxButtons.YesNo);

			if (result == DialogResult.Yes)
			{
				SqlCommand trunkate = new SqlCommand("EXECUTE dbo.trunk" + CurrentTable.ToString(), connection);

				try
				{
					trunkate.ExecuteNonQuery();
					UpdateView();
				}
				catch (Exception exc)
				{
					MessageBox.Show("Error: " + exc.Message);
				}
			}
			else return;
		}

		private void FindButton_Click(object sender, EventArgs e)
		{
			try
			{
				int disk_id = 0;
				switch (CurrentTable)
				{
					case TableEnum.Disk:
						SqlCommand getFilteredDisk = new SqlCommand {Connection = connection};
						switch (paramsForFindingCombo.Text)
						{
							case "Средняя цена выше, чем:":
								getFilteredDisk.CommandText = "SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d WHERE price > @price";
								getFilteredDisk.Parameters.AddWithValue("@price", Convert.ToInt32(findingValueText.Text));
								break;
							case "Средняя цена ниже, чем:":
								getFilteredDisk.CommandText = "SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d WHERE price < @price";
								getFilteredDisk.Parameters.AddWithValue("@price", Convert.ToInt32(findingValueText.Text));
								break;
							case "Рейтинг выше, чем:":
								getFilteredDisk.CommandText = "SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d WHERE rating > @rating";
								getFilteredDisk.Parameters.AddWithValue("@rating", Convert.ToDouble(findingValueText.Text));
								break;
							case "Рейтинг ниже, чем:":
								getFilteredDisk.CommandText = "SELECT id, type_id, manufacturer_id, CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации', (SELECT t.type FROM Disk_type t WHERE d.type_id = t.id) as 'Тип устройства', 'Обьем' = CASE WHEN copacity >= 1000 THEN CONVERT(varchar(10), ROUND(CONVERT(float, copacity / 1000), 1)) + ' TB' WHEN copacity >= 1 and copacity <= 1000 THEN CONVERT(varchar(10), copacity) + ' GB' END, reading_speed as 'Скорость чтения', writing_speed as 'Скорость записи', rating as 'Рейтинг', price as 'Средняя цена' FROM Disk d WHERE rating < @rating";
								getFilteredDisk.Parameters.AddWithValue("@rating", Convert.ToDouble(findingValueText.Text));
								break;
							default:
								break;
						}

						ExecSelect(getFilteredDisk);

						dataView.Columns["id"].Visible = false;
						dataView.Columns["type_id"].Visible = false;
						dataView.Columns["manufacturer_id"].Visible = false;
						dataView.Columns["Средняя цена"].DefaultCellStyle.Format = "c";
						break;

					case TableEnum.Review:
						foreach (DataRow disk in disksWithId.Rows)
						{
							if (disk["disk"].ToString() == disksCombo.Text)
							{
								disk_id = Convert.ToInt32(disk["id"]);
							}
						}

						SqlCommand getFilteredReviews = new SqlCommand("SELECT id, disk_id, (SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', d.copacity) FROM Disk d WHERE d.id = r.disk_id) as 'Носитель информации', rating as 'Оценка', comment as 'Коментарий' FROM Review r WHERE disk_id = @disk_id", connection);
						getFilteredReviews.Parameters.AddWithValue("@disk_id", disk_id);

						ExecSelect(getFilteredReviews);

						dataView.Columns["id"].Visible = false;
						dataView.Columns["disk_id"].Visible = false;
						break;

					case TableEnum.Offer:
						foreach (DataRow disk in disksWithId.Rows)
						{
							if (disk["disk"].ToString() == disksCombo.Text)
							{
								disk_id = Convert.ToInt32(disk["id"]);
							}
						}

						SqlCommand getFilteredOffers = new SqlCommand("SELECT id, disk_id, (SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name, ' ', d.copacity) FROM Disk d WHERE d.id = o.disk_id) as 'Носитель информации', shop as 'Магазин', price as 'Цена', url as 'Ссылка' FROM Offer o WHERE disk_id = @disk_id", connection);
						getFilteredOffers.Parameters.AddWithValue("@disk_id", disk_id);

						ExecSelect(getFilteredOffers);

						dataView.Columns["id"].Visible = false;
						dataView.Columns["disk_id"].Visible = false;
						dataView.Columns["Цена"].DefaultCellStyle.Format = "c";
						break;

					default:
						break;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Неверно введены данные");
			}
		}


		//Выборки
		private void ReviewCountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CurrentTable = TableEnum.OtherSelection;
			SqlCommand sqlCommand = new SqlCommand("SELECT CONCAT(d.name, ' ', d.copacity) as 'Носитель информации', COUNT(rev.id) as 'Количество отзывов' FROM Review rev INNER JOIN Disk d ON rev.disk_id = d.id GROUP BY CONCAT(d.name, ' ', d.copacity) HAVING COUNT(rev.id) > 2", connection);
			ExecSelect(sqlCommand);

			foreach (Control item in searchReviewOrOfferElements)
			{
				item.Visible = false;
			}
			foreach (Control item in searchDiskElements)
			{
				item.Visible = false;
			}
		}

		private void AvgratingAfter2019ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CurrentTable = TableEnum.OtherSelection;
			SqlCommand sqlCommand = new SqlCommand("SELECT AVG(CAST(rating AS float)) AS AVG_rating FROM (SELECT rating FROM Review WHERE date >= CAST('2020-01-01' AS Date)) AS tempRates", connection);
			ExecSelect(sqlCommand);

			foreach (Control item in searchReviewOrOfferElements)
			{
				item.Visible = false;
			}
			foreach (Control item in searchDiskElements)
			{
				item.Visible = false;
			}
		}

		private void AllSSDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CurrentTable = TableEnum.OtherSelection;
			SqlCommand sqlCommand = new SqlCommand("SELECT CONCAT((SELECT m.name FROM Manufacturer m WHERE d.manufacturer_id = m.id), ' ', d.name) as 'Носитель информации' FROM Disk d WHERE type_id = ANY(SELECT id FROM Disk_type WHERE type = 'SSD' or 'SSD M.2')", connection);
			ExecSelect(sqlCommand);

			foreach (Control item in searchReviewOrOfferElements)
			{
				item.Visible = false;
			}
			foreach (Control item in searchDiskElements)
			{
				item.Visible = false;
			}
		}

		private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CurrentTable = TableEnum.OtherSelection;
			SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DisksInfo", connection);
			ExecSelect(sqlCommand);

			foreach (Control item in searchReviewOrOfferElements)
			{
				item.Visible = false;
			}
			foreach (Control item in searchDiskElements)
			{
				item.Visible = false;
			}
		}
	}
}
