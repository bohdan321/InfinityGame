using UnityEngine;
using System.Collections;

public class BehaviourFlower : BaseBehaviourObject
{
    public override ModelObjectBase CreteObject(ModelObjectBase modelObjectBasedel )
    {
        ModelFlower modelFlower = (ModelFlower)modelObjectBasedel; 
  
        return modelFlower;
    }

    public override void UpdateObject(ModelObjectBase modelObjectBasedel)
    {
        
    }
}

