using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;


/// <summary>
/// Класс, реализующий метод для сохранения объекта «Проект» в файл и метод загрузки проекта из файла
/// </summary>
public class ProjectManager
{
    
    public static string _path= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"/ContactsApp.notes";
    
    /// <summary>
    /// Выполняет сохранение списка контактов
    /// </summary>
    /// <param name="data">Список контактов для сохранения</param>
    public static void SaveToFile(Project data, string filePath)
    {
        JsonSerializer serializer = new JsonSerializer();
        using (StreamWriter sw = new StreamWriter(filePath))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, data);
        }
    }

    /// <summary>
    /// Выполняет загруку списка контактов
    /// </summary>    
    public static Project LoadFromFile(string filePath)
    {
        Project project = null;
        JsonSerializer serializer = new JsonSerializer();

        if(System.IO.File.Exists(_path)==false)
        {            
            using (StreamWriter sw = new StreamWriter(filePath)) ;
        }
        using (StreamReader sr = new StreamReader(filePath))
        using (JsonReader reader = new JsonTextReader(sr))
        {
            //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
            project = (Project)serializer.Deserialize<Project>(reader);
        }
        return project;
    }
}
