using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class OnOpacityToCommand 
{
	private static Dictionary< GameObject , OpacityToAnimation> OpacityToCoroutine = new Dictionary< GameObject , OpacityToAnimation>();
	
	public static Dictionary<GameObject , OpacityToAnimation>  OpacityToCoroutineController
	{
		get{return OpacityToCoroutine;}
	} 
	
	public static void AddOpacityToCoroutineController( float startPos , float toPos, GameObject obj , float speed, MonoBehaviour monoBehaviour)
	{ 
		if(OpacityToCoroutine.ContainsKey(obj))
		{	
			OpacityToCoroutine[obj].StopOpacityTo();
			OpacityToCoroutine[obj].StartOpacityTo(  startPos ,   toPos,   obj ,   speed);
		}
		else
		{ 
			OpacityToCoroutine.Add(obj , new OpacityToAnimation(  startPos ,   toPos,   obj ,   speed,   monoBehaviour));		
		} 
	}
	
	
	public static void onFinishAnimation(GameObject obj , Action<GameObject> onFinishAnimation)
	{
		if(OpacityToCoroutine.ContainsKey(obj))
		{	
			if(OpacityToCoroutineController[obj].onFinishOpacityToAnimation == null)
			{
				OpacityToCoroutineController[obj].onFinishOpacityToAnimation += onFinishAnimation;
			}
			else
			{
				OpacityToCoroutineController[obj].onFinishOpacityToAnimation -= onFinishAnimation;
				OpacityToCoroutineController[obj].onFinishOpacityToAnimation += onFinishAnimation;
			}
		}
	}
	
	public static void DeleteAnimation	(GameObject obj)
	{
		if(OpacityToCoroutine.ContainsKey(obj))
		{
			OpacityToCoroutine[obj].StopOpacityTo();
			OpacityToCoroutine.Remove(obj);
		}	 
	}	
}
