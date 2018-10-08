using UnityEngine;

[System.Serializable]
public class Node : BaseNode {
    public int NodePosX { get; set; }
    public int NodePosY { get; set; }
    public int MaxSize { get; set; }
    public int Band { get; set; }
    public Direction dir { get; set ; }

    public override void InitEffects()
    {
        this.BlockEffects.Band = Band;
        this.BlockEffects._scaleMultiplier = MaxSize;
        this.BlockEffects._startScale = 1;
        this.BlockEffects._useBuffer = true;
    }
}


public enum Direction
{
    Left,
    Middle,
    Right
}


