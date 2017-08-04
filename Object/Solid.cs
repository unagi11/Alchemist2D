using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TileSpace;

public class Solid : Tile{

	public bool blocking;

	override public void SetDirection(int number)//오버라이딩
	{
		direction = number;

		switch (number) {
		case 0:
			transform.eulerAngles = new Vector3 (0, 0, 0);
			break;

		case 1:
			transform.eulerAngles = new Vector3 (0, 0, 90);
			break;

		case 2:
			this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 180);
			break;

		case 3:
			transform.eulerAngles = new Vector3 (0, 0, 270);
			break;
		}
	}
}
