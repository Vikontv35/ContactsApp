using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        private Contact _contact;
        private Project _project;
        [SetUp]
        public void InitProject()
        {
            _contact = new Contact();
            _contact.Surname = "Ivanon";
            _contact.Name = "Ivan";
            _contact.Number.Number = 79139645215;
            _contact.Birth = new DateTime(1990, 02, 12);
            _contact.Email = "tr@mail.ru";
            _contact.IdVk = "23554578";

            _project = new Project();
        }

        [Test(Description = "Позитивный тест сериализации")]
        public void Test_Save_To_File_Correct_Value()
        {         
            _project._contactsList.Add(_contact);
            ProjectManager.SaveToFile(_project,Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                + "/source/repos/ContactsApp/ContactsAppUI/ContactsApp.UnitTests/ContactsAppTest1.notes");

            string reference = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                + "/source/repos/ContactsApp/ContactsAppUI/ContactsApp.UnitTests/ContactsAppTest.notes");
            string actual= System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                + "/source/repos/ContactsApp/ContactsAppUI/ContactsApp.UnitTests/ContactsAppTest1.notes");

            Assert.AreEqual(reference, actual, "Тест пройден, если исключений не возникло");                       
        }

        [Test(Description = "Позитивный тест десериализации")]
        public void Test_Load_From_File_Correct_Value()
        {
            _project._contactsList.Add(_contact);
            Project actualProject = new Project();            
            
            actualProject = ProjectManager.LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                "/source/repos/ContactsApp/ContactsAppUI/ContactsApp.UnitTests/ContactsAppTest.notes");

            Assert.AreEqual(_project._contactsList.Count, actualProject._contactsList.Count, "Загрузка работает некоректно1");
            for (int i = 0; i != _project._contactsList.Count; i++)
                {
                Assert.AreEqual(_project._contactsList[i].Surname, actualProject._contactsList[i].Surname,
                        "Загрузка работает некоректно2");
                Assert.AreEqual(_project._contactsList[i].Name, actualProject._contactsList[i].Name,
                        "Загрузка работает некоректно3");
                Assert.AreEqual(_project._contactsList[i].Number.Number, actualProject._contactsList[i].Number.Number,
                        "Загрузка работает некоректно4");
                Assert.AreEqual(_project._contactsList[i].IdVk, actualProject._contactsList[i].IdVk,
                        "Загрузка работает некоректно5");
                Assert.AreEqual(_project._contactsList[i].Birth, actualProject._contactsList[i].Birth,
                        "Загрузка работает некоректно6");
                Assert.AreEqual(_project._contactsList[i].Email, actualProject._contactsList[i].Email,
                         "Загрузка работает некоректно7");
            }
                                  
        }
    }
}
