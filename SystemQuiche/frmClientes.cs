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
using System.Security.Cryptography;

namespace SystemQuiche
{
    public partial class frmClientes : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        
        public frmClientes()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtEndereco.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtNomeCliente.Text = "";
            txtContato.Text = "";
            txtNotas.Text = "";
            txtContatoAlt.Text = "";
            txtClienteID.Text = "";
            btnSalvar.Enabled = true;
            btnDeletar.Enabled = false;
            btnAtualizar.Enabled = false;
            txtNomeCliente.Focus();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void auto()
        {
            txtClienteID.Text = "C-" + GetUniqueKey(6);
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text == "")
            {
                MessageBox.Show("Informe o nome", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeCliente.Focus();
                return;
            }

            if (txtEndereco.Text == "")
            {
                MessageBox.Show("Informe o endereço", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndereco.Focus();
                return;
            }
            if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe a cidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCidade.Focus();
                return;
            }

            if (txtContato.Text == "")
            {
                MessageBox.Show("Informe o nº do contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContato.Focus();
                return;
            }

            try
            {
                auto();

                con = new SqlConnection(cs.DBConn);
                con.Open();

                string cb = "insert into Customer(CustomerID,Customername,address,City,ContactNo,ContactNo1,Email,Notes) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtClienteID.Text);
                cmd.Parameters.AddWithValue("@d2", txtNomeCliente.Text);
                cmd.Parameters.AddWithValue("@d3", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@d4", txtCidade.Text);
                cmd.Parameters.AddWithValue("@d5", txtContato.Text);
                cmd.Parameters.AddWithValue("@d6", txtContatoAlt.Text);
                cmd.Parameters.AddWithValue("@d7", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d8", txtNotas.Text);

                cmd.ExecuteReader();
                MessageBox.Show("Salvo com sucesso", "Detalhes dos Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSalvar.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delete_records()
        {

            try
            {

                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Customer where CustomerID='" + txtClienteID.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;

                RowsAffected = cmd.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    MessageBox.Show("Deletado com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                if (MessageBox.Show("Deseja deletar o registro ?", "Registro Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    delete_records();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeCliente.Text == "")
                {
                    MessageBox.Show("Informe o nome", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeCliente.Focus();
                    return;
                }

                if (txtEndereco.Text == "")
                {
                    MessageBox.Show("Informe o  endereço", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEndereco.Focus();
                    return;
                }
                if (txtCidade.Text == "")
                {
                    MessageBox.Show("Informe a cidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCidade.Focus();
                    return;
                }

                if (txtContato.Text == "")
                {
                    MessageBox.Show("Informe o no. do contato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContato.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update Customer set Customername=@d2,address=@d3,City=@d4,ContactNo=@d5,ContactNo1=@d6,Email=@d7,Notes=@d8 where CustomerID=@d1";

                cmd = new SqlCommand(cb);

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtClienteID.Text);
                cmd.Parameters.AddWithValue("@d2", txtNomeCliente.Text);
                cmd.Parameters.AddWithValue("@d3", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@d4", txtCidade.Text);
                cmd.Parameters.AddWithValue("@d5", txtContato.Text);
                cmd.Parameters.AddWithValue("@d6", txtContatoAlt.Text);
                cmd.Parameters.AddWithValue("@d7", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d8", txtNotas.Text);
                cmd.ExecuteReader();
                MessageBox.Show("Atualizado com sucesso", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAtualizar.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtContatoAlt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnObterDados_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmClientesRecord frm = new frmClientesRecord();
            frm.Show();
            frm.ObterDados();
        }
        
    }
}
