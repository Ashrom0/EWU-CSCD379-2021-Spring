using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SecretSanta.Business;
using System;
using SecretSanta.Data;
using System.Collections.Generic;

namespace SecretSanta.Business.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void Create_WithUser_ReturnUser()
        {
            UserRepository repository = new();
            User? newUser = new User() {Id=4, FirstName="Ryo", LastName="Fukui"};
            User? createdUser = repository.Create(newUser);
            Assert.AreSame(newUser, createdUser);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void GetItem_WithId_ReturnsUserRepositoryUser(int id)
        {
            UserRepository repository = new();
            User? foundUser = repository.GetItem(id);
            Assert.IsNotNull(foundUser);
        }

        [TestMethod]
        public void List_WithData_ReturnsUsers()
        {
            UserRepository repository = new();
            IEnumerable<User> users = repository.List();
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void Remove_WithValidId_ReturnsTrue(int id)
        {
            UserRepository repository = new();
            Assert.IsTrue(repository.Remove(id));
        }

        [TestMethod]
        [DataRow(42)]
        public void Remove_WithInvalidId_ReturnsFalse(int id)
        {
            UserRepository repository = new();
            Assert.IsFalse(repository.Remove(id));
        }

        [TestMethod]
        public void Save_WithUser()
        {
            UserRepository repository = new();
            User? newUser = new User() {Id=2, FirstName="Ryo", LastName="Fukui"};
            repository.Save(newUser);
            User? updatedUser = repository.GetItem(newUser.Id);
            Assert.AreSame(newUser, updatedUser);
        }
    }
}