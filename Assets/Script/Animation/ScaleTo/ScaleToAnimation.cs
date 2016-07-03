using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class ScaleToAnimation  
{
	public Action<GameObject> onFinishScaleToAnimation;
	
	private MonoBehaviour monoBehaviour;
	private IEnumerator   coroutineScale;

	float startTime;
	float journeyLength;
	
	float distCovered ;
	float fracJourney ;

 
    public ScaleToAnimation(Vector2 startPos   , Vector2 toPos, GameObject obj , float speed , MonoBehaviour _monoBehaviour )
	{
		monoBehaviour = _monoBehaviour;
        StartScaleTo (startPos , toPos   , obj , speed );
	}

	
	/*private IEnumerator ScaleTo(Vector2 startPos   , Vector2 toPos, GameObject obj , float speed ) 
	{  

		if(obj != null)
		{
			while (Vector3.Distance( startPos,   toPos) >= 0f) 
			{ 
				startPos = Vector3.Lerp (startPos, toPos, Time.deltaTime * speed);
				
				if(obj != null)
				{
                    obj.transform.localScale = new Vector3 (startPos.x , startPos.y , 1f);
 				}
				yield return null;
			}
		}
		
		if (onFinishScaleToAnimation != null)
			onFinishScaleToAnimation ();


		yield return true; 
	}*/
 

    private IEnumerator ScaleTo(Vector2 startPos, Vector2 endPos,  GameObject obj , float speed )
    {    
        if(obj != null)
        { 
            speed *=  100f; 
 
            while (Vector2.Distance( new Vector2(obj.GetComponent<RectTransform>().sizeDelta.x , obj.GetComponent<RectTransform>().sizeDelta.y),   endPos) >= 0.05f) 
            {          
                obj.GetComponent<RectTransform>().sizeDelta = iTween.Vector2Update(obj.GetComponent<RectTransform>().sizeDelta, endPos,   speed );

                 //obj.transform.localPosition = new Vector3(obj.transform.localPosition.x  , obj.transform.localPosition.y , 0); 
                yield return null;
            }

            //Debug.Log("MoveTo Finish");
        }

        if (onFinishScaleToAnimation != null)
            onFinishScaleToAnimation ( obj);
    } 
	
    public void StartScaleTo(Vector2 startPos   , Vector2 toPos, GameObject obj , float speed   )
	{	
        coroutineScale = ScaleTo (  startPos ,   toPos,   obj ,  speed);
		monoBehaviour.StartCoroutine (coroutineScale);
	}
	
	public void StopScaleTo()
	{
		monoBehaviour.StopCoroutine (coroutineScale);
	}
	
	
	public IEnumerator CoroutineScale
	{
		get{return coroutineScale;}
	}
 
}
