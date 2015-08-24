using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HotKeyBar : MonoBehaviour {

	public GameObject slot;
	List<GameObject> slotObjects = new List<GameObject>();
	
	void Start () {

		for(int i = 0; i < 10; i ++)
		{
			GameObject tmpSlot = Instantiate(slot) as GameObject;
			tmpSlot.name = "Slot"+i;
			tmpSlot.GetComponent<HotKeyBarSlot>().id = i;
			tmpSlot.transform.SetParent(this.transform);
			tmpSlot.transform.GetChild(2).GetComponent<Text>().text = i.ToString();
			
			slotObjects.Add(tmpSlot);
		}
	
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha0))
		{
			slotObjects[0].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			slotObjects[1].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			slotObjects[2].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			slotObjects[3].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			slotObjects[4].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			slotObjects[5].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha6))
		{
			slotObjects[6].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			slotObjects[7].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha8))
		{
			slotObjects[8].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
		if(Input.GetKeyDown(KeyCode.Alpha9))
		{
			slotObjects[9].GetComponent<HotKeyBarSlot>().Item.Use(null);
		}
	}

}
