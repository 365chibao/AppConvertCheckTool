using AppConvertCheckTool.Module;
using System.Diagnostics;
using System.Text.Json;

namespace AppConvertCheckTool
{
    public partial class ConvertUpdateJson : Form
    {
        private List<ReplaceRule> rules;
        private string jsonFilePath = Application.StartupPath + "replaceRules.json";

        public ConvertUpdateJson()
        {
            InitializeComponent();
        }

        private void UpdateJson_Load(object sender, EventArgs e)
        {
            LoadJsonData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadJsonData()
        {
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    string json = File.ReadAllText(jsonFilePath);
                    rules = JsonSerializer.Deserialize<List<ReplaceRule>>(json) ?? new List<ReplaceRule>();
                }
                else
                {
                    rules = new List<ReplaceRule>();
                }
                dgvListRule.DataSource = new BindingSource { DataSource = rules };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải JSON: {ex.Message}");
            }
        }
        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(FileProcessor.inputFolder))
                {
                    Directory.CreateDirectory(FileProcessor.inputFolder);
                }

                // Mở File Explorer đến thư mục Input nếu đã tồn tại
                Process.Start("explorer.exe", FileProcessor.inputFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu JSON: {ex.Message}");
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(FileProcessor.outputFolder))
                {
                    Directory.CreateDirectory(FileProcessor.outputFolder);
                }

                // Mở File Explorer đến thư mục Output nếu đã tồn tại
                Process.Start("explorer.exe", FileProcessor.outputFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}");
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                FileProcessor.ProcessFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}");
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    // Lưu vào file JSON ngay sau khi chỉnh sửa ô
                    SaveJsonData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu chỉnh sửa: {ex.Message}");
            }
        }

        private void SaveJsonData()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(rules, options);
                File.WriteAllText(jsonFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu JSON: {ex.Message}");
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadJsonData();
        }
    }
}
