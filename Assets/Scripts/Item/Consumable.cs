using UnityEngine;
using System.Collections;

[System.Serializable]
public class Consumable : Item {

	[SerializeField]
	int healthToGain;
	public int HealthToGain {
		get {
			return healthToGain;
		}
		set {
			healthToGain = value;
		}
	}

	[SerializeField]
	int manaToGain;
	public int ManaToGain {
		get {
			return manaToGain;
		}
		set {
			manaToGain = value;
		}
	}

	public Consumable()
	{}

	public Consumable(int itemId, string itemName, string itemIconName, string gameObjectName, string itemDescription, bool isStackable, int maxStack, ItemType itemType, ItemQuality itemQuality, int itemCost, int healthToGain, int manaToGain)
	: base(itemId, itemName, itemIconName, gameObjectName, itemDescription, isStackable, maxStack, itemType, itemQuality, itemCost)
	{
		this.HealthToGain = healthToGain;
		this.ManaToGain = manaToGain;
	}

	public override void Use (ContainerSlot slot)
	{
		if(this.ItemAmount > 1)
		{
			ContainerManager.Instance.Console.LogConsole("Used one of " + this.ItemAmount + " " + this.ItemName);
			Debug.Log("Used one of " + this.ItemAmount + " " + this.ItemName);
		}		
		else
		{
			ContainerManager.Instance.Console.LogConsole("Used last " + this.ItemName);
			Debug.Log("Used last " + this.ItemName);
		}
		this.ItemAmount--;
	}

	public override Item GetClone ()
	{
		return new Consumable(base.ItemId, base.ItemName, base.ItemIconName, base.GameObjectName, base.ItemDescription, base.IsStackable, base.MaxStack, base.ItemType, base.ItemQuality, base.ItemCost, this.healthToGain, this.manaToGain);
	}

	public override string GetToolTip (string damageContent)
	{
		return base.GetToolTip (null);
	}

}
