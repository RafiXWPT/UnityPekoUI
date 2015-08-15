using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotKeyBarSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler {

	public int id;
	Item item;

	public Item Item {
		get {
			return item;
		}
		set {
			item = value;
		}
	}

	Color normalColor = new Color32(255,255,255,255);
	Color hoveredColor = new Color32(245,254,188,255);
	Color draggedColor = new Color32(111,111,111,255);

	bool isDragging;

	Image icon;
	Text amount;

	void Awake()
	{
		icon = transform.GetChild(0).GetComponent<Image>();
		amount = transform.GetChild(1).GetComponent<Text>();
	}
	
	void Start () {
		this.item = new Item();
		icon.enabled = false;
		amount.enabled = false;
	}

	void Update () {
		if(this.item.ItemAmount < 1)
			this.item = new Item();

		if(this.item.ItemType == ItemType.NULL)
		{
			icon.enabled = false;
			amount.enabled = false;
		}
		else
		{
			icon.sprite = this.item.ItemIcon;
			if(this.item.ItemAmount > 1)
			{
				amount.text = this.item.ItemAmount.ToString();
				amount.enabled = true;
			}
			else
			{
				amount.enabled = false;
			}
			icon.enabled = true;
		}

		if(isDragging)
		{
			icon.color = draggedColor;
			GetComponent<Image>().color = draggedColor;
		}
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		GetComponent<Image>().color = hoveredColor;
		if(this.item.ItemType != ItemType.NULL && !ContainerManager.Instance.IsDragging)
			ContainerManager.Instance.ShowToolTip(this.item, this.transform.position);
	}
	
	public void OnPointerExit (PointerEventData eventData)
	{
		GetComponent<Image>().color = normalColor;
		ContainerManager.Instance.HideToolTip();
	}
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if(eventData.button.Equals(PointerEventData.InputButton.Right) && this.Item.ItemType != ItemType.NULL)
		{
			this.item.Use(null);
			Debug.Log(this.item.ItemAmount);
			if(this.item.ItemAmount < 1)
			{
				ContainerManager.Instance.HideToolTip();
				this.item = new Item();
			}
		}
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
		
		icon.color = normalColor;
		GetComponent<Image>().color = normalColor;

		if(eventData.pointerEnter != null && eventData.pointerEnter.tag == "HotKeyBarSlot")
		{
			if(eventData.pointerEnter.GetComponent<HotKeyBarSlot>().item.ItemType == ItemType.NULL)
			{
				eventData.pointerEnter.GetComponent<HotKeyBarSlot>().item = this.item;
				this.item = new Item();
			}
			else
			{
				Item tmpItem = this.item;
				this.item = eventData.pointerEnter.GetComponent<HotKeyBarSlot>().item;
				eventData.pointerEnter.GetComponent<HotKeyBarSlot>().item = tmpItem;
			}
			ContainerManager.Instance.DraggingItem = null;
		}
		else if(eventData.pointerEnter == null)
		{
			this.item = new Item();
		}
	}
}
