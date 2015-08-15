using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterEquipmentSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler {

	public ItemType equipmentPart;
	public Sprite backgroundImage;

	Item item;
	public Item Item {
		get {
			return item;
		}
		set {
			item = value;
		}
	}
	
	Color normalColor = new Color32(131,131,131,255);
	Color hoveredColor = new Color32(245,254,188,255);
	Color canPlaceColor = new Color32(170,246,170,255);
	Color cantPlaceColor = new Color32(246,170,170,255);
	Color draggedColor = new Color32(111,111,111,255);

	bool isHover;
	bool isDragging;

	Image icon;
	
	void Start () {
		item = new Item();
		icon = transform.GetChild(0).GetComponent<Image>();
		icon.sprite = backgroundImage;
	}

	void Update () {
		if(isHover && !ContainerManager.Instance.IsDragging)
		{
			GetComponent<Image>().color = hoveredColor;
		}

		if(this.item.ItemType == ItemType.NULL)
		{
			icon.sprite = backgroundImage;
		}
		else
		{
			icon.sprite = this.item.ItemIcon;
		}
		
		if(isDragging)
		{
			icon.color = draggedColor;
			this.GetComponent<Image>().color = draggedColor;
		}
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		isHover = true;
		if(ContainerManager.Instance.IsDragging && (ContainerManager.Instance.DraggingItem.ItemType == ItemType.ONEHAND_WEAPON || ContainerManager.Instance.DraggingItem.ItemType == ItemType.TWOHAND_WEAPON) && this.equipmentPart == ItemType.WEAPON)
		{
			GetComponent<Image>().color = canPlaceColor;
		}
		else if(ContainerManager.Instance.IsDragging && ContainerManager.Instance.DraggingItem.ItemType == this.equipmentPart)
		{
			GetComponent<Image>().color = canPlaceColor;
		}
		else if(ContainerManager.Instance.IsDragging && ContainerManager.Instance.DraggingItem.ItemType != this.equipmentPart)
		{
			GetComponent<Image>().color = cantPlaceColor;
		}
		else if (!ContainerManager.Instance.IsDragging)
		{
			GetComponent<Image>().color = hoveredColor;
		}

		if(this.item.ItemType != ItemType.NULL && !ContainerManager.Instance.IsDragging)
			ContainerManager.Instance.ShowToolTip(this.item, this.transform.position);
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		isHover = false;
		this.GetComponent<Image>().color = normalColor;
		ContainerManager.Instance.HideToolTip();
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		return;
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if(!eventData.button.Equals(PointerEventData.InputButton.Left))
			return;
		
		if(this.item.ItemType == ItemType.NULL)
			return;
		else
		{
			ContainerManager.Instance.DraggingItem = this.item;
			ContainerManager.Instance.IsDragging = true;
			isDragging = true;
		}
	}

	public void OnDrag (PointerEventData eventData)
	{
		if(this.item.ItemType == ItemType.NULL)
			return;
		
		if(eventData.button.Equals(PointerEventData.InputButton.Left))
			ContainerManager.Instance.ShowHoldingItemIcon(eventData.position);
	}

	
	public void OnEndDrag (PointerEventData eventData)
	{
		if(!eventData.button.Equals(PointerEventData.InputButton.Left))
			return;
		
		if(this.item.ItemType == ItemType.NULL)
			return;
		
		ContainerManager.Instance.IsDragging = false;
		ContainerManager.Instance.HideHoldingItemIcon();
		isDragging = false;

		icon.color = new Color32(255,255,255,255);
		this.GetComponent<Image>().color = normalColor;

		if(eventData.pointerEnter != null && eventData.pointerEnter.tag == "ContainerSlot")
		{
			ContainerManager.Instance.UnWearItem(this, eventData.pointerEnter.GetComponent<ContainerSlot>());
			ContainerManager.Instance.DraggingItem = null;
		}
		else if(eventData.pointerEnter != null && eventData.pointerEnter.tag == "HotKeyBarSlot")
		{
			eventData.pointerEnter.GetComponent<HotKeyBarSlot>().Item = ContainerManager.Instance.DraggingItem;
			ContainerManager.Instance.DraggingItem = null;
		}

	}

}
