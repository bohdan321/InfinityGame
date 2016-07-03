using UnityEngine;
using System.Collections;

public class BehaviourRabbit : BaseBehaviourObject
{
    public override ModelObjectBase CreteObject(ModelObjectBase modelObjectBasedel )
    {
        ModelRabbit modelRabbit = (ModelRabbit)modelObjectBasedel; 
  
        return modelRabbit;
    }

    public override void UpdateObject(ModelObjectBase modelObjectBasedel)
    {

    }
}

