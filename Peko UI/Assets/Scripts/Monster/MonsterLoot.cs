using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MonsterLoot : MonoBehaviour {
	
	[SerializeField]
	List<Item> lootItems = new List<Item>();

	bool canBeOpen = false;
	bool isOpen = false;

	Container inventory;

	public List<Item> LootItems {
		get {
			return lootItems;
		}
		set {
			lootItems = value;
		}
	}

	void Update()
	{
		if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, this.transform.position) <= 3f)
			canBeOpen = true;
		else
			canBeOpen = false;

		if(isOpen && !ContainerManager.Instance.IsLootPanelOpen)
			isOpen = false;

		if(isOpen && !canBeOpen)
		{
			ContainerManager.Instance.DestroyLootWindow();
			isOpen = false;
		}
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(1) && canBeOpen && !EventSystem.current.IsPointerOverGameObject()) {
			ContainerManager.Instance.ShowLootWindow(this.lootItems);
			ContainerManager.Instance.IsLootPanelOpen = true;
			isOpen = true;
		}
	}

	/*public void CollectAll()
	{
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Container>();
		for(int i = 0; i < lootItems.Count; i ++)
		{
			if(lootItems[i].ItemType != ItemType.NULL)
			{
				if(lootItems[i].ItemType != ItemType.CURRENCY)
				{
					if(lootItems[i].IsStackable)
					{
						if(inventory.AddItemToContainer(lootItems[i].ItemId,lootItems[i].ItemAmount))
						{
							lootItems[i] = new Item();
						}
					}
					else
					{
						if(inventory.AddItemToContainer(lootItems[i].ItemId,1))
						{
							lootItems[i] = new Item();
						}
					}
				}
				else
				{
					ContainerManager.Instance.AddMoney(lootItems[i].ItemAmount*lootItems[i].ItemCost);
					lootItems[i] = new Item();
				}
			}
		}
	}*/
}
