using UnityEngine;
using System.Collections;

[System.Serializable]
public class Currency : Item {

	public Currency()
	{}

	public Currency(int itemId, string itemName, string itemIconName, string gameObjectName, string itemDescription, bool isStackable, int maxStack, ItemType itemType, ItemQuality itemQuality, int itemCost)
	: base(itemId, itemName, itemIconName, gameObjectName, itemDescription, isStackable, maxStack, itemType, itemQuality, itemCost)
	{}

	public override void Use (ContainerSlot slot)
	{
		Debug.Log("Used: " + this.ItemName);
	}

	public override Item GetClone ()
	{
		return new Currency(base.ItemId, base.ItemName, base.ItemIconName, base.GameObjectName, base.ItemDescription, base.IsStackable, base.MaxStack, base.ItemType, base.ItemQuality, base.ItemCost);
	}

	public override string GetToolTip (string damageContent)
	{
		return base.GetToolTip (null);
	}
}
