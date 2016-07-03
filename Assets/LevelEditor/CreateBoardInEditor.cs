using UnityEngine;
using System;
using System.Collections.Generic;
 
public class CreateBoardInEditor : MonoBehaviour
{

	[SerializeField]
    public SettingBoard.TypeLevel typeLevel;

	List<GameObject> gameElements = new List<GameObject> (); 

	[SerializeField]
	private GameObject substrate;

 	private GameObject board;
	
	public void CreteBoard(int rows , int cols)
	{
		Vector2 startPosition = Vector2.one;

		float delta = -0.52f;

		if(rows%2 == 0)
		{
			startPosition = new Vector2 ((rows/2 * delta) - delta/2f , 3);
		}
		else
		{
			startPosition = new Vector2 ((rows/2 * delta)   , 3);
		}

		for(int i = 0; i < rows; i++)
		{
			for(int j = 0; j < cols; j++)
			{
				GameObject substrate = Instantiate(this.substrate) as GameObject;
				substrate.transform.parent = transform.transform;
				substrate.transform.localScale =  Vector3.one;

				substrate.transform.localPosition = new Vector2(startPosition.x  -  i *  delta  ,  startPosition.y + j * delta);

				substrate.AddComponent<BoardPieceEditor>();
			}
		}
     
	}


	public void ClearBoard()
	{
		while (transform.childCount > 0)
		{
			DestroyImmediate(transform.GetChild(0).gameObject);
		}
	}	
 
	public GameObject Board
	{
		get{return gameObject;}
	}


}

