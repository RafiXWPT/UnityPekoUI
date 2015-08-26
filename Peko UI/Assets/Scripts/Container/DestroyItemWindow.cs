using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyItemWindow : MonoBehaviour {

	Slider slider;
	public Text text;
	public Image image;
	public ContainerSlot itemToDrop;

	void Awake()
	{
		slider = this.GetComponentInChildren<Slider>();
	}

	void Start () {

	}

	void Update () {
	}

	public void SetUp()
	{
		image.sprite = itemToDrop.Container.containerItems[itemToDrop.id].ItemIcon;
		text.text = string.Format("Do you really want to destroy: <b>{0}x {1}</b>?", itemToDrop.Container.containerItems[itemToDrop.id].ItemAmount, itemToDrop.Container.containerItems[itemToDrop.id].ItemName);
	}

	public IEnumerator WindowTimer()
	{
		this.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		this.transform.SetAsLastSibling();
		slider.value = 0f;
		itemToDrop.IsOnDestroy = true;
		while(slider.value < 10f && !ContainerManager.Instance.IsDragging)
		{
			slider.value += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		this.gameObject.SetActive(false);
		itemToDrop.IsOnDestroy = false;
		itemToDrop.ColorAsNormal();
		yield return null;
	}

	public void Yes()
	{
		StopCoroutine("WindowTimer");
		itemToDrop.Container.containerItems[itemToDrop.id] = new Item();
		this.gameObject.SetActive(false);
		itemToDrop.IsOnDestroy = false;
		itemToDrop.ColorAsNormal();
	}

	public void No()
	{
		StopCoroutine("WindowTimer");
		this.gameObject.SetActive(false);
		itemToDrop.IsOnDestroy = false;
		itemToDrop.ColorAsNormal();
	}
}
