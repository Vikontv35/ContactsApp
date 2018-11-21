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
    public partial class ContactForm : Form
    {
        private Contact _newcontact=new Contact();
        public Contact Newcontact
        {
            get { return _newcontact; }
            set
            {
                _newcontact.Surname = value.Surname;
                _newcontact.Name = value.Name;
                _newcontact._number = value._number;
                _newcontact.Birth = value.Birth;
                _newcontact.Email = value.Email;
                _newcontact.IdVk = value.IdVk;
            }
        }
        
            
        public ContactForm()
        {
            InitializeComponent();

            
        }
                        
        /// <summary>
        /// Считывает фамилию контакта с TextBox
        /// </summary>
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                _newcontact.Surname = SurnameTextBox.Text;
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                SurnameTextBox.BackColor = Color.LightSalmon;
                i++;
            }
            if(i!=0)
            {
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                SurnameTextBox.BackColor = Color.White;
            }
        }
        
        /// <summary>
        /// Считывает имя контакта с TextBox
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                _newcontact.Name = NameTextBox.Text;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                NameTextBox.BackColor = Color.LightSalmon;
                i++;
            }
            if (i != 0)
            {
                NameTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                NameTextBox.BackColor = Color.White;
            }
            
        }

        /// <summary>
        /// Считывает дату рождения контакта с TimePicker
        /// </summary>
        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                _newcontact.Birth = BirthdayTimePicker.Value;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                BirthdayTimePicker.BackColor = Color.LightSalmon;
                i++;
            }
            if (i != 0)
            {
                BirthdayTimePicker.BackColor = Color.LightSalmon;
            }
            else
            {
                BirthdayTimePicker.BackColor = Color.White;
            }
            
        }

        /// <summary>
        /// Считывает номмер телефон контакта с TextBox
        /// </summary>
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            long number;
            try
            {
                long.TryParse(PhoneTextBox.Text, out number);
                _newcontact._number.Number = number;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                PhoneTextBox.BackColor = Color.LightSalmon;
                i++;
            }
            if (i != 0)
            {
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                PhoneTextBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает e-mail контакта с TextBox
        /// </summary>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                _newcontact.Email = EmailTextBox.Text;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                EmailTextBox.BackColor = Color.LightSalmon;
                i++;
            }
            if (i != 0)
            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                EmailTextBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает idvk контакта с TextBox
        /// </summary>
        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                _newcontact.IdVk = VKTextBox.Text;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                VKTextBox.BackColor = Color.LightSalmon;
                i++;
            }
            if (i != 0)
            {
                VKTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                VKTextBox.BackColor = Color.White;
            }
            
        }

        /// <summary>
        /// Возвращает значение OK
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Возвращает значение Cancle
        /// </summary>        
        private void CancleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
            
        }

        /// <summary>
        /// Заполнение формы для редактирования
        /// </summary>
        private void OuterForm_Load(object sender, EventArgs e)
        {
            if (_newcontact.Surname != null)
            {
                SurnameTextBox.Text = _newcontact.Surname;
                NameTextBox.Text = _newcontact.Name;
                BirthdayTimePicker.Value = _newcontact.Birth;
                PhoneTextBox.Text = _newcontact._number.Number.ToString();
                EmailTextBox.Text = _newcontact.Email;
                VKTextBox.Text = _newcontact.IdVk;
            }
        }
    }
}
