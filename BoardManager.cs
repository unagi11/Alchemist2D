using UnityEngine;
using System;
using System.Collections.Generic;
using random = UnityEngine.Random;

using TileSpace;

public class BoardManager : MonoBehaviour
{
	public GameObject[] Tile;//바닥에 깔리는 tiles;
	public GameObject[] Unit;//바닥 위에 깔리는 Unit;

	private Transform boardHolder;
	private int[,] tileMap;//floor만 깔아둔다.

	void BoardSetup(int cols, int rows)
	{
		int tileNumber, tileState;
		Tile instanceTileSC;//인스턴스화 한 타일의 Solid 혹은 Fluid코드를 Tile로 업캐스팅한다.
		boardHolder = new GameObject("Board").transform;

		for (int y = 0; y < rows; y++)//10
		{
			for (int x = 0; x < cols; x++)//16
			{
				tileNumber = tileMap [y, x] / 10;//10의 자리 = 타일 번호
				tileState = tileMap [y, x] % 10;//1의 자리 = 상태 번호호

				GameObject toInstantiate = Tile [tileNumber];
				GameObject instance = Instantiate(toInstantiate, Vector3.zero , Quaternion.identity);
				instanceTileSC = instance.GetComponent<Tile> ();
				instanceTileSC.SetState(tileState);//tileState만 입력한다. tileNumber는 이미 입력되어있다.
				instanceTileSC.SetLocation(x, rows - y - 1);

				instance.transform.SetParent (boardHolder);
			}
		}

		Instantiate (Unit [0], new Vector3 (1, 1, 0), Quaternion.identity);

		for (int y = 0; y < rows; y++)//10
		{
			for (int x = 0; x < cols; x++)//16
			{
				instanceTileSC = boardHolder.GetChild (x + (rows - y - 1) * cols).GetComponent<Tile> ();//실제로는 0번째가 (9, 0)이다. 그래서 (0,0)부터 시작하기 위해서 저렇게 된다.
				if (instanceTileSC.tileY != 0) {//맨아래가 아니면
					instanceTileSC.downT = boardHolder.GetChild (x + (rows - y) * cols).gameObject;
				} if (instanceTileSC.tileX != 0) {//맨왼쪽이 아니면
					instanceTileSC.leftT = boardHolder.GetChild (x - 1 + (rows - y - 1) * cols).gameObject;
				} if (instanceTileSC.tileY != rows - 1) {//맨 위 아니라면
					instanceTileSC.upT = boardHolder.GetChild (x + (rows - y - 2) * cols).gameObject;
				} if (instanceTileSC.tileX != cols - 1) {//맨 오른쪽이 아니라면
					instanceTileSC.rightT = boardHolder.GetChild (x + 1 + (rows - y - 1) * cols).gameObject;
				}
			}
		}

	}

	public void SetupScene(int [,] map)
	{
		tileMap = map;
		/*사실 floor를 원소로 갖는 자료구조 list를 이용해서 할까도 생각했지만,
		 * 맵을 쉽게 수정할수 있을지 모르겠어서 그냥 포기 */
		Tile = Resources.LoadAll<GameObject>("Tile");
		Unit = Resources.LoadAll<GameObject>("Unit");

		BoardSetup(map.Length/map.GetLength(0), map.GetLength(0));//cols : 16, rows : 10
	}
}
