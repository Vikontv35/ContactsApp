using System;
using System.Collections.Generic;

/// <summary>
/// Класс, содежащий список всех контактов созданных в приложении
/// </summary>
public class Project
{
    /// <summary>
    /// Хранит список контактов
    /// </summary>
    public List<Contact> _contactsList = new List<Contact>();

    /// <summary>
    /// Функция, сортирующая список по алфавиту
    /// </summary>
    /// <param name="data">Список, который требуеться отсортировать</param>
    /// <returns></returns>
    public static Project Sort(Project data)
    {
        Project returneProject = new Project();
        returneProject._contactsList.Add(data._contactsList[0]);        
        for (int i=1;i<data._contactsList.Count;i++)
        {
            if (data._contactsList[i].Surname[0] >= returneProject._contactsList[i - 1].Surname[0])
            {
                returneProject._contactsList.Add(data._contactsList[i]);
            }
            else
            {
                
                bool flag=false;
                int k = i - 1;
                while (data._contactsList[i].Surname[0] < returneProject._contactsList[k].Surname[0])
                {
                    if (k == 0)
                    {
                        returneProject._contactsList.Insert(0, data._contactsList[i]);
                        flag = true;
                        break;
                    }
                    k--;                    
                }
                if ((flag == false) &&(k==0))
                {
                    returneProject._contactsList.Insert(1, data._contactsList[i]);
                }
                if((flag == false) && (k != 0))
                {
                    returneProject._contactsList.Insert(k+1, data._contactsList[i]);
                }
            }

        }

        return returneProject;
    }

    /// <summary>
    /// Функция, сортирующая список совпадающих имён и фамилий по алфавиту
    /// </summary>
    /// <param name="data">Список, в котором ведёться поиск</param>
    /// <param name="find">Подстрока, которую нужно найти</param>
    /// <returns></returns>
    public static Project Sort(Project data,string find)
    {
        Project returnProject = new Project();
        for(int i=0;i<data._contactsList.Count;i++)
        {
            if(data._contactsList[i].Surname.Contains(find) || data._contactsList[i].Name.Contains(find))
            {
                returnProject._contactsList.Add(data._contactsList[i]);
            }

        }
        if(returnProject._contactsList.Count==0)
        {
            returnProject = null;
            return returnProject;
        }
        Project.Sort(returnProject);
        return returnProject;
    }

    /// <summary>
    /// Поиск людей в списке с днём рождения в указанную дату
    /// </summary>
    /// <param name="data"></param>
    /// <param name="today"></param>
    /// <returns></returns>
    public static Project Birthday(Project data,DateTime today)
    {
        Project returnProject = new Project();
        for (int i = 0; i < data._contactsList.Count; i++)
        {
            if((data._contactsList[i].Birth.Day==today.Day) && (data._contactsList[i].Birth.Month == today.Month))
            {
                returnProject._contactsList.Add(data._contactsList[i]);
            }
        }
        return returnProject;
    }    
}
