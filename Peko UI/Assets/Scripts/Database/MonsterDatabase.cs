using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterDatabase : MonoBehaviour {

	[SerializeField]
	List<Monster> monsterContainer;

	public List<Monster> MonsterContainer {
		get {
			return monsterContainer;
		}
		set {
			monsterContainer = value;
		}
	}

	void Start () {
		monsterContainer = new List<Monster>();

		monsterContainer.Add(new Monster(0,
		                                 "Common Monster", 
		                                 10, 
		                                 MonsterType.BEAST, 
		                                 MonsterQuality.COMMON, 
		                                 new List<MonsterItem>() {new MonsterItem(0,1,99,1.0f),
																  new MonsterItem(3,1,1,0.5f),
																  new MonsterItem(4,1,1,0.25f),
																  new MonsterItem(8,1,1,0.5f),
																  new MonsterItem(9,1,1,0.1f),
																  new MonsterItem(100,1,20,0.6f)},
										"Corpse"));

		monsterContainer.Add(new Monster(1,
		                                 "Uncommon Monster", 
		                                 100, 
		                                 MonsterType.BEAST, 
		                                 MonsterQuality.UNCOMMON, 
		                                 new List<MonsterItem>() {new MonsterItem(1,1,99,1.0f),
										 new MonsterItem(5,1,1,0.5f),
										 new MonsterItem(6,1,1,0.25f),
										 new MonsterItem(10,1,1,0.5f),
										 new MonsterItem(11,1,1,0.1f),
										 new MonsterItem(100,1,20,0.6f)},
										 "Corpse"));

		monsterContainer.Add(new Monster(2,
		                                 "Rare Monster", 
		                                 1000, 
		                                 MonsterType.BEAST, 
		                                 MonsterQuality.RARE, 
		                                 new List<MonsterItem>() {new MonsterItem(1,1,99,1.0f),
																 new MonsterItem(6,1,1,0.5f),
																 new MonsterItem(7,1,1,0.25f),
																 new MonsterItem(11,1,1,0.5f),
																 new MonsterItem(12,1,1,0.1f),
																 new MonsterItem(101,1,20,0.6f)},
										 "Corpse"));

		monsterContainer.Add(new Monster(3,
		                                 "Epic Monster", 
		                                 10000, 
		                                 MonsterType.BEAST, 
		                                 MonsterQuality.EPIC, 
		                                 new List<MonsterItem>() {new MonsterItem(2,1,99,1.0f),
																 new MonsterItem(7,1,1,0.5f),
																 new MonsterItem(8,1,1,0.25f),
																 new MonsterItem(12,1,1,0.5f),
																 new MonsterItem(13,1,1,0.1f),
																 new MonsterItem(101,1,20,0.6f)},
										"Corpse"));

		monsterContainer.Add(new Monster(4,
		                                 "Legendary Monster", 
		                                 100000, 
		                                 MonsterType.BEAST, 
		                                 MonsterQuality.LEGENDARY, 
		                                 new List<MonsterItem>() {new MonsterItem(2,1,99,1.0f),
																 new MonsterItem(13,1,1,0.5f),
																 new MonsterItem(14,1,1,0.25f),
																 new MonsterItem(18,1,1,0.5f),
																 new MonsterItem(19,1,1,0.1f),
																 new MonsterItem(102,1,20,0.6f)},
										"Corpse"));

		monsterContainer.Add(new Monster(5,
		                                 "Artifact Guardian", 
		                                 1000000, 
		                                 MonsterType.BEAST, 
		                                 MonsterQuality.ARTIFACT, 
		                                 new List<MonsterItem>() {new MonsterItem(2,1,99,1.0f),
																new MonsterItem(23,1,1,0.5f),
																new MonsterItem(24,1,1,0.25f),
																new MonsterItem(28,1,1,0.5f),
																new MonsterItem(29,1,1,0.1f),
																new MonsterItem(102,1,20,0.6f)},
										"Corpse"));
	}

	public Monster GetMonsterFromDatabase(int monster_id)
	{
		Monster tmpMonster = null;
		
		if(tmpMonster == null)
			tmpMonster = monsterContainer.Find(monster => monster.MonsterId == monster_id);

		if(tmpMonster != null)
			return tmpMonster;
		else
			return new Monster();
	}
}
