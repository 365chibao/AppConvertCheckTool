using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AppConvertCheckTool.Module
{
    public class FileProcessor
    {
        // Đường dẫn thư mục chính
        static string folderPath = Application.StartupPath;

        // Đường dẫn thư mục Input và Output
        public static string inputFolder = Path.Combine(folderPath, "Input");
        public static string outputFolder = Path.Combine(folderPath, "Output");

        public static void ProcessFiles()
        {
            try
            {
                // Kiểm tra và tạo thư mục Input
                if (!Directory.Exists(inputFolder))
                {
                    Directory.CreateDirectory(inputFolder);
                }

                // Kiểm tra và tạo thư mục Output
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // Đường dẫn file JSON
                string jsonFilePath = Path.Combine(folderPath, "replaceRules.json");

                // Kiểm tra file JSON tồn tại
                if (!File.Exists(jsonFilePath))
                {
                    MessageBox.Show("Không tìm thấy file replaceRules.json trong thư mục chính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đọc file JSON chứa quy tắc thay thế
                string jsonContent = File.ReadAllText(jsonFilePath);
                List<ReplaceRule> replaceRules = JsonSerializer.Deserialize<List<ReplaceRule>>(jsonContent);

                // Lấy tất cả file .cs trong thư mục Input
                string[] csFiles = Directory.GetFiles(inputFolder, "*.cs", SearchOption.AllDirectories);

                // Kiểm tra xem có file .cs nào không
                if (csFiles.Length == 0)
                {
                    MessageBox.Show("Không tìm thấy file .cs nào trong thư mục Input!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xử lý từng file .cs
                foreach (string csFile in csFiles)
                {
                    // Đọc nội dung file .cs
                    string fileContent = File.ReadAllText(csFile);

                    // Thực hiện thay thế
                    string modifiedContent = fileContent;
                    foreach (var rule in replaceRules)
                    {
                        if (string.IsNullOrEmpty(rule.From) || rule.To == null)
                            continue; // Bỏ qua nếu rule không hợp lệ

                        try
                        {
                            if (rule.Type.ToLower() == "regex")
                            {
                                // Thay thế bằng regex
                                modifiedContent = Regex.Replace(modifiedContent, rule.From, rule.To);
                            }
                            else
                            {
                                // Thay thế trực tiếp
                                modifiedContent = modifiedContent.Replace(rule.From, rule.To);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi áp dụng quy tắc cho file {csFile}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }

                    // Tạo đường dẫn file đầu ra
                    string relativePath = Path.GetRelativePath(inputFolder, csFile);
                    string outputFilePath = Path.Combine(outputFolder, relativePath);

                    // Tạo thư mục cha trong Output nếu chưa tồn tại
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                    // Lưu file đã chỉnh sửa vào thư mục Output
                    File.WriteAllText(outputFilePath, modifiedContent, new UTF8Encoding(true));
                }

                MessageBox.Show("Xử lý tất cả file thành công!\n\r Kết quả được lưu trong thư mục Output.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
