## Öğrenci ve Ders Yönetim Sistemi 📚🎓
Bu uygulama, bir okul yönetim sistemini simüle eder ve öğrenci, öğretim görevlisi ve dersleri yönetmenizi sağlar. Kullanıcılar, öğrenci ve öğretim görevlisi tanımlayabilir, dersler oluşturabilir ve öğrencilerin derslere kayıt işlemlerini yapabilirler. Veriler JSON formatında kaydedilir ve her seferinde dosyadan yüklenir.

## Özellikler 🌟
Öğrenci Tanımlama: Öğrenci adı, soyadı ve ID'si ile öğrenci kaydı yapılabilir.
Öğretim Görevlisi Tanımlama: Öğretim görevlisi adı, soyadı ve ID'si ile öğretim görevlisi kaydı yapılabilir.
Ders Tanımlama: Ders adı, kredisi ve öğretim görevlisi belirlenerek yeni dersler oluşturulabilir.
Ders Detaylarını Görüntüleme: Oluşturulan derslerin detayları (ad, kredi, öğretim görevlisi, öğrenciler) gösterilebilir.
Öğrenci Kaydı Yapma: Öğrenciler, mevcut derslere kayıt olabilirler.
JSON Veritabanı: Öğrenciler, öğretim görevlileri ve dersler JSON dosyalarına kaydedilir ve her uygulama çalıştırıldığında bu dosyalardan yüklenir.

## Kullanıcı Arayüzü
Program, kullanıcıya bir menü sunarak çeşitli işlemleri yapmasını sağlar. Menü seçenekleri şu şekildedir:

Öğrenci Tanımla: Yeni bir öğrenci ekler.
Öğretim Görevlisi Tanımla: Yeni bir öğretim görevlisi ekler.
Ders Tanımla: Yeni bir ders ekler.
Dersin Detaylarını Göster: Mevcut derslerin detaylarını görüntüler.
Öğrenci Kaydı Yap: Öğrencilerin derslere kayıt olmasını sağlar.
Çıkış: Programdan çıkış yapar.

## Kullanım 📋
Başlatma
Proje Dosyasını İndirin:

Projeyi bilgisayarınıza indirin veya bir IDE (örneğin Visual Studio) ile açın.

Gerekli Kütüphaneleri Yükleyin:Install-Package Newtonsoft.Json

Bu uygulama, Newtonsoft.Json kütüphanesini kullanmaktadır. Bu kütüphaneyi yüklemek için NuGet Package Manager kullanabilirsiniz:

## Çalıştırma 🚀
Uygulamayı Başlatın: Uygulamayı çalıştırdığınızda, ana menü ekranda belirecektir.
Menüyü Kullanarak İşlemleri Yapın:
Menüdeki sayısal seçeneklere göre işlemleri gerçekleştirebilirsiniz. Örneğin, 1 tuşuna basarak öğrenci ekleyebilir, 3 tuşuna basarak ders ekleyebilirsiniz.
JSON Dosyaları: Veriler students.json, instructors.json ve courses.json dosyalarına kaydedilecektir. Bu dosyalar uygulama her başlatıldığında otomatik olarak yüklenir.

## JSON Dosya Yapısı 📂
Veriler JSON formatında şu şekilde saklanacaktır:

students.json:

json
[
  {
    "Name": "Ahmet",
    "Surname": "Yılmaz",
    "Id": 1001,
    "EnrolledCourses": [
      {
        "Name": "Matematik 101",
        "Credits": 3
      }
    ]
  }
]

instructors.json:

json
[
  {
    "Name": "Dr. Hasan",
    "Surname": "Yıldız",
    "Id": 2001,
    "Courses": [
      {
        "Name": "Matematik 101",
        "Credits": 3
      }
    ]
  }
]

courses.json:

json
[
  {
    "Name": "Matematik 101",
    "Credits": 3,
    "Instructor": {
      "Name": "Dr. Hasan",
      "Surname": "Yıldız"
    },
    "EnrolledStudents": [
      {
        "Name": "Ahmet",
        "Surname": "Yılmaz"
      }
    ]
  }
]

## Lisans 📄
https://github.com/mehmetkbts
