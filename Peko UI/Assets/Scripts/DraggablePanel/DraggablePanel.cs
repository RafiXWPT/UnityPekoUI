using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggablePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector2 mousePos;
	Vector2 newPos;
	public GameObject toMove;

	public void OnBeginDrag(PointerEventData eventData)
	{
		mousePos = new Vector2(eventData.position.x,eventData.position.y);
		mousePos.x = mousePos.x - toMove.transform.position.x;
		mousePos.y = mousePos.y - toMove.transform.position.y;
	}

	public void OnDrag(PointerEventData eventData)
	{
		newPos = new Vector2(eventData.position.x, eventData.position.y);
		newPos.x = newPos.x - mousePos.x;
		newPos.y = newPos.y - mousePos.y;
		toMove.transform.position = newPos;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		mousePos = Vector2.zero;
		newPos = Vector2.zero;
	}
}
