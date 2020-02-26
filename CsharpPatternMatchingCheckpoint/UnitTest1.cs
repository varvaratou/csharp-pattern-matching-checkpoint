using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpPatternMatchingCheckpoint
{
    [TestClass]
    public class TestsBefore
    {

        [TestMethod]
        public void Test1()
        {
            //Arrange
            var passingStudent = new Student("Jane", "Doe", true, 'B');
            var failingStudent = new Student("Jane", "Doe", true, 'D');

            //Act
            bool passResult = getPassOrFail_ByPropertyPatternMatching(passingStudent);
            bool failResult = getPassOrFail_ByPropertyPatternMatching(failingStudent);

            //Assert
            Assert.AreEqual(true, passResult && !failResult);
        }

        [TestMethod]
        public void Test2()
        {
            //Arrange
            var passingStudent = new Student("Jane", "Doe", true, 'B');
            var failingStudent = new Student("Jane", "Doe", true, 'D');

            //Act
            bool passResult = getPassOrFail_ByTuplePatternMatching(passingStudent);
            bool failResult = getPassOrFail_ByTuplePatternMatching(failingStudent);

            //Assert
            Assert.AreEqual(true, passResult && !failResult);
        }

        [TestMethod]
        public void Test3()
        {
            //Arrange
            var passingStudent = new Student("Jane", "Doe", true, 'B');
            var failingStudent = new Student("Jane", "Doe", true, 'D');

            //Act
            bool passResult = getPassOrFail_ByPositionalPatternMatching(passingStudent);
            bool failResult = getPassOrFail_ByPositionalPatternMatching(failingStudent);

            //Assert
            Assert.AreEqual(true, passResult && !failResult);
        }

        public static bool getPassOrFail_ByPropertyPatternMatching(Student student) =>
        student switch
        {
            // Use property pattern matching to determine if Grade is pass (A,B,C) or fail (D,F) and TuitionPaid is true.
            var x when x.Grade <= 'C' && x.TuitionPaid == true => true,
            var x when x.Grade >= 'D' && x.TuitionPaid == true => false,
            _ => false,
        };

        public static bool getPassOrFail_ByTuplePatternMatching(Student student) =>
        (student.Grade, student.TuitionPaid) switch
        {
            // Use tuple pattern matching to determine if Grade is pass (A,B,C) or fail (D,F) and TuitionPaid is true.
            ('A', true) => true,
            ('B', true) => true,
            ('C', true) => true,
            _ => false,
        };

        public static bool getPassOrFail_ByPositionalPatternMatching(Student student) =>
        student switch
        {
            // Use positional pattern matching to determine if Grade is pass (A,B,C) or fail (D,F) and TuitionPaid is true.
            // Note: You will to define the Deconstruct method for Student
            var (a, b) when a < 'D' && a >= 'A' && b => true,
            _ => false
        };
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool TuitionPaid { get; set; }
        public char Grade { get; set; }

        public Student(string firstName, string lastName, bool tuitionPaid, char grade) =>
            (FirstName, LastName, TuitionPaid, Grade) = (firstName, lastName, tuitionPaid, grade);

        public void Deconstruct(out char a, out bool b) => (a, b) = (Grade, TuitionPaid);
    }
}
