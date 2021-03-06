using LitJson;
using SFB;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<DataManager>();

            return _instance;
        }
    }

    public const string FILE_TYPE = "json";
    public const string FILE_DEFAULT_NAME = "untitled";

    private string[] currentLoadPath = null;

    private RectToolData _data; // TODO Loaddata
    public RectToolData data
    {
        get
        {
            if (_data == null)
                _data = new RectToolData();
            return _data;
        }
    }

    public void ChooseLoadFile()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Choose Galaxy Chat json file", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), FILE_TYPE, false);

        if (paths.Length > 0 && !string.IsNullOrWhiteSpace(paths[0])) 
        {
            var sr = new StreamReader(paths[0]);
            var fileContents = sr.ReadToEnd();

            sr.Close();
            LoadFileToImage(fileContents, paths);
        }
    }

    public void ChooseSaveFolder()
    {
        var fileName = (currentLoadPath != null && currentLoadPath.Length > 0) ? Path.GetFileName(currentLoadPath[0]) : FILE_DEFAULT_NAME;
        var path = StandaloneFileBrowser.SaveFilePanel("Choose save path", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName, FILE_TYPE);
        if (!string.IsNullOrWhiteSpace(path))
        {
            var newDelay = new List<uint>();

            File.WriteAllText(path, JsonMapper.ToJson(_data));
            Debug.Log("Save : DONE | Path : " + path);
        }
        else
        {
            Debug.Log("ChooseSaveFolder - No path select");
        }
    }

    private void LoadFileToImage(string fileContent, string[] paths)
    {
        currentLoadPath = paths;
        _data = JsonMapper.ToObject<RectToolData>(fileContent);
        Debug.Log("LoadFileToNode - Loaded");
    }
}