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
    public partial class frmCadastroUsuario : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            Autocomplete();
        }
        private void Reset ()
        {
            txtNomeUsuario.Text = "";
            cmbTipoUsuario.SelectedIndex = -1;
            txtSenha.Text = "";
            txtNumContato.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            btnCadastrar.Enabled = true;
            btnDeletar.Enabled = false;
            btnAtualizarCadastro.Enabled = false;
            txtNomeUsuario.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNomeUsuario.Text == "")
            {
                MessageBox.Show("Informe o usuário", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeUsuario.Focus();
                return;
            }
            if (cmbTipoUsuario.Text == "")
            {
                MessageBox.Show("Selecione o tipo do usuário", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipoUsuario.Focus();
                return;
            }
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Informe a senha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return;
            }
            if(txtNome.Text == "")
            {
                MessageBox.Show("Informe o nome", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return;
            }
            if(txtNumContato.Text == "")
            {
                MessageBox.Show("Informe o no. do contato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumContato.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Informe o  email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select username from registration where username=@find";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "username"));
                cmd.Parameters["@find"].Value = txtNomeUsuario.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Usuário ja existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeUsuario.Text = "";
                    txtNomeUsuario.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "select Email from registration where Email='" + txtEmail.Text + "'";

                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Email ja existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Text = "";
                    txtEmail.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();

                string cb = "insert into Registration(Username,UsertYpe,Password,ContactNo,Email,Name,JoiningDate) VALUES ('" + txtNomeUsuario.Text + "','" + cmbTipoUsuario.Text + "','" + txtSenha.Text + "','" + txtNumContato.Text + "','" + txtEmail.Text + "','" + txtNome.Text + "','" + System.DateTime.Now + "')";

                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Registrado com sucesso", "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                btnCadastrar.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerificarDisponibilidade_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeUsuario.Text == "")
                {
                    MessageBox.Show("Informe o  username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeUsuario.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select username from registration where username='" + txtNomeUsuario.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Usuário não disponível", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!rdr.Read())
                {
                    MessageBox.Show("Usuário disponível", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomeUsuario.Focus();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Email_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Endereço de Email inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void Name_Of_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void NomeUsuario_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9_]");
            if (txtNomeUsuario.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtNomeUsuario.Text))
                {
                    MessageBox.Show("Somente letras, números e sublinhado é permitido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeUsuario.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void btnObterDetalhes_Click(object sender, EventArgs e)
        {
            frmRegistroUsuariosDetalhes frm = new frmRegistroUsuariosDetalhes();
            frm.dataGridView1.DataSource = frm.ObterDados();
            frm.Show();
        }
        private void Username_TextChanged(object sender, EventArgs e)
        {

            btnDeletar.Enabled = true;
            btnAtualizarCadastro.Enabled = true;
            try
            {
                txtNomeUsuario.Text = txtNomeUsuario.Text.TrimEnd();
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT Usertype,password,name,contactno,email FROM registration WHERE username = '" + txtNomeUsuario.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    cmbTipoUsuario.Text = (rdr.GetString(0).Trim());
                    txtSenha.Text = (rdr.GetString(1).Trim());
                    txtNome.Text = (rdr.GetString(2).Trim());
                    txtNumContato.Text = (rdr.GetString(3).Trim());
                    txtEmail.Text = (rdr.GetString(4).Trim());
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

        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT username FROM registration", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "registration");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Username"].ToString());

                }
                txtNomeUsuario.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNomeUsuario.AutoCompleteCustomSource = col;
                txtNomeUsuario.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarCadastro_Click(object sender, EventArgs e)
        {
            if (txtNomeUsuario.Text == "")
            {
                MessageBox.Show("Informe o usuário", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeUsuario.Focus();
                return;
            }
            if (cmbTipoUsuario.Text == "")
            {
                MessageBox.Show("Selecione o tipo do usuário", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipoUsuario.Focus();
                return;
            }
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Informe a senha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
                return;
            }
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o nome", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return;
            }
            if (txtNumContato.Text == "")                
            {
                MessageBox.Show("Informe o no. do contato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumContato.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Informe o  email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();

                string cb = "update registration set usertype='" + cmbTipoUsuario.Text + "', password='" + txtSenha.Text + "',contactno='" + txtNumContato.Text + "',email='" + txtEmail.Text + "',name='" + txtNome.Text + "' where username='" + txtNomeUsuario.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();

                MessageBox.Show("Atualizado com sucesso", "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Autocomplete();
                btnAtualizarCadastro.Enabled = false;                
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
                delete_cadastro();
            }
        }
        private void delete_cadastro()
        {

            try
            {
                if (txtNomeUsuario.Text == "admin")
                {
                    MessageBox.Show("A conta 'admin' não pode ser excluída", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "delete from Registration where Username='" + txtNomeUsuario.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Deletado com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Autocomplete();
                    Reset();
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


        private void txtNumContato_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
