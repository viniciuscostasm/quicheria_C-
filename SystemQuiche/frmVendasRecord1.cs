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
    public partial class frmVendasRecord1 : Form
    {
        DataTable dTable;
        SqlConnection con = null;
        SqlDataAdapter adp;
        DataSet ds;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();

        public frmVendasRecord1()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmVendasRecord1_Load(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Nada para exportar para o Excel..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null)
            {
                MessageBox.Show("Nada para exportar para o Excel..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dtpFaturaDateDe.Text = DateTime.Today.ToString();
            dtpFaturaDateAte.Text = DateTime.Today.ToString();
            groupBox3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            dataGridView2.DataSource = null;
            groupBox10.Visible = false;
        
        }

        private void btnDados_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox3.Visible = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(invoiceNo) as [Order No.],RTRIM(InvoiceDate) as [Order Date],RTRIM(SubTotal) as [SubTotal],RTRIM(VATPer) as [Vat+ST %],RTRIM(VATAmount) as [VAT+ST Amount],RTRIM(DiscountPer) as [Discount %],RTRIM(DiscountAmount) as [Discount Amount],RTRIM(GrandTotal) as [Grand Total],RTRIM(TotalPayment) as [Total Payment],RTRIM(PaymentDue) as [Payment Due],Remarks from Invoice_Info where InvoiceDate between @d1 and @d2 order by InvoiceDate desc", con);
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = dtpFaturaDateDe.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = dtpFaturaDateAte.Value.Date;
                //cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = String.Format("{0:dd/MM/yyyy}", dtpInvoiceDateFrom.Value.Date);
                //cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = String.Format("{0:dd/MM/yyyy}", dtpInvoiceDateTo.Value.Date);

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
                textBox1.Text = sum.ToString();
                textBox2.Text = sum1.ToString();
                textBox3.Text = sum2.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox10.Visible = true;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(invoiceNo) as [Order No.],RTRIM(InvoiceDate) as [Order Date],RTRIM(SubTotal) as [SubTotal],RTRIM(VATPer) as [Vat+ST %],RTRIM(VATAmount) as [VAT+ST Amount],RTRIM(DiscountPer) as [Discount %],RTRIM(DiscountAmount) as [Discount Amount],RTRIM(GrandTotal) as [Grand Total],RTRIM(TotalPayment) as [Total Payment],RTRIM(PaymentDue) as [Payment Due],Remarks from Invoice_Info and InvoiceDate between @d1 and @d2 and PaymentDue > 0 order by InvoiceDate desc", con);
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
                textBox12.Text = sum.ToString();
                textBox11.Text = sum1.ToString();
                textBox10.Text = sum2.ToString();

                con.Close();
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
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dtpFaturaDateDe.Text = DateTime.Today.ToString();
            dtpFaturaDateAte.Text = DateTime.Today.ToString();
            groupBox3.Visible = false;
            dateTimePicker1.Text = DateTime.Today.ToString();
            dateTimePicker2.Text = DateTime.Today.ToString();
            dataGridView2.DataSource = null;
            groupBox10.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void btnVerRelatorio_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptVendas rpt = new rptVendas();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                RMS_DBDataSet myDS = new RMS_DBDataSet();
                //The DataSet you created.
                con = new SqlConnection(cs.DBConn);
                cmd.Connection = con;
                cmd.CommandText = "SELECT * from Invoice_Info where InvoiceDate Between @d1 and @d2 order by InvoiceDate";
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = dtpFaturaDateDe.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = dtpFaturaDateAte.Value.Date;
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "Invoice_Info");
                rpt.SetDataSource(myDS);
                frmVendasReport frm = new frmVendasReport();
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                rptVendas rpt = new rptVendas();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                RMS_DBDataSet myDS = new RMS_DBDataSet();
                //The DataSet you created.
                con = new SqlConnection(cs.DBConn);
                cmd.Connection = con;
                cmd.CommandText = "SELECT * from Invoice_Info where InvoiceDate Between @d1 and @d2 and PaymentDue > 0 order by InvoiceDate ";
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = dateTimePicker2.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = dateTimePicker1.Value.Date;
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                myDA.Fill(myDS, "Invoice_Info");
                rpt.SetDataSource(myDS);
                frmVendasReport frm = new frmVendasReport();
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
