using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour {

	void Update () {

		if(Input.GetKeyDown(KeyCode.I)){
			ContainerManager.Instance.OpenCloseInventory();
		}
		else if(Input.GetKeyDown(KeyCode.C)){
			ContainerManager.Instance.OpenCloseCharacter();
		}
		else if(Input.GetKeyDown(KeyCode.U))
		{
			ContainerManager.Instance.OpenCloseCrafting();
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ContainerManager.Instance.CloseLastPanel();
		}
	}
}
