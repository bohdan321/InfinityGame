using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.UI;


public class TouchDispatcher : MonoBehaviour , IBeginDragHandler , IPointerDownHandler , IDragHandler , IEndDragHandler
{
 	
	GameObject touchObj;

	[SerializeField]
	Camera mainCamera;

	[SerializeField]
	GameElementView gameElementView;

    GameLogicController gameLogic = new GameLogicController();

    void Start()
    {
        gameElementView.GetmodelObjectBase = gameLogic.CreteRandomElement();

        gameElementView.UpdateAllElementsView();
    }

	public void OnPointerDown (PointerEventData eventData)
	{
        gameLogic.ClearContainer();

		if (eventData != null && eventData.pointerEnter != null)
		{ 
			touchObj = eventData.pointerEnter.gameObject;
		}
 	}


	public void OnBeginDrag(PointerEventData eventData) 
	{
		if (Input.GetMouseButton(0))
		{
			if ( eventData.pointerDrag != null )
			{          
 			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (Input.GetMouseButton(0) || Input.touchCount == 1)
		{
			if (touchObj != null)
			{   
				touchObj.transform.localPosition =  mainCamera.ScreenToWorldPoint(Input.mousePosition);

 			}
		}
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {   
            gameElementView.GetmodelObjectBase = gameLogic.CreteRandomElement();

            gameElementView.UpdateAllElementsView();
        }
    }

	public void OnEndDrag(PointerEventData eventData)
	{ 

        try
        {
            if(CreateBoard.instantiate.GetTileView.GetmodelObjectBase == null)
            {
                CreateBoard.instantiate.GetTileView.GetmodelObjectBase = gameElementView.GetmodelObjectBase;
                CreateBoard.instantiate.GetTileView.UpdateAllElementsView();            

                gameLogic.FindCombination(CreateBoard.instantiate.boardElement , new Vector2(7f , 7f) , CreateBoard.instantiate.GetTileView);

                touchObj = null;

                gameElementView.MoveToStartPosition();

                gameElementView.GetmodelObjectBase = gameLogic.CreteRandomElement();

                gameElementView.UpdateAllElementsView();
            }
            else
            {
                touchObj = null;

                gameElementView.MoveToStartPosition(0.15f);
            }
        }
        catch (System.IndexOutOfRangeException e)  // CS0168
        {
            gameElementView.MoveToStartPosition();
        }


	 	
	}
 
}
