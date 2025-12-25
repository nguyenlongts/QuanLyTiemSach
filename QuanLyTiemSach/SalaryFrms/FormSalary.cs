using QuanLyTiemSach.Business.Services;
using QuanLyTiemSach.DAL;
using System;
using System.Windows.Forms;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.SalaryFrms
{
    public partial class FormSalary : Form
    {
        private readonly ISalaryService _salaryService;
        private readonly BookStoreDbContext _context;
        private List<Employee> _employees;

        public FormSalary(ISalaryService salaryService)
        {
            InitializeComponent();
            _salaryService = salaryService;
        }

        private void SalaryForm_Load(object sender, EventArgs e)
        {
            InitializeMonthComboBox();
            LoadSalaryData();
            //LoadEmployees();
            ConfigureDataGridView();

        }
        //private void LoadEmployees()
        //{
        //    _employees = _salaryService.GetAllEmployees();
        //    cboEmployee.DataSource = _employees;
        //    cboEmployee.DisplayMember = "FullName";
        //    cboEmployee.ValueMember = "EmployeeId";
        //}

        private void InitializeMonthComboBox()
        {
            cboMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboMonth.Items.Add($"Tháng {i}");
            }
            cboMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void ConfigureDataGridView()
        {
            dgvSalary.AutoGenerateColumns = false;
            dgvSalary.Columns.Clear();

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã",
                DataPropertyName = "Id",
                Width = 80
            });

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Nhân Viên",
                DataPropertyName = "EmployeeId",
                Width = 150
            });

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tháng",
                DataPropertyName = "Month",
                Width = 100
            });

            dgvSalary.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lương (VNĐ)",
                DataPropertyName = "Amount",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
        }

        private void txtShifts_TextChanged(object sender, EventArgs e)
        {
            // Auto calculate when shifts input changes
            if (!string.IsNullOrWhiteSpace(txtShifts.Text))
            {
                CalculateSalary();
            }
            else
            {
                txtAmount.Text = string.Empty;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void CalculateSalary()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtShifts.Text))
                {
                    MessageBox.Show("Vui lòng nhập số ca làm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtShifts.Text, out int shifts) || shifts < 0)
                {
                    MessageBox.Show("Số ca làm không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                {
                    return;
                }

                int employeeId = int.Parse(txtEmployeeId.Text);
                int month = cboMonth.SelectedIndex + 1;
                int shifts = int.Parse(txtShifts.Text);

                // Check if salary already exists
                if (_salaryService.IsSalaryExists(employeeId, month))
                {
                    var result = MessageBox.Show(
                        $"Lương tháng {month} cho nhân viên {employeeId} đã tồn tại. Bạn có muốn cập nhật?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // Create or update salary
                bool success = _salaryService.CreateOrUpdateSalary(employeeId, month, shifts, out string message);

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
            if (string.IsNullOrWhiteSpace(txtEmployeeId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeId.Focus();
                return false;
            }

            if (!int.TryParse(txtEmployeeId.Text, out int empId) || empId <= 0)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeId.Focus();
                return false;
            }

            if (cboMonth.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tháng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonth.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtShifts.Text))
            {
                MessageBox.Show("Vui lòng nhập số ca làm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShifts.Focus();
                return false;
            }

            if (!int.TryParse(txtShifts.Text, out int shifts) || shifts < 0)
            {
                MessageBox.Show("Số ca làm không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShifts.Focus();
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
            txtEmployeeId.Clear();
            txtShifts.Clear();
            txtAmount.Clear();
            cboMonth.SelectedIndex = DateTime.Now.Month - 1;
            txtEmployeeId.Focus();
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