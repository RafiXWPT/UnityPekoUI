using UnityEngine;
using System.Collections;

[System.Serializable]
public class Equipment : Item {

	#region properties
	[SerializeField]
	int defense;
	public int Defense {
		get {
			return defense;
		}
		set {
			defense = value;
		}
	}

	[SerializeField]
	int strength;
	public int Strength {
		get {
			return strength;
		}
		set {
			strength = value;
		}
	}

	[SerializeField]
	int agility;
	public int Agility {
		get {
			return agility;
		}
		set {
			agility = value;
		}
	}

	[SerializeField]
	int intelligence;
	public int Intelligence {
		get {
			return intelligence;
		}
		set {
			intelligence = value;
		}
	}

	[SerializeField]
	int stamina;
	public int Stamina {
		get {
			return stamina;
		}
		set {
			stamina = value;
		}
	}
	#endregion

	public Equipment()
	{}

	public Equipment(int itemId, string itemName, string itemIconName, string gameObjectName, string itemDescription, bool isStackable, int maxStack, ItemType itemType, ItemQuality itemQuality, int itemCost, int defense, int strength, int agility, int intelligence, int stamina)
	: base(itemId, itemName, itemIconName, gameObjectName, itemDescription, isStackable, maxStack, itemType, itemQuality, itemCost)
	{
		this.defense = defense;
		this.strength = strength;
		this.agility = agility;
		this.intelligence = intelligence;
		this.stamina = stamina;
	}

	public override Item GetClone()
	{
		return new Equipment(base.ItemId, base.ItemName, base.ItemIconName, base.GameObjectName, base.ItemDescription, base.IsStackable, base.MaxStack, base.ItemType, base.ItemQuality, base.ItemCost, this.Defense, this.Strength, this.Agility, this.Intelligence, this.Stamina);
	}

	public override void Use (ContainerSlot slot)
	{
		if(slot == null)
			return;

		Debug.Log("Trying to wear: " + this.ItemName);
		ContainerManager.Instance.Console.LogConsole("Trying to wear: " + this.ItemName);
		ContainerManager.Instance.DraggingItem = this;
		ContainerManager.Instance.WearItem(slot, null);
	}

	public override string GetToolTip (string damageContent)
	{
		string content = base.GetToolTip (damageContent);
		if(this.defense > 0)
		{
			content += "\n";
			content += string.Format("<size=14><color=white>{0} defense</color></size>", this.defense);
		}
		if(this.strength > 0)
		{
			content += "\n";
			content += string.Format("<size=14><color=green>+ {0} Strength</color></size>", this.strength);
		}
		if(this.agility > 0)
		{
			content += "\n";
			content += string.Format("<size=14><color=green>+ {0} Agility</color></size>", this.agility);
		}
		if(this.intelligence > 0)
		{
			content += "\n";
			content += string.Format("<size=14><color=green>+ {0} Intelligence</color></size>", this.intelligence);
		}
		if(this.stamina > 0)
		{
			content += "\n";
			content += string.Format("<size=14><color=green>+ {0} Stamina</color></size>", this.stamina);
		}

		return content;
	}

}
