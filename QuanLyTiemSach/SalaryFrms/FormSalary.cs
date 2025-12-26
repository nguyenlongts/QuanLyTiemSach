using QuanLyTiemSach.BLL.Services.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.SalaryFrms
{
    public partial class FormSalary : Form
    {
        private readonly ISalaryService _salaryService;

        public FormSalary(ISalaryService salaryService)
        {
            InitializeComponent();
            _salaryService = salaryService;
        }

        private void SalaryForm_Load(object sender, EventArgs e)
        {
            InitializeMonthComboBox();
            InitializeYearComboBox();
            LoadEmployees();
            ConfigureDataGridView();
            LoadSalaryData();
            ConfigureLayout();
        }


        private void ConfigureLayout()
        {
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            groupBoxInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            groupBoxList.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            dgvSalary.Dock = DockStyle.Fill;

            btnCalculate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = _salaryService.GetAllEmployees()
                    .Where(e => e.IsActive) 
                    .OrderBy(e => e.FullName)
                    .ToList();

                cboEmployee.DataSource = employees;
                cboEmployee.DisplayMember = "FullName";
                cboEmployee.ValueMember = "EmployeeId";
                cboEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeMonthComboBox()
        {
            cboMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboMonth.Items.Add($"Tháng {i}");
            }
            cboMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void InitializeYearComboBox()
        {
            cboYear.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 2; i <= currentYear + 1; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = currentYear;
        }

        private void ConfigureDataGridView()
        {
            dgvSalary.AutoGenerateColumns = false;
            dgvSalary.Columns.Clear();

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Lương",
                DataPropertyName = "Id",
                Width = 100
            });

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã NV",
                DataPropertyName = "EmployeeId",
                Width = 100
            });

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tháng",
                DataPropertyName = "Month",
                Width = 80
            });

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lương (VNĐ)",
                DataPropertyName = "Amount",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedValue != null && cboEmployee.SelectedValue is int)
            {
                var selectedEmployee = cboEmployee.SelectedItem as Employee;
                if (selectedEmployee != null)
                {
                    txtEmployeeId.Text = selectedEmployee.EmployeeCode;
                    LoadShiftCount();
                }
            }
            else
            {
                txtEmployeeId.Clear();
                txtShifts.Clear();
                txtAmount.Clear();
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShiftCount();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShiftCount();
        }

        private void LoadShiftCount()
        {
            try
            {
                if (cboEmployee.SelectedIndex < 0 ||
                    cboMonth.SelectedIndex < 0 ||
                    cboYear.SelectedItem == null)
                {
                    txtShifts.Text = string.Empty;
                    txtAmount.Text = string.Empty;
                    return;
                }

                int employeeId = (int)cboEmployee.SelectedValue;
                int month = cboMonth.SelectedIndex + 1;
                int year = (int)cboYear.SelectedItem;

                int shifts = _salaryService.GetShiftCountByMonth(employeeId, month, year);
                txtShifts.Text = shifts.ToString();

                if (shifts > 0)
                {
                    CalculateSalary();
                }
                else
                {
                    txtAmount.Text = "0 VNĐ";
                    MessageBox.Show($"Nhân viên chưa có ca làm nào trong tháng {month}/{year}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải số ca: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShifts.Clear();
                txtAmount.Clear();
            }
        }

        private void CalculateSalary()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtShifts.Text))
                {
                    txtAmount.Text = string.Empty;
                    return;
                }

                if (!int.TryParse(txtShifts.Text, out int shifts) || shifts < 0)
                {
                    txtAmount.Text = string.Empty;
                    return;
                }

                decimal totalSalary = _salaryService.CalculateSalary(shifts);
                txtAmount.Text = totalSalary.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính lương: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            LoadShiftCount();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                {
                    return;
                }

                int employeeId = (int)cboEmployee.SelectedValue;
                int month = cboMonth.SelectedIndex + 1;
                int year = (int)cboYear.SelectedItem;

                int shifts = int.Parse(txtShifts.Text);
                if (shifts == 0)
                {
                    MessageBox.Show($"Nhân viên chưa có ca làm nào trong tháng {month}/{year}!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_salaryService.IsSalaryExists(employeeId, month))
                {
                    var result = MessageBox.Show(
                        $"Lương tháng {month}/{year} cho nhân viên này đã tồn tại. Bạn có muốn cập nhật?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }

                bool success = _salaryService.CreateOrUpdateSalary(employeeId, month, year, out string message);

                if (success)
                {
                    MessageBox.Show(message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSalaryData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cboEmployee.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEmployee.Focus();
                return false;
            }

            if (cboMonth.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tháng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonth.Focus();
                return false;
            }

            if (cboYear.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboYear.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtShifts.Text) || txtShifts.Text == "0")
            {
                MessageBox.Show("Chưa có thông tin ca làm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cboEmployee.SelectedIndex = -1;
            txtEmployeeId.Clear();
            txtShifts.Clear();
            txtAmount.Clear();
            cboMonth.SelectedIndex = DateTime.Now.Month - 1;
            cboYear.SelectedItem = DateTime.Now.Year;
            cboEmployee.Focus();
        }

        private void LoadSalaryData()
        {
            try
            {
                var salaries = _salaryService.GetAllSalaries();
                dgvSalary.DataSource = null;
                dgvSalary.DataSource = salaries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}