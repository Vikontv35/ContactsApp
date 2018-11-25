using System;

/// <summary>
/// Класс, хранящий фамилию, имя, номер телефона, e-mail и vkID
/// </summary>
public class Contact
{
    /// <summary>
    /// Хранит фамилию контакта
    /// </summary>
    private string _surname;

    /// <summary>
    /// Хранит имя контакта
    /// </summary>
    private string _name;

    /// <summary>
    /// Хранит номер телефона контакта
    /// </summary>
    public PhoneNumber _number=new PhoneNumber();

    /// <summary>
    /// Хранит Email контакта
    /// </summary>
    private string _email;

    /// <summary>
    /// Хранит дату рождения контакта
    /// </summary>
    private DateTime _birth;

    /// <summary>
    /// Хранит idVK контакта
    /// </summary>
    private string _idVK;

    /// <summary>
    /// Возвращает и задаёт фамилию контакта 
    /// </summary>
    public string Surname
    {
        get { return _surname; }
        set
        {
            if ((value.Length) > 50)
            {
                throw new ArgumentException("Длинна фамилии не должна превышать 50 символов.");
            }
            int i = 0;
            
            while (i < value.Length)
            {
                if ((value[i] < 'A') || (value[i] > 'z') || (value[i] > 'Z' && value[i] < 'a'))
                {
                    throw new ArgumentException("Фамилия должна содержать только буквы.");
                }
                i++;
            }
            i = 0;
            if (value[i] >= 'a' && value[i] <= 'z')
            {
                throw new ArgumentException("Фамилия должна начинаться с заглавной буквы.");
            }
            _surname = value;
        }
    }

    /// <summary>
    /// Возвращает и задаёт имя контакта
    /// </summary>
    public string Name
    {
        get { return _name; }
        set
        {
            if ((value.Length) > 50)
            {
                throw new ArgumentException("Длинна имени не должна превышать 50 символов.");
            }
            int i = 0;

            while (i < value.Length)
            {
                if ((value[i] < 'A') || (value[i] > 'z') || (value[i] > 'Z' && value[i] < 'a'))
                {
                    throw new ArgumentException("Имя должно содержать только буквы.");
                }
                i++;
            }
            i = 0;
            if (value[i] >= 'a' && value[i] <= 'z')
            {
                throw new ArgumentException("Имя должно начинаться с заглавной буквы.");
            }
            _name = value;
        }
    }

    /// <summary>
    /// Возвращает и задаёт Email контакта
    /// </summary>
    public string Email
    {
        get { return _email; }
        set
        {
            if ((value.Length) > 15)
            {
                throw new ArgumentException("Длинна e-mail не должна превышать 50 символов.");
            }
            _email = value;
        }
    }

    /// <summary>
    /// Возвращает и задаёт idVK Контакта
    /// </summary>
    public string IdVk
    {
        get { return _idVK; }
        set
        {
            if ((value.Length) > 15)
            {
                throw new ArgumentException("Длинна id VK не должна превышать 15 символов.");
            }
            _idVK = value;
        }
    }

    /// <summary>
    /// Возвращает и задаёт дату рождения
    /// </summary>
    public DateTime Birth
    {
        get { return _birth; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Дата рождения не может быть больше текушей даты");
            }
            if (value.Year < 1900)
            {
                throw new ArgumentException("Дата рождения не может быть быть меньше 1900 года");
            }
            _birth = value;
        }
    }

    /// <summary>
    /// Возвращает и задаёт номер телефона
    /// </summary>
    public PhoneNumber Number
    {
        get { return _number; }
        set { _number = value; }
    }
    public Contact() { }

    /// <summary>
    /// Конструктор класса Contact
    /// </summary>
    /// <param name="name">Имя контакта</param>
    /// <param name="surname">Фамилия контакта</param>
    /// <param name="num">Номертелефона контакта</param>
    /// <param name="date">Дата рождения контакта</param>
    /// <param name="idvk">vk.com контакта</param>
    /// <param name="email">e-mail контакта</param>
    public Contact(string name, string surname,long num, DateTime date,string idvk,string email)
    {
        Name = name;
        Surname = surname;
        _number.Number = num;
        Birth = date;
        IdVk = idvk;
        Email = email;
    }
}
