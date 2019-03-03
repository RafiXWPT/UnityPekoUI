using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MonsterType
{
	NULL,
	BEAST
}

public enum MonsterQuality
{
	NULL,
	COMMON,
	UNCOMMON,
	RARE,
	EPIC,
	LEGENDARY,
	ARTIFACT
}

public class MonsterItem
{
	int itemId;

	public int ItemId {
		get {
			return itemId;
		}
	}

	int minAmount;

	public int MinAmount {
		get {
			return minAmount;
		}
	}

	int maxAmount;

	public int MaxAmount {
		get {
			return maxAmount;
		}
	}

	float chance;

	public float Chance {
		get {
			return chance;
		}
	}

	public MonsterItem(int itemId, int minAmount, int maxAmount, float chance)
	{
		this.itemId = itemId;
		this.minAmount = minAmount;
		this.maxAmount = maxAmount;
		this.chance = chance;
	}
}

[System.Serializable]
public class Monster {

	[SerializeField]
	int monsterId;
	
	public int MonsterId {
		get {
			return monsterId;
		}
	}

	[SerializeField]
	string monsterName;

	public string MonsterName {
		get {
			return monsterName;
		}
	}

	[SerializeField]
	int monsterExperience;

	public int MonsterExperience {
		get {
			return monsterExperience;
		}
	}

	[SerializeField]
	MonsterType monsterType;

	public MonsterType MonsterType {
		get {
			return monsterType;
		}
	}

	[SerializeField]
	MonsterQuality monsterQuality;

	public MonsterQuality MonsterQuality {
		get {
			return monsterQuality;
		}
	}

	[SerializeField]
	List<MonsterItem> monsterItems;

	public List<MonsterItem> MonsterItems {
		get {
			return monsterItems;
		}
	}

	[SerializeField]
	string monsterCorpseName;
	
	public string MonsterCorpseName {
		get {
			return monsterCorpseName;
		}
	}

	[SerializeField]
	GameObject monsterCorpse;

	public GameObject MonsterCorpse {
		get {
			return monsterCorpse;
		}
	}

	public Monster()
	{

	}

	public Monster(int monsterId, string monsterName, int monsterExperience, MonsterType monsterType, MonsterQuality monsterQuality, List<MonsterItem> monsterItems, string monsterCorpseName)
	{
		this.monsterId = monsterId;
		this.monsterName = monsterName;
		this.monsterExperience = monsterExperience;
		this.monsterType = monsterType;
		this.monsterQuality = monsterQuality;
		this.monsterItems = monsterItems;
		this.monsterCorpseName = monsterCorpseName;
		this.monsterCorpse = Resources.Load<GameObject>("Prefabs/Corpse/"+monsterCorpseName);
	}

	public Monster GetClone()
	{
		return new Monster(this.monsterId, this.monsterName, this.monsterExperience, this.monsterType, this.monsterQuality, this.monsterItems, this.monsterCorpseName);
	}

}
