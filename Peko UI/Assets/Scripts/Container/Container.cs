using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Container : ContainerManager {

	public GameObject slot;
	public int slotCount;
	public List<Item> containerItems;

	[SerializeField]
	bool isInventory;

	public bool IsInventory {
		get {
			return isInventory;
		}
	}

	List<GameObject> slotObjects;

	void Awake()
	{
		containerItems = new List<Item>();
		slotObjects = new List<GameObject>();
	}

	void Start () {
	
		for(int i = 0; i < slotCount; i ++)
		{
			GameObject tmpSlot = (GameObject)Instantiate(slot);
			tmpSlot.name = "Slot"+i;
			tmpSlot.GetComponent<ContainerSlot>().id = i;
			tmpSlot.transform.SetParent(this.transform);

			slotObjects.Add(tmpSlot);
			containerItems.Add(new Item());
		}
		
	}

	public void ReLoad()
	{
		foreach(GameObject slotobj in slotObjects)
			Destroy(slotobj);

		slotObjects.Clear();
		for(int i = 0; i < containerItems.Count; i++)
		{
			GameObject tmpSlot = (GameObject)Instantiate(slot);
			tmpSlot.name = "Slot"+i;
			tmpSlot.GetComponent<ContainerSlot>().id = i;
			tmpSlot.transform.SetParent(this.transform);

			slotObjects.Add(tmpSlot);
		}
	}

	public bool AddItemToContainer(int item_id, int amount)
	{
		Item fromDatabase = ContainerManager.Instance.ItemDatabase.GetItemFromDatabase(item_id).GetClone();
		fromDatabase.ItemAmount = amount;

		if(containerItems.Count(item => item.ItemType == ItemType.NULL) == 0
		   && !fromDatabase.IsStackable)
		{
			Debug.Log("Inventory is full.");
			ContainerManager.Instance.Console.LogConsole("Inventory is full.");
			return false;
		}
		else if(fromDatabase.IsStackable && 
		        containerItems.Count(x=> (x.ItemAmount < x.MaxStack) && (x.ItemId == item_id)) - containerItems.Count(x=> (x.ItemType == ItemType.NULL)) == 0 &&
		        containerItems.Count(x=> (x.ItemType == ItemType.NULL)) == 0)
		{
			Debug.Log("Inventory is full.");
			ContainerManager.Instance.Console.LogConsole("Inventory is full.");
			return false;
		}

		if(fromDatabase.IsStackable)
		{
			if(PlaceStackableItem(fromDatabase))
			{
				return true;
			}
			else
			{
				return PlaceNonStackebleItem(fromDatabase);
			}
		}
		else
		{
			return PlaceNonStackebleItem(fromDatabase);
		}

	}

	bool PlaceStackableItem(Item item)
	{
		for(int i = 0; i < containerItems.Count; i++)
		{
			if(containerItems[i].ItemId == item.ItemId && (containerItems[i].ItemAmount+item.ItemAmount) < item.MaxStack)
			{
				containerItems[i].ItemAmount += item.ItemAmount;
				Debug.Log("Added " + item.ItemAmount + " " + item.ItemName);
				ContainerManager.Instance.Console.LogConsole("Added " + item.ItemAmount + " " + item.ItemName);
				return true;
			}
			else if(containerItems[i].ItemId == item.ItemId && (containerItems[i].ItemAmount+item.ItemAmount) > item.MaxStack)
			{
				int canAdd = containerItems[i].MaxStack - containerItems[i].ItemAmount;
				containerItems[i].ItemAmount += canAdd;
				item.ItemAmount -= canAdd;
			}
		}

		return false;
	}

	bool PlaceNonStackebleItem(Item item)
	{
		for(int i = 0; i < containerItems.Count; i++)
		{
			if(containerItems[i].ItemType == ItemType.NULL)
			{
				containerItems[i] = item;
				Debug.Log("Added " + item.ItemAmount + " " + item.ItemName);
				ContainerManager.Instance.Console.LogConsole("Added " + item.ItemAmount + " " + item.ItemName);
				return true;
			}
		}
		return false;
	}

}
