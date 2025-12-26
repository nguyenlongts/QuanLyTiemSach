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
        private readonly SemaphoreSlim _loadLock = new SemaphoreSlim(1, 1);
        private bool _isLoading = true;

        public FormSalary(ISalaryService salaryService)
        {
            InitializeComponent();
            _salaryService = salaryService;
        }

        private async void SalaryForm_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            InitializeMonthComboBox();
            InitializeYearComboBox();
            await LoadEmployeesAsync();
            ConfigureDataGridView();
            await LoadSalaryDataAsync();
            ConfigureLayout();
            _isLoading = false;
        }

        private async Task LoadEmployeesAsync()
        {
            try
            {
                var employees = (await _salaryService.GetAllEmployeesAsync())
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
                MessageBox.Show($"Lỗi khi tải nhân viên: {ex.Message}");
            }
        }
        private async Task LoadShiftCountAsync()
        {
            if (cboEmployee.SelectedItem is not Employee employee ||
                cboMonth.SelectedIndex < 0 ||
                cboYear.SelectedItem == null)
            {
                txtShifts.Clear();
                txtAmount.Clear();
                return;
            }

            await _loadLock.WaitAsync();
            try
            {
                int employeeId = employee.EmployeeId;
                int month = cboMonth.SelectedIndex + 1;
                int year = (int)cboYear.SelectedItem;

                int shifts = await _salaryService
                    .GetShiftCountByMonthAsync(employeeId, month, year);

                txtShifts.Text = shifts.ToString();
                txtAmount.Text = shifts > 0
                    ? _salaryService.CalculateSalary(shifts).ToString("N0") + " VNĐ"
                    : "0 VNĐ";
            }
            finally
            {
                _loadLock.Release();
            }
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



        private async void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (cboEmployee.SelectedItem is Employee emp)
            {
                txtEmployeeId.Text = emp.EmployeeCode.ToString();
                await LoadShiftCountAsync();
            }
            else
            {
                txtEmployeeId.Clear();
            }
        }


        private async void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadShiftCountAsync();
        }

        private async void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            await LoadShiftCountAsync();
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


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            int employeeId = (int)cboEmployee.SelectedValue;
            int month = cboMonth.SelectedIndex + 1;
            int year = (int)cboYear.SelectedItem;

            if (await _salaryService.IsSalaryExistsAsync(employeeId, month))
            {
                var confirm = MessageBox.Show(
                    "Lương đã tồn tại, bạn có muốn cập nhật?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo);

                if (confirm != DialogResult.Yes) return;
            }

            var result = await _salaryService
                .CreateOrUpdateSalaryAsync(employeeId, month, year);

            MessageBox.Show(result.message,
                result.success ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK,
                result.success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.success)
            {
                await LoadSalaryDataAsync();
                ClearForm();
            }
        }
        private async Task LoadSalaryDataAsync()
        {
            dgvSalary.DataSource = null;
            dgvSalary.DataSource = await _salaryService.GetAllSalariesAsync();
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
    }
}