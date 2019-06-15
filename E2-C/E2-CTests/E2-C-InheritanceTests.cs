using Microsoft.VisualStudio.TestTools.UnitTesting;
using E2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Tests
{    
    /// <summary>
    /// کلاس های 
    /// Person, Employee, Student, Teacher
    /// باید به گونه‌ای پیاده‌سازی شوند که ارث‌بری‌ها، متدهای 
    /// virtual, abstract, override
    /// به درستی و مطابق با تست‌ها تعریف شوند.
    /// </summary>
    [TestClass()]
    public class InheritanceTests
    {
        class PersonTestClass : Person
        {
            
            public PersonTestClass(string Name, bool isFemale) : base(Name, isFemale)
            { }
            public override int LunchRate => 0;
            public override string Name => base.Name;
            
        }

        /// <summary>
        /// Person
        /// یک کلاس 
        /// abstract
        /// است با یک سازنده که نام و مونث بودن را به عنوان پارمتر دریافت می‌کند.
        /// این کلاس یک 
        /// virtual getter
        /// به نام 
        /// Name
        /// دارد که نام با پیشوند
        /// خانم یا آقا
        /// را برمی‌گرداند.
        /// علاوه بر این یک 
        /// getter
        /// به نام
        /// IsFemale
        /// نیز دارد.
        /// همچنین دارای یک 
        /// abstract getter
        /// به نام 
        /// LunchRate
        /// </summary>
        [TestMethod()]
        public void PersonTest()
        {
           // Assert.Inconclusive();
           
            // Person should be an abstract class
            Assert.IsTrue(typeof(Person).IsAbstract);

            // It should not have an empty constructor
            Assert.IsTrue(typeof(Person).GetConstructor(Type.EmptyTypes) == null);

            // LunchRate should be abstract
            Assert.IsTrue(typeof(Person).GetMethod("get_LunchRate").IsAbstract);

            Person p = new PersonTestClass("فاطمه معتمد آریا", true);
            Assert.AreEqual("خانم فاطمه معتمد آریا", p.Name);
            Assert.AreEqual(true, p.IsFemale);
            
        }

        /// <summary>
        /// کلاس 
        /// Student
        /// از 
        /// Person
        /// به ارث برده و نرخ ناهار را برابر ۲۰۰۰ تومان قرار می‌دهد.
        /// این کلاس را بگونه‌ای پیاده‌سازی کنید که تست زیر پاس شود.
        /// </summary>
        [TestMethod()]
        public void StudentTest()
        {
           // Assert.Inconclusive();
           
            Person p = new Student("حسن روحانی", false);
            Assert.IsFalse(p.IsFemale);
            Assert.AreEqual("آقای حسن روحانی", p.Name);
            Assert.AreEqual(p.LunchRate, 2000);

            // Student should not override/modify the Name get property.
            Assert.AreNotEqual(
                typeof(Student).GetMethod("get_Name").DeclaringType,
                typeof(Student));
                

        }

        /// <summary>
        /// کلاس 
        /// Employee
        /// از 
        /// Person
        /// به ارث برده و نرخ ناهار را برابر ۵۰۰۰ تومان قرار می‌دهد.
        /// علاوه بر این یک متد
        /// virtual
        /// به نام 
        /// CalculateSalary
        /// اضافه می‌کند که حقوق کارمند را برابر ساعتی ۵۰۰۰ تومان حساب می‌کند.
        /// این کلاس را بگونه‌ای پیاده‌سازی کنید که تست زیر پاس شود.
        /// </summary>
        [TestMethod()]
        public void EmployeeTest()
        {
           // Assert.Inconclusive();
           

            Person p = new Employee("محمد ابراهیم همت", false);
            Assert.IsFalse(p.IsFemale);
            Assert.AreEqual("آقای محمد ابراهیم همت", p.Name);

            // Student should not override/modify the Name get property.
            Assert.AreNotEqual(
                typeof(Employee).GetMethod("get_Name").DeclaringType,
                typeof(Employee));

            Assert.AreEqual(p.LunchRate, 5000);

            Employee e = p as Employee;
            Assert.AreEqual(e.LunchRate, 5000);

            Assert.AreEqual(50_000, e.CalculateSalary(10));
            
        }

        /// <summary>
        /// کلاس 
        /// Teacher
        /// از 
        /// Employee
        /// به ارث برده و نرخ ناهار را برابر ۱۰۰۰۰ تومان قرار می‌دهد.
        /// علاوه بر این متد
        /// CalculateSalary
        /// را
        /// override
        ///  می‌کند که حقوق استاد را برابر ساعتی ۲۰۰۰۰ تومان حساب می‌کند.
        /// این کلاس را بگونه‌ای پیاده‌سازی کنید که تست زیر پاس شود.
        /// </summary>
        [TestMethod()]
        public void TeacherTest()
        {
           // Assert.Inconclusive();
           
            Person p = new Teacher("محمد رضا شجریان", false);
            Assert.IsFalse(p.IsFemale);
            Assert.AreEqual("استاد محمد رضا شجریان", p.Name);
            Assert.AreEqual(p.LunchRate, 10000);

            Employee e = p as Employee;
            Assert.AreEqual(200_000, e.CalculateSalary(10));
            Assert.AreEqual(e.LunchRate, 10000);

            Teacher t = p as Teacher;
            Assert.AreEqual(200_000, e.CalculateSalary(10));
            Assert.AreEqual(t.LunchRate, 10000);
            
        }
    }
}