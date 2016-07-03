using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class BaseStrategyModificatedLevelEditor : IStrategyModificatedLevelEditor
{
    string [] getLevel;

    private const string pathToLevel = "Assets/Resources/Prefabs/";

    public   string [] Level
    {
        get{return getLevel;}
        set{getLevel = value;}
    }

    public Dictionary<int , string> getAllLevelNumber = new Dictionary<int , string>();

    string nameFile = "Level_";

    void GetAllLevel()
    {
        Level = Directory.GetFiles(@"Assets/Resources/Prefabs", "*.xml"); 

		Debug.Log("Level all count "  + Level.Length);

        int [] index = new int[Level.Length]; 

        getAllLevelNumber.Clear();

        string s = "";
 
        for(int i = 0; i < Level.Length; i++)
        {
            s = ""; 

            for(int j = pathToLevel.Length  + nameFile.Length;  j < Level[i].Length; j++)
            {
                if (Level[i][j] == '.')
                {
                    index[i] = int.Parse(s);

                    getAllLevelNumber.Add(index[i] - 1  , Level[i]);
                    break;
                }

                s += Level[i][j];
            }     
        }  
 
     }

    public  void UpdateInfo()
    {
        GetAllLevel();
    }

    public FileStream CreateLevel(int numberLevel )
    {

        GetAllLevel();

        int i = getLevel.Length - 1;

        FileStream fs = null;  

        if (numberLevel == getLevel.Length)
        {                
            fs = new FileStream(pathToLevel + "Level_" + (numberLevel + 1).ToString() + ".xml", FileMode.Create);  
        }
        else
        {
            while ( i > numberLevel)
            { 
                File.Move(getAllLevelNumber[i], @"Assets/Resources/Prefabs/" + "Level_" + (i + 2).ToString() + ".xml");

                i--;
            }

            fs = new FileStream(pathToLevel + "Level_" + (numberLevel + 2).ToString() + ".xml", FileMode.Create); 
         }       
            
        return fs;
    }
 
    public TextAsset LoadLevel(int numberLevel )
    {
        TextAsset textAsset = (TextAsset) Resources.Load("Prefabs/" + "Level_" +  (numberLevel + 1).ToString());

        return textAsset; 
    }
     

    public FileStream SaveLevel(int numberLevel )
    {
        FileStream fs = null; 

        fs = new FileStream(pathToLevel + "Level_" + (numberLevel + 1).ToString() + ".xml", FileMode.Create , FileAccess.Write);

        return fs;  
    }

    public   void DeleteLevel(int numberLavel)
    {
        GetAllLevel();

        File.Delete( getAllLevelNumber[numberLavel].ToString() );

        for (int i = numberLavel + 1; i < getLevel.Length; i++)
        {
            File.Move( getAllLevelNumber[i]  , @"Assets/Resources/Prefabs/" + "Level_" +  (i).ToString()   + ".xml");
        }
    }

    public   void EditLevel( int numberLavel)
    {
 
    }
}

