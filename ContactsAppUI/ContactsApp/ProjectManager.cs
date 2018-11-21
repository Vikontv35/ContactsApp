using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;


/// <summary>
/// Класс, реализующий метод для сохранения объекта «Проект» в файл и метод загрузки проекта из файла
/// </summary>
public class ProjectManager
{
    
    private static string _path= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"/save/ContactsApp.notes";
    
    /// <summary>
    /// Выполняет сохранение списка контактов
    /// </summary>
    /// <param name="data">Список контактов для сохранения</param>
    public static void SaveToFile(Project data)
    {
        
        JsonSerializer serializer = new JsonSerializer();
        using (StreamWriter sw = new StreamWriter(_path))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, data);
        }
    }

    /// <summary>
    /// Выполняет загруку списка контактов
    /// </summary>    
    public static Project LoadFromFile()
    {
        Project project = null;
        JsonSerializer serializer = new JsonSerializer();

        using (StreamReader sr = new StreamReader(_path))
        using (JsonReader reader = new JsonTextReader(sr))
        {
            //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
            project = (Project)serializer.Deserialize<Project>(reader);
        }
        return project;
    }
}
