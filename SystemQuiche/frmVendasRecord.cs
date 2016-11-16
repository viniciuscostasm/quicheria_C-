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
using Excel = Microsoft.Office.Interop.Excel;

namespace SystemQuiche
{
    public partial class frmVendasRecord : Form
    {
        DataTable dTable;
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public frmVendasRecord()
        {
            InitializeComponent();
        }

        private void frmVendasRecord_Load(object sender, EventArgs e)
        {

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Erro!! Nada para exportar para o Excel..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount - 1;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("Erro!! Nada para exportar para o Excel..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView2.RowCount - 1;
                colsTotal = dataGridView2.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView2.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView2.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dtpInvoiceDateFrom.Text = DateTime.Today.ToString();
            dtpInvoiceDateTo.Text = DateTime.Today.ToString();
            groupBox3.Visible = false;
        }

        private void btnResete_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            dataGridView2.DataSource = null;
            groupBox6.Visible = false;
        }

        private void btnObterDados_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox3.Visible = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(invoiceNo) as [No. Pedido],RTRIM(InvoiceDate) as [Data Pedido],RTRIM(SubTotal) as [SubTotal],RTRIM(VATPer) as [Imposto %],RTRIM(VATAmount) as [Valor Imposto],RTRIM(DiscountPer) as [Desconto %],RTRIM(DiscountAmount) as [Valor Desconto],RTRIM(GrandTotal) as [Total],RTRIM(TotalPayment) as [Valor Pago],RTRIM(PaymentDue) as [Valor Devido],Remarks from Invoice_Info where  InvoiceDate between @d1 and @d2 order by InvoiceDate desc", con);
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = String.Format("{0:dd/MM/yyyy}", dtpInvoiceDateFrom.Value.Date);
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = String.Format("{0:dd/MM/yyyy}", dtpInvoiceDateTo.Value.Date);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Invoice_Info");
                dataGridView1.DataSource = myDataSet.Tables["Invoice_Info"].DefaultView;
                Int64 sum = 0;
                Int64 sum1 = 0;
                Int64 sum2 = 0;

                foreach (DataGridViewRow r in this.dataGridView1.Rows)
                {
                    Int64 i = Convert.ToInt64(r.Cells[7].Value);
                    Int64 j = Convert.ToInt64(r.Cells[8].Value);
                    Int64 k = Convert.ToInt64(r.Cells[9].Value);
                    sum = sum + i;
                    sum1 = sum1 + j;
                    sum2 = sum2 + k;

                }
                txtValor.Text = sum.ToString();
                txtTotalPago.Text = sum1.ToString();
                txtTotalDevido.Text = sum2.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDados_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox6.Visible = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(invoiceNo) as [No. Pedido],RTRIM(InvoiceDate) as [Data Pedido],RTRIM(SubTotal) as [SubTotal],RTRIM(VATPer) as [Imposto %],RTRIM(VATAmount) as [Valor Imposto],RTRIM(DiscountPer) as [Desconto %],RTRIM(DiscountAmount) as [Valor Desconto],RTRIM(GrandTotal) as [Total],RTRIM(TotalPayment) as [Total Pago],RTRIM(PaymentDue) as [Valor Devido],Remarks from Invoice_Info where InvoiceDate between @d1 and @d2 and PaymentDue > 0 order by InvoiceDate desc", con);
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = dateTimePicker2.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = dateTimePicker1.Value.Date;
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "Invoice_Info");
                dataGridView2.DataSource = myDataSet.Tables["Invoice_Info"].DefaultView;
                Int64 sum = 0;
                Int64 sum1 = 0;
                Int64 sum2 = 0;

