using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float OriginSpeed = 5f;
	public float CurrentSpeed = 5f;

	public GameObject FireBall;
	public GameObject IceSpear;

	private SpriteRenderer SpRd;

	public static PlayerController PCinstance;

	void Start()
	{
		PCinstance = this;
		FireBall = Resources.Load ("Spell\\#0_FireBall") as GameObject;
		IceSpear = Resources.Load ("Spell\\#1_IceSpear") as GameObject;
		SpRd = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		Move ();
		Shoot ();
	}

	void Move()
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");

		Vector3 HorizontalVector = Vector3.zero;
		Vector3 VerticalVector = Vector3.zero;

		if (moveVertical < 0)//아래
		{
			transform.eulerAngles = new Vector3(0, 0, 90);
			SpRd.flipX = true;
			VerticalVector = Vector3.down;
		}
		else if (moveVertical > 0)//위
		{
			transform.eulerAngles = new Vector3(0, 0, 90);
			SpRd.flipX = false;
			VerticalVector = Vector3.up;
		}
		else if (moveHorizontal < 0)//왼쪽
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			SpRd.flipX = true;
			HorizontalVector = Vector3.left;
		}
		else if (moveHorizontal > 0)//오른쪽
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
			SpRd.flipX = false;
			HorizontalVector = Vector3.right;
		}		

		transform.position += (HorizontalVector + VerticalVector) * CurrentSpeed * Time.deltaTime;
	}

	void Shoot() {
		if (Input.GetKey (KeyCode.Space)) {
			Instantiate (IceSpear, transform.position, transform.rotation).GetComponent<SpriteRenderer>().flipX = SpRd.flipX;
			//GameObject g = Instantiate (IceSpear, transform.position, transform.rotation);
			//g.GetComponent<SpriteRenderer> ().flipX = SpRd.flipX;
		}
	}
}