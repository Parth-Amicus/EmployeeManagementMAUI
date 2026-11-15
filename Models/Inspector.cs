using System;
using System.Collections.Generic;
using System.Text;


namespace EmployeeManagementMAUI.Models;

public class Inspector
{
    //string.Empty provides an initial empty value instead of null
    public string Name { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
}
