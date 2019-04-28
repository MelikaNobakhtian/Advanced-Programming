using A7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace A7Tests
{
    [TestClass]
    public class ProgramTests
    {


        
        [TestMethod]
        public void Q1DegreeEnumTest()
        {
            var actual = GetEnumTypesSorted<Degree>();
            string[] expected = new string[] { "Bachelor", "Diploma", "Master", "None", "PhD" };
            CollectionAssert.AreEqual(expected, actual);
        }
        

        
        [TestMethod]
        public void Q4KhaleTest3_Constructor()
        {
            var khale = CreateKhalleInstance(null as Khalle, "47212121", "Zahra", "http://img.co/zahra.jpg", Degree.PhD);
        }


        [TestMethod]
        public void Q4KhaleTest1_ITeacher()
        {
            var khale = CreateKhalleInstance(null as Khalle, "47212121", "Zahra", "http://img.co/zahra.jpg", Degree.PhD);

            ITeacher teacher = khale;
            Assert.AreEqual($"{khale.GetType().Name} {khale.Name} is teaching", khale.Teach());

            Assert.AreEqual("Zahra", khale.Name);
            Assert.AreEqual("http://img.co/zahra.jpg", khale.ImgUrl);
            Assert.AreEqual(Degree.PhD, khale.TopDegree);
        }
        

        
        [TestMethod]
        public void Q4KhaleTest2_ICitizen()
        {
            var khale = CreateKhalleInstance(null as Khalle, "47212121", "Zahra", "http://img.co/zahra.jpg", Degree.PhD);

            ICitizen citizen = khale;

            Assert.AreEqual("47212121", citizen.NationalId);
            Assert.AreEqual("Zahra", citizen.Name);

        }
        


        
        [TestMethod]
        public void Q5DabirTest3_Constructor()
        {

            var dabir = CreateDabirInstance(null as Dabir, "47212121", "Ali", "http://img.co/Ali.jpg", Degree.Master, 10);
            
        }
        

        
        [TestMethod]
        public void Q5DabirTest1_ITeacher()
        {

            var dabir = CreateDabirInstance(null as Dabir, "47212121", "Ali", "http://img.co/ali.jpg", Degree.Master,10);

            ITeacher teacher = dabir;

            Assert.AreEqual($"{dabir.GetType().Name} {dabir.Name} is teaching", dabir.Teach());

            Assert.AreEqual("Ali", dabir.Name);
            Assert.AreEqual("http://img.co/ali.jpg", dabir.ImgUrl);
            Assert.AreEqual(Degree.Master, dabir.TopDegree);
        }
        

        
        [TestMethod]
        public void Q5DabirTest2_ICitizen()
        {
            var dabir = CreateDabirInstance(null as Dabir, "47212121", "Ali", "http://img.co/ali.jpg", Degree.Master, 10);

            ICitizen citizen = dabir;

            Assert.AreEqual("47212121", citizen.NationalId);
            Assert.AreEqual("Ali", citizen.Name);
        }
        

        
        [TestMethod]
        public void Q6ProfessorTest3_Constructor()
        {
            var professor = CreateProfInstance(null as Professor, "47212121", "Sauleh", "http://img.co/sauleh.jpg",
                Degree.PhD, 20);
        }
        

        
        [TestMethod]
        public void Q6ProfessorTest1_ITeacher()
        {
            var prof = CreateProfInstance(null as Professor, "47212121", "Sauleh", "http://img.co/sauleh.jpg", Degree.PhD, 20);

            ITeacher teacher = prof;
            Assert.AreEqual($"{prof.GetType().Name} {prof.Name} is teaching", prof.Teach());

            Assert.AreEqual("Sauleh", prof.Name);
            Assert.AreEqual("http://img.co/sauleh.jpg", prof.ImgUrl);
            Assert.AreEqual(Degree.PhD, prof.TopDegree);
        }
        

        
        [TestMethod]
        public void Q6ProfessorTest2_ICitizen()
        {
            var prof = CreateProfInstance(null as Professor, "47212121", "Sauleh", "http://img.co/sauleh.jpg", Degree.PhD, 20);
            ICitizen citizen = prof;

            Assert.AreEqual("47212121", citizen.NationalId);
            Assert.AreEqual("Sauleh", citizen.Name);
        }
        

        
        [TestMethod]
        public void FinalTest()
        {
            var inst = new EduInstitute<Dabir>("Kalakchi", Degree.Master);
            var kDabir = new Dabir("1234567890", "Mr. Tatil", "Example Url", Degree.Diploma, 0);
            var okReg = inst.Register(kDabir);
            Assert.AreEqual("Dabir Mr. Tatil is teaching", kDabir.Teach());
            Assert.IsFalse(okReg);
        }
        


        #region Helper Methods
        private static string[] GetEnumTypesSorted<_Type>()
        {
            return ((Degree[])Enum.GetValues(typeof(_Type)))
                            .Select(e => e.ToString()).OrderBy(x => x).ToArray();
        }


        private dynamic CreateKhalleInstance<_ReturnType, T1, T2, T3, T4>(_ReturnType rt, T1 o1, T2 o2, T3 o3, T4 o4)
            where _ReturnType : class
        {
            ConstructorInfo ctor = (typeof(_ReturnType)).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            _ReturnType kz = ctor.Invoke(new object[] { "47212121", "Zahra", "http://img.co/zahra.jpg", Degree.PhD }) as _ReturnType;
            return kz;
        }


        private dynamic CreateDabirInstance<_ReturnType, T1, T2, T3, T4, T5>(_ReturnType rt, T1 o1, T2 o2, T3 o3, T4 o4, T5 o5)
            where _ReturnType : class
        {
            ConstructorInfo ctor = (typeof(_ReturnType)).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            _ReturnType kz = ctor.Invoke(new object[] { "47212121", "Ali", "http://img.co/ali.jpg", Degree.Master, 10 }) as _ReturnType;
            return kz;
        }

        private dynamic CreateProfInstance<_ReturnType, T1, T2, T3, T4, T5>(_ReturnType rt, T1 o1, T2 o2, T3 o3, T4 o4, T5 o5)
            where _ReturnType : class
        {
            ConstructorInfo ctor = (typeof(_ReturnType)).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            _ReturnType kz = ctor.Invoke(new object[] { "47212121", "Sauleh", "http://img.co/sauleh.jpg", Degree.PhD, 20 }) as _ReturnType;
            return kz;
        }


        #endregion
        

    }
}