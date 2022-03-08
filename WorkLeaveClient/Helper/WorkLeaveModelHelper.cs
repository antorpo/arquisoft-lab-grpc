using WorkLeave;

namespace WorkLeaveClient.Helper
{
    public static class WorkLeaveModelHelper
    {
        public static Employee employeeRequest => new()
        {
            EmployeeId = 1,
            Name = "Diego Botia",
            AccruedLeaveDays = 10,
            RequestedLeaveDays = 4
        };
    }
}
