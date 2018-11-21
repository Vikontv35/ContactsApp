using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {

        private Project project;
        public MainForm()
        {
            InitializeComponent();
            
            project= ProjectManager.LoadFromFile();
            if (project != null)
            {
                int i = 0;
                while (i != project._contactsList.Count)
                {
                    ContactsListBox.Items.Add(project._contactsList[i].Surname);
                    i++;
                }
            }
            else
            {
                project = new Project();
            }
        }

        /// <summary>
        /// Функция добавления записи
        /// </summary>
        private void Add()
        {
            var newForm = new ContactForm();
            var i = newForm.ShowDialog();            
            if (i == DialogResult.OK)
            {
                var Contact = newForm.Newcontact;
                project._contactsList.Add(Contact);
                ContactsListBox.Items.Add(Contact.Surname);
                ProjectManager.SaveToFile(project);
            }
        }

        /// <summary>
        /// Функция редактирования контакта
        /// </summary>
        private void Edit()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            var selectedContact = project._contactsList[selectedIndex];
            var newForm = new ContactForm();
            newForm.Newcontact = selectedContact;
            var i = newForm.ShowDialog();            
            if (i == DialogResult.OK)
            {
                var updatedContact = newForm.Newcontact;
                project._contactsList.Insert(selectedIndex, updatedContact);
                ContactsListBox.Items.Insert(selectedIndex, updatedContact.Surname);
                project._contactsList.RemoveAt(selectedIndex + 1);
                ContactsListBox.Items.RemoveAt(selectedIndex + 1);
                ProjectManager.SaveToFile(project);
            }
        }

        /// <summary>
        /// Функция удаления записи
        /// </summary>
        private void Remove()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            project._contactsList.RemoveAt(selectedIndex);
            ContactsListBox.Items.RemoveAt(selectedIndex);
            ProjectManager.SaveToFile(project);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Вызывает форму для создания нового контакта
        /// </summary>
        private void AddContactButton_Click(object sender, EventArgs e)
        {
            Add();            
        }

        /// <summary>
        /// Вызывает форму для редактирования записи по нажатию кнопки
        /// </summary>        
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            Edit();
        }

        /// <summary>
        /// Переключение между контактами из списка и вывод выбранного контакта в левой панели
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if(selectedIndex==-1)
            {
                selectedIndex = 0;
            }
            Contact contact = project._contactsList[selectedIndex];
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayTimePicker.Value = contact.Birth;
            PhoneTextBox.Text = contact._number.Number.ToString();
            EmailTextBox.Text = contact.Email;
            VKTextBox.Text = contact.IdVk;
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            Remove();
        }

        /// <summary>
        /// Добавление нового контакта
        /// </summary>
        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        /// <summary>
        /// Закрытие программы
        /// </summary>
        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Редактирование существующего контакта
        /// </summary>        
        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit();
        }

        /// <summary>
        /// Удаление существующего контакта
        /// </summary>        
        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }

        /// <summary>
        /// Вызывает форму с информацией
        /// </summary>        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new About();
            newForm.Show();
        }
    }
}
