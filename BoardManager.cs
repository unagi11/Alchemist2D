using UnityEngine;
using System;
using System.Collections.Generic;
using random = UnityEngine.Random;

using TileSpace;

public class BoardManager : MonoBehaviour
{
	public GameObject[] floorTiles;//바닥에 깔리는 tiles;
	public GameObject[] unit;//바닥 위에 깔리는 tiles;

	private Transform boardHolder;
	private float[,] tileMap;//floor만 깔아둔다.

	void BoardSetup(int cols, int rows)
	{
		boardHolder = new GameObject("Board").transform;
		for (int x = 0; x < rows; x++)
		{
			for (int y = 0; y < cols; y++)
			{
				int tileNum, directNum;
				Tile SC;
				if (tileMap [x, y] == 0.0)
					continue;
				else{
					tileNum = (int)(tileMap [x, y] - tileMap [x, y] % 1);
					directNum = (int)((tileMap [x, y] % 1) * 10);
				//	print (tileNum+ ""+ directNum);
				}
				GameObject toInstantiate = null;
				toInstantiate = floorTiles [tileNum];

				GameObject instance = Instantiate(toInstantiate, new Vector3(y, rows - x - 1, 0f), Quaternion.identity);
				instance.transform.SetParent (boardHolder);

				if (toInstantiate.GetComponent<Solid> ()) {
					SC = (Tile)toInstantiate.GetComponent<Solid> ();
					SC.SetDirection(directNum);
				}
				else if (toInstantiate.GetComponent<Fluid> ()) {
					
					SC = (Tile)toInstantiate.GetComponent<Fluid> ();
					SC.SetDirection(directNum);
				}
			}
		}

		Instantiate (unit [0], new Vector3 (1, 1, 0), Quaternion.identity);
	}


	public void SetupScene(float [,] map)
	{
		tileMap = map;
		/*사실 floor를 원소로 갖는 자료구조 list를 이용해서 할까도 생각했지만,
		 * 맵을 쉽게 수정할수 있을지 모르겠어서 그냥 포기 */

		BoardSetup(map.Length/map.GetLength(0), map.GetLength(0));
	}
}
