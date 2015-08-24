using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContainerSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler  {

	public int id;

	Container container;
	public Container Container {
		get {
			return container;
		}
		set {
			container = value;
		}
	}

	Image icon;
	Text amount;

	Color normalColor = new Color32(255,255,255,255);
	Color hoveredColor = new Color32(245,254,188,255);
	Color draggedColor = new Color32(111,111,111,255);

	bool isDragging;

	void Awake()
	{
		icon = transform.GetChild(0).GetComponent<Image>();
		amount = GetComponentInChildren<Text>();
	}
	
	void Start () {
		container = this.transform.parent.GetComponent<Container>();
		icon.enabled = false;
		amount.enabled = false;
	}

	void Update () {
		if(container.containerItems[id].ItemAmount < 1)
			container.containerItems[id] = new Item();

		if(container.containerItems[id].ItemType == ItemType.NULL)
		{
			icon.enabled = false;
			amount.enabled = false;
		}
		else
		{
			icon.sprite = container.containerItems[id].ItemIcon;
			if(container.containerItems[id].ItemAmount > 1)
			{
				amount.text = container.containerItems[id].ItemAmount.ToString();
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
		if(container.containerItems[id].ItemType != ItemType.NULL && !ContainerManager.Instance.IsDragging)
			ContainerManager.Instance.ShowToolTip(container.containerItems[id], this.transform.position);
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		GetComponent<Image>().color = normalColor;
		ContainerManager.Instance.HideToolTip();
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		Item clicked = container.containerItems[id];
		if(clicked.ItemType == ItemType.NULL)
			return;

		if(eventData.button.Equals(PointerEventData.InputButton.Right))
		{
			clicked.Use(this);
			if(clicked.ItemAmount < 1)
			{
				ContainerManager.Instance.HideToolTip();
				container.containerItems[id] = new Item();
			}
		}
		else if(eventData.button.Equals(PointerEventData.InputButton.Left) && Input.GetKey(KeyCode.LeftShift)  && clicked.IsStackable)
		{
			Debug.Log("splitStack");
			//TODO
		}
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if(!eventData.button.Equals(PointerEventData.InputButton.Left))
			return;

		if(container.containerItems[id].ItemType == ItemType.NULL)
			return;
		else
		{
			ContainerManager.Instance.DraggingItem = container.containerItems[id];
			ContainerManager.Instance.IsDragging = true;
			isDragging = true;
		}
	}
	
	public void OnDrag (PointerEventData eventData)
	{
		if(container.containerItems[id].ItemType == ItemType.NULL)
			return;

		if(eventData.button.Equals(PointerEventData.InputButton.Left))
			ContainerManager.Instance.ShowHoldingItemIcon(eventData.position);
	}
	
	public void OnEndDrag (PointerEventData eventData)
	{
		if(!eventData.button.Equals(PointerEventData.InputButton.Left))
			return;

		if(container.containerItems[id].ItemType == ItemType.NULL)
			return;
		
		ContainerManager.Instance.IsDragging = false;
		ContainerManager.Instance.HideHoldingItemIcon();
		isDragging = false;

		icon.color = normalColor;
		GetComponent<Image>().color = normalColor;

		if(eventData.pointerEnter != null && eventData.pointerEnter.tag == "ContainerSlot")
		{
			if(container.containerItems[id].ItemType == ItemType.CURRENCY && eventData.pointerEnter.GetComponent<ContainerSlot>().Container.IsInventory)
			{
				ContainerManager.Instance.AddMoney(container.containerItems[id].ItemAmount * container.containerItems[id].ItemCost);
				container.containerItems[id] = new Item();
			}
			else if (container.containerItems[id].ItemType != ItemType.CURRENCY)
			{
				ContainerManager.Instance.Swap(this, eventData.pointerEnter.GetComponent<ContainerSlot>());
			}
			ContainerManager.Instance.DraggingItem = null;
		}
		else if(eventData.pointerEnter != null && eventData.pointerEnter.tag == "HotKeyBarSlot" && this.container.IsInventory)
		{
			eventData.pointerEnter.GetComponent<HotKeyBarSlot>().Item = ContainerManager.Instance.DraggingItem;
			ContainerManager.Instance.DraggingItem = null;
		}
		else if(eventData.pointerEnter != null && eventData.pointerEnter.tag == "CharacterEquipmentSlot" && eventData.pointerEnter.GetComponent<CharacterEquipmentSlot>() )
		{
			ContainerManager.Instance.WearItem(this, eventData.pointerEnter.GetComponent<CharacterEquipmentSlot>());
			ContainerManager.Instance.DraggingItem = null;
		}
		else if(eventData.pointerEnter == null)
		{
			ContainerManager.Instance.DropItem(this);
		}

	}
	
}
