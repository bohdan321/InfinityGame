using UnityEngine;
using System.Collections;
using System.IO;


public class StrategyModificatedLevelEditor 
{
    public static FileStream CreateLevel(IStrategyModificatedLevelEditor strategy , int numberLavel)
    {
        return strategy.CreateLevel(numberLavel);
    }

    public static TextAsset LoadLevel(IStrategyModificatedLevelEditor strategy ,  int numberLavel)
    {
       return strategy.LoadLevel(numberLavel);
    }

    public static FileStream SaveLevel(IStrategyModificatedLevelEditor strategy ,  int numberLavel)
    {   
        return strategy.SaveLevel(numberLavel);
    }

    public static void DeleteLevel(IStrategyModificatedLevelEditor strategy ,  int numberLavel)
    {
        strategy.DeleteLevel(numberLavel);

    }

    public static void EditLevel(IStrategyModificatedLevelEditor strategy ,  int numberLavel)
    {
        strategy.EditLevel(numberLavel);
    }

    public static void UpdateInfo(IStrategyModificatedLevelEditor strategy)
    {
        strategy.UpdateInfo();
    }
}

