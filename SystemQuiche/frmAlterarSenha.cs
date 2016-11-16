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
    public partial class frmAlterarSenha : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        
        public frmAlterarSenha()
        {
            InitializeComponent();
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                if ((txtNomeUsuario.Text.Trim().Length == 0 ))
                {
                    MessageBox.Show("Informe o Usuário", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeUsuario.Focus();
                    return;
                }
                if ((txtOldSenha.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Informe a senha anterior", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldSenha.Focus();
                    return;
                }
                if ((txtNovaSenha.Text.Trim().Length == 0 ))
                {
                    MessageBox.Show("Informe a nova senha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNovaSenha.Focus();
                    return;
                }
                if ((txtConfirmaSenha.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Confirme a nova senha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmaSenha.Focus();
                    return;
                }
                if ((txtNovaSenha.TextLength < 5))
                {
                    MessageBox.Show("A nova senha deve ter o minimo 5 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNovaSenha.Text = "";
                    txtConfirmaSenha.Text = "";
                    txtNovaSenha.Focus();
                    return;
                }
                else if ((txtNovaSenha.Text != txtConfirmaSenha.Text))
                {
                    MessageBox.Show("Senha não confere", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNovaSenha.Text = "";
                    txtOldSenha.Text = "";
                    txtConfirmaSenha.Text = "";
                    txtOldSenha.Focus();
                    return;
                }
                else if ((txtOldSenha.Text == txtNovaSenha.Text))
                {
                    MessageBox.Show("Senha é a mesma.Informe uma nova senha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNovaSenha.Text = "";
                    txtConfirmaSenha.Text = "";
                    txtNovaSenha.Focus();
                    return;
                }
              
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string co = "Update Registration set Password = '" + txtNovaSenha.Text + "'where UserName='" + txtNomeUsuario.Text + "' and Password = '" + txtOldSenha.Text + "'";

                cmd = new SqlCommand(co);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if ((RowsAffected > 0))
                {
                    MessageBox.Show("Alteração feita com sucesso", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    txtNomeUsuario.Text = "";
                    txtNovaSenha.Text = "";
                    txtOldSenha.Text = "";
                    txtConfirmaSenha.Text = "";
                    frmLogin LoginForm1 = new frmLogin();
                    LoginForm1.Show();
                    LoginForm1.txtNomeUsuario.Text = "";
                    LoginForm1.txtSenha.Text = "";
                    LoginForm1.progressBar1.Visible = false;
                    LoginForm1.txtNomeUsuario.Focus();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválido(s)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeUsuario.Text = "";
                    txtNovaSenha.Text = "";
                    txtOldSenha.Text = "";
                    txtConfirmaSenha.Text = "";
                    txtNomeUsuario.Focus();
                }
                if ((con.State == ConnectionState.Open))
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

        private void frmAlterarSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.txtNomeUsuario.Text = "";
            frm.txtSenha.Text = "";
            frm.progressBar1.Visible = false;
            frm.txtNomeUsuario.Focus();
        }
            
    }
        
}


