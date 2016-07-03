using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardPieceEditor) ), CanEditMultipleObjects]
public class BoardPieceCustomEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		var boardPieceEditor = target as BoardPieceEditor;


		if (GUILayout.Button("Repaint"))
		{
            boardPieceEditor.Repair( );

  		}

 



        /*if (GUILayout.Button("Destroy"))
		{
            
 		}*/
	}





}

[CustomEditor(typeof(BoardGameElementEditor) ), CanEditMultipleObjects]

public class BoardGameElementCustomEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		var boardGameElementEditor = target as BoardGameElementEditor;

		if (GUILayout.Button("Repaint"))
		{

			boardGameElementEditor.Repair();
		}

		/*if (GUILayout.Button("Destroy"))
		{
            
 		}*/
	}
}
    