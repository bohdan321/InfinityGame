using UnityEngine;
using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
[Serializable]
#endif

public class BoardPieceEditor : MonoBehaviour 
{
    [SerializeField]
    public SettingBoard.TypeCellBoard typeCellBoard;


	public void Repair( )
	{
		#if UNITY_EDITOR
		switch(typeCellBoard)
		{
        	//typeCellBoard = SettingBoard.TypeCellBoard.empty;
			case  SettingBoard.TypeCellBoard.empty:
				
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
			SceneView.RepaintAll();

				break;
			
			case  SettingBoard.TypeCellBoard.busy:
				
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
				SceneView.RepaintAll();

				break;
		}
 		#endif
	}


}


