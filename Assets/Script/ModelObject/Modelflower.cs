using UnityEngine;
using System.Collections;

public class ModelFlower : ModelObjectBase
{
    public ModelFlower()
    {
        NameObject = "Flower";         

        TypeObject = "flower";     

        UpgradeTypeObject = typeof(BehaviourRabbit);
    }
}

