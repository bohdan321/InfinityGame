using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class OpacityToAnimation  
{
    public Action<GameObject> onFinishOpacityToAnimation;
	
	private MonoBehaviour monoBehaviour;
	private IEnumerator   coroutineOpacity;
	
	float startTime;
	float journeyLength;
	
	float distCovered ;
	float fracJourney ;
	
	
	public OpacityToAnimation(float startPos   , float toPos, GameObject obj , float speed , MonoBehaviour _monoBehaviour)
	{
		monoBehaviour = _monoBehaviour;
		StartOpacityTo (startPos , toPos   , obj , speed);
	}
	
	
	private IEnumerator OpacityTo(float startPos   , float toPos, GameObject obj , float speed ) 
	{  

		CanvasGroup cg = obj.GetComponent<CanvasGroup> ();

		if(obj != null)
		{
 
			while (Math.Sqrt(( startPos    - toPos ) * ( startPos    - toPos )) >= 0.01f) 
			{ 
				startPos = Mathf.Lerp (startPos, toPos, Time.deltaTime * speed);
					
				if(obj != null)
				{
					cg.alpha = startPos;
				}

				yield return null;
			}
		}
		
		if (onFinishOpacityToAnimation != null)
            onFinishOpacityToAnimation (obj);
		
		
		yield return true; 
	}
	
	
	public void StartOpacityTo(float startPos   , float toPos, GameObject obj , float speed)
	{	
		coroutineOpacity = OpacityTo (  startPos ,   toPos,   obj ,   speed);
		monoBehaviour.StartCoroutine (coroutineOpacity);
	}
	
	public void StopOpacityTo()
	{
		monoBehaviour.StopCoroutine (coroutineOpacity);
	}
	
	
	public IEnumerator CoroutineOpacity
	{
		get{return coroutineOpacity;}
	}
}
