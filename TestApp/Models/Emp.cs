namespace TestApp.Models
{
    public class Emp
    {
        public Emp(int empId, string? empName, int deptNo)
        {
            EmpId = empId;
            EmpName = empName;
            DeptNo = deptNo;
        }

        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public int DeptNo { get; set; }
    }
}
