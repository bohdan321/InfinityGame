using UnityEngine;
using System.Collections;
using System;

namespace Animations
{
	public class MoveToAnimation 
	{ 

		private MonoBehaviour monoBehaviour;
		private IEnumerator   coroutineMoveTo;
		public  Action<GameObject> onFinishMoveTo;		
		
        public MoveToAnimation(Vector2 startPos, Vector2 endPos,  GameObject obj ,float speed , MonoBehaviour _monoBehaviour )
		{
			monoBehaviour = _monoBehaviour;
			StartMoveTo (startPos , endPos , obj , speed );
		}
		   
        private IEnumerator MoveTo(Vector2 startPos, Vector2 endPos, float speed , GameObject obj  )
        {    
            if(obj != null)
            { 
                speed *= 100f;

                while (Vector2.Distance( new Vector3(obj.transform.position.x , obj.transform.position.y),   endPos) >= 0.01f) 
                {     
                   obj.transform.position = iTween.Vector2Update(obj.transform.position, endPos , speed);
 
                   obj.transform.localPosition = new Vector3(obj.transform.localPosition.x  , obj.transform.localPosition.y , 0);
 
                    yield return null;
                }
                  //Debug.Log("MoveTo Finish");
            }

            if (onFinishMoveTo != null)
                onFinishMoveTo (obj);
        }          
		
        public void StartMoveTo(Vector2 startPos, Vector2 endPos, GameObject obj, float speed   )
		{ 
            coroutineMoveTo = MoveTo (startPos , endPos , speed  , obj  );
			
			if(monoBehaviour == null)
			{
				Debug.LogError("monoBehaviour == null ");
			}
			monoBehaviour.StartCoroutine (coroutineMoveTo);
		} 
		
		public void StopMoveTo()
		{
			monoBehaviour.StopCoroutine (coroutineMoveTo);
		}
	}
}
