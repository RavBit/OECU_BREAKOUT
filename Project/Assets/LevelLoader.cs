using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class LevelLoader : MonoBehaviour {
    private NodesContainer nodes;
    public List<Node> Nodes;
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
            nodes = JsonConvert.DeserializeObject<NodesContainer>(json);
        }
        Nodes = nodes.nodes.ToList();
        GridBase.OnGeneratedLevel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
