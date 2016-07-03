using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileView : GameElementView 
{
    [SerializeField]
    SpriteRenderer substrate;

    Vector2 startIconPosition;

    void Start()
    {
        base.Start();

        startIconPosition = new Vector2(GetGameObjectGameElementView.gameObject.transform.position.x  , GetGameObjectGameElementView.gameObject.transform.position.y );
    }
   
    public SpriteRenderer GetSubstrate
    {
        get{return substrate;}
    }

    private int x;
    private int y;

    public Vector2 PositionElement
    {
        get{ return new Vector2(x, y);}

        set
        {
            x = (int)value.x;
            y = (int)value.y;
        }
    }

    public override void MoveToStartPosition()
    {
        GetGameObjectGameElementView.transform.position = startIconPosition;

        GetGameObjectGameElementView.transform.localPosition = new Vector3(GetGameObjectGameElementView.transform.localPosition.x  ,GetGameObjectGameElementView.transform.localPosition.y , 0);  
    }

}

 
