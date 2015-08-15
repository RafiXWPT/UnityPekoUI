using UnityEngine;
using System.Collections;
using System.Globalization;

public enum ItemType
{
	NULL,
	ONEHAND_WEAPON,
	TWOHAND_WEAPON,
	SHIELD,
	HELMET,
	CHEST,
	BOOTS,
	HANDS,
	NECKLACE,
	RING,
	POTION,
	CURRENCY,
	WEAPON,
}

public enum ItemQuality
{
	NULL,
	COMMON,
	UNCOMMON,
	RARE,
	EPIC,
	LEGENDARY,
	ARTIFACT
}

public enum WeaponType
{
	NULL,
	SWORD,
	AXE,
	CLUB
}

[System.Serializable]
public class Item {

	#region Properties

	[SerializeField]
	int itemId;
	public int ItemId {
		get {
			return itemId;
		}
		set {
			itemId = value;
		}
	}

	[SerializeField]
	string itemName;
	public string ItemName {
		get {
			return itemName;
		}
		set {
			itemName = value;
		}
	}
	
	string itemIconName;
	public string ItemIconName {
		get {
			return itemIconName;
		}
		set {
			itemIconName = value;
		}
	}

	string gameObjectName;
	public string GameObjectName {
		get {
			return gameObjectName;
		}
		set {
			gameObjectName = value;
		}
	}

	[SerializeField]
	string itemDescription;
	public string ItemDescription {
		get {
			return itemDescription;
		}
		set {
			itemDescription = value;
		}
	}

	[SerializeField]
	bool isStackable;
	public bool IsStackable {
		get {
			return isStackable;
		}
		set {
			isStackable = value;
		}
	}

	[SerializeField]
	int maxStack;
	public int MaxStack {
		get {
			return maxStack;
		}
		set {
			maxStack = value;
		}
	}

	[SerializeField]
	ItemType itemType;
	public ItemType ItemType {
		get {
			return itemType;
		}
		set {
			itemType = value;
		}
	}

	[SerializeField]
	ItemQuality itemQuality;
	public ItemQuality ItemQuality {
		get {
			return itemQuality;
		}
		set {
			itemQuality = value;
		}
	}

	[SerializeField]
	int itemCost;
	public int ItemCost {
		get {
			return itemCost;
		}
		set {
			itemCost = value;
		}
	}

	[SerializeField]
	Sprite itemIcon;
	public Sprite ItemIcon {
		get {
			return itemIcon;
		}
		set {
			itemIcon = value;
		}
	}

	[SerializeField]
	GameObject itemObject;
	public GameObject ItemObject {
		get {
			return itemObject;
		}
		set {
			itemObject = value;
		}
	}

	[SerializeField]
	int itemAmount;
	public int ItemAmount {
		get {
			return itemAmount;
		}
		set {
			itemAmount = value;
		}
	}

	#endregion

	public Item()
	{}

	public Item(int itemId, string itemName, string itemIconName, string gameObjectName, string itemDescription, bool isStackable, int maxStack, ItemType itemType, ItemQuality itemQuality, int itemCost)
	{
		this.itemId = itemId;
		this.itemName = itemName;
		this.itemIconName = itemIconName;
		this.gameObjectName = gameObjectName;
		this.itemDescription = itemDescription;
		this.isStackable = isStackable;
		this.maxStack = maxStack;
		this.itemType = itemType;
		this.itemQuality = itemQuality;
		this.itemCost = itemCost;
		this.itemAmount = 1;

		this.itemIcon = Resources.Load<Sprite>("ItemIcons/"+this.itemIconName);
		this.itemObject = Resources.Load<GameObject>("Prefabs/Items/"+this.gameObjectName);
	}

	public virtual void Use(ContainerSlot slot)
	{
		return;
	}

	public virtual string GetToolTip(string damageContent){
		string content = "";
		string color = "";
		switch (this.itemQuality) 
		{
		case ItemQuality.COMMON:
			color = "white";
			break;
		case ItemQuality.UNCOMMON:
			color = "lime";
			break;
		case ItemQuality.RARE:
			color = "navy";
			break;
		case ItemQuality.EPIC:
			color = "magenta";
			break;
		case ItemQuality.LEGENDARY:
			color = "orange";
			break;
		case ItemQuality.ARTIFACT:
			color = "red";
			break;
		}

		content += string.Format("<size=16><color=" + color + "><b>{0}</b></color></size>", this.itemName);

		var strFormatter = CultureInfo.CurrentCulture.TextInfo;

		if(this.itemType == ItemType.ONEHAND_WEAPON)
			content += string.Format("\n<size=10><color=white><i>{0} One-Hand Weapon</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.TWOHAND_WEAPON)
			content += string.Format("\n<size=10><color=white><i>{0} Two-Hand Weapon</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if(this.itemType == ItemType.SHIELD)
			content += string.Format("\n<size=10><color=white><i>{0} Shield</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if(this.itemType == ItemType.HELMET)
			content += string.Format("\n<size=10><color=white><i>{0} Helmet</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.CHEST)
			content += string.Format("\n<size=10><color=white><i>{0} Chest</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.BOOTS)
			content += string.Format("\n<size=10><color=white><i>{0} Boots</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.HANDS)
			content += string.Format("\n<size=10><color=white><i>{0} Hands</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.NECKLACE)
			content += string.Format("\n<size=10><color=white><i>{0} Necklace</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.RING)
			content += string.Format("\n<size=10><color=white><i>{0} Ring</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.POTION)
			content += string.Format("\n<size=10><color=white><i>{0} Potion</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));
		else if (this.itemType == ItemType.CURRENCY)
			content += string.Format("\n<size=10><color=white><i>{0} Currency</i></color></size>", strFormatter.ToTitleCase(this.itemQuality.ToString().ToLower()));

		if(this.itemDescription.Length > 0)
		{
			content += "\n";
			content += string.Format("<size=14><color=orange><i>{0}</i></color></size>", this.itemDescription);
		}

		if(damageContent != null)
		{
			content += "\n";
			content += damageContent;
		}

		return content;
	}

	public virtual Item GetClone(){
		return null;
	}

}
