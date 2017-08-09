using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TileSpace;

public class Fluid : Tile{
	
	public bool isFlow;
	public float flowSpeed;

	private Vector2 flowVector = Vector2.zero;


	override public void SetState(int state)//오버라이딩
	{
		Animator animator = gameObject.GetComponent<Animator> ();
		tileState = state;

		switch (state) {
		case 0://흐르지 않는다.
			transform.eulerAngles = new Vector3 (0, 0, 0);
			isFlow = false;
			break;

		case 1://오른쪽으로 흐른다.
			transform.eulerAngles = new Vector3 (0, 0, 0);
			isFlow = true;
			break;

		case 2://위쪽으로 흐른다.
			transform.eulerAngles = new Vector3 (0, 0, 90);
			isFlow = true;
			break;

		case 3://왼쪽으로 흐른다.
			transform.eulerAngles = new Vector3 (0, 0, 180);
			isFlow = true;
			break;

		case 4://아래쪽으로 흐른다.
			transform.eulerAngles = new Vector3 (0, 0, 270);
			isFlow = true;
			break;
		}

		animator.SetBool ("flow", isFlow);
	}

	void OnTriggerStay2D (Collider2D other)
	{
		switch (tileState) {
		case 0://흐르지 않는다.
			return;

		case 1://오른쪽으로 흐른다.
			if (other.attachedRigidbody.velocity.x == Vector2.right.x)//오른쪽으로 힘을 받고 있다. or 다른힘도 받고 있다.
				break;
			flowVector = Vector2.right;//오른쪽으로 힘을 받고있지 않다 or 오른쪽 이외의 힘을 받고 있다.
			break;

		case 2://위쪽으로 흐른다.
			if (other.attachedRigidbody.velocity.y == Vector2.up.y)
				break;
			flowVector = Vector2.up;
			break;

		case 3://왼쪽으로 흐른다.
			if (other.attachedRigidbody.velocity.x == Vector2.left.x)
				break;
			flowVector = Vector2.left;
			break;

		case 4://아래쪽으로 흐른다.
			if (other.attachedRigidbody.velocity.y == Vector2.down.y)
				break;
			flowVector = Vector2.down;
			break;
		}
		other.attachedRigidbody.velocity = (other.attachedRigidbody.velocity.normalized + flowVector) * flowSpeed;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		print ("'" + other.gameObject.name + "' Entered in Collision '" + gameObject.name + "'");
	}
}