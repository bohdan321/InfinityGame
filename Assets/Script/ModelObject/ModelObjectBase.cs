using UnityEngine;
using System.Collections;
using System;

public class ModelObjectBase 
{
    private Vector2 matrixPosition;

    private string nameObject;

    private string typeObject;

    private Type upgradeTypeObject;

    public Vector2 MatrixPosition
    {
        get{return matrixPosition; }
        set{matrixPosition = value; }
    }


    public string NameObject
    {
        get{return nameObject; }
        set{nameObject = value; }
    }

    public string TypeObject
    {
        get{return typeObject; }
        set{typeObject = value; }
    }

    public Type UpgradeTypeObject
    {
        get{return upgradeTypeObject;}
        set{upgradeTypeObject = value;}
    }

}

