using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;

public class ContainerManager : MonoBehaviour {
	
	#region instance
	private static ContainerManager instance;
	public static ContainerManager Instance {
		get 
		{
			if(instance == null)
			{
				instance = FindObjectOfType<ContainerManager>();
			}
			return instance;
		}
	}
	#endregion

	#region properties
	public ItemDatabase ItemDatabase {
		get {
			return itemDatabase;
		}
	}

	public bool IsDragging {
		get {
			return isDragging;
		}
		set {
			isDragging = value;
		}
	}
	
	public Item DraggingItem {
		get {
			return draggingItem;
		}
		set {
			draggingItem = value;
		}
	}

	public bool IsLootPanelOpen {
		get {
			return isLootPanelOpen;
		}
		set {
			isLootPanelOpen = value;
		}
	}

	public CharacterEquipmentSlot[] EqSlots {
		get {
			return eqSlots;
		}
	}

	public Console Console {
		get {
			return console;
		}
	}

	public List<GameObject> PannelsOpened {
		get {
			return pannelsOpened;
		}
		set {
			pannelsOpened = value;
		}
	}

	#endregion

	// Inventory Control
	bool isLootPanelOpen;

	// Inventory & character pannels
	GameObject inventoryPanel;
	GameObject characterPanel;
	GameObject itemDestroyPanel;

	// Database
	ItemDatabase itemDatabase;

	// Console
	Console console;

	// Dragging Control
	bool isDragging;
	Item draggingItem;

	// Holding Item Control
	GameObject holdingItemIcon;
	Vector2 holdingItemIconOffset = new Vector2(-10f, 10f);

	// Tooltip
	GameObject toolTip;

	// Equipment
	CharacterEquipment characterEquipment;
	CharacterEquipmentSlot[] eqSlots;

	// LootPanel
	GameObject lootPanel;

	// Inventory
	Container inventory;

	// Gold Panel
	GameObject goldCountPanel;
	Text[] currencyCount;
	int money;

	// PannelsOpenHierarchy
	List<GameObject> pannelsOpened = new List<GameObject>();

	void Awake()
	{
		inventoryPanel = GameObject.Find("InventoryPanel");
		characterPanel = GameObject.Find("CharacterPanel");
		itemDestroyPanel = GameObject.Find("DestroyItemPanel");

		itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		characterEquipment = GameObject.FindGameObjectWithTag("CharacterEquipment").GetComponent<CharacterEquipment>();
		toolTip = GameObject.FindGameObjectWithTag("ToolTip");
		goldCountPanel = GameObject.FindGameObjectWithTag("GoldCountPanel");

		lootPanel = GameObject.FindGameObjectWithTag("LootPanel");

		holdingItemIcon = GameObject.Find("HoldingItemIcon");

		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Container>();


	}
	
	void Start () {

		eqSlots = FindObjectsOfType<CharacterEquipmentSlot>();
		console = FindObjectOfType<Console>();

		isDragging = false;
		draggingItem = null;

		holdingItemIcon.GetComponent<CanvasGroup>().alpha = 0f;
		toolTip.GetComponent<CanvasGroup>().alpha = 0f;

		currencyCount = goldCountPanel.GetComponentsInChildren<Text>();

		lootPanel.SetActive(false);
		inventoryPanel.SetActive(false);
		characterPanel.SetActive(false);
		itemDestroyPanel.SetActive(false);
		console.LogConsole("Welcome!");
	}

	public void DropItem(ContainerSlot itemToDrop)
	{
		itemDestroyPanel.SetActive(true);
		DestroyItemWindow destroyWindow = itemDestroyPanel.GetComponent<DestroyItemWindow>();
		destroyWindow.StopCoroutine("WindowTimer");
		destroyWindow.itemToDrop = itemToDrop;
		destroyWindow.SetUp();
		destroyWindow.StartCoroutine("WindowTimer");
	}

	public void OpenCloseInventory()
	{
		if(inventoryPanel.activeSelf)
		{
			pannelsOpened.Remove(inventoryPanel);
			inventoryPanel.SetActive(false);
		}
		else
		{
			pannelsOpened.Add(inventoryPanel);
			inventoryPanel.SetActive(true);
		}
	}

	public void OpenCloseCharacter()
	{
		if(characterPanel.activeSelf)
		{
			pannelsOpened.Remove(characterPanel);
			characterPanel.SetActive(false);
		}
		else
		{
			pannelsOpened.Add(characterPanel);
			characterPanel.SetActive(true);
		}
	}

