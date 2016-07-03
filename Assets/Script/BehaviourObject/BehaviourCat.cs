using UnityEngine;
using System.Collections;

public class BehaviourCat  : BaseBehaviourObject
{
    public override ModelObjectBase CreteObject(ModelObjectBase modelObjectBasedel )
    {
        ModelCat modelCat = (ModelCat)modelObjectBasedel; 
  
        return modelCat;
     }

    public override void UpdateObject(ModelObjectBase modelObjectBasedel)
    {

    }
}

