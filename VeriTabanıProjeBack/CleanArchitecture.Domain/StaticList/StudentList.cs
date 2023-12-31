using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.StaticList;
public sealed class StudentList
{
    public static List<Student> GetStaticStudents()
    {
        List<Student> students = new List<Student>
        {
            new()
            {
                Id = "97e114e6-a9fd-4ef6-a1e9-1fb86706622a",
                Name = "Öğrenci",
                LastName = "Öğrenenoğulları",
                Birthdate = new DateTime(2004,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "3f592656-1eff-4b54-ba3a-e1a41faa6577",
                Name = "Muhammet Taha",
                LastName = "Kırkgöz",
                Birthdate = new DateTime(2004,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "9dc14775-9287-4eed-90ae-8eaa4064c362",
                Name = "Furkan",
                LastName = "Özüdoğru",
                Birthdate = new DateTime(2004,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "a3767016-30a4-4d76-aa46-14fe3f210f28",
                Name = "Rıdvan",
                LastName = "Kalın",
                Birthdate = new DateTime(2002,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "c1597f66-43d9-4b20-9fb2-d48363a1ca5f",
                Name = "Mert",
                LastName = "Yılmaz",
                Birthdate = new DateTime(2002,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "e6bf6ad7-10c9-4b56-9582-bf8b3cfa3285",
                Name = "Mehmet",
                LastName = "Çalışır",
                Birthdate = new DateTime(2002,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "3b9b286e-47f9-4860-84f7-1249ec5e3e07",
                Name = "Zeynep",
                LastName = "Demir",
                Birthdate = new DateTime(2002,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "a5e48c97-6eb8-480f-8660-2d636f67536e",
                Name = "Ayşe",
                LastName = "Özen",
                Birthdate = new DateTime(2000,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "d7201267-2b28-46fa-ad25-f141d125ca51",
                Name = "Fatma",
                LastName = "Fındıkoğulları",
                Birthdate = new DateTime(2000,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "c6b9fe56-82dc-45d8-accf-143979df4477",
                Name = "Sabiha",
                LastName = "Gökçen",
                Birthdate = new DateTime(2000,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "07a23f17-7fb1-4360-a3d4-35a8e4a623a7",
                Name = "Emir",
                LastName = "Ates",
                Birthdate = new DateTime(2001,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "6f956b9d-ea61-44d6-a4f9-bb101ebd6b63",
                Name = "Temel",
                LastName = "Dursunoğluları",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "cfef8df1-f33e-4fb8-836d-907d197a5815",
                Name = "Selin",
                LastName = "Fındık",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "89f1d421-7e0f-46ca-9334-5d5f3c5a7914",
                Name = "Deniz",
                LastName = "Denizci",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "a87a8e71-5bf7-43a4-98ff-8e2f108516de",
                Name = "Nehir",
                LastName = "Akarsu",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "5d10120a-9042-4fbc-a87f-6a626faf9bfb",
                Name = "Işıl",
                LastName = "Parlak",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "be74ec91-1a6c-46c5-b4bb-b0ae55ea9c0c",
                Name = "Mert Yıldı",
                LastName = "",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "8fdfe7b8-dbbf-4a1e-ab50-38adeed534d5",
                Name = "Yiğit",
                LastName = "Yılmıştı",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "f0e44a0d-1e82-41c4-a83f-685654866a51",
                Name = "Talat",
                LastName = "Kalasçılar",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },
            new()
            {
                Id = "373fd7ed-05a3-44bd-9629-f0fc5ffd4225",
                Name = "Şebnem",
                LastName = "Boğuk",
                Birthdate = new DateTime(2003,1,1),
                EnrollmentDate = new DateTime(2021,1,1)
            },

        };

        return students;
    }
}
/*
  
    public string StudentNo { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public DateTime EnrollmentDate { get; set; }
 */