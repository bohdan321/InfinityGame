using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Animations
{
	public static class OnMoveToCommand 
	{
		private static Dictionary<GameObject , MoveToAnimation> MoveToCoroutine = new Dictionary< GameObject , MoveToAnimation>();
		
		public static Dictionary<GameObject , MoveToAnimation>  MoveToCoroutineController { get { return MoveToCoroutine; } } 
		public static bool IsCoRoutines { get { return MoveToCoroutine.Count == 0; } }
		
        public static void AddMoveToCoroutineController( Vector2 startPos , Vector2 toPos, GameObject obj , float speed, MonoBehaviour monoBehaviour   )
		{ 
			if(MoveToCoroutine.ContainsKey(obj))
			{	
				MoveToCoroutine[obj].StopMoveTo();

                DeleteAnimation(obj);

                MoveToCoroutine.Add(obj , new MoveToAnimation(  startPos ,   toPos,   obj ,   speed,   monoBehaviour  ));      
				//MoveToCoroutine[obj].StartMoveTo(  startPos ,   toPos,   obj ,   speed , type);
			}
			else
			{ 
				MoveToCoroutine.Add(obj , new MoveToAnimation(  startPos ,   toPos,   obj ,   speed,   monoBehaviour  ));		
			} 
        }
        	
		
		public static void onFinishAnimation(GameObject obj , Action<GameObject> onFinishAnimation)
		{
            if(MoveToCoroutine.ContainsKey(obj))
			{	
				if(MoveToCoroutineController[obj].onFinishMoveTo == null)
				{
					MoveToCoroutineController[obj].onFinishMoveTo += onFinishAnimation;
				}
				else
				{
					MoveToCoroutineController[obj].onFinishMoveTo -= onFinishAnimation;
					MoveToCoroutineController[obj].onFinishMoveTo += onFinishAnimation;
				}
 			}
		}
		
		public static void DeleteAnimation	(GameObject obj)
		{
			if(MoveToCoroutine.ContainsKey(obj))
			{
				MoveToCoroutine[obj].StopMoveTo();
				MoveToCoroutine.Remove(obj);
			}	 
		}
	}
}
