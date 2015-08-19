using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMonster : MonoBehaviour {

	public List<string> monsters;

	void Start () {

		foreach(string monsterName in monsters)
		{
			GameObject monster = Instantiate(Resources.Load("Prefabs/Monsters/"+monsterName)) as GameObject;
			monster.transform.SetParent(GameObject.Find("Monsters").transform);
		}
	}
}
