using UnityEngine;
using System;
using System.Collections.Generic;
using random = UnityEngine.Random;

using TileSpace;

public class BoardManager : MonoBehaviour
{
	public GameObject[] Tile;//바닥에 깔리는 tiles;
	public GameObject[] Unit;//바닥 위에 깔리는 Unit;

	public List<GameObject> TileList;

	private Transform boardHolder;
	private int[,] tileMap;//floor만 깔아둔다.

	void BoardSetup(int cols, int rows)
	{
		int tileNumber, tileState;
		Tile instanceTileSC;//인스턴스화 한 타일의 Solid 혹은 Fluid코드를 Tile로 업캐스팅한다.
		boardHolder = new GameObject("Board").transform;

		for (int x = 0; x < rows; x++)
		{
			for (int y = 0; y < cols; y++)
			{
				tileNumber = tileMap [x, y] / 10;//10의 자리 = 타일 번호
				tileState = tileMap [x, y] % 10;//1의 자리 = 상태 번호호

				GameObject toInstantiate = Tile [tileNumber];
				GameObject instance = Instantiate(toInstantiate, new Vector3(y, rows - x - 1, 0f), Quaternion.identity);

				if (toInstantiate.GetComponent<Solid> ()) {
					instanceTileSC = (Tile)instance.GetComponent<Solid> ();
					instanceTileSC.SetState(tileState);//tileState만 입력한다. tileNumber는 이미 입력되어있다.
				}
				else if (toInstantiate.GetComponent<Fluid> ()) {
					instanceTileSC = (Tile)instance.GetComponent<Fluid> ();
					instanceTileSC.SetState(tileState);
				}

				instance.transform.SetParent (boardHolder);

				TileList.Add (instance);
			}	
		}
		print (TileList.Count);

		Instantiate (Unit [0], new Vector3 (1, 1, 0), Quaternion.identity);

	}

	public void SetupScene(int [,] map)
	{
		tileMap = map;
		/*사실 floor를 원소로 갖는 자료구조 list를 이용해서 할까도 생각했지만,
		 * 맵을 쉽게 수정할수 있을지 모르겠어서 그냥 포기 */
		Tile = Resources.LoadAll<GameObject>("Tile");
		Unit = Resources.LoadAll<GameObject>("Unit");

		BoardSetup(map.Length/map.GetLength(0), map.GetLength(0));
	}
}
