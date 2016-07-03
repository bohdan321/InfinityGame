using UnityEngine;
using System.Collections;

public abstract class BaseBehaviourObject : MonoBehaviour
{
    public abstract ModelObjectBase CreteObject(ModelObjectBase modelObjectBasedel); 

    public abstract void UpdateObject(ModelObjectBase modelObjectBasedel); 
}

