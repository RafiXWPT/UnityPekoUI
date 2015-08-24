using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ResetInventory : MonoBehaviour, IPointerClickHandler {

	public GameObject inventory;

	public void OnPointerClick (PointerEventData eventData)
	{
		if(eventData.button.Equals(PointerEventData.InputButton.Left))
		{
			inventory.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			inventory.SetActive(false);
		}
	}
}
