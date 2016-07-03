using System.Linq;
using UnityEngine;
using UnityEditor;
using System.IO;

using System.Globalization;
using System.Collections;
using System.Collections.Generic;
 
public class GameEditorWindow : EditorWindow
{
	private int generatedLevelCols = 9;
	private int generatedLevelRows = 9;
    Vector2 scrollPos = Vector2.zero;

    CreateBoardInEditor createBoardInEditor;

	BoardSerialize boardSerialize = new BoardSerialize();	

    int lastLevelModification;

    BaseStrategyModificatedLevelEditor baseStrategyModificatedLevelEditor =   new BaseStrategyModificatedLevelEditor();

	[MenuItem("LevelEditor/Open Game Editor Window")]

	public static void OpenWindow()
	{
		GameEditorWindow window = (GameEditorWindow)EditorWindow.GetWindow(typeof(GameEditorWindow));
   	}

	public  void OnFocus()
	{
		createBoardInEditor = GameObject.Find ("Board").gameObject.GetComponent<CreateBoardInEditor> ();
 	}

    GUIStyle style;

	void OnGUI()
	{
        if(createBoardInEditor == null)
        createBoardInEditor = GameObject.Find ("Board").gameObject.GetComponent<CreateBoardInEditor> ();


        style = GUI.skin.GetStyle("label");

        style.fontSize = 18;

        style.normal.textColor = Color.black;

        style.fontStyle = FontStyle.Bold;
       
		GUILayout.Space(15);		
	 
		//GUILayout.Space(15);

        GUILayout.Label ("----------------------------------------------------------"  , style);

        GUILayout.Space(10);   

        GUILayout.Label ("Last modification №" + lastLevelModification.ToString()  , style);

        GUILayout.Label ("----------------------------------------------------------"  , style);

        if (GUILayout.Button("-------------------------------------------------------"))
        {
            // null
        }
 
        if(baseStrategyModificatedLevelEditor.getAllLevelNumber.Count == 0 )
        baseStrategyModificatedLevelEditor.UpdateInfo();

        DisplayAllLevel();
	}

    void ShowLevel(string numberLevel)
	{             
		createBoardInEditor.GetComponent<CreateBoardInEditor>().typeLevel = boardSerialize.typeLevel;

		for(int i = 0; i < boardSerialize.positionElementBoard.Count; i++ )
		{
            GameObject item = Instantiate(Resources.Load("Prefab/playboard_square")) as GameObject;


			item.transform.parent = createBoardInEditor.Board.transform;
			item.transform.localScale = Vector3.one;
			item.transform.position = boardSerialize.positionElementBoard[i];
			item.AddComponent<BoardPieceEditor>().typeCellBoard = boardSerialize.typeCellBoard[i]; 

            if( boardSerialize.typeCellBoard[i] == SettingBoard.TypeCellBoard.empty)
			{
				item.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
			}
		} 
	} 


    void GenerateLevel()
    {
		if (createBoardInEditor.Board.transform.childCount > 0)
		{
			createBoardInEditor.ClearBoard();
		}
		{
			createBoardInEditor.CreteBoard(9, 9);
		}
    } 

    void DisplayAllLevel() 
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, true, true, GUILayout.Width(this.position.width), GUILayout.Height(this.position.height - 300));

        if (baseStrategyModificatedLevelEditor.Level != null)
        {
            for (int i = 0; i < baseStrategyModificatedLevelEditor.Level.Length; i++)
            {           
                GUILayout.Space(15);

                GUILayout.Label("------------------------------------------------------------------", style);

                GUILayout.Label("Level  №" + baseStrategyModificatedLevelEditor.getAllLevelNumber[i], style);

                GUILayout.BeginVertical();

                GUILayout.Space(10);

                GUILayout.BeginHorizontal();

                GUILayout.Space(10);          
 
                GUILayout.Space(10);   

                if (GUILayout.Button("Load level", EditorStyles.toolbarButton, GUILayout.Height(20), GUILayout.Width(150)))
                {
                    lastLevelModification = i + 1;
                      
                    boardSerialize = Serializator.DeXml(new BaseStrategyModificatedLevelEditor() , i);

                    ShowLevel("");
                }

                GUILayout.Space(10);   

                if (GUILayout.Button("Save level", EditorStyles.toolbarButton, GUILayout.Height(20), GUILayout.Width(150)))
                {
            
                    boardSerialize.SaveSettingBoard(createBoardInEditor.gameObject); 

                    Serializator.SaveXml( boardSerialize, new BaseStrategyModificatedLevelEditor(),  i);

                    baseStrategyModificatedLevelEditor.UpdateInfo();


                    //SaveLevel
                }

                GUILayout.Space(10);   

                if (GUILayout.Button("Add level", EditorStyles.toolbarButton, GUILayout.Height(20), GUILayout.Width(150)))
                { 
                    GenerateLevel();

                    boardSerialize.SaveSettingBoard(createBoardInEditor.gameObject); 
 
                    Serializator.AddNewXml( boardSerialize, new BaseStrategyModificatedLevelEditor(),  i);

                    baseStrategyModificatedLevelEditor.UpdateInfo();

                }

                GUILayout.Space(10);   

                if (GUILayout.Button("Remove level", EditorStyles.toolbarButton, GUILayout.Height(20), GUILayout.Width(150)))
                {           
                    StrategyModificatedLevelEditor.DeleteLevel(baseStrategyModificatedLevelEditor, i);   

                    baseStrategyModificatedLevelEditor.UpdateInfo();
                }
     
                GUILayout.EndVertical();

                GUILayout.EndHorizontal();

                GUILayout.Label("------------------------------------------------------------------", style);
            }           
        }

        EditorGUILayout.EndScrollView();

        BaseButton();
    }


    void BaseButton()
    {
        GUILayout.Space(15);

        GUILayout.BeginHorizontal();

        GUILayout.Space(10);   

        if (GUILayout.Button("Clear Board", EditorStyles.toolbarButton, GUILayout.Height(20), GUILayout.Width(150)))
        {
            createBoardInEditor.ClearBoard();
        }

        GUILayout.Space(15); 

        if (GUILayout.Button("Add new level", EditorStyles.toolbarButton, GUILayout.Height(20), GUILayout.Width(150)))            
        {
            GenerateLevel();

            boardSerialize.SaveSettingBoard(createBoardInEditor.gameObject); 

            Serializator.AddNewXml( boardSerialize, new BaseStrategyModificatedLevelEditor(),  baseStrategyModificatedLevelEditor.Level.Length);

            baseStrategyModificatedLevelEditor.UpdateInfo();
        }

        GUILayout.Space(15);

        if (GUILayout.Button("Load all level", EditorStyles.toolbarButton, GUILayout.Height(20), GUILayout.Width(150)))
        {
            baseStrategyModificatedLevelEditor.UpdateInfo();
        }  

        GUILayout.EndHorizontal();
    }
 
}
 



