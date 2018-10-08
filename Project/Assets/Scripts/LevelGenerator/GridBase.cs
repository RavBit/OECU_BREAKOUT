using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase : MonoBehaviour {
    public GameObject BackgroundPrefab;
    public GameObject NodePrefab;
    [Header("Size for Grid:")]
    public int xSize, ySize;
    public Node[,] mapData;


    //METHODS:
    public delegate void OnGenerateLevel();
    public event OnGenerateLevel GeneratedLevel;

    //TODO LINK CLASSES CORRECTLY:
    public LevelLoader LL;
    // Use this for initialization
    void Start () {
        GeneratedLevel += GenerateLevel;
        mapData = new Node[xSize, ySize];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    protected virtual void OnGeneratedLevel()
    {
        if(GeneratedLevel != null)
        {
            GeneratedLevel();
        }
    }
    
    public void GenerateLevel()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject _background = Instantiate(BackgroundPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                _background.transform.parent = this.transform;
            }
        }
        LoadNodes();
    }

    public void LoadNodes()
    {
        foreach(Node n in LL.Nodes)
        {
            if(mapData[n.nodePosX, n.nodePosY] != null)
            {
                Debug.LogError("Can't draw [NODE: " + n.nodePosX + "." + n.nodePosY + "] Location used by [NODE :" + mapData[n.nodePosX, n.nodePosY].nodePosX + "." + mapData[n.nodePosX, n.nodePosY].nodePosY+ "]");
            }
            else
            {
                GameObject _node = Instantiate(NodePrefab, new Vector3(n.nodePosX, n.nodePosY, 0), Quaternion.identity) as GameObject;
                _node.transform.parent = this.transform;
                DirectionNode(n);
            }



        }
    }
    public void DirectionNode(Node n)
    {
        switch(n.dir)
        {
            case (Direction.Middle):
                int cal = n.MaxSize / 2;
                if(cal == 0)
                {
                    return;
                }
                for (int i = 0; i <= cal; i++)
                {
                    if (n.nodePosX - i > 0)
                        mapData[n.nodePosX - i, n.nodePosY] = n;
                    if (n.nodePosX + i < mapData.Length)
                        mapData[n.nodePosX + i, n.nodePosY] = n;
                }
                break;
        }
    }
    public void MapTiles()
    {

    }
}
