using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class OnScaleToCommand   
{
 
	private static Dictionary< GameObject , ScaleToAnimation> ScaleToCoroutine = new Dictionary< GameObject , ScaleToAnimation>();
	
	public static Dictionary<GameObject , ScaleToAnimation>  ScaleToCoroutineController
	{
		get{return ScaleToCoroutine;}
	} 
 
    public static void AddScaleToCoroutineController( Vector2 startPos , Vector2 toPos, GameObject obj , float speed, MonoBehaviour monoBehaviour )
	{ 
		if(ScaleToCoroutine.ContainsKey(obj))
		{	
			ScaleToCoroutine[obj].StopScaleTo();
            ScaleToCoroutine[obj].StartScaleTo(  startPos ,   toPos,   obj ,   speed     );
		}
		else
		{ 
            ScaleToCoroutine.Add(obj , new ScaleToAnimation(  startPos ,   toPos,   obj ,   speed,   monoBehaviour      ));		
		} 
	}
 
	
	public static void onFinishAnimation(GameObject obj , Action<GameObject> onFinishAnimation)
	{
		if(ScaleToCoroutine.ContainsKey(obj))
		{	
			if(ScaleToCoroutineController[obj].onFinishScaleToAnimation == null)
			{
				ScaleToCoroutineController[obj].onFinishScaleToAnimation += onFinishAnimation;
			}
			else
			{
				ScaleToCoroutineController[obj].onFinishScaleToAnimation -= onFinishAnimation;
				ScaleToCoroutineController[obj].onFinishScaleToAnimation += onFinishAnimation;
			}
		}
	}
	
	public static void DeleteAnimation	(GameObject obj)
    {
		if(ScaleToCoroutine.ContainsKey(obj))
        {
			ScaleToCoroutine[obj].StopScaleTo();
			ScaleToCoroutine.Remove(obj);
        }	 
    } 
}
