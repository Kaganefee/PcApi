## PCApi Projesi 
 
 Proje, C# dilini kullanarak SOLID prensiplerine uygun, çok katmanlı bir mimariye sahip olan bir bilgisayar mini ticaret uygulamasıdır. CRUD işlemleri için Entity Framework kullanılmış ve veritabanı olarak MSSQL tercih edilmiştir. Bu proje hala tamamlanma aşamasındadır ve geliştirme sürecine devam edilerek özellikleri ve işlevselliği artırılacaktır.

## Kullanılan Teknolojiler

- Restful API: Projede kullanılan API mimarisi REST prensiplerine uygun olarak tasarlanmıştır.
- Result Types: Farklı durumları temsil etmek için kullanılan sonuç tipleri sayesinde işlemlerin sonucu hakkında daha ayrıntılı bilgiler elde edilebilir.
- Interceptor: Projede kullanılan interceptorlar, işlemler sırasında loglama, hata yönetimi gibi çapraz kesen endişeleri ele almak için kullanılmaktadır.
- Autofac: Projede kullanılan IoC/DI konteyneri olarak Autofac tercih edilmiştir.
- AOP (Aspect Oriented Programming): Projede kullanılan AOP prensipleri, kod tekrarını azaltmak ve çapraz kesen endişeleri ele almak için kullanılmaktadır.
- Fluent Validation: Veri doğrulama için kullanılan Fluent Validation kütüphanesi, girişleri doğrulamak ve hata mesajlarını yönetmek için kullanılmaktadır.
- Cross Cutting Concerns: Projede kullanılan çapraz kesen endişeler (ör. loglama, hata yönetimi) ayrı modüllerde ele alınmış ve tekrar kullanılabilirlik sağlanmıştır.
- Repository Design Pattern: Veri erişim katmanında kullanılan Repository tasarım deseni, veri işlemlerinin yönetimini kolaylaştırmak için kullanılmıştır.

