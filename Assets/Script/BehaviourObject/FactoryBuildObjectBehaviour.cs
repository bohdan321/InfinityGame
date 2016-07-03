using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FactoryBuildObjectBehaviour 
{
    static Dictionary<Type , BaseBehaviourObject> creteObject;

    static Dictionary<Type , ModelObjectBase  >  type;

    private List<Type> allTypeElement ;

    private static FactoryBuildObjectBehaviour instantiate;

    public static FactoryBuildObjectBehaviour Instantiate
    {
        get
        {
            if (instantiate == null)
            {
                instantiate = new FactoryBuildObjectBehaviour();
            }

            return instantiate;
        }
    }

    public  FactoryBuildObjectBehaviour()
    {
        Debug.Log("gameElementView.name -----");
        creteObject = new Dictionary<Type, BaseBehaviourObject>();

        creteObject.Add(typeof(BehaviourFlower) , new BehaviourFlower());
        creteObject.Add(typeof(BehaviourRabbit) , new BehaviourRabbit());
        creteObject.Add(typeof(BehaviourCat) , new BehaviourCat());

        type = new Dictionary<Type, ModelObjectBase>();

        type.Add(typeof(BehaviourCat) , new ModelCat());
        type.Add(typeof(BehaviourRabbit) ,new  ModelRabbit());
        type.Add(typeof(BehaviourFlower) , new ModelFlower());

        GetTypeElement();
    }

    public void GetTypeElement()
    {
        allTypeElement = new List<Type>();

        foreach( KeyValuePair<Type, BaseBehaviourObject> kvp in creteObject )
        {
            allTypeElement.Add(kvp.Key);
        }
    }

    public   ModelObjectBase CreteObject(Type typeObject)   
    { 
        ModelObjectBase modelObjectBase =  creteObject[typeObject].CreteObject(type[typeObject]);
       
        return modelObjectBase;
    }

    public ModelObjectBase CreateRandomObject()
    {
        int i = UnityEngine.Random.Range(0, allTypeElement.Count);
 
        return CreteObject(allTypeElement[i]);
    }

    public List<Type>  GetAllTypeElement
    {
        get{return allTypeElement;}
    }

}

