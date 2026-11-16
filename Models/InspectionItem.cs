using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementMAUI.Models
{
    public  class InspectionItem
    {
        
        public string Title { get; set; } = string.Empty;
        public string Site { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
    }
}
