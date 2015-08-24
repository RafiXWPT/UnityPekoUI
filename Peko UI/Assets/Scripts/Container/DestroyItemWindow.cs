using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyItemWindow : MonoBehaviour {

	Slider slider;
	public Text text;
	public Image image;
	public ContainerSlot itemToDrop;
	
	void Start () {
		slider = this.GetComponentInChildren<Slider>();
		//StartCoroutine("WindowTimer");
	}

	void Update () {
	}

	public void SetUp()
	{
		image.sprite = itemToDrop.Container.containerItems[itemToDrop.id].ItemIcon;
		text.text = string.Format("Do you really want to destroy: <b>{0}</b>?", itemToDrop.Container.containerItems[itemToDrop.id].ItemName);
	}

	public IEnumerator WindowTimer()
	{
		slider.value = 0f;
		while(slider.value < 10f)
		{
			slider.value += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		this.gameObject.SetActive(false);
		yield return null;
	}

	public void Yes()
	{
		StopCoroutine("WindowTimer");
		itemToDrop.Container.containerItems[itemToDrop.id] = new Item();
		this.gameObject.SetActive(false);
	}

	public void No()
	{
		StopCoroutine("WindowTimer");
		this.gameObject.SetActive(false);
	}
}
