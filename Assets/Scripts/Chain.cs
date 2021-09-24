using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
	public Transform player;
	public float speed = 2f;
	public bool IsFired = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			IsFired = true;
		}

		if (IsFired)
		{
			transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
		}
		else
		{
			transform.position = player.position;
			transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ball")
		{
			IsFired = false;
			col.GetComponent<Ball>().Split();
		} else if (col.name.Contains("Top"))
		{
			IsFired = false;
		}
	}
}
