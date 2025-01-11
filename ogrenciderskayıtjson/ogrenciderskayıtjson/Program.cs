using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public abstract class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Id { get; set; }

    public Person(string name, string surname, int id)
    {
        Name = name;
        Surname = surname;
        Id = id;
    }

    public virtual void BilgiGoster()
    {
        Console.WriteLine($"Adı: {Name}, Soyadı: {Surname}, ID: {Id}");
    }
}

public class Ogrenci : Person
{
    public List<Course> EnrolledCourses { get; set; }

    public Ogrenci(string name, string surname, int id) : base(name, surname, id)
    {
        EnrolledCourses = new List<Course>();
    }

    public override void BilgiGoster()
    {
        base.BilgiGoster();
        Console.WriteLine("Kayıtlı Dersler:");
        foreach (var course in EnrolledCourses)
        {
            Console.WriteLine($"- {course.Name}");
        }
    }

    public void RegisterCourse(Course course)
    {
        EnrolledCourses.Add(course);
        Console.WriteLine($"{Name} adlı öğrenci {course.Name} dersine kayıt oldu.");
    }
}

public class OgretimGorevlisi : Person
{
    public List<Course> Courses { get; set; }

    public OgretimGorevlisi(string name, string surname, int id) : base(name, surname, id)
    {
        Courses = new List<Course>();
    }

    public override void BilgiGoster()
    {
        base.BilgiGoster();
        Console.WriteLine("Verdiği Dersler:");
        foreach (var course in Courses)
        {
            Console.WriteLine($"- {course.Name}");
        }
    }

    public void AddCourse(Course course)
    {
        Courses.Add(course);
        Console.WriteLine($"{Name} öğretim görevlisi {course.Name} dersini ekledi.");
    }
}

public class Course
{
    public string Name { get; set; }
    public int Credits { get; set; }
    public OgretimGorevlisi Instructor { get; set; }
    public List<Ogrenci> EnrolledStudents { get; set; }

    public Course(string name, int credits, OgretimGorevlisi instructor)
    {
        Name = name;
        Credits = credits;
        Instructor = instructor;
        EnrolledStudents = new List<Ogrenci>();
    }

    public void EnrollStudent(Ogrenci student)
    {
        EnrolledStudents.Add(student);
        Console.WriteLine($"{student.Name} dersine kayıt oldu: {Name}");
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine($"Ders Adı: {Name}, Kredi: {Credits}");
        Console.WriteLine($"Öğretim Görevlisi: {Instructor.Name} {Instructor.Surname}");
        Console.WriteLine("Kayıtlı Öğrenciler:");
        foreach (var student in EnrolledStudents)
        {
            Console.WriteLine($"- {student.Name} {student.Surname}");
        }
    }
}

class Program
{
    static string studentsFilePath = "students.json";
    static string instructorsFilePath = "instructors.json";
    static string coursesFilePath = "courses.json";

    static void Main(string[] args)
    {
        List<Ogrenci> ogrenciler = LoadStudents();
        List<OgretimGorevlisi> ogretimGorevlileri = LoadInstructors();
        List<Course> dersler = LoadCourses();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Öğrenci ve Ders Yönetim Sistemi");
            Console.WriteLine("1. Öğrenci Tanımla");
            Console.WriteLine("2. Öğretim Görevlisi Tanımla");
            Console.WriteLine("3. Ders Tanımla");
            Console.WriteLine("4. Dersin Detaylarını Göster");
            Console.WriteLine("5. Öğrenci Kaydı Yap");
            Console.WriteLine("6. Çıkış");
            Console.Write("Bir seçenek girin: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Öğrencinin Adı: ");
                    string ogrenciAdi = Console.ReadLine();
                    Console.Write("Öğrencinin Soyadı: ");
                    string ogrenciSoyadi = Console.ReadLine();
                    Console.Write("Öğrencinin ID'si: ");
                    int ogrenciId = int.Parse(Console.ReadLine());

                    Ogrenci ogrenci = new Ogrenci(ogrenciAdi, ogrenciSoyadi, ogrenciId);
                    ogrenciler.Add(ogrenci);
                    SaveStudents(ogrenciler);
                    break;

                case "2":
                    Console.Write("Öğretim Görevlisinin Adı: ");
                    string ogretimGorevlisiAdi = Console.ReadLine();
                    Console.Write("Öğretim Görevlisinin Soyadı: ");
                    string ogretimGorevlisiSoyadi = Console.ReadLine();
                    Console.Write("Öğretim Görevlisinin ID'si: ");
                    int ogretimGorevlisiId = int.Parse(Console.ReadLine());

                    OgretimGorevlisi ogretimGorevlisi = new OgretimGorevlisi(ogretimGorevlisiAdi, ogretimGorevlisiSoyadi, ogretimGorevlisiId);
                    ogretimGorevlileri.Add(ogretimGorevlisi);
                    SaveInstructors(ogretimGorevlileri);
                    break;

                case "3":
                    Console.WriteLine("Ders Adı: ");
                    string dersAdi = Console.ReadLine();
                    Console.WriteLine("Ders Kredisi: ");
                    int dersKredi = int.Parse(Console.ReadLine());

                    Console.WriteLine("Öğretim görevlisi seçin:");
                    for (int i = 0; i < ogretimGorevlileri.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ogretimGorevlileri[i].Name} {ogretimGorevlileri[i].Surname}");
                    }
                    int ogretimGorevlisiSecim = int.Parse(Console.ReadLine()) - 1;
                    OgretimGorevlisi selectedOgretimGorevlisi = ogretimGorevlileri[ogretimGorevlisiSecim];

