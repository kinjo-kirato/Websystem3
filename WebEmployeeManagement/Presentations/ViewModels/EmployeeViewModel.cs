using System.ComponentModel.DataAnnotations;

namespace WebEmployeeManagement.Presentations.ViewModels;

public class EmployeeViewModel
{
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "社員名を入力してください。")]
    [StringLength(30, ErrorMessage = "社員名は30文字以内で入力してください。")]
    public string EmployeeName { get; set; } = string.Empty;

    [Required(ErrorMessage = "部門を選択してください。")]
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;
}
