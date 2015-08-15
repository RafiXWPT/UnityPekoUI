using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Console : MonoBehaviour {

	public GameObject line;
	List<GameObject> messages;
	int lineCount = 0;
	
	void Start () {
		messages = new List<GameObject>();
	}

	void Update () {
	
	}

	public void LogConsole(string message)
	{
		GameObject line_prefab = (GameObject)Instantiate(line);
		line_prefab.transform.SetParent(this.transform);
		line_prefab.name = "Message" + lineCount;
		line_prefab.GetComponent<Text>().text = System.DateTime.Now.ToString() + ": " + message;
		messages.Add(line_prefab);
		if(lineCount >= 30){
			Destroy(messages[0]);
			messages.RemoveAt(0);
		}
		lineCount++;
	}
}
