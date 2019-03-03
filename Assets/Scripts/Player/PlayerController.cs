using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;

	void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.W))
		{
			Move (Vector3.forward);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Move (Vector3.back);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			Rotate(Vector3.down);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			Rotate(Vector3.up);
		}
	}
	
	void Move(Vector3 direction)
	{
		this.transform.Translate(direction * moveSpeed * Time.deltaTime);
	}
	
	void Rotate(Vector3 direction)
	{
		this.transform.Rotate(direction * rotateSpeed * Time.deltaTime);
	}
}
