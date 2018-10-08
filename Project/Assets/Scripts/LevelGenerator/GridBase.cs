using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase : MonoBehaviour {
    public GameObject BackgroundPrefab;
    public List<GameObject> NodeObjects;
    public GameObject NodePrefab;
    [Header("Size for Grid:")]
    public int xSize, ySize;
    public Node[,] mapData;


    //METHODS:
    /*public delegate void OnGenerateLevel();
    public event OnGenerateLevel GeneratedLevel;*/


    // Use this for initialization
    void Start () {
        //GeneratedLevel += GenerateLevel;
        mapData = new Node[xSize, ySize];
    }

    /*protected virtual void OnGeneratedLevel()
    {
        if(GeneratedLevel != null)
        {
            GeneratedLevel();
        }
    }*/
    


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
        foreach(Node n in GetComponent<LevelLoader>().Levels[0].nodes)
        {
            if(mapData[n.NodePosX, n.NodePosY] != null)
            {
                Debug.LogError("Can't draw [NODE: " + n.NodePosX + "." + n.NodePosY + "] Location used by [NODE :" + mapData[n.NodePosX, n.NodePosY].NodePosX + "." + mapData[n.NodePosX, n.NodePosY].NodePosY+ "]");
            }
            else
            {
                GameObject _node = Instantiate(NodePrefab, new Vector3(n.NodePosX, n.NodePosY, 0), Quaternion.identity) as GameObject;
                _node.transform.parent = this.transform;
                n.BlockEffects = _node.GetComponent<BlockEffects>();
                DirectionNode(n);
                n.InitEffects();
            }



        }
    }

    private void DirectionNode(Node n)
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
                    if (n.NodePosX - i > 0)
                        mapData[n.NodePosX - i, n.NodePosY] = n;
                    if (n.NodePosX + i < mapData.Length)
                        mapData[n.NodePosX + i, n.NodePosY] = n;
                }
                break;
        }
    }
}
