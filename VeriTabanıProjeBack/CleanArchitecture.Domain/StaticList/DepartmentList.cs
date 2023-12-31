using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.StaticList;
public sealed class DepartmentList
{
    public static List<Department> GetStaticDepartments()
    {
        List<Department> departments = new List<Department>
        {
            new Department()
            {
                Id = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b",
                DepatmentCode = 1,
                DepartmentName = "Yazılım Mühendisliği"
            },
            new Department()
            {
                Id = "428a89af-c687-4a25-9383-1e2d9a5c85e4",
                DepatmentCode = 2,
                DepartmentName = "Bilgisayar Mühendisliği"
            },
            new Department()
            {
                Id ="019936e5-55df-478b-a3f4-04e1168a96ca",
                DepatmentCode = 3,
                DepartmentName = "Endüstri Mühendisliği"
            },
        };

        return departments;
    }
}
