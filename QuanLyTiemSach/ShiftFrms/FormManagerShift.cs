using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.BLL.Services.Implements;
using QuanLyTiemSach.DAL;
//using WorkShiftManagement.Data;
using WorkShiftManagement.Models;

namespace WorkShiftManagement.Forms
{
    public partial class FormManagerShift : Form
    {
        private readonly WorkShiftService _service;
        private readonly BookStoreDbContext _context;
        private DateTime _currentWeekStart;
        private List<Employee> _employees;

        public FormManagerShift()
        {
            InitializeComponent();

            _context = new BookStoreDbContext();
            _service = new WorkShiftService(_context);

            // Set tuần hiện tại
            _currentWeekStart = GetMondayOfWeek(DateTime.Now);
        }

        private void WorkShiftForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadShiftTypes();
            LoadWeekSchedule();
            ConfigureLayout();
        }

        private void ConfigureLayout()
        {
            panelTop.Dock = DockStyle.Top;
            groupBoxAdd.Dock = DockStyle.Top;
            panelSchedule.Dock = DockStyle.Fill;

            btnPreviousWeek.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            btnNextWeek.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            lblWeekRange.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            btnAddShift.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dgvSchedule.Dock = DockStyle.Fill;
        }

        private void LoadEmployees()
        {
            _employees = _service.GetAllEmployees();
            cboEmployee.DataSource = _employees;
            cboEmployee.DisplayMember = "FullName";
            cboEmployee.ValueMember = "EmployeeId";
        }

        private void LoadShiftTypes()
        {
            var shiftTypes = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "Ca Sáng (6h-12h)"),
                new KeyValuePair<int, string>(2, "Ca Trưa (12h-18h)"),
                new KeyValuePair<int, string>(3, "Ca Chiều (18h-22h)"),
                new KeyValuePair<int, string>(4, "Ca Tối (22h-6h)")
            };

            cboShiftType.DataSource = shiftTypes;
            cboShiftType.DisplayMember = "Value";
            cboShiftType.ValueMember = "Key";
        }

        private DateTime GetMondayOfWeek(DateTime date)
        {
            int daysUntilMonday = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            return date.AddDays(-daysUntilMonday).Date;
        }

        private void LoadWeekSchedule()
        {
            DateTime endDate = _currentWeekStart.AddDays(6);
            lblWeekRange.Text = $"Tuần từ {_currentWeekStart:dd/MM/yyyy} đến {endDate:dd/MM/yyyy}";

            var workShifts = _service.GetWorkShiftsByWeek(_currentWeekStart);

            BuildScheduleTable(workShifts);
        }

        private void BuildScheduleTable(List<WorkShift> workShifts)
        {
            dgvSchedule.Columns.Clear();
            dgvSchedule.Rows.Clear();

            // Thêm cột cho Ca làm
            var colShift = new DataGridViewTextBoxColumn
            {
                Name = "Shift",
                HeaderText = "Ca Làm",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold),
                    BackColor = Color.LightGray
                }
            };
            dgvSchedule.Columns.Add(colShift);

            // Thêm 7 cột cho 7 ngày trong tuần
            var vietnameseCulture = new CultureInfo("vi-VN");
            for (int i = 0; i < 7; i++)
            {
                DateTime date = _currentWeekStart.AddDays(i);
                string dayName = vietnameseCulture.DateTimeFormat.GetDayName(date.DayOfWeek);

                var col = new DataGridViewTextBoxColumn
                {
                    Name = $"Day{i}",
                    HeaderText = $"{dayName}\n{date:dd/MM/yyyy}",
                    Width = 150,
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        WrapMode = DataGridViewTriState.True,
                        Alignment = DataGridViewContentAlignment.TopLeft
                    }
                };
                dgvSchedule.Columns.Add(col);
            }

            // Thêm 4 dòng cho 4 ca
            string[] shifts = { "Ca Sáng\n(6h-12h)", "Ca Trưa\n(12h-18h)", "Ca Chiều\n(18h-22h)", "Ca Tối\n(22h-6h)" };
            for (int i = 0; i < 4; i++)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dgvSchedule);
                row.Cells[0].Value = shifts[i];
                row.Height = 100;
                dgvSchedule.Rows.Add(row);
            }

            // Điền dữ liệu
            foreach (var shift in workShifts)
            {
                int dayIndex = (shift.WorkDate - _currentWeekStart).Days + 1; // +1 vì cột 0 là Ca làm
                int rowIndex = shift.ShiftType - 1;

                if (dayIndex >= 1 && dayIndex <= 7 && rowIndex >= 0 && rowIndex < 4)
                {
                    string currentValue = dgvSchedule.Rows[rowIndex].Cells[dayIndex].Value?.ToString() ?? "";
                    string newValue = currentValue + (currentValue.Length > 0 ? "\n" : "") +
                                    $"• {shift.Employee.FullName}";

                    if (!string.IsNullOrEmpty(shift.Note))
                    {
                        newValue += $" ({shift.Note})";
                    }

                    dgvSchedule.Rows[rowIndex].Cells[dayIndex].Value = newValue;
                    dgvSchedule.Rows[rowIndex].Cells[dayIndex].Tag = shift.WorkShiftId;
                }
            }

            // Styling
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            dgvSchedule.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSchedule.ColumnHeadersHeight = 50;
            dgvSchedule.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboShiftType.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = (int)cboEmployee.SelectedValue;
            DateTime workDate = dtpWorkDate.Value.Date;
            int shiftType = (int)cboShiftType.SelectedValue;
            string note = txtNote.Text.Trim();

            string error = _service.AddWorkShift(employeeId, workDate, shiftType, note);

            if (error == null)
            {
                MessageBox.Show("Thêm ca làm việc thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNote.Clear();
                LoadWeekSchedule();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            _currentWeekStart = _currentWeekStart.AddDays(-7);
            LoadWeekSchedule();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            _currentWeekStart = _currentWeekStart.AddDays(7);
            LoadWeekSchedule();
        }

        private void dgvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            var cell = dgvSchedule.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString())) return;

            // Hiển thị menu xóa ca làm
            var result = MessageBox.Show(
                "Bạn có muốn xóa ca làm việc này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes && cell.Tag != null)
            {
                int workShiftId = (int)cell.Tag;
                if (_service.DeleteWorkShift(workShiftId))
                {
                    MessageBox.Show("Xóa ca làm việc thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWeekSchedule();
                }
                else
                {
                    MessageBox.Show("Xóa ca làm việc thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}