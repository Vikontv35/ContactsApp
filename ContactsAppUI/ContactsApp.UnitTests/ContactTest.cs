using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ContactTest
    {
        private Contact _contact;

        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
        }

        [TestCase("IvanovIvanovIvanovIvanovIvanovIvanovIvanovIvanovIvanovIvanov", 
            "Должно возникать исключение, если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии больше 50 символов")]
        [TestCase("?","Должно возникать исключение, если один из присвоеных символов меньше ascii кода A",
            TestName ="Присвоение неправильной фамиилии, с символом меньше ascii кода A")]
        [TestCase("{", "Должно возникать исключение, если один из присвоеных символов больше ascii кода z",
            TestName = "Присвоение неправильной фамиилии, с символом больше ascii кода z")]
        [TestCase("[", "Должно возникать исключение, если один из присвоеных символов больше ascii кода Z и меньше ascii кода a",
            TestName = "Присвоение неправильной фамиилии, с символом больше ascii кода Z и меньше ascii кода a")]
        [TestCase("ivanov", "Должно возникать исключение, если первый из присвоеных символов больше ascii кода a и меньше ascii кода z",
            TestName = "Присвоение неправильной фамиилии, с первым символом больше ascii кода a и меньше ascii кода z")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {            
            Assert.Throws<ArgumentException>(
            () => { _contact.Surname = wrongSurname; },
            message);
        }

        [TestCase("Ivanov",
           "Тест пройден если иключений не возникло",
           TestName = "Присвоение правильной фамилии")]
        public void Test_Surname_Set_CorrectValue(string rightSurname, string massage)
        {            
            Assert.DoesNotThrow(
                () => { _contact.Surname = rightSurname; },
                massage);
        }

        [Test(Description = "Позитивный тест геттера Surname")]
        public void Test_Surname_Get_CorrectValue()
        {
            //Ожидаемое, поданое значение
            var expected = "Ivanov";
            _contact.Surname = expected;
            //Возвращаемое значение
            var actual = _contact.Surname;
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [TestCase("IvanIvanIvanIvanIvanIvanIvanIvanIvanIvanIvanIvanIvan",
           "Должно возникать исключение, если имя длиннее 50 символов",
           TestName = "Присвоение неправильного имени больше 50 символов")]
        [TestCase("?", "Должно возникать исключение, если один из присвоеных символов меньше ascii кода A",
           TestName = "Присвоение неправильного имени, с символом меньше ascii кода A")]
        [TestCase("{", "Должно возникать исключение, если один из присвоеных символов больше ascii кода z",
           TestName = "Присвоение неправильного имени, с символом больше ascii кода z")]
        [TestCase("[", "Должно возникать исключение, если один из присвоеных символов больше ascii кода Z и меньше ascii кода a",
           TestName = "Присвоение неправильного имени, с символом больше ascii кода Z и меньше ascii кода a")]
        [TestCase("ivan", "Должно возникать исключение, если первый из присвоеных символов больше ascii кода a и меньше ascii кода z",
           TestName = "Присвоение неправильного имени, с первым символом больше ascii кода a и меньше ascii кода z")]
        public void Test_Name_Set_ArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
            () => { _contact.Name = wrongName; },
            message);
        }
       
        [TestCase("Ivan",
           "Тест пройден если иключений не возникло",
           TestName = "Присвоение правильного имени")]
        public void Test_Name_Set_CorrectValue(string rightName,string massage)
        {            
            Assert.DoesNotThrow(
                () => { _contact.Name = rightName; },
               massage);
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void Test_Name_Get_CorrectValue()
        {
            //Ожидаемое, поданое значение
            var expected = "Ivan";
            _contact.Surname = expected;
            //Возвращаемое значение
            var actual = _contact.Surname;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }

        [TestCase("mail-mail-mail-mail",
           "Должно возникать исключение, если email длиннее 15 символов",
           TestName = "Присвоение неправильного email")]
        public void Test_Email_Set_ArgumentException(string wrongEmail, string massage)
        {            
            Assert.Throws<ArgumentException>(
            () => { _contact.Email = wrongEmail; },
            massage);
        }

        [TestCase("mail@gmail.com",
           "Тест пройден если иключений не возникло",
           TestName = "Присвоение правильного email")]
        public void Test_Email_Set_CorrectValue(string rightEmail, string massage)
        {            
            Assert.DoesNotThrow(
            () => { _contact.Email = rightEmail; },
            massage);
        }

        [Test(Description = "Позитивный тест геттера Email")]
        public void Test_Email_Get_CorrectValue()
        {
            //Ожидаемое, поданое значение
            var expected = "tr@mail.ru";
            _contact.Email = expected;
            //Возвращаемое значение
            var actual = _contact.Email;
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильный email");
        }

        [TestCase("12345678901234567",
           "Должно возникать исключение, если idvk длиннее 15 символов",
           TestName = "Присвоение неправильного idvk")]
        public void Test_IdVK_Set_ArgumentException(string wrongIdVK, string massage)
        {
            Assert.Throws<ArgumentException>(
            () => { _contact.IdVk = wrongIdVK; },
            massage);
        }

        [TestCase("123456",
           "Тест пройден если иключений не возникло",
           TestName = "Присвоение правильного idvk")]
        public void Test_IdVK_Set_CorrectValue(string rightIdVK, string massage)
        {
            Assert.DoesNotThrow(
            () => { _contact.IdVk = rightIdVK; },
            massage);
        }

        [Test(Description = "Позитивный тест геттера IdVK")]
        public void Test_IdVK_Get_CorrectValue()
        {
            //Ожидаемое, поданое значение
            var expected = "123456";
            _contact.IdVk = expected;
            //Возвращаемое значение
            var actual = _contact.IdVk;
            Assert.AreEqual(expected, actual, "Геттер IdVK возвращает неправильный idvk");
        }
        private static DateTime r = new DateTime(3000, 11, 12);
        [TestCase("3000, 11, 12",
           "Должно возникать исключение, если дата рождение больше сегодняшней",
           TestName = "Присвоение неправильной даты рождения больше допустимого")]
        [TestCase("1890, 01, 01",
           "Должно возникать исключение, если дата рождение меньше 1900 года",
           TestName = "Присвоение неправильной даты рождения меньше допусимого")]
        public void Test_Birth_Set_ArgumentException(string wrongBirth, string massage)
        {
            Assert.Throws<ArgumentException>(
            () => { _contact.Birth = DateTime.Parse(wrongBirth); },
            massage);
        }

        [TestCase("1990,03,15",
           "Тест пройден если иключений не возникло",
           TestName = "Присвоение правильной даты рождения")]
        public void Test_Birth_Set_CorrectValue(string rightBirth, string massage)
        {
            Assert.DoesNotThrow(
            () => { _contact.Birth = DateTime.Parse(rightBirth); },
            massage);
        }

        [Test(Description = "Позитивный тест геттера Birth")]
        public void Test_Birth_Get_CorrectValue()
        {
            //Ожидаемое, поданое значение
            DateTime expected = new DateTime(1991, 12, 31);
            _contact.Birth = expected;
            //Возвращаемое значение
            var actual = _contact.Birth;
            Assert.AreEqual(expected, actual, "Геттер Birth возвращает неправильную дату рождения");
        }

        [TestCase(9999999999, "Должно возникать исключение, если номер меньше 10000000000",
        TestName = "Присвоение значения номера меньше 11 символов")]
        [TestCase(100000000000, "Должно возникать исключение, если номер больше 100000000000",
        TestName = "Присвоение значения номера больше 11 символов")]
        [TestCase(60000000000, "Должно возникать исключение, если номер начнинается не с 7",
        TestName = "Присвоение неправильного номера с первым числом меньше 7")]
        [TestCase(80000000000, "Должно возникать исключение, если номер начнинается не с 7",
        TestName = "Присвоение неправильного номера с первым числом больше 7")]
        public void Test_Contact_Number_Set_ArgumentException(long wrongNumber, string message)
        {
            Assert.Throws<ArgumentException>(
            () => { _contact.Number.Number = wrongNumber; },
            message);
        }

        [Test(Description = "Позитивный тест сеттера Number")]
        public void Test_Contact_Number_Set_CorrectValue()
        {
            var expected = 79139522613;
            Assert.DoesNotThrow(
                () => { _contact.Number.Number = expected; },
                "Тест не пройден, если выдаётся исключение");
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void Test_Contact_Number_Get_CorrectValue()
        {           
            //Ожидаемое, поданое значение
            var expected = 79139522613;
            _contact.Number.Number = expected;
            //Возвращаемое значение
            var actual = _contact.Number.Number;
            Assert.AreEqual(expected, actual, "Геттер Number возвращает неправильный номер телефона");
        }
    }
}

