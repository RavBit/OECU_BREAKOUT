using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class LevelLoader : MonoBehaviour {
    private LevelsContainer levels;
    public List<Level> Levels;
    private string dataPath;
    [ContextMenu("LoadFromJson")]
    public void Start()
    {
        dataPath = (Application.streamingAssetsPath + "/Nodes.json");
        LoadJson();
    }
    private void LoadJson()
    {
        using (StreamReader stream = new StreamReader(dataPath))
        {
            string json = stream.ReadToEnd();
            levels = JsonConvert.DeserializeObject<LevelsContainer>(json);
        }
        Levels = levels.levels.ToList();
    }
}

[Serializable]
public class LevelsContainer
{
    public Level[] levels;
}