using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Console_CRUD_APP.Data;
using Console_CRUD_APP.Models;
using System.IO;

namespace SystemIO.test
{
    [TestFixture]
    class RepositoryTest
    {
        private const string _filePath = @"C:\Users\kmlnd\Documents\C#\Student_Console_Application\Console_CRUD_APP\StudentTest.txt";
        private const string _originalData = @"C:\Users\kmlnd\Documents\C#\Student_Console_Application\Console_CRUD_APP\StudentTestSeed.txt";

        private StudentRepository repo = new Console_CRUD_APP.Data.StudentRepository(_filePath);

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_originalData,_filePath);
        }

        [Test]
        public void CanReadDataFrom()
        {
            
            List<Student> students = repo.List();
            Assert.AreEqual("Kenneth",students[0].FirstName);
            Assert.AreEqual("Melendez", students[0].LastName);
            Assert.AreEqual("Computer Science", students[0].Major);
            Assert.AreEqual(3.0, students[0].GPA);
        }

        [Test]
        public void CanAddStudent()
        {

            addDummy();
            List<Student> students = repo.List();

            Assert.AreEqual("TestFirstName", students.Last().FirstName);
            Assert.AreEqual("TestLastName", students.Last().LastName);
            Assert.AreEqual("TestMajor", students.Last().Major);
            Assert.AreEqual(3.0, students.Last().GPA);
        }

        public void addDummy()
        {
            Student newStudent = new Student();
            newStudent.FirstName = "TestFirstName";
            newStudent.LastName = "TestLastName";
            newStudent.Major = "TestMajor";
            newStudent.GPA = 3.0M;
            repo.Add(newStudent);
        }

        [Test]
        public void CanDeleteStudent()
        {
            StudentRepository repo = new StudentRepository(_filePath);
        }
    }
}
