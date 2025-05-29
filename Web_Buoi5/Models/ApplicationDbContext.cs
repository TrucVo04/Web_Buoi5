using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Buoi5.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Văn học" },
                new Category { Id = 2, Name = "Tâm lý" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Sách Trốn Lên Mái Nhà Khóc",
                    Author = "Nguyễn Nhật Ánh",
                    Price = 120000,
                    Description = "Tập hợp những câu chuyện ngắn đầy cảm xúc về tuổi thơ.",
                    ImagePath = "/wwwroot/images/b1.jpg",
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Tôi Thấy Hoa Vàng Trên Cỏ Xanh",
                    Author = "Nguyễn Nhật Ánh",
                    Price = 150000,
                    Description = "Hồi ức tuổi thơ đầy cảm xúc tại làng quê Việt Nam.",
                    ImagePath = "/Content/ImageBooks/hoavangtrencoxanh.jpg",
                    CategoryId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "Đắc Nhân Tâm",
                    Author = "Dale Carnegie",
                    Price = 180000,
                    Description = "Cuốn sách kinh điển về nghệ thuật giao tiếp và thuyết phục.",
                    ImagePath = "/Content/ImageBooks/dacnhantam.jpg",
                    CategoryId = 2
                }
            );
        }
    }
}