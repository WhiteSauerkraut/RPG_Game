using Newtonsoft.Json;
using System;
using System.IO;

/**
 * 创建日期：3/27
 * 创建人：lyj
 * 描述：数据持久化辅助类
 **/

public static class SaveHelper
{

    /*
     * 判断文件是否存在
     */
    public static bool IsFileExists(string fileName)
    {
        return File.Exists(fileName);
    }

    /*
     * 判断文件夹是否存在
     */
    public static bool IsDirectoryExists(string fileName)
    {
        return Directory.Exists(fileName);
    }

    /*
     * 将数据写入文本文件
     */
    public static void CreateFile(string fileName, string content)
    {
        StreamWriter streamWriter = new StreamWriter(fileName);
        streamWriter.Write(content);
        streamWriter.Close();
    }

    /*
     * 创建文件夹
     */
    public static void CreateDirectory(string fileName)
    {
        if (IsDirectoryExists(fileName))
        {
            return;
        }

        Directory.CreateDirectory(fileName);
    }

    /**
     * 删除文件夹及其文件
     * */
    public static void DeleteFolder(string file)
    {
        try
        {
            System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file)
            {
                Attributes = FileAttributes.Normal & FileAttributes.Directory
            };

            // 去除文件的只读属性
            System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);

            // 判断文件夹是否还存在
            if (Directory.Exists(file))

            {
                foreach (string f in Directory.GetFileSystemEntries(file))
                {
                    if (File.Exists(f))
                    {
                        File.Delete(f);
                    }
                    else
                    {
                        DeleteFolder(f);
                    }
                }
                Directory.Delete(file);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }
    }

    /*
     * 将对象存入文本
     */
    public static void SetData(string fileName, object obj)
    {
        string toSave = SerializeObject(obj);
        CreateFile(fileName, toSave);
    }

    /*
     * 从文本读取对象
     */
    public static object GetData(string fileName, Type pType)
    {
        StreamReader streamReader = File.OpenText(fileName);
        string data = streamReader.ReadToEnd();
        streamReader.Close();
        return DeserializeObject(data, pType);
    }

    /**
     * 将一个对象序列为字符串
     */
    private static string SerializeObject(object obj)
    {
        string serializedString = string.Empty;
        serializedString = JsonConvert.SerializeObject(obj);
        return serializedString;
    }

    /*
     * 将字符串反序列化为对象
     */
    private static object DeserializeObject(string pString, Type pType)
    {
        object deserializedObject = null;
        deserializedObject = JsonConvert.DeserializeObject(pString, pType);
        return deserializedObject;
    }

}
