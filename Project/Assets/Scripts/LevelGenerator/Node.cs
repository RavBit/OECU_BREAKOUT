using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node {
    public int nodePosX;
    public int nodePosY;
    public int MaxSize;
    public Direction dir = Direction.Middle; 
}


public enum Direction
{
    Left,
    Middle,
    Right
}

