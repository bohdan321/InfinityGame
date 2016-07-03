using UnityEngine;
using System.Collections;
using System;

public class GameElementView : MonoBehaviour
{
	[SerializeField]
	SpriteRenderer iconElement;

    private Vector2 startPosition;

    public void Start()
    {   
        startPosition = gameObject.transform.position;
    }

    private ModelObjectBase modelObjectBase;  
 
    public void UpdateAllElementsView()
    {
        string path = String.Format("Items/{0}" , modelObjectBase.NameObject);
  
        iconElement.sprite = Resources.Load<Sprite>(path);

        this.modelObjectBase =  modelObjectBase;
    }

    public SpriteRenderer GetIconElement
    {
        get{return iconElement;}
    }

    public  ModelObjectBase GetmodelObjectBase
    {
        get{ return modelObjectBase;}
        set{modelObjectBase = value;}
    }

    public virtual void MoveToStartPosition()
    {
        gameObject.transform.position = startPosition;

        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x  ,gameObject.transform.localPosition.y , 0);  
    }

    public void MoveToStartPosition(float speed)
    {
        Animations.OnMoveToCommand.AddMoveToCoroutineController(new Vector2(gameObject.transform.position.x  ,gameObject.transform.position.y) , startPosition , 
            gameObject , speed , this);
    }

    public GameObject GetGameObjectGameElementView
    {
        get{ return iconElement.gameObject;}
    }
}