                foreach (DataGridViewRow r in this.dataGridView2.Rows)
                {
                    Int64 i = Convert.ToInt64(r.Cells[7].Value);
                    Int64 j = Convert.ToInt64(r.Cells[8].Value);
                    Int64 k = Convert.ToInt64(r.Cells[9].Value);
                    sum = sum + i;
                    sum1 = sum1 + j;
                    sum2 = sum2 + k;
                }
                txtValor2.Text = sum.ToString();
                txtVrlPago.Text = sum1.ToString();
                txtVlrDevido.Text = sum2.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVendasRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmVendas frm = new frmVendas();
            frm.Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmVendas Vendas = new frmVendas();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                Vendas.Show();
                Vendas.txtNumPedido.Text = dr.Cells[0].Value.ToString();
                Vendas.dtpDataPedido.Text = dr.Cells[1].Value.ToString();
                Vendas.txtSubTotal.Text = dr.Cells[2].Value.ToString();
                Vendas.txtTaxPer.Text = dr.Cells[3].Value.ToString();
                Vendas.txtTaxAmt.Text = dr.Cells[4].Value.ToString();
                Vendas.txtDescontoPer.Text = dr.Cells[5].Value.ToString();
                Vendas.txtDescontoAmount.Text = dr.Cells[6].Value.ToString();
                Vendas.txtTotal.Text = dr.Cells[7].Value.ToString();
                Vendas.txtTotalPago.Text = dr.Cells[8].Value.ToString();
                Vendas.txtValorDevido.Text = dr.Cells[9].Value.ToString();
                Vendas.txtObservacoes.Text = dr.Cells[10].Value.ToString();
                Vendas.btnAtualizar.Enabled = true;
                Vendas.btnDeletar.Enabled = true;
                Vendas.btnPrint.Enabled = true;
                Vendas.btnSalvar.Enabled = false;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Product.ProductID,ProductSold.Productname,ProductSold.Price,ProductSold.Quantity,ProductSold.TotalAmount from Invoice_Info,ProductSold,Product where Invoice_info.InvoiceNo=ProductSold.InvoiceNo and Product.ProductID=ProductSold.ProductID and invoice_Info.InvoiceNo='" + dr.Cells[0].Value.ToString() + "'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read() == true)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(rdr[0].ToString().Trim());
                    lst.SubItems.Add(rdr[1].ToString().Trim());
                    lst.SubItems.Add(rdr[2].ToString().Trim());
                    lst.SubItems.Add(rdr[3].ToString().Trim());
                    lst.SubItems.Add(rdr[4].ToString().Trim());
                    Vendas.listView1.Items.Add(lst);
                }
                Vendas.listView1.Enabled = false;
                Vendas.btnIncluirCarrinho.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                this.Hide();
                frmVendas Vendas = new frmVendas();
                // or simply use column name instead of index
                // dr.Cells["id"].Value.ToString();
                Vendas.Show();
                Vendas.txtNumPedido.Text = dr.Cells[0].Value.ToString();
                Vendas.dtpDataPedido.Text = dr.Cells[1].Value.ToString();
                Vendas.txtSubTotal.Text = dr.Cells[2].Value.ToString();
                Vendas.txtTaxPer.Text = dr.Cells[3].Value.ToString();
                Vendas.txtTaxAmt.Text = dr.Cells[4].Value.ToString();
                Vendas.txtDescontoPer.Text = dr.Cells[5].Value.ToString();
                Vendas.txtDescontoAmount.Text = dr.Cells[6].Value.ToString();
                Vendas.txtTotal.Text = dr.Cells[7].Value.ToString();
                Vendas.txtTotalPago.Text = dr.Cells[8].Value.ToString();
                Vendas.txtValorDevido.Text = dr.Cells[9].Value.ToString();
                Vendas.txtObservacoes.Text = dr.Cells[10].Value.ToString();
                Vendas.btnAtualizar.Enabled = true;
                Vendas.btnDeletar.Enabled = true;
                Vendas.btnPrint.Enabled = true;
                Vendas.btnSalvar.Enabled = false;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Product.ProductID,ProductSold.Productname,ProductSold.Price,ProductSold.Quantity,ProductSold.TotalAmount from Invoice_Info,ProductSold,Product where Invoice_info.InvoiceNo=ProductSold.InvoiceNo and Product.ProductID=ProductSold.ProductID and invoice_Info.InvoiceNo='" + dr.Cells[0].Value.ToString() + "'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read() == true)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(rdr[0].ToString().Trim());
                    lst.SubItems.Add(rdr[1].ToString().Trim());
                    lst.SubItems.Add(rdr[2].ToString().Trim());
                    lst.SubItems.Add(rdr[3].ToString().Trim());
                    lst.SubItems.Add(rdr[4].ToString().Trim());
                    Vendas.listView1.Items.Add(lst);
                }
                Vendas.listView1.Enabled = false;
                Vendas.btnIncluirCarrinho.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dtpInvoiceDateFrom.Text = DateTime.Today.ToString();
            dtpInvoiceDateTo.Text = DateTime.Today.ToString();
            groupBox3.Visible = false;
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            dataGridView2.DataSource = null;
            groupBox6.Visible = false;

        }
    }
}
