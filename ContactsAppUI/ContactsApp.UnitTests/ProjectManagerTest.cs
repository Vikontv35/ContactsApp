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
            
            Assert.DoesNotThrow(
                () => { ProjectManager.SaveToFile(_project,
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ContactsAppTest.notes");
                },"Тест пройден, если исключений не возникло");
        }

        [Test(Description = "Позитивный тест десериализации")]
        public void Test_Load_From_File_Correct_Value()
        {
            Project actualProject = new Project();
            _project._contactsList.Add(_contact);

            ProjectManager.SaveToFile(_project,"C:\\Users\\Viktor\\Documents\\ContactsAppTest2.notes");

            actualProject = ProjectManager.LoadFromFile("C:\\Users\\Viktor\\Documents\\ContactsAppTest2.notes");

            Assert.AreEqual(_project, actualProject, "Загрузка из файла работает некоректно");
        }
    }
}
