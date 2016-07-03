using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

    public class LoadSaveLevels
{
   /* static string [] getLevel;

    public static string [] Level
    {
        get{return getLevel;}
        set{getLevel = value;}
    }

    public static void GetAllLevel()
    {
        Level = Directory.GetFiles(@"Assets/Prefabs", "*.xml"); 
    }

    public static FileStream AddNewLevel()
    {
        GetAllLevel();

        FileStream fs = null;   

        if (getLevel == null || getLevel.Length == 0)
        {

            fs = new FileStream("Assets/Prefabs/" + "Level_1" + ".xml", FileMode.Create); 
        }
        else
        {
            fs = new FileStream("Assets/Prefabs/" + "Level_" + (getLevel.Length + 1).ToString() + ".xml", FileMode.Create); 
        }

        LoadSaveLevels.GetAllLevel();

        return fs;
    }

    public static FileStream AddNewLevel(string numberLevel)
    {
        GetAllLevel();

        FileStream fs = null;   

        for (int i = int.Parse(numberLevel) + 1; i < getLevel.Length; i++)
        {
            Debug.Log(getLevel[i] + " " +  (i + 1).ToString());

            File.Move( getLevel[i]  , @"Assets/Prefabs/" + "Level_" +  (i + 1).ToString()   + ".xml");
        }
      
        fs = new FileStream("Assets/Prefabs/" + "Level_" + (int.Parse(numberLevel) + 2).ToString() + ".xml", FileMode.Create); 

        LoadSaveLevels.GetAllLevel();

        return fs;
    }

    public static void DeleteLevel(string numberLevel)
    {
        File.Delete("Assets/Prefabs/" + "Level_" + numberLevel + ".xml");

        LoadSaveLevels.GetAllLevel();

        for (int i = 0; i < getLevel.Length; i++)
        {
            File.Move( getLevel[i]  , @"Assets/Prefabs/" + "Level_" +  (i + 1).ToString()   + ".xml");
        }
    }
        
    public static FileStream EditLevel(int numberLevel)
    {
        FileStream fs = null;   

        fs = new FileStream("Assets/Prefabs/" + "Level_" + (numberLevel + 1).ToString() + ".xml", FileMode.Create); 

        return fs;                
    }*/
        
}

