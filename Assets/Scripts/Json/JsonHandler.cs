using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonHandler
{
    public static void WriteToFile(string jsonString)
    {
        string jsonFile = Path.Combine(Application.dataPath, "data.json");
        if (File.Exists(jsonFile))
        {
            File.OpenWrite(jsonFile);
            File.WriteAllText(jsonFile, jsonString);
        }
        {
            CreateJsonFile();
        }
    }

    public static void ResetJSON()
    {
        string jsonFile = Path.Combine(Application.dataPath, "data.json");
        if (File.Exists(jsonFile))
        {
            File.Delete(jsonFile);
            File.Create(jsonFile);
        }
    }

    public static void CreateJsonFile()
    {
        string jsonFile = Path.Combine(Application.dataPath, "data.json");
        if (File.Exists(jsonFile))
            return;
        Debug.Log("Creating json file");
        File.Create(jsonFile);
        var levels = GameManager.instance.levels.ToArray();
        foreach (var level in levels)
        {
            string jsonString = JsonConvert.SerializeObject(level);
            WriteToFile(jsonString);
        }
    }
}
