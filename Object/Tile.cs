using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSpace {
	public class Tile : MonoBehaviour
	{
		public int tileNumber;//타일의 번호
		public int tileState;//타일의 상태(방향이라던가 애니메이션이라던가)
		public float tileX, tileY;

		public float tileSpeed = 0f;

		public GameObject upT, downT, rightT, leftT;//Tile
		public GameObject upU, downU, rightU, leftU;//Unit

		virtual public void SetState (int number){
			//override
		}

		public void SetLocation (int X, int Y){
			tileX = X;
			tileY = Y;
			transform.position = new Vector3 (X, Y, 0f);
		}

		public Vector3 GetLocation (){
			return new Vector3 (tileX, tileY, 0f);
		}

		public void SetEnviorTile(GameObject upT, GameObject downT, GameObject rightT, GameObject leftT) {
			this.upT = upT;
			this.downT = downT;
			this.rightT = rightT;
			this.leftT = leftT;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.gameObject.tag == "Player") {
				PlayerController.PCinstance.CurrentSpeed = PlayerController.PCinstance.OriginSpeed + tileSpeed;
			}

			print (gameObject.name + ": (" + gameObject.transform.position + ")");

		}

		void OnTriggerExit2D (Collider2D other)
		{
			other.attachedRigidbody.velocity = Vector2.zero;
		}


	}
}