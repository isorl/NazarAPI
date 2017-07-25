namespace NazarAPI
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class DataModel : DbContext
    {
        // Контекст настроен для использования строки подключения "DataModel" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "NazarAPI.DataModel" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DataModel" 
        // в файле конфигурации приложения.
        public DataModel()
            : base("name=DataModel")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataModel>());


        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().Property(p => p.TransactionDate).IsOptional().HasColumnType("DateTime2");
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}