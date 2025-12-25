using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using QuanLyTiemSach.Domain.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    public partial class FormViewOrderDetail : Form
    {
        private Order _order;

        public FormViewOrderDetail(Order order)
        {
            _order = order;
            InitializeComponent();
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            lblOrderId.Text = $"Mã hóa đơn: #{_order.Id}";
            lblOrderDate.Text = $"Ngày mua: {_order.OrderDate:dd/MM/yyyy HH:mm}";
            lblCustomerName.Text = $"Khách hàng: {_order.Customer?.Name ?? "N/A"}";
            lblCustomerPhone.Text = $"SĐT: {_order.Customer?.PhoneNumber ?? "N/A"}";

            dgvItems.Rows.Clear();
            foreach (var item in _order.OrderDetails)
            {
                dgvItems.Rows.Add(
                    item.BookID,
                    item.Book?.Title ?? "N/A",
                    item.UnitPrice,
                    item.Quantity,
                    item.UnitPrice * item.Quantity
                );
            }

            lblTotalAmount.Text = $"TỔNG TIỀN: {_order.TotalAmount:N0} đ";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = $"HoaDon_{_order.Id}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportOrderToPDF(saveFileDialog.FileName);
                    MessageBox.Show($"Xuất PDF thành công!\nĐường dẫn: {saveFileDialog.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportOrderToPDF(string filePath)
        {
            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    using (Document document = new Document(pdf))
                    {
                        PdfFont font = GetVietnameseFont();
                        document.SetFont(font);

                        document.Add(new Paragraph("HÓA ĐƠN MUA HÀNG")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20)
                            .SetBold());

                        document.Add(new Paragraph($"Mã hóa đơn: #{_order.Id}")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(14));

                        document.Add(new Paragraph("\n"));

                        document.Add(new Paragraph($"Ngày: {_order.OrderDate:dd/MM/yyyy HH:mm}")
                            .SetFontSize(12));
                        document.Add(new Paragraph($"Khách hàng: {_order.Customer?.Name ?? "Khách vãng lai"}")
                            .SetFontSize(12));
                        document.Add(new Paragraph($"Số điện thoại: {_order.Customer?.PhoneNumber ?? "N/A"}")
                            .SetFontSize(12));

                        document.Add(new Paragraph("\n"));

                        float[] columnWidths = { 1, 3, 2, 1.5f, 2 };
                        Table table = new Table(UnitValue.CreatePercentArray(columnWidths));
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        table.AddHeaderCell(CreateHeaderCell("Mã sách"));
                        table.AddHeaderCell(CreateHeaderCell("Tên sách"));
                        table.AddHeaderCell(CreateHeaderCell("Đơn giá"));
                        table.AddHeaderCell(CreateHeaderCell("Số lượng"));
                        table.AddHeaderCell(CreateHeaderCell("Thành tiền"));

                        foreach (var item in _order.OrderDetails)
                        {
                            table.AddCell(CreateCell(item.BookID));
                            table.AddCell(CreateCell(item.Book?.Title ?? "N/A"));
                            table.AddCell(CreateCell($"{item.UnitPrice:N0} đ"));
                            table.AddCell(CreateCell(item.Quantity.ToString()));
                            table.AddCell(CreateCell($"{item.UnitPrice * item.Quantity:N0} đ"));
                        }

                        document.Add(table);

                        document.Add(new Paragraph("\n"));

                        document.Add(new Paragraph($"TỔNG TIỀN: {_order.TotalAmount:N0} đ")
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .SetFontSize(14)
                            .SetBold());

                        document.Add(new Paragraph("\n\n"));
                        document.Add(new Paragraph("Cảm ơn quý khách đã mua hàng!")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(12)
                            .SetItalic());
                    }
                }
            }
        }

        private PdfFont GetVietnameseFont()
        {
            try
            {
                string fontPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                    "arial.ttf"
                );

                if (File.Exists(fontPath))
                {
                    return PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                }

                string[] fontNames = { "times.ttf", "tahoma.ttf", "verdana.ttf" };
                foreach (var fontName in fontNames)
                {
                    fontPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                        fontName
                    );

                    if (File.Exists(fontPath))
                    {
                        return PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                    }
                }

         
                return PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            }
            catch
            {
       
                return PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            }
        }

        private Cell CreateHeaderCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text))
                .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBold()
                .SetPadding(5);
        }

        private Cell CreateCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetPadding(5);
        }
    }
}