using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameLogicController  
{
    private List<TileView> container ;

    private List<Vector2> containerPos ;

    public GameLogicController()
    {
        container = new List<TileView>();
        containerPos = new List<Vector2>();
    }

    int startCount;
 
    public void AddElementContainer(TileView gameElement)
    {
         if (!containerPos.Contains(gameElement.PositionElement))
        {
            if (container.Count > 0 && gameElement.GetmodelObjectBase != null)
            {
                if (container[0].GetmodelObjectBase.TypeObject == gameElement.GetmodelObjectBase.TypeObject && gameElement.GetmodelObjectBase.TypeObject!= "")
                {                  
                    containerPos.Add(gameElement.PositionElement);

                    container.Add(gameElement); 
                }
            }
                
            if (container.Count == 0)
            {
                containerPos.Add(gameElement.PositionElement);
                container.Add(gameElement);
            }       
        } 
    }

    public void ClearContainer( )
    {
        container.Clear();
        containerPos.Clear();
        startCount = 0;
    }

    public void FindCombination(TileView [, ] board ,   Vector2 sizeBoard , TileView gameElement  )
    {    
       AddElementContainer(gameElement);
 
        if (gameElement.PositionElement.y > 0)
        {
             AddElementContainer( board[(int)gameElement.PositionElement.x , (int)gameElement.PositionElement.y - 1] );
        }

        if (gameElement.PositionElement.x > 0)
        {
            AddElementContainer(board[(int)gameElement.PositionElement.x - 1, (int)gameElement.PositionElement.y]);
        }

        if (gameElement.PositionElement.y < (int)sizeBoard.y - 1)
        {
            AddElementContainer( board[(int)gameElement.PositionElement.x, (int)gameElement.PositionElement.y + 1]);
        }  

        if (gameElement.PositionElement.x < (int)sizeBoard.x - 1)
        {
            AddElementContainer(board[(int)gameElement.PositionElement.x + 1, (int)gameElement.PositionElement.y] );
        }//0220

        startCount++;

        if (startCount == container.Count && container.Count  >= 3)
        {


            for (int i = 1; i < container.Count; i++)
            {
          //    UpgradeObject (CreateBoard.instantiate.boardElement[(int)container[i].PositionElement.x, (int)container[i].PositionElement.y]);
                    
                CreateBoard.instantiate.boardElement[(int)container[i].PositionElement.x, (int)container[i].PositionElement.y].GetmodelObjectBase = null;
                Debug.Log("Stop " + container.Count);

                StartMoveObject(CreateBoard.instantiate.boardElement[(int)container[i].PositionElement.x, (int)container[i].PositionElement.y] );
            }


        }
        else
        {
            if(startCount < container.Count)
            FindCombination(CreateBoard.instantiate.boardElement, new Vector2(7f, 7f), container[startCount]);
        } 
    }

    void StartMoveObject(TileView obj)
    {
        TileView tileView = CreateBoard.instantiate.boardElement[(int)container[0].PositionElement.x, (int)container[0].PositionElement.y];

        Vector2 startPos = new Vector2(obj.GetGameObjectGameElementView.transform.position.x , obj.GetGameObjectGameElementView.transform.position.y);

        Vector2 toPos = new Vector2( tileView.gameObject.transform.position.x ,  tileView.gameObject.transform.position.y);

        Animations.OnMoveToCommand.AddMoveToCoroutineController(startPos, toPos,    obj.GetGameObjectGameElementView , 0.15f , tileView.GetComponent<MonoBehaviour>() ); 

        Animations.OnMoveToCommand.onFinishAnimation(obj.GetGameObjectGameElementView , FinishDestroyObject);
    }

    void FinishDestroyObject(GameObject obj)
    {
        obj.transform.parent.gameObject.GetComponent<TileView>().GetIconElement.sprite = null;

        obj.transform.parent.gameObject.GetComponent<TileView>().MoveToStartPosition();
       
        container.Remove(obj.transform.parent.gameObject.GetComponent<TileView>());

        Animations.OnMoveToCommand.DeleteAnimation(obj);


        if (container.Count == 1)
        {
            UpgradeObject(CreateBoard.instantiate.boardElement[(int)container[0].PositionElement.x, (int)container[0].PositionElement.y]);
        }

    }

    void UpgradeObject(TileView tileView)
    {
        tileView.GetmodelObjectBase = FactoryBuildObjectBehaviour.Instantiate.CreteObject(tileView.GetmodelObjectBase.UpgradeTypeObject);

        tileView.UpdateAllElementsView();

        FindCombinationAfterUpgrades(tileView);
    }

    void FindCombinationAfterUpgrades(TileView tileView)
    {
        ClearContainer();

        FindCombination(CreateBoard.instantiate.boardElement , new Vector2(7f , 7f) ,  tileView);
    }

    public ModelObjectBase CreteRandomElement()
    {      
        ModelObjectBase modelObjectBase =  new ModelObjectBase();
        modelObjectBase = FactoryBuildObjectBehaviour.Instantiate.CreateRandomObject();
        return modelObjectBase;
    }

   
}
