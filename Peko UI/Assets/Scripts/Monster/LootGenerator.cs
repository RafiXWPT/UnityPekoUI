using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootGenerator : MonoBehaviour {

	public int monsterId;
	Monster monster;

	public Monster Monster {
		get {
			return monster;
		}
	}

	void Start () {
		monster = GameObject.FindGameObjectWithTag("MonsterDatabase").GetComponent<MonsterDatabase>().GetMonsterFromDatabase(monsterId).GetClone();
	}

	public List<Item> GenerateLoot()
	{
		List<Item> tmpItem = new List<Item>();

		foreach(MonsterItem item in monster.MonsterItems)
		{
			float getLuck = Random.value;
			if(getLuck >= (1.0f - item.Chance))
			{
				Item toAdd = ContainerManager.Instance.ItemDatabase.GetItemFromDatabase(item.ItemId);
				int randAmount = Random.Range(item.MinAmount, item.MaxAmount+1);
				toAdd.ItemAmount = randAmount;
				tmpItem.Add(toAdd);
			}
		}

		return tmpItem;
	}

}
