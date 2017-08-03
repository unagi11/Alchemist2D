using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSpace {
	public class Tile : MonoBehaviour
	{
		public int tileNumber;
		public int direction;
		//0: default
		//1: rotate z 90'
		//2: rotate z 180'
		//3: rotate z 270'

		public Tile()
		{
			tileNumber = 0;
			direction = 0;
		}
				
		public Tile(int Number, int direction)
		{
			tileNumber = Number; 
			this.direction = direction;
		}
			
		virtual public void SetDirection (int number){
			print ("hello");
		}
	}
}