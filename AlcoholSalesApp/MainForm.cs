using AlcoholSalesApp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class MainForm : Form
{
    private Button btnAddDrink;
    private DataGridView dataGridView1;
    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mmaks\\source\\repos\\AlcoholSalesApp\\AlcoholSales.mdf;Integrated Security=True";

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadDrinks();
    }

    private void LoadDrinks()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Drinks", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }

    private void btnAddDrink_Click(object sender, EventArgs e)
    {
        AddDrinkForm form = new AddDrinkForm();
        form.FormClosed += (s, args) => LoadDrinks(); // ← після закриття форми — оновлюємо таблицю
        form.ShowDialog(); // НЕ .Show() !
    }


    private void InitializeComponent()
    {
            this.btnAddDrink = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddDrink
            // 
            this.btnAddDrink.Location = new System.Drawing.Point(447, 308);
            this.btnAddDrink.Name = "btnAddDrink";
            this.btnAddDrink.Size = new System.Drawing.Size(111, 39);
            this.btnAddDrink.TabIndex = 3;
            this.btnAddDrink.Text = "Додати";
            this.btnAddDrink.UseVisualStyleBackColor = true;
            this.btnAddDrink.Click += new System.EventHandler(this.btnAddDrink_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(546, 290);
            this.dataGridView1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(570, 356);
            this.Controls.Add(this.btnAddDrink);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

    }
}

