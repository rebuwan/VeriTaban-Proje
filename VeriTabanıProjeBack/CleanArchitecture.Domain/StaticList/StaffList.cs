using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.StaticList;
public sealed class StaffList
{
    public static List<Staff> GetStaticStaffs()
    {
        List<Staff> departments = new List<Staff>
        {
            new()
            {
                Id = "faab27dc-6192-4875-9457-d32eb6092e48",
                StaffNo = "210001",
                Name = "Hacı",
                LastName = "Hocaoğlu",
                Birthdate = new DateTime(1980,1,15),
            },
            new()
            {
                Id = "c9f60608-50be-412e-9b96-1f65e888b09c",
                StaffNo = "210002",
                Name = "Emre",
                LastName = "Taşlıarmut",
                Birthdate = new DateTime(1980,2,15),
            },
            new()
            {
                Id = "36ca4cc9-84fe-4457-b6db-bc95215c0416",
                StaffNo = "210003",
                Name = "Hayrullah",
                LastName = "Kalkan",
                Birthdate = new DateTime(1980,2,15),
            },
            new()
            {
                Id = "04ec1ac9-50dc-4c5c-a7ec-37fce182c52a",
                StaffNo = "210004",
                Name = "Tarık",
                LastName = "Kaya",
                Birthdate = new DateTime(1980,2,15),
            },
            new()
            {
                Id = "a5af3cf7-96ac-4b5c-acce-232f6ccead3e",
                StaffNo = "210005",
                Name = "Asena",
                LastName = "Bozkurt",
                Birthdate = new DateTime(1980,2,15),
            },
        };

        return departments;
    }
}