using UnityEngine;
using System.Collections;

public class ModelRabbit :ModelObjectBase
{
    public ModelRabbit()
    {
        NameObject = "Rabbit";         

        TypeObject = "rabbit";      

        UpgradeTypeObject = typeof(BehaviourCat);
    }
}

