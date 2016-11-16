using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SystemQuiche
{
    public partial class frmProdutos : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public frmProdutos()
        {
            InitializeComponent();
        }
        public void ObterDados()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(ProductID),RTRIM(ProductName),RTRIM(Category.ID),RTRIM(CategoryName),RTRIM(Price) from Product,Category where Product.CategoryID=Category.ID  order by Productname", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            FillCombo();
            Autocomplete();
            ObterDados();
        }
        public void FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(CategoryName) from Category order by CategoryName";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCategoria.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            txtNomeProduto.Text = "";
            cmbCategoria.Text = "";
            txtPreco.Text = "";
            txtProcurarProduto.Text = "";
            ObterDados();
            btnDeletar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = true;
            txtNomeProduto.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text == "")
            {
                MessageBox.Show("Informe o nome do produto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeProduto.Focus();
                return;
            }
            if (cmbCategoria.Text == "")
            {
                MessageBox.Show("Selecione a categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategoria.Focus();
                return;
            }
            if (txtPreco.Text == "")
            {
                MessageBox.Show("Informe o preço", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPreco.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ProductName from Product where ProductName='" + txtNomeProduto.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Nome do produto ja existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeProduto.Text = "";
                    txtNomeProduto.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Product(ProductName,CategoryID,Price) VALUES ('" + txtNomeProduto.Text + "'," + txtCategoriaID.Text + "," + txtPreco.Text + ")";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Salvo com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                ObterDados();
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja deletar este registro ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from product where productID=" + txtProdutoID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Deletado com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    ObterDados();
                    Autocomplete();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    Autocomplete();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT distinct ProductName FROM product", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Product");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["productname"].ToString());

                }
                txtNomeProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNomeProduto.AutoCompleteCustomSource = col;
                txtNomeProduto.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text == "")
            {
                MessageBox.Show("Informe o nome do produto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeProduto.Focus();
                return;
            }
            if (cmbCategoria.Text == "")
            {
                MessageBox.Show("Selecione a categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategoria.Focus();
                return;
            }

            if (txtPreco.Text == "")
            {
                MessageBox.Show("Informe o preço", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPreco.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update product set ProductName='" + txtNomeProduto.Text + "',CategoryID=" + txtCategoriaID.Text + ",price=" + txtPreco.Text + " Where ProductID='" + txtProdutoID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Atualizado com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                ObterDados();
                btnAtualizar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT ID from Category WHERE CategoryName = '" + cmbCategoria.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtCategoriaID.Text = rdr.GetInt32(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtProcurarProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(ProductID),RTRIM(ProductName),RTRIM(Category.ID),RTRIM(CategoryName),RTRIM(Price) from Product,Category where Product.CategoryID=Category.ID and ProductName like '" + txtProcurarProduto.Text + "%' order by Productname", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
            txtProdutoID.Text = dr.Cells[0].Value.ToString();
            txtNomeProduto.Text = dr.Cells[1].Value.ToString();
            txtCategoriaID.Text = dr.Cells[2].Value.ToString();
            cmbCategoria.Text = dr.Cells[3].Value.ToString();
            txtPreco.Text = dr.Cells[4].Value.ToString();
            btnDeletar.Enabled = true;
            btnAtualizar.Enabled = true;
            txtNomeProduto.Focus();
            btnSalvar.Enabled = false;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
    }
}
