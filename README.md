# CRUD İşlemleri Projesi

Bu proje, **ASP.NET Core 9.0 Web API** kullanılarak geliştirilmiş bir **CRUD (Create, Read, Update, Delete)** uygulamasıdır.  
Kullanıcı yönetimi için **ASP.NET Core Identity**, veri yönetimi için **Entity Framework Core (SQL Server)** kullanılmıştır.  
Ayrıca JWT tabanlı kimlik doğrulama ve email ile şifre sıfırlama özellikleri entegre edilmiştir.

---

## 🚀 Özellikler

- Kullanıcı kayıt, giriş ve kimlik doğrulama işlemleri
- JWT token ile güvenli API erişimi
- Şifre sıfırlama ve email gönderimi
- Todo listesi yönetimi (CRUD)
- Kullanıcı ve Todo ilişkisi: Bir kullanıcı birden fazla Todo'ya sahip olabilir
- CORS ve OpenAPI desteği
- JSON döndürmede `ReferenceLoopHandling.Ignore` ile döngü sorunları önlenir

---

## 💻 Kullanılan Teknolojiler

- ASP.NET Core 9.0
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT (JSON Web Token)
- SMTP Email (Gmail)
- OpenAPI / Swagger
- Newtonsoft.Json
