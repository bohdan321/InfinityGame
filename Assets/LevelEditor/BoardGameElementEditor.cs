using UnityEngine;
using System.Collections;
using System;

#if UNITY_EDITOR
using UnityEditor;
[Serializable]
#endif

public class BoardGameElementEditor : MonoBehaviour
{
	[SerializeField]
	public SettingBoard.TypeGameElement typeGameElement;

	private string path = "Items/"; 

	public void Repair( )
	{
		#if UNITY_EDITOR
		switch(typeGameElement)
		{
			case  SettingBoard.TypeGameElement.Flower:

				gameObject.transform.Find("GameElement").gameObject.GetComponent<SpriteRenderer>().sprite = 

					Resources.Load<Sprite>( path + SettingBoard.TypeGameElement.Flower.ToString());

				SceneView.RepaintAll();

				break;

			case  SettingBoard.TypeGameElement.Rabbit:

				gameObject.transform.Find("GameElement").gameObject.GetComponent<SpriteRenderer>().sprite = 

					Resources.Load<Sprite>( path + SettingBoard.TypeGameElement.Rabbit.ToString());
				SceneView.RepaintAll();

				break;

			case  SettingBoard.TypeGameElement.Cat:

				gameObject.transform.Find("GameElement").gameObject.GetComponent<SpriteRenderer>().sprite = 

					Resources.Load<Sprite>( path + SettingBoard.TypeGameElement.Cat.ToString());

				SceneView.RepaintAll();

				break;

		}
		#endif
	}
}

