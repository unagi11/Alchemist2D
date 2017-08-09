using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float OriginSpeed = 5f;
	public float CurrentSpeed = 5f;

	private SpriteRenderer SpRd;


	public static PlayerController PCinstance;

	void Start()
	{
		PCinstance = this;
		SpRd = GetComponent<SpriteRenderer>();
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
			SpRd.flipX = true;
			VerticalVector = Vector3.down;
		}
		else if (moveVertical > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 90);
			SpRd.flipX = false;
			VerticalVector = Vector3.up;
		}

		if (moveHorizontal < 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			SpRd.flipX = true;
			HorizontalVector = Vector3.left;
		}
		else if (moveHorizontal > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			SpRd.flipX = false;
			HorizontalVector = Vector3.right;
		}		

		transform.position += (HorizontalVector + VerticalVector) * CurrentSpeed * Time.deltaTime;
	}
}