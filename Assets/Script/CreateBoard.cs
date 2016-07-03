using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateBoard : MonoBehaviour 
{

	[SerializeField]
	GameObject substrate;
	 
	[SerializeField]
	  int rows ;

	[SerializeField]
	  int cols;
 
	[SerializeField]
	  float delta = -0.52f;

	private int x;

	private int y;
 
	List<GameObject> allBoardElement = new List<GameObject>();

	public TileView [,] boardElement; 

	public static CreateBoard instantiate;

    public Camera mainCamera;

	void Awake()
	{
		instantiate = this;
	}

    void Start()
    {
        substrate.SetActive(false);
        CreteBoard(  rows , cols);
    }


	public void CreteBoard(int rows , int cols)
	{
		boardElement = new TileView[rows , rows];

		Vector2 startPosition = Vector2.one;
		float delta = this.delta;

		if(rows%2 == 0)
		{
			startPosition = new Vector2 ((rows/2 * delta) - delta/2f , 1.9f);
		}
		else
		{
			startPosition = new Vector2 ((rows/2 * delta)   , 1.9f);
		}

		foreach (GameObject t in allBoardElement)
		{
			Destroy(t);
		}

		allBoardElement.Clear();

		for(int i = 0; i < rows; i++)
		{
			for(int j = 0; j < cols; j++)
			{
				GameObject substrate = Instantiate(this.substrate) as GameObject;
				substrate.transform.parent = transform.transform;
				substrate.transform.localScale =  Vector3.one;


				//switch (SettingBoard.TypeCellBoard)
				{
				//	case SettingBoard.TypeCellBoard.busy:
						
						TileView t = substrate.GetComponent<TileView>();

						t.PositionElement = new Vector2(i , j);


						substrate.transform.localPosition = new Vector2(startPosition.x  -  i *  delta  ,  startPosition.y + j * delta);
						substrate.SetActive(true);

						allBoardElement.Add(substrate);

						boardElement[i, j] = substrate.GetComponent<TileView>();
				}


              /*  TileView t = substrate.GetComponent<TileView>();

                t.PositionElement = new Vector2(i , j);


				substrate.transform.localPosition = new Vector2(startPosition.x  -  i *  delta  ,  startPosition.y + j * delta);
				substrate.SetActive(true);

				allBoardElement.Add(substrate);

                boardElement[i, j] = substrate.GetComponent<TileView>();*/

 			}
		}	
	}


	public void ShowLevel(string numberLevel ,  BoardSerialize boardSerialize)
	{             

		for(int i = 0; i < boardSerialize.positionElementBoard.Count; i++ )
		{
			GameObject item = Instantiate(Resources.Load("Prefab/playboard_square")) as GameObject;


			item.transform.parent = gameObject.transform;
			item.transform.localScale = Vector3.one;
			item.transform.position = boardSerialize.positionElementBoard[i];
			item.AddComponent<BoardPieceEditor>().typeCellBoard = boardSerialize.typeCellBoard[i]; 



			if( boardSerialize.typeCellBoard[i] == SettingBoard.TypeCellBoard.empty)
			{
				item.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.1f);
			}
		} 
	} 

 
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			//CreteBoard(  rows , cols);
		}

        x =	  (int)(((mainCamera.ScreenToWorldPoint(Input.mousePosition).x + 1.74f ) + 0.29f)*10f / 5.8f)   ;

        y =  - (int)(((mainCamera.ScreenToWorldPoint(Input.mousePosition).y - 1.9f ) - 0.29f)*10f / 5.8f)  ;
	}

 	
	public TileView GetTileView
	{		
		get{return boardElement[x, y].gameObject.GetComponent<TileView>();}
	}
 
}
