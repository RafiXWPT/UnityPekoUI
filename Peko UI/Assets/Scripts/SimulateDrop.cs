using UnityEngine;
using System.Collections;

public class SimulateDrop : MonoBehaviour {

	Container inventory;

	void Awake()
	{
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Container>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddItem()
	{
		int randi = Random.Range(4, 60);
		inventory.AddItemToContainer(randi,1);
	}

	public void AddPotion()
	{
		int randi = Random.Range (100,103);
		int randj = Random.Range (1,10);
		inventory.AddItemToContainer(randi, randj);
	}

	public void AddGold()
	{
		int randi = Random.Range(1, 1000);
		ContainerManager.Instance.AddMoney(randi);
	}
}
