using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	GameObject corpse;
	string monsterName;

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
		corpseGeneration.GetComponent<MonsterLoot>().LootItems = GetComponent<LootGenerator>().GenerateLoot();

		Destroy(this.gameObject);
	}
}
