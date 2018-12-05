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

        private Project _project;

        public MainForm()
        {
            InitializeComponent();
            
            _project= ProjectManager.LoadFromFile(ProjectManager._path);            
            if (_project != null)
            {
                int i = 0;//foreach
                while (i != _project._contactsList.Count)
                {
                    ContactsListBox.Items.Add(_project._contactsList[i].Surname);
                    i++;
                }
            }
            else
            {
                _project = new Project();
            }
            Project birth = Project.Birthday(_project, DateTime.Today);
            for(int i=0;i!=birth._contactsList.Count;i++)
            {
                BirthdaySurnameLabel.Text = BirthdaySurnameLabel.Text + birth._contactsList[i].Surname+". ";
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
                var Contact = newForm.Contact;
                _project._contactsList.Add(Contact);
                _project=Project.Sort(_project); 
                for (int k = 0; k != _project._contactsList.Count-1; k++)
                {
                    ContactsListBox.Items.RemoveAt(0);
                }
                for (int k = 0; k != _project._contactsList.Count; k++)
                {
                    ContactsListBox.Items.Add(_project._contactsList[k].Surname);
                }
                ProjectManager.SaveToFile(_project, ProjectManager._path);
            }
        }

        /// <summary>
        /// Функция редактирования контакта
        /// </summary>
        private void Edit()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите запись для редактирования", "Отсутствие записи");
            }
            else
            {

                var selectedContact = _project._contactsList[selectedIndex];
                var newForm = new ContactForm();
                newForm.Contact = selectedContact;
                var i = newForm.ShowDialog();
                if (i == DialogResult.OK)
                {
                    var updatedContact = newForm.Contact;
                    _project._contactsList.Insert(selectedIndex, updatedContact);
                    ContactsListBox.Items.Insert(selectedIndex, updatedContact.Surname);
                    _project._contactsList.RemoveAt(selectedIndex + 1);
                    ContactsListBox.Items.RemoveAt(selectedIndex + 1);

                    _project = Project.Sort(_project);
                    for (int k = 0; k != _project._contactsList.Count; k++)
                    {
                        ContactsListBox.Items.RemoveAt(0);
                    }
                    for (int k = 0; k != _project._contactsList.Count; k++)
                    {
                        ContactsListBox.Items.Add(_project._contactsList[k].Surname);
                    }
                    ProjectManager.SaveToFile(_project, ProjectManager._path);
                }
            }
        }

        /// <summary>
        /// Функция удаления записи
        /// </summary>
        private void Remove()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите запись для удаления", "Отсутствие записи");
            }
            else
            {
                var i=MessageBox.Show("Удалить эту запись?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (i == DialogResult.OK)
                {
                    _project._contactsList.RemoveAt(selectedIndex);
                    ContactsListBox.Items.RemoveAt(selectedIndex);
                    ProjectManager.SaveToFile(_project, ProjectManager._path);
                }

            }
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
            if (selectedIndex >= 0)
            {
                Contact contact = _project._contactsList[selectedIndex];
                SurnameTextBox.Text = contact.Surname;
                NameTextBox.Text = contact.Name;
                BirthdayTimePicker.Value = contact.Birth;
                PhoneTextBox.Text = contact.Number.Number.ToString();
                EmailTextBox.Text = contact.Email;
                VKTextBox.Text = contact.IdVk;
            }
            else
            {
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                BirthdayTimePicker.Value = DateTime.Today;
                PhoneTextBox.Text = "";
                EmailTextBox.Text = "";
                VKTextBox.Text = "";
            }
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
            var newForm = new AboutForm();
            newForm.Show();
        }

        /// <summary>
        /// Сортирует список по алфавиту
        /// </summary>        
        private void button1_Click_1(object sender, EventArgs e)
        {            
            _project = ProjectManager.LoadFromFile(ProjectManager._path);
            _project=Project.Sort(_project);
            ProjectManager.SaveToFile(_project, ProjectManager._path); 
            
            for(int i=0;i!= _project._contactsList.Count;i++)
            {
                ContactsListBox.Items.RemoveAt(0);                
            }
            for (int i = 0; i != _project._contactsList.Count; i++)
            {
                ContactsListBox.Items.Add(_project._contactsList[i].Surname);
            }
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FindTextBox.Text == "")
            {
                _project = ProjectManager.LoadFromFile(ProjectManager._path);
                while(ContactsListBox.Items.Count!=0)
                {
                    ContactsListBox.Items.RemoveAt(0);
                }
                for (int i = 0; i != _project._contactsList.Count; i++)
                {
                    ContactsListBox.Items.Add(_project._contactsList[i].Surname);
                }
            }
            else
            {
                _project = ProjectManager.LoadFromFile(ProjectManager._path);
                _project = Project.Sort(_project, FindTextBox.Text);
                if (_project == null)
                {
                    while (ContactsListBox.Items.Count != 0)
                    {
                        ContactsListBox.Items.RemoveAt(0);
                    }
                }
                else
                {
                    while (ContactsListBox.Items.Count != 0)
                    {
                        ContactsListBox.Items.RemoveAt(0);
                    }
                    for (int i = 0; i != _project._contactsList.Count; i++)
                    {
                        ContactsListBox.Items.Add(_project._contactsList[i].Surname);
                    }
                }
            }
        
        }

        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
                Remove();
            }
        }
    }
    
}
