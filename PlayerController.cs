using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 1f;
	private SpriteRenderer sprd;
	void Start()
	{
		sprd = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		Move();			
	}

	void Move()
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");

		Vector3 HorizontalVector = Vector3.zero;
		Vector3 VerticalVector = Vector3.zero;

		if (moveVertical < 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 90);
			sprd.flipX = true;
			VerticalVector = Vector3.down;
		}
		else if (moveVertical > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 90);
			sprd.flipX = false;
			VerticalVector = Vector3.up;
		}

		if (moveHorizontal < 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			sprd.flipX = true;
			HorizontalVector = Vector3.left;
		}
		else if (moveHorizontal > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			sprd.flipX = false;
			HorizontalVector = Vector3.right;
		}		

		transform.position += (HorizontalVector + VerticalVector) * speed * Time.deltaTime;
	}
}