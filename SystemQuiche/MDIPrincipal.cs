using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemQuiche
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Categorias = new frmCategoria();
            Categorias.MdiParent = this;
            Categorias.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Produtos = new frmProdutos();
            Produtos.MdiParent = this;
            Produtos.Show();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form CadastroUsuario = new frmCadastroUsuario();
            CadastroUsuario.MdiParent = this;
            CadastroUsuario.Show();
        }

        private void cadastrosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form CadastroUsuario = new frmCadastroUsuario();
            CadastroUsuario.MdiParent = this;
            CadastroUsuario.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Produtos = new frmProdutos();
            Produtos.MdiParent = this;
            Produtos.Show();
        }

        private void loginDetalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Login_Detalhes = new frmLoginDetalhes();
            Login_Detalhes.MdiParent = this;
            Login_Detalhes.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Perfil_Clientes = new frmClientes();
            Perfil_Clientes.MdiParent = this;
            Perfil_Clientes.Show();
        }

        private void faturamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Faturamento = new frmVendas();
            Faturamento.MdiParent = this;
            Faturamento.Show();
        }

        private void faturamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Faturamento = new frmVendas();
            Faturamento.MdiParent = this;
            Faturamento.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Relatorio_Clientes = new frmClientesReport();
            Relatorio_Clientes.MdiParent = this;
            Relatorio_Clientes.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Relatorio_Vendas = new frmVendasReport();
            Relatorio_Vendas.MdiParent = this;
            Relatorio_Vendas.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void gerenciadorDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WinWord.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WordPad.exe");
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobreSistema = new frmSobre();
            sobreSistema.MdiParent = this;
            sobreSistema.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString();
        }
    }
}
