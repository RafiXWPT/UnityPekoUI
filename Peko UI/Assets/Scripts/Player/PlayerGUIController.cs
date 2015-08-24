using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour {

	void Start () {

	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.I)){
			ContainerManager.Instance.OpenCloseInventory();
		}
		else if(Input.GetKeyDown(KeyCode.C)){
			ContainerManager.Instance.OpenCloseCharacter();
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ContainerManager.Instance.CloseLastPanel();
		}

	}
}
