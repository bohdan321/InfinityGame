using UnityEngine;
using System.Collections;
using System.IO;

public interface IStrategyModificatedLevelEditor  
{
    FileStream CreateLevel(int numberLavel);

    FileStream SaveLevel(int numberLavel);

    TextAsset LoadLevel(int numberLavel);

    void DeleteLevel(int numberLavel);

    void EditLevel(int numberLavel);

    void UpdateInfo();
}

