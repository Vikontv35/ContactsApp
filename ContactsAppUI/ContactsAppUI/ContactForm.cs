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
        private Contact _contact=new Contact();
        public Contact Contact
        {
            get { return _contact; }
            set
            {
                _contact = new Contact();
                _contact.Surname = value.Surname;
                _contact.Name = value.Name;
                _contact.Number = value._number;
                _contact.Birth = value.Birth;
                _contact.Email = value.Email;
                _contact.IdVk = value.IdVk;
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
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch(Exception ex)
            {                
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
            
        }
        
        /// <summary>
        /// Считывает имя контакта с TextBox
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
                NameTextBox.BackColor = Color.LightSalmon;                
            }            
        }

        /// <summary>
        /// Считывает дату рождения контакта с TimePicker
        /// </summary>
        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Birth = BirthdayTimePicker.Value;
                BirthdayTimePicker.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                BirthdayTimePicker.BackColor = Color.LightSalmon;                
            }
        }

        /// <summary>
        /// Считывает номмер телефон контакта с TextBox
        /// </summary>
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneTextBox.Text, out number);
                _contact.Number.Number = number;
                PhoneTextBox.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                PhoneTextBox.BackColor = Color.LightSalmon;
            }            
        }

        /// <summary>
        /// Считывает e-mail контакта с TextBox
        /// </summary>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                EmailTextBox.BackColor = Color.LightSalmon;               
            }
        }

        /// <summary>
        /// Считывает idvk контакта с TextBox
        /// </summary>
        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.IdVk = VKTextBox.Text;
                VKTextBox.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Неверный ввод данных");
                VKTextBox.BackColor = Color.LightSalmon;                
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
            if (_contact.Surname != null)
            {
                SurnameTextBox.Text = _contact.Surname;
                NameTextBox.Text = _contact.Name;
                BirthdayTimePicker.Value = _contact.Birth;
                PhoneTextBox.Text = _contact.Number.Number.ToString();
                EmailTextBox.Text = _contact.Email;
                VKTextBox.Text = _contact.IdVk;
            }
        }
    }
}
