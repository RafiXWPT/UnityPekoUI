using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	GameObject corpse;
	string monsterName;

	MonsterLoot monsterLoot;

	void Awake()
	{

	}

	void Start () {
		corpse = GetComponent<LootGenerator>().Monster.MonsterCorpse;
		monsterName = GetComponent<LootGenerator>().Monster.MonsterName;
		Die ();
	}

	public void Die()
	{
		GameObject corpseGeneration = Instantiate(corpse, transform.position, Quaternion.identity) as GameObject;
		corpseGeneration.name = "Dead " + monsterName;
		corpseGeneration.transform.SetParent(GameObject.Find("Monsters").transform);
		monsterLoot = corpseGeneration.GetComponent<MonsterLoot>();
		monsterLoot.LootItems = GetComponent<LootGenerator>().GenerateLoot();


		string loot = monsterName + " dropped: ";
		for(int i = 0; i < monsterLoot.LootItems.Count; i++)
		{
			loot += monsterLoot.LootItems[i].ItemAmount + "x " + monsterLoot.LootItems[i].ItemName;
			if( i < monsterLoot.LootItems.Count - 1)
				loot += ", ";
			else
				loot += ".";
		}

		ContainerManager.Instance.Console.LogConsole(loot);

		Destroy(this.gameObject);
	}
}
