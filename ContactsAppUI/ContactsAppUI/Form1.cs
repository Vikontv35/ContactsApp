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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contact contact1 = new Contact("Viktor", "Pronin",79137651234,new DateTime(1987,05,07),"Tr","tr@maul.ru");
            Contact contact2 = new Contact("Sergey", "Pronin",78732514637,new DateTime(1934,06,07),"Opr", "opr@maul.ru");

            Project project = new Project();
            project._contactsList.Add(contact1);
            project._contactsList.Add(contact2);

            ProjectManager.SaveToFile(project);

            Project project1 = ProjectManager.LoadFromFile();
        }
    }
}