	public void CloseLastPanel()
	{
		if(pannelsOpened.Count > 0)
		{
			pannelsOpened[pannelsOpened.Count-1].SetActive(false);
			pannelsOpened.RemoveAt(pannelsOpened.Count-1);
		}
		else
		{
			Debug.Log("Otwieram Main Menu.");
		}
	}

	public void CreateLootWindow(List<Item> items)
	{
		pannelsOpened.Add(lootPanel);
		lootPanel.SetActive(true);
		lootPanel.GetComponentInChildren<Container>().containerItems = items;
		lootPanel.GetComponentInChildren<Container>().ReLoad();
	}

	public void DestroyLootWindow()
	{
		pannelsOpened.Remove(lootPanel);
		lootPanel.SetActive(false);
		isLootPanelOpen = false;
	}

	public void CollectAll()
	{
		Container loot = lootPanel.GetComponentInChildren<Container>();

		for(int i = 0; i < loot.containerItems.Count; i++)
		{
			if(loot.containerItems[i].ItemType != ItemType.NULL)
			{
				if(loot.containerItems[i].ItemType == ItemType.CURRENCY)
				{
					AddMoney(loot.containerItems[i].ItemAmount*loot.containerItems[i].ItemCost);
					loot.containerItems[i] = new Item();
				}
				else
				{
					if(loot.containerItems[i].IsStackable)
					{
						if(inventory.AddItemToContainer(loot.containerItems[i].ItemId,loot.containerItems[i].ItemAmount))
						{
							loot.containerItems[i] = new Item();
						}
					}
					else
					{
						if(inventory.AddItemToContainer(loot.containerItems[i].ItemId,1))
						{
							loot.containerItems[i] = new Item();
						}
					}
				}
			}
		}
	}

	public void ShowHoldingItemIcon(Vector2 position)
	{
		holdingItemIcon.GetComponent<Image>().sprite = draggingItem.ItemIcon;
		holdingItemIcon.GetComponent<CanvasGroup>().alpha = 1f;
		holdingItemIcon.transform.SetAsLastSibling();
		holdingItemIcon.transform.position = position - holdingItemIconOffset;
	}

	public void HideHoldingItemIcon()
	{
		holdingItemIcon.GetComponent<CanvasGroup>().alpha = 0f;
		holdingItemIcon.transform.SetAsLastSibling();
	}

	public void ShowToolTip(Item item, Vector2 position)
	{
		toolTip.GetComponent<CanvasGroup>().alpha = 1f;

		toolTip.GetComponentInChildren<Text>().text = item.GetToolTip(null);
	
		toolTip.transform.SetAsLastSibling();
		
		GUIStyle height_calculator = new GUIStyle();
		GUIContent toolTipContent = new GUIContent(toolTip.transform.GetChild(0).GetComponent<Text>().text);
		
		float textWidth = toolTip.transform.GetChild(0).GetComponent<Text>().preferredWidth;
		float textHeight = height_calculator.CalcHeight(toolTipContent, textWidth);
		
		float horizontalOffset = 0f;
		float verticalOffset = 0f;
		
		if(position.x + textWidth >= Screen.width)
			horizontalOffset = textWidth;
		if(position.y - textHeight <= 20f)
			verticalOffset = textHeight + 32f;
		
		toolTip.transform.position = new Vector2(position.x - horizontalOffset - 15f, position.y + verticalOffset - 15f);
	}

	public void HideToolTip()
	{
		toolTip.GetComponent<CanvasGroup>().alpha = 0f;
	}

	public void Swap(ContainerSlot from, ContainerSlot to)
	{
		if (from == to)
			return;

		if(from.Container.containerItems[from.id].ItemId != to.Container.containerItems[to.id].ItemId)
		{
			from.Container.containerItems[from.id] = to.Container.containerItems[to.id];
			to.Container.containerItems[to.id] = draggingItem;
		}
		else if (from.Container.containerItems[from.id].ItemId == to.Container.containerItems[to.id].ItemId && 
		        (to.Container.containerItems[to.id].IsStackable))
		{
			int leftToMax = to.Container.containerItems[to.id].MaxStack - to.Container.containerItems[to.id].ItemAmount;
			if(from.Container.containerItems[from.id].ItemAmount <= leftToMax)
			{
				to.Container.containerItems[to.id].ItemAmount += from.Container.containerItems[from.id].ItemAmount;
				from.Container.containerItems[from.id] = new Item();
			}
			else if (from.Container.containerItems[from.id].ItemAmount > leftToMax)
			{
				to.Container.containerItems[to.id].ItemAmount += leftToMax;
				from.Container.containerItems[from.id].ItemAmount -= leftToMax;
			}
		}

	}

