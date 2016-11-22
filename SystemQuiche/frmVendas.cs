using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace SystemQuiche
{
    public partial class frmVendas : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        ConnectionString cs = new ConnectionString();
        SqlDataReader rdr;

        public frmVendas()
        {
            InitializeComponent();
        }

        private void auto()
        {
          txtNumPedido.Text = "OD-" + GetUniqueKey(8);

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
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtTaxPer.Text == "")
                {
                    MessageBox.Show("Informe a taxa de percentagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaxPer.Focus();
                    return;
                }
                if (txtDescontoPer.Text == "")
                {
                    MessageBox.Show("Informe o desconto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescontoPer.Focus();
                    return;
                }
                if (txtTotalPago.Text == "")
                {
                    MessageBox.Show("Informe o  Valor Pago", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalPago.Focus();
                    return;
                }

                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Erro no produto adicionado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                auto();

                con = new SqlConnection(cs.DBConn);
                con.Open();

                string cb = "insert Into Invoice_Info(InvoiceNo,InvoiceDate,SubTotal,VATPer,VATAmount,DiscountPer,DiscountAmount,GrandTotal,TotalPayment,PaymentDue,Remarks) VALUES ('" + txtNumPedido.Text + "','" + dtpDataPedido.Text + "'," + txtSubTotal.Text + "," + txtTaxPer.Text + "," + txtTaxAmt.Text + "," + txtDescontoPer.Text + "," + txtDescontoAmount.Text + "," + txtTotal.Text + "," + txtTotalPago.Text + "," + txtValorDevido.Text + ",'" + txtObservacoes.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();


                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);

                    string cd = "insert Into ProductSold(InvoiceNo,ProductID,ProductName,Quantity,Price,TotalAmount) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                    cmd = new SqlCommand(cd);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("d1", txtNumPedido.Text);
                    cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("d3", listView1.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("d4", listView1.Items[i].SubItems[4].Text);
                    cmd.Parameters.AddWithValue("d5", listView1.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("d6", listView1.Items[i].SubItems[5].Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                btnSalvar.Enabled = false;
                btnPrint.Enabled = true;
                MessageBox.Show("Colocado com sucesso", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Calcular()
        {
            if (txtTaxPer.Text != "")
            {
                txtTaxAmt.Text = Convert.ToInt32((Convert.ToInt32(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100)).ToString();

            }
            if (txtDescontoPer.Text != "")
            {
                txtDescontoAmount.Text = Convert.ToInt32(((Convert.ToInt32(txtSubTotal.Text) + Convert.ToInt32(txtTaxAmt.Text)) * Convert.ToDouble(txtDescontoPer.Text) / 100)).ToString();
            }
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;
            int.TryParse(txtTaxAmt.Text, out val1);
            int.TryParse(txtSubTotal.Text, out val2);
            int.TryParse(txtDescontoAmount.Text, out val3);
            int.TryParse(txtTotal.Text, out val4);
            int.TryParse(txtTotalPago.Text, out val5);
            val4 = val1 + val2 - val3;
            txtTotal.Text = val4.ToString();
            int I = (val4 - val5);
            txtValorDevido.Text = I.ToString();


        }

        private void txtQtdVenda_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtPreco.Text, out val1);
            int.TryParse(txtQtdVenda.Text, out val2);
            int I = (val1 * val2);
            txtValorTotal.Text = I.ToString();
        }

        public double subtotal()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            i = 0;
            j = 0;
            k = 0;


            try
            {

                j = listView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(listView1.Items[i].SubItems[5].Text);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }

        private void btnIncluirCarrinho_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbNomeProduto.Text == "")
                {
                    MessageBox.Show("Selecione o nome do produto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtQtdVenda.Text == "")
                {
                    MessageBox.Show("Informe a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQtdVenda.Focus();
                    return;
                }
                int QuantidadeVenda = Convert.ToInt32(txtQtdVenda.Text);
                if (QuantidadeVenda == 0)
                {
                    MessageBox.Show("Quantidade não pode ser zero", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQtdVenda.Focus();
                    return;
                }

                if (listView1.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(txtProdutoID.Text);
                    lst.SubItems.Add(cmbNomeProduto.Text);
                    lst.SubItems.Add(txtPreco.Text);
                    lst.SubItems.Add(txtQtdVenda.Text);
                    lst.SubItems.Add(txtValorTotal.Text);
                    listView1.Items.Add(lst);
                    txtSubTotal.Text = subtotal().ToString();

                    Calcular();
                    cmbNomeProduto.Text = "";
                    txtProdutoID.Text = "";
                    txtPreco.Text = "";
                    txtQtdVenda.Text = "";
                    txtValorTotal.Text = "";
                    return;
                }

                for (int j = 0; j <= listView1.Items.Count - 1; j++)
                {
                    if (listView1.Items[j].SubItems[1].Text == txtProdutoID.Text)
                    {
                        listView1.Items[j].SubItems[1].Text = txtProdutoID.Text;
                        listView1.Items[j].SubItems[2].Text = cmbNomeProduto.Text;
                        listView1.Items[j].SubItems[3].Text = txtPreco.Text;
                        listView1.Items[j].SubItems[4].Text = (Convert.ToInt32(listView1.Items[j].SubItems[4].Text) + Convert.ToInt32(txtQtdVenda.Text)).ToString();
                        listView1.Items[j].SubItems[5].Text = (Convert.ToInt32(listView1.Items[j].SubItems[5].Text) + Convert.ToInt32(txtValorTotal.Text)).ToString();
                        txtSubTotal.Text = subtotal().ToString();
                        Calcular();
                        cmbNomeProduto.Text = "";
                        txtProdutoID.Text = "";
                        txtPreco.Text = "";
                        txtQtdVenda.Text = "";
                        txtValorTotal.Text = "";
                        return;

                    }
                }

                ListViewItem lst1 = new ListViewItem();

                lst1.SubItems.Add(txtProdutoID.Text);
                lst1.SubItems.Add(cmbNomeProduto.Text);
                lst1.SubItems.Add(txtPreco.Text);
                lst1.SubItems.Add(txtQtdVenda.Text);
                lst1.SubItems.Add(txtValorTotal.Text);
                listView1.Items.Add(lst1);
                txtSubTotal.Text = subtotal().ToString();
                Calcular();
                cmbNomeProduto.Text = "";
                txtProdutoID.Text = "";
                txtPreco.Text = "";
                txtQtdVenda.Text = "";
                txtValorTotal.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Sem items para remover", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    listView1.FocusedItem.Remove();
                    itmCnt = listView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        
                        t = t + 1;

                    }
                    txtSubTotal.Text = subtotal().ToString();
                    Calcular();
                }

                btnRemover.Enabled = false;
                if (listView1.Items.Count == 0)
                {
                    txtSubTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTaxPer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTaxPer.Text))
                {
                    txtTaxAmt.Text = "";
                    txtTotal.Text = "";
                    return;
                }
                Calcular();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemover.Enabled = true;
        }

        private void Reset()
        {
            txtNumPedido.Text = "";
            dtpDataPedido.Text = DateTime.Today.ToString();

            cmbNomeProduto.Text = "";
            txtProdutoID.Text = "";
            txtPreco.Text = "";

            txtQtdVenda.Text = "";
            txtValorTotal.Text = "";
            listView1.Items.Clear();
            txtDescontoAmount.Text = "";
            txtDescontoPer.Text = "";

            txtSubTotal.Text = "";
            txtTaxPer.Text = "";
            txtTaxAmt.Text = "";
            txtTotal.Text = "";
            txtTotalPago.Text = "";
            txtValorDevido.Text = "";
            txtObservacoes.Text = "";
            btnSalvar.Enabled = true;
            btnDeletar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnRemover.Enabled = false;
            btnPrint.Enabled = false;
            listView1.Enabled = true;
            btnIncluirCarrinho.Enabled = true;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Reset();
            Reset();
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
                string cq1 = "delete from productSold where InvoiceNo='" + txtNumPedido.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from Invoice_Info where InvoiceNo='" + txtNumPedido.Text + "'";
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

        private void txtTotalPago_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtTotal.Text, out val1);
            int.TryParse(txtTotalPago.Text, out val2);
            int I = (val1 - val2);
            txtValorDevido.Text = I.ToString();
        }

        private void txtTotalPago_Validating(object sender, CancelEventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtTotal.Text, out val1);
            int.TryParse(txtTotalPago.Text, out val2);
            if (val2 > val1)
            {
                MessageBox.Show("Valor Pago não pode ser maior que o valor total", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPago.Text = "";
                txtValorDevido.Text = "";
                txtTotalPago.Focus();
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptFatura rpt = new rptFatura();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                RMS_DBDataSet myDS = new RMS_DBDataSet();
                //The DataSet you created.
                con = new SqlConnection(cs.DBConn);
                cmd.Connection = con;
                cmd.CommandText = "SELECT * from invoice_info,productsold where invoice_info.invoiceno=productsold.invoiceno and Invoice_info.invoiceNo='" + txtNumPedido.Text + "'";
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "Invoice_Info");
                myDA.Fill(myDS, "ProductSold");
                rpt.SetDataSource(myDS);
                frmFaturaReport frm = new frmFaturaReport();
                //frm.crystalReportViewer1.ReportSource = rpt;
                frm.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String cb = "update Invoice_info set  VATPer=" + txtTaxPer.Text + ",VATAmount=" + txtTaxAmt.Text + ",DiscountPer=" + txtDescontoPer.Text + ",DiscountAmount=" + txtDescontoAmount.Text + ",GrandTotal= " + txtTotal.Text + ",TotalPayment= " + txtTotalPago.Text + ",PaymentDue= " + txtValorDevido.Text + ",Remarks='" + txtObservacoes.Text + "' where Invoiceno= '" + txtNumPedido.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                btnAtualizar.Enabled = false;
                MessageBox.Show("Atualizado com sucesso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcurarPedido_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmVendasRecord frm = new frmVendasRecord();
            frm.dataGridView1.DataSource = null;
            frm.dtpInvoiceDateFrom.Text = DateTime.Today.ToString();
            frm.dtpInvoiceDateTo.Text = DateTime.Today.ToString();
            frm.groupBox3.Visible = false;
            frm.dateTimePicker1.Text = DateTime.Today.ToString();
            frm.dateTimePicker2.Text = DateTime.Today.ToString();
            frm.dataGridView2.DataSource = null;
            frm.groupBox6.Visible = false;
            frm.Show();
        }

        private void txtQtdVenda_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalPago_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTaxPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDescontoPer_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }
        public void FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(ProductName) from Product order by ProductName";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   cmbNomeProduto.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmVendas_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void cmbNomeProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT ProductID,Price from Product WHERE ProductName = '" + cmbNomeProduto.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    txtProdutoID.Text = rdr.GetInt32(0).ToString().Trim();
                    txtPreco.Text = rdr.GetValue(1).ToString().Trim();
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
        
    }
}
