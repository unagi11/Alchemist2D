using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TileSpace;

public class Fluid : Tile{
	
	public bool isFlow;

	override public void SetDirection(int number)//오버라이딩
	{
		Animator animator = gameObject.GetComponent<Animator> ();
		Transform tf = transform;
		direction = number;
		switch (number) {
				case 0:
			tf.eulerAngles = new Vector3 (0, 0, 0);
			animator.SetBool ("flow", false);
			print (number);
			break;
		case 1:
			tf.eulerAngles = new Vector3 (0, 0, 0);
			animator.SetBool ("flow", true);
			print (number);
			break;

		case 2:
			tf.eulerAngles = new Vector3 (0, 0, 90);
			animator.SetBool ("flow", true);
			print (number);
			break;

		case 3:
			tf.eulerAngles = new Vector3 (0, 0, 180);
			animator.SetBool ("flow", true);
			print (number);
			break;

		case 4:
			tf.eulerAngles = new Vector3 (0, 0, 270);
			animator.SetBool ("flow", true);
			print (number);
			break;
		}
	}
}