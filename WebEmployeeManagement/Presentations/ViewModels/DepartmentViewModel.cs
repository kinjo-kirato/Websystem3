using System.ComponentModel.DataAnnotations;

namespace WebEmployeeManagement.Presentations.ViewModels;

public class DepartmentViewModel
{
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "部門名を入力してください。")]
    [StringLength(30, ErrorMessage = "部署名は30文字以内で入力してください。")]
    public string DepartmentName { get; set; } = string.Empty;
}