                    Course course = new Course(dersAdi, dersKredi, selectedOgretimGorevlisi);
                    dersler.Add(course);
                    SaveCourses(dersler);
                    break;

                case "4":
                    Console.WriteLine("Ders seçin:");
                    for (int i = 0; i < dersler.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dersler[i].Name}");
                    }
                    int dersSecim = int.Parse(Console.ReadLine()) - 1;
                    dersler[dersSecim].ShowCourseDetails();
                    break;

                case "5":
                    Console.WriteLine("Öğrenci seçin:");
                    for (int i = 0; i < ogrenciler.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ogrenciler[i].Name} {ogrenciler[i].Surname}");
                    }
                    int ogrenciSecim = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("Ders seçin:");
                    for (int i = 0; i < dersler.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dersler[i].Name}");
                    }
                    int dersSecimKayit = int.Parse(Console.ReadLine()) - 1;

                    ogrenciler[ogrenciSecim].RegisterCourse(dersler[dersSecimKayit]);
                    dersler[dersSecimKayit].EnrollStudent(ogrenciler[ogrenciSecim]);
                    SaveStudents(ogrenciler);
                    SaveCourses(dersler);
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Geçersiz seçenek.");
                    break;
            }

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    static void SaveStudents(List<Ogrenci> ogrenciler)
    {
        string json = JsonConvert.SerializeObject(ogrenciler, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        File.WriteAllText(studentsFilePath, json);
        Console.WriteLine("Öğrenciler kaydedildi. Dosya içeriği:");
        Console.WriteLine(File.ReadAllText(studentsFilePath));
    }

    static void SaveInstructors(List<OgretimGorevlisi> ogretimGorevlileri)
    {
        string json = JsonConvert.SerializeObject(ogretimGorevlileri, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        File.WriteAllText(instructorsFilePath, json);
        Console.WriteLine("Öğretim Görevlileri kaydedildi. Dosya içeriği:");
        Console.WriteLine(File.ReadAllText(instructorsFilePath));
    }

    static void SaveCourses(List<Course> dersler)
    {
        // Kursları kaydederken sadece gerekli alanları JSON'a yazarız
        var derslerToSave = dersler.ConvertAll(ders => new
        {
            ders.Name,
            ders.Credits,
            Instructor = new { ders.Instructor.Name, ders.Instructor.Surname },
            EnrolledStudents = ders.EnrolledStudents.ConvertAll(student => new { student.Name, student.Surname })
        });

        string json = JsonConvert.SerializeObject(derslerToSave, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        File.WriteAllText(coursesFilePath, json);
        Console.WriteLine("Dersler kaydedildi. Dosya içeriği:");
        Console.WriteLine(File.ReadAllText(coursesFilePath));
    }

    static List<Ogrenci> LoadStudents()
    {
        if (File.Exists(studentsFilePath))
        {
            string json = File.ReadAllText(studentsFilePath);
            return JsonConvert.DeserializeObject<List<Ogrenci>>(json);
        }
        return new List<Ogrenci>();
    }

    static List<OgretimGorevlisi> LoadInstructors()
    {
        if (File.Exists(instructorsFilePath))
        {
            string json = File.ReadAllText(instructorsFilePath);
            return JsonConvert.DeserializeObject<List<OgretimGorevlisi>>(json);
        }
        return new List<OgretimGorevlisi>();
    }

    static List<Course> LoadCourses()
    {
        if (File.Exists(coursesFilePath))
        {
            string json = File.ReadAllText(coursesFilePath);
            return JsonConvert.DeserializeObject<List<Course>>(json);
        }
        return new List<Course>();
    }
}