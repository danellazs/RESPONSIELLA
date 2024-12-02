
using System.Data;
using Npgsql;

using System.Data;
using System.Xml.Linq;

namespace responsiella

{
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=informatika;Database=responsiella";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadComboBoxData()
        {
            try
            {
                conn.Open();

                // Load departments into cbKaryawan
                sql = "SELECT id_dep, nama_dep FROM departemen";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader rd = cmd.ExecuteReader();
                DataTable dtDep = new DataTable();
                dtDep.Load(rd);
                cbKaryawan.DataSource = dtDep;
                cbKaryawan.DisplayMember = "nama_dep"; // Visible name
                cbKaryawan.ValueMember = "id_dep";    // Underlying value
                rd.Close();

                // Load job positions into cbJabatan
                sql = "SELECT id_jabatan, nama_jabatan FROM jabatan";
                cmd = new NpgsqlCommand(sql, conn);
                rd = cmd.ExecuteReader();
                DataTable dtJab = new DataTable();
                dtJab.Load(rd);
                cbJabatan.DataSource = dtJab;
                cbJabatan.DisplayMember = "nama_jabatan";
                cbJabatan.ValueMember = "id_jabatan";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ComboBox data: " + ex.Message, "FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EstablishConn(string connstring)
        {
            this.connstring = connstring;
            conn = new NpgsqlConnection(connstring); //satu method memiliki parameter string untuk melakukan
            // koneksi ke postgres
        }

        private void EstablishConn()
        {
            MessageBox.Show("Connection to PostGre is underway", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            EstablishConn();
            EstablishConn(connstring);
            LoadComboBoxData();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                dgvDataTable.DataSource = null;
                sql = "select * from select_all()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dgvDataTable.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string idKaryawan = Guid.NewGuid().ToString("N").Substring(0, 6); // Generates a 6-character unique ID

                sql = @"select * from add_karyawan(:in_id_karyawan, :in_nama, :in_id_dep, :in_id_jabatan)";
                cmd = new NpgsqlCommand(sql, conn);

                // Assign parameters before executing
                cmd.Parameters.AddWithValue("in_id_karyawan", idKaryawan);
                cmd.Parameters.AddWithValue("in_nama", TbName.Text);
                cmd.Parameters.AddWithValue("in_id_dep", cbKaryawan.SelectedValue != null ? Convert.ToInt32(cbKaryawan.SelectedValue) : 0);
                cmd.Parameters.AddWithValue("in_id_jabatan", cbJabatan.SelectedValue != null ? Convert.ToInt32(cbJabatan.SelectedValue) : 0);

                int result = (int)cmd.ExecuteScalar(); // Execute the SQL query

                // Handle result
                if (result == 201) // Assuming 201 means success based on your SQL function
                {
                    MessageBox.Show("Data Karyawan Berhasil Diinputkan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLoad.PerformClick(); // Reload data
                    TbName.Text = null; // Clear input field
                }
                else if (result == 409) // Assuming 409 means conflict
                {
                    MessageBox.Show("Data Karyawan sudah ada!", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Insert FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Pilih baris data dahulu!", "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Log column names of the DataGridView to confirm
            foreach (DataGridViewColumn column in dgvDataTable.Columns)
            {
                Console.WriteLine(column.Name); // Print out column names to confirm they're correct
            }

            // Check if the column exists in the DataGridView
            if (!dgvDataTable.Columns.Contains("in_id_karyawan"))
            {
                MessageBox.Show("Column 'in_id_karyawan' not found in the DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                sql = @"select * from edit_karyawan(:in_id_karyawan, :in_nama, :in_id_dep, :in_id_jabatan)";
                cmd = new NpgsqlCommand(sql, conn);

                // Assuming the column name is correct after inspecting logs, update the parameters
                cmd.Parameters.AddWithValue("in_id_karyawan", r.Cells["in_id_karyawan"].Value.ToString());
                cmd.Parameters.AddWithValue("in_nama", TbName.Text);
                cmd.Parameters.AddWithValue("in_id_dep", (int)cbJabatan.SelectedValue);
                cmd.Parameters.AddWithValue("in_id_jabatan", (int)cbKaryawan.SelectedValue);

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Karyawan Berhasil Diupdate", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    BtnLoad.PerformClick();
                    TbName.Text = null;
                    cmd.Parameters.AddWithValue("in_id_dep", cbKaryawan.SelectedValue != null ? Convert.ToInt32(cbKaryawan.SelectedValue) : 0);
                    cmd.Parameters.AddWithValue("in_id_jabatan", cbJabatan.SelectedValue != null ? Convert.ToInt32(cbJabatan.SelectedValue) : 0);

                    r = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Pilih baris data dahulu!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Log column names in the DataGridView
            foreach (DataGridViewColumn column in dgvDataTable.Columns)
            {
                Console.WriteLine(column.Name); // This will log the actual column names
            }

            // Check if the '_nama' column exists
            if (!dgvDataTable.Columns.Contains("_nama"))
            {
                MessageBox.Show("Column '_nama' not found in the DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Proceed with deletion if the column exists
            if (MessageBox.Show("Apakah Anda ingin menghapus data " + r.Cells["in_nama"].Value.ToString() + " ?", "Hapus data terkonfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    sql = @"select * from delete_karyawan(:in_id_karyawan)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("in_id_karyawan", r.Cells["in_id_karyawan"].Value.ToString());
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("Data Karyawan Berhasil Dihapus", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        BtnLoad.PerformClick();
                        TbName.Text = null;
                        cmd.Parameters.AddWithValue("in_id_dep", cbKaryawan.SelectedValue != null ? Convert.ToInt32(cbKaryawan.SelectedValue) : 0);
                        cmd.Parameters.AddWithValue("in_id_jabatan", cbJabatan.SelectedValue != null ? Convert.ToInt32(cbJabatan.SelectedValue) : 0);

                        r = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Delete FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvDataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvDataTable.Rows[e.RowIndex];
                TbName.Text = r.Cells["nama"].Value.ToString(); // Use the correct column name
                cbKaryawan.SelectedValue = Convert.ToInt32(r.Cells["id_dep"].Value);
                cbJabatan.SelectedValue = Convert.ToInt32(r.Cells["id_jabatan"].Value);
            }
        }

    }
}