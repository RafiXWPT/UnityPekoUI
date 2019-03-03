using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExpandMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler  {

	public GameObject menuToControll;

	int childCount;
	bool isOpen;
	bool isUnderControll;

	Color normalColor = new Color32(255,255,255,255);
	Color hoveredColor = new Color32(245,254,188,255);

	void Start () {
		childCount = menuToControll.transform.childCount;
		isOpen = false;
		isUnderControll = false;
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		GetComponent<Image>().color = hoveredColor;
	}
	
	public void OnPointerExit (PointerEventData eventData)
	{
		GetComponent<Image>().color = normalColor;
	}
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if(eventData.button.Equals(PointerEventData.InputButton.Left))
		{
			if(isUnderControll)
			{
				StopAllCoroutines();
				isUnderControll = false;
			}


			if (!isOpen)
				StartCoroutine("StartExpand");
			else
				StartCoroutine("StartCollapse");
		}
	}

	IEnumerator StartExpand()
	{
		isUnderControll = true;
		int heightToExpand = childCount*20 + childCount*5;
		LayoutElement menuHeight = menuToControll.GetComponent<LayoutElement>();

		while(menuHeight.preferredHeight < heightToExpand)
		{
			menuHeight.preferredHeight += 15f;
			yield return new WaitForSeconds(0.005f);
		}

		isOpen = true;
		isUnderControll = false;
		yield return null;
	}

	IEnumerator StartCollapse()
	{
		isUnderControll = true;
		LayoutElement menuHeight = menuToControll.GetComponent<LayoutElement>();
		
		while(menuHeight.preferredHeight > 0f)
		{
			menuHeight.preferredHeight -= 15f;
			yield return new WaitForSeconds(0.005f);
		}
		
		isOpen = false;
		isUnderControll = false;
		yield return null;
	}
}
