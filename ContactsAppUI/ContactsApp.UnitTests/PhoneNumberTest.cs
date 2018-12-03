using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTest
    {
        private PhoneNumber _number;

        [SetUp]
        public void InitNumber()
        {
            _number = new PhoneNumber();
        }

        [TestCase(9999999999, "Должно возникать исключение, если номер меньше 10000000000",
        TestName = "Присвоение значения номера меньше 11 символов")]
        [TestCase(100000000000, "Должно возникать исключение, если номер больше 100000000000",
        TestName = "Присвоение значения номера больше 11 символов")]
        [TestCase(60000000000, "Должно возникать исключение, если номер начнинается не с 7",       
        TestName = "Присвоение неправильного номера с первым числом меньше 7")]
        [TestCase(80000000000, "Должно возникать исключение, если номер начнинается не с 7",
        TestName = "Присвоение неправильного номера с первым числом больше 7")]
        public void Test_Number_Set_ArgumentException(long wrongNumber, string message)
        {
            Assert.Throws<ArgumentException>(
            () => { _number.Number = wrongNumber; },
            message);
        }
        
        [Test(Description = "Позитивный тест сеттера Number")]        
        public void Test_Number_Set_CorrectValue()
        {
            var expected = 79139522613;
            Assert.DoesNotThrow(
                () => { _number.Number = expected; },
                "Тест не пройден, если выдаётся исключение");
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void Test_Number_Get_CorrectValue()
        {
            //Ожидаемое, поданое значение
            var expected = 79139522613;
            _number.Number = expected;
            //Возвращаемое значение
            var actual = _number.Number;
            Assert.AreEqual(expected, actual, "Геттер Number возвращает неправильный номер телефона");
        }
    }
}
