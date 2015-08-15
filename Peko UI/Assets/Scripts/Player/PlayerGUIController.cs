using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour {


	GameObject inventory;
	GameObject character;

	void Awake()
	{
		inventory = GameObject.Find("InventoryPanel");
		character = GameObject.Find("CharacterPanel");
	}

	void Start () {
		inventory.SetActive(false);
		character.SetActive(false);
		//inventory.GetComponent<CanvasGroup>().alpha = 0f;
		//inventory.GetComponent<CanvasGroup>().blocksRaycasts = false;
		//character.GetComponent<CanvasGroup>().alpha = 0f;
		//character.GetComponent<CanvasGroup>().blocksRaycasts = false;

		ContainerManager.Instance.IsInventoryOpen = false;
		ContainerManager.Instance.IsCharacterOpen = false;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.I) && !ContainerManager.Instance.IsInventoryOpen){
			ShowInventory();
		}
		else if(Input.GetKeyDown(KeyCode.I) && ContainerManager.Instance.IsInventoryOpen){
			HideInventory();
		}
		else if(Input.GetKeyDown(KeyCode.C) && !ContainerManager.Instance.IsCharacterOpen){
			ShowCharacter();
		}
		else if(Input.GetKeyDown(KeyCode.C) && ContainerManager.Instance.IsCharacterOpen){
			HideCharacter();
		}
	}

	void ShowInventory()
	{
		inventory.SetActive(true);
		//inventory.GetComponent<CanvasGroup>().alpha = 1f;
		//inventory.GetComponent<CanvasGroup>().blocksRaycasts = true;
		ContainerManager.Instance.IsInventoryOpen = true;
	}

	void HideInventory()
	{
		inventory.SetActive(false);
		//inventory.GetComponent<CanvasGroup>().alpha = 0f;
		//inventory.GetComponent<CanvasGroup>().blocksRaycasts = false;
		ContainerManager.Instance.IsInventoryOpen = false;
	}

	void ShowCharacter()
	{
		character.SetActive(true);
		//character.GetComponent<CanvasGroup>().alpha = 1f;
		//character.GetComponent<CanvasGroup>().blocksRaycasts = true;
		ContainerManager.Instance.IsCharacterOpen = true;
	}
	
	void HideCharacter()
	{
		character.SetActive(false);
		//character.GetComponent<CanvasGroup>().alpha = 0f;
		//character.GetComponent<CanvasGroup>().blocksRaycasts = false;
		ContainerManager.Instance.IsCharacterOpen = false;
	}
}
