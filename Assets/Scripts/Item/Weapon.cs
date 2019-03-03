using UnityEngine;
using System.Collections;
using System.Globalization;

[System.Serializable]
public class Weapon : Equipment {

	[SerializeField]
	int damageFrom;
	public int DamageFrom {
		get {
			return damageFrom;
		}
		set {
			damageFrom = value;
		}
	}

	[SerializeField]
	int damageTo;
	public int DamageTo {
		get {
			return damageTo;
		}
		set {
			damageTo = value;
		}
	}

	[SerializeField]
	WeaponType weaponType;
	public WeaponType WeaponType {
		get {
			return weaponType;
		}
		set {
			weaponType = value;
		}
	}

	[SerializeField]
	float speed;
	public float Speed {
		get {
			return speed;
		}
		set {
			speed = value;
		}
	}
	
	public Weapon()
	{
	}

	public Weapon(int itemId, string itemName, string itemIconName, string gameObjectName, string itemDescription, bool isStackable, int maxStack, ItemType itemType, ItemQuality itemQuality, int itemCost, int defense, int strength, int agility, int intelligence, int stamina, int damageFrom, int damageTo, WeaponType weaponType, float speed)
	: base(itemId, itemName, itemIconName, gameObjectName, itemDescription, isStackable, maxStack, itemType, itemQuality, itemCost, defense, strength, agility, intelligence, stamina)
	{
		this.damageFrom = damageFrom;
		this.damageTo = damageTo;
		this.weaponType = weaponType;
		this.speed = speed;
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
	
	public override Item GetClone()
	{
		return new Weapon(base.ItemId, base.ItemName, base.ItemIconName, base.GameObjectName, base.ItemDescription, base.IsStackable, base.MaxStack, base.ItemType, base.ItemQuality, base.ItemCost, base.Defense, base.Strength, base.Agility, base.Intelligence, base.Stamina, this.DamageFrom, this.DamageTo, this.WeaponType, this.Speed);
	}
	
	public override string GetToolTip (string damageContent)
	{
		string content = base.GetToolTip (string.Format("<size=14><color=white>{0} - {1} damage <i>(speed: {2:0.0})</i></color></size>", this.damageFrom, this.damageTo, this.speed));
		return content;
	}

}
