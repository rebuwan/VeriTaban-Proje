using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.StaticList;
public sealed class CourseList
{
    public static List<Course> GetStaticCourses()
    {
        List<Course> EntityList = new List<Course>
        {
            new()
            {
                Id = "68e26027e-71ce-4029-9711-cb29d6e3f77a",
                CourseCode = "YZM001",
                CourseName = "Yazılım Mühendisliğine giriş",
                Credit = 5,
                DepartmentId = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b"
            },
            new()
            {
                Id = "abd9d1c6-9d68-4156-ad90-a2fa2436c9cf",
                CourseCode = "YZM002",
                CourseName = "Algoritma ve Programlamaya Giriş",
                Credit = 6,
                DepartmentId = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b"
            },
            new()
            {
                Id ="8a995023-ac25-405a-81c5-2874f794e1cb",
                CourseCode = "YZM003",
                CourseName = "Bilişim Teknolojilerine Giriş",
                Credit = 3,
                DepartmentId = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b"
            },
            new()
            {
                Id ="80968860-26d3-4569-b47d-7da468488bfd",
                CourseCode = "YZM004",
                CourseName = "Nesneye Yönelik Programlama",
                Credit = 6,
                DepartmentId = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b"
            },
            new()
            {
                Id ="224118e4-b082-4422-be23-dd09e287698d",
                CourseCode = "YZM005",
                CourseName = "Web Programlama",
                Credit = 4,
                DepartmentId = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b"
            },
            new()
            {
                Id ="71f9988d-a027-4109-8e2f-e5ec5714ae6d",
                CourseCode = "YZM006",
                CourseName = "Web Teknolojileri",
                Credit = 3,
                DepartmentId = "7bacad35-7f51-49a2-96f8-f2c9fc995b7b"
            },
            // Yazılım Dersleri Sonu

            // Bilgisayar Dersleri

            new()
            {
                Id ="491c5d09-3635-442f-be16-6104702ba4ab",
                CourseCode = "BLG001",
                CourseName = "Bilgisayar Mühendisliğine Giriş",
                Credit = 5,
                DepartmentId = "428a89af-c687-4a25-9383-1e2d9a5c85e4"
            },
            new()
            {
                Id ="bb61aaab-4f1a-49e8-90c0-3d8e105b2b34",
                CourseCode = "BLG002",
                CourseName = "Programlamaya Giriş",
                Credit = 5,
                DepartmentId = "428a89af-c687-4a25-9383-1e2d9a5c85e4"
            },

            new()
            {
                Id ="50c72958-e82e-414d-8368-89c88278fb47",
                CourseCode = "BLG003",
                CourseName = "Sayısal Tasarım",
                Credit = 5,
                DepartmentId = "428a89af-c687-4a25-9383-1e2d9a5c85e4"
            },
            // Bilgisayar Dersleri Sonu

            //Endüstri Dersleri
            new()
            {
                Id ="f6f95e72-d3fb-43ec-8369-f763c0aaa9a3",
                CourseCode = "END001",
                CourseName = "Endüstri Mühendisliğine Giriş",
                Credit = 5,
                DepartmentId = "019936e5-55df-478b-a3f4-04e1168a96ca"
            },
            new()
            {
                Id ="53a8f494-6b72-4bc6-959c-80773da43a9b",
                CourseCode = "END002",
                CourseName = "Genel Ekonomi",
                Credit = 5,
                DepartmentId = "019936e5-55df-478b-a3f4-04e1168a96ca"
            },
            new()
            {
                Id ="fd0b62b2-4a1b-4fea-ac4b-f534f039b3fd",
                CourseCode = "END003",
                CourseName = "Maliyet Muhasebesi",
                Credit = 5,
                DepartmentId = "019936e5-55df-478b-a3f4-04e1168a96ca"
            }
            //Endüstri Dersleri Sonu
        };

        return EntityList;
    }


}