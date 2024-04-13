//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Project_MLD.Models;
//using Project_MLD.Service.Repository;
//using System.Linq;

//namespace TestProject1
//{
//    public class DocRepositoryTests : IDisposable
//    {
//        private readonly MldDatabaseContext _context;
//        private readonly DocRepository _repository;

//        public DocRepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<MldDatabaseContext>()
//                   .UseSqlServer("ConnectionStrings") // replace with your test database connection string
//                   .Options;
//            _context = new MldDatabaseContext(options);
//            _repository = new DocRepository(_context);
//        }
//        public void Dispose()
//        {
//            // Clean up the database here
//            _context.Docs.RemoveRange(_context.Docs);
//            _context.SaveChanges();
//        }

//        [Fact]
//        public void AddDoc_ReturnsNewDoc()
//        {
//            // Arrange
//            var doc = new Doc
//            {
//                Name = "Sample Document", // You can replace this with any string value
//                Content = System.Text.Encoding.UTF8.GetBytes("This is some sample content."), // You can replace this with any byte array value
//                CategoryId = 2, // You can replace this with any integer value
//                Document4Id = 4 // You can replace this with any integer value
//            };

//            // Act
//            var result = _repository.AddDoc(doc);

//            // Assert
//            Assert.Equal((IEnumerable<T>)doc, result);
//        }

//        [Fact]
//        public void DeleteDoc_ReturnsTrueWhenExists()
//        {
//            // Arrange
//            var doc = new Doc
//            {
//                Name = "Sample Document", // You can replace this with any string value
//                Content = System.Text.Encoding.UTF8.GetBytes("This is some sample content."), // You can replace this with any byte array value
//                CategoryId = 2, // You can replace this with any integer value
//                Document4Id = 4 // You can replace this with any integer value
//            };
//            var added = _repository.AddDoc(doc);

//            // Act
//            var result = _repository.DeleteDoc(added.Id);

//            // Assert
//            Assert.True(result);
//        }

//        [Fact]
//        public void GetAllDocs_ReturnsAllDocs()
//        {
//            // Arrange
//            var doc1 = new Doc
//            {
//                Name = "Sample Document 1", // You can replace this with any string value
//                Content = System.Text.Encoding.UTF8.GetBytes("This is some sample content for doc 1."), // You can replace this with any byte array value
//                CategoryId = 2, // You can replace this with any integer value
//                Document4Id = 4 // You can replace this with any integer value
//            };
//            var doc2 = new Doc
//            {
//                Name = "Sample Document 2", // You can replace this with any string value
//                Content = System.Text.Encoding.UTF8.GetBytes("This is some sample content for doc 2."), // You can replace this with any byte array value
//                CategoryId = 3, // You can replace this with any integer value
//                Document4Id = 14 // You can replace this with any integer value
//            };
//            _repository.AddDoc(doc1);
//            _repository.AddDoc(doc2);

//            // Act
//            var result = _repository.GetAllDocs();

//            // Assert
//            Assert.Equal(2, result.Count());
//        }

//        [Fact]
//        public void GetDocById_ReturnsDocWhenExists()
//        {
//            // Arrange
//            var doc = new Doc
//            {
//                Name = "Sample Document", // You can replace this with any string value
//                Content = System.Text.Encoding.UTF8.GetBytes("This is some sample content."), // You can replace this with any byte array value
//                CategoryId = 2, // You can replace this with any integer value
//                Document4Id = 4 // You can replace this with any integer value
//            };
//            var added = _repository.AddDoc(doc);

//            // Act
//            var result = _repository.GetDocById(added.Id);

//            // Assert
//            Assert.Equal(doc, result);
//        }
//    }
//}
