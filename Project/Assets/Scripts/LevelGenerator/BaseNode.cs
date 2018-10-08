using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNode
{
    public ParamCube ParamCube { set; get; }
    public BlockEffects BlockEffects { set; get; }
    public abstract void InitEffects();
}
