using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterEquipment : MonoBehaviour {

	#region properties
	public int BaseDamageFrom {
		get {
			return baseDamageFrom;
		}
		set {
			baseDamageFrom = value;
		}
	}

	public int BaseDamageTo {
		get {
			return baseDamageTo;
		}
		set {
			baseDamageTo = value;
		}
	}

	public float BaseSpeed {
		get {
			return baseSpeed;
		}
		set {
			baseSpeed = value;
		}
	}

	public int BaseDefense {
		get {
			return baseDefense;
		}
		set {
			baseDefense = value;
		}
	}

	public int BaseStrength {
		get {
			return baseStrength;
		}
		set {
			baseStrength = value;
		}
	}

	public int BaseAgility {
		get {
			return baseAgility;
		}
		set {
			baseAgility = value;
		}
	}

	public int BaseIntelligence {
		get {
			return baseIntelligence;
		}
		set {
			baseIntelligence = value;
		}
	}
	
	public int BaseStamina {
		get {
			return baseStamina;
		}
		set {
			baseStamina = value;
		}
	}

	public int DamageFrom {
		get {
			return damageFrom;
		}
		set {
			damageFrom = value;
		}
	}

	public int DamageTo {
		get {
			return damageTo;
		}
		set {
			damageTo = value;
		}
	}
	
	public float Speed {
		get {
			return speed;
		}
		set {
			speed = value;
		}
	}

	public int Defense {
		get {
			return defense;
		}
		set {
			defense = value;
		}
	}
	
	public int Strength {
		get {
			return strength;
		}
		set {
			strength = value;
		}
	}

	public int Agility {
		get {
			return agility;
		}
		set {
			agility = value;
		}
	}
	
	public int Intelligence {
		get {
			return intelligence;
		}
		set {
			intelligence = value;
		}
	}
	
	public int Stamina {
		get {
			return stamina;
		}
		set {
			stamina = value;
		}
	}

	#endregion
	
	int baseDamageFrom;
	int damageFrom;
	int damageTo;
	int baseDamageTo;

	float speed;
	float baseSpeed;

	int defense;
	int baseDefense;

	int strength;
	int baseStrength;
	int agility;
	int baseAgility;
	int intelligence;
	int baseIntelligence;
	int stamina;
	int baseStamina;
	
	public GameObject statsValues;
	List<CharacterEquipmentSlot> equipmentSlots;
	Text[] statsText;
	
	void Start () {
		statsText = statsValues.GetComponentsInChildren<Text>();

		baseDamageFrom = 0;
		baseDamageTo = 10;
		baseSpeed = 2.5f;
		baseDefense = 50;
		baseStrength = 10;
		baseAgility = 5;
		baseIntelligence = 0;
		baseStamina = 11;
		RecalculateStats();
	}

	public void RecalculateStats()
	{
		damageFrom = baseDamageFrom;
		damageTo = baseDamageTo;
		speed = baseSpeed;
		defense = baseDefense;
		strength = baseStrength;
		agility = baseAgility;
		intelligence = baseIntelligence;
		stamina = baseStamina;

		foreach(CharacterEquipmentSlot slot in ContainerManager.Instance.EqSlots/*GetComponentsInChildren<CharacterEquipmentSlot>()*/)
		{
			if(slot.Item.ItemType != ItemType.NULL)
			{
				if(slot.Item.ItemType == ItemType.ONEHAND_WEAPON || slot.Item.ItemType == ItemType.TWOHAND_WEAPON)
				{
					Weapon item = slot.Item as Weapon;
					
					damageFrom += item.DamageFrom;
					damageTo += item.DamageTo;
					speed = item.Speed;

					defense += item.Defense;
					strength += item.Strength;
					agility += item.Agility;
					intelligence += item.Intelligence;
					stamina += item.Stamina;
				}
				else
				{
					Equipment item = slot.Item as Equipment;

					defense += item.Defense;
					strength += item.Strength;
					agility += item.Agility;
					intelligence += item.Intelligence;
					stamina += item.Stamina;
				}
			}
		}

		statsText[0].text = string.Format("Damage: {0} to {1} (Speed: {2:0.0})", damageFrom, damageTo, speed);
		statsText[1].text = string.Format("Defense: {0}", defense);
		statsText[2].text = string.Format("Strength: <b>{0}</b>", strength);
		statsText[3].text = string.Format("Agility: <b>{0}</b>", agility);
		statsText[4].text = string.Format("Intelligence: <b>{0}</b>", intelligence);
		statsText[5].text = string.Format("Stamina: <b>{0}</b>", stamina);

	}

}