	public void WearItem(ContainerSlot from, CharacterEquipmentSlot to)
	{
		if(from != null && to != null)
		{
			if(from.Container.containerItems[from.id].ItemType == to.equipmentPart || 
			 ((from.Container.containerItems[from.id].ItemType == ItemType.ONEHAND_WEAPON || from.Container.containerItems[from.id].ItemType == ItemType.TWOHAND_WEAPON)) && to.equipmentPart == ItemType.WEAPON)
			{
				if(from.Container.containerItems[from.id].ItemType == ItemType.TWOHAND_WEAPON)
				{
					CharacterEquipmentSlot shield = Array.Find(eqSlots, slot => (slot.equipmentPart == ItemType.SHIELD));
					if(shield.Item.ItemType == ItemType.NULL)
					{
						from.Container.containerItems[from.id] = to.Item;
						to.Item = draggingItem;

						characterEquipment.RecalculateStats();
						this.HideToolTip();
					}
					else
					{
						if(from.Container.AddItemToContainer(shield.Item.ItemId,1))
						{
							from.Container.containerItems[from.id] = to.Item;
							to.Item = draggingItem;

							shield.Item = new Item();
							
							characterEquipment.RecalculateStats();
							this.HideToolTip();
						}
						else
						{
							Debug.Log("Inventory is full.");
						}
					}
				}
				else if (from.Container.containerItems[from.id].ItemType == ItemType.SHIELD)
				{
					CharacterEquipmentSlot mainHand = Array.Find(eqSlots, slot => (slot.equipmentPart == ItemType.WEAPON));
					if(mainHand.Item.ItemType == ItemType.NULL || mainHand.Item.ItemType == ItemType.ONEHAND_WEAPON)
					{
						from.Container.containerItems[from.id] = to.Item;
						to.Item = draggingItem;
						
						characterEquipment.RecalculateStats();
						this.HideToolTip();
					}
					else
					{
						if(from.Container.AddItemToContainer(mainHand.Item.ItemId,1))
						{
							from.Container.containerItems[from.id] = to.Item;
							to.Item = draggingItem;

							mainHand.Item = new Item();
							
							characterEquipment.RecalculateStats();
							this.HideToolTip();
						}
						else
						{
							Debug.Log("Inventory is full.");
						}
					}
				}
				else
				{
					from.Container.containerItems[from.id] = to.Item;
					to.Item = draggingItem;

					characterEquipment.RecalculateStats();
					this.HideToolTip();
				}
			}
		}
		else if (from != null && to == null)
		{
			CharacterEquipmentSlot eqSlot;
			if(from.Container.containerItems[from.id].ItemType == ItemType.ONEHAND_WEAPON || from.Container.containerItems[from.id].ItemType == ItemType.TWOHAND_WEAPON)
			{
				eqSlot = Array.Find(eqSlots, slot => (slot.equipmentPart == ItemType.WEAPON));
			}
			else
			{
				eqSlot = Array.Find(eqSlots, slot => (slot.equipmentPart == from.Container.containerItems[from.id].ItemType));
			}

			this.WearItem(from, eqSlot);
			return;
		}
	}

	public void UnWearItem(CharacterEquipmentSlot from, ContainerSlot to)
	{
		from.Item = to.Container.containerItems[to.id];
		to.Container.containerItems[to.id] = draggingItem;
	}

	public void AddMoney(int amount)
	{
		console.LogConsole("Added " + amount + " gold.");
		money += amount;
		RecalculateMoney();
	}

	public bool RemoveMoney(int amount)
	{
		if(money - amount > 0)
		{
			money -= amount;
			RecalculateMoney();
			return true;
		}
		else
			return false;
	}

	void RecalculateMoney()
	{
		int bronzeCount = 0;
		int silverCount = 0;
		int goldenCount = 0;
		
		goldenCount = money / 10000;
		silverCount = (money - (goldenCount*10000)) / 100;
		bronzeCount = (money - (goldenCount*10000) - (silverCount*100));

		currencyCount[0].text = bronzeCount.ToString();
		currencyCount[1].text = silverCount.ToString();
		currencyCount[2].text = goldenCount.ToString();
	}

}
