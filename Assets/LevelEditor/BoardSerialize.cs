using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization; 
using System.IO; 
using System;

public class BoardSerialize 
{ 	
    
 	[XmlArray("BoardPieceEditor")]

 	[XmlArrayItem("BoardPosition")]
	public List<Vector2> positionElementBoard = new List<Vector2>();  

	[XmlArrayItem("TypeBarrier")]
    public List<SettingBoard.TypeCellBoard> typeCellBoard = new List<SettingBoard.TypeCellBoard>();

	[XmlArrayItem("TypeLevel")]
    public SettingBoard.TypeLevel typeLevel;

	public BoardSerialize() { }   
	
	public void SaveSettingBoard(GameObject board) 
    {	
        positionElementBoard.Clear();
        typeCellBoard.Clear();
        
		foreach(Transform t in board.transform)
		{
			Vector2 posEl = new Vector2();
			posEl = t.transform.position;
			positionElementBoard.Add(posEl);

            SettingBoard.TypeCellBoard tb = t.gameObject.GetComponent<BoardPieceEditor>().typeCellBoard;
			typeCellBoard.Add(tb);
  		}
	}  

	public void SettingBoard(CreateBoardInEditor boardEditor)
	{
		// typeLevel =  boardEditor.typeLevel;
	}
}


