using System;
using BookS.Core.Maintenance;
using BookS.Core.Models;
using BookS.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Repositories
{
    [TestClass]
    public class TestAuthorRepository
    {
        [TestMethod]
        public void TestAddSuccessfull()
        {
            var author = new Author
            {
                Name = "Admin",
                Surname = "Minda",
                DateOfBirth = DateTime.Parse("01.04.1993"),
                Gender = Gender.Male
            };

            AuthorRepository authorRepository = new AuthorRepository();

            var result = authorRepository.Add(author);

            Assert.AreEqual(result.Status, ResultStatus.Success);
            Assert.AreEqual(result.ResultMessage, "Author successfully added to the database");

            RemoveFromDb(author);
        }

        private void RemoveFromDb(Author pAuthor)
        {
            
        }
    }
}
