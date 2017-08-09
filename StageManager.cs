﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	enum tileCode{none, wall, ground, water};

	/* 20170804 현재 floorCode
	 *#0: 타일 없음
	 *#1: 벽
	 *#2: 땅
	 *#3: 물(흐르는 애니메이션 포함)
	 */

	public int[,] map1 = {
		{ 12, 10, 10, 10, 10, 10, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},//00,00 ~ 00,105
		{ 10, 20, 20, 20, 20, 10, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
		{ 10, 20, 20, 20, 20, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10},
		{ 10, 20, 20, 20, 20, 20, 30, 30, 30, 30, 33, 33, 33, 33, 33, 10},
		{ 10, 20, 20, 20, 20, 20, 30, 30, 30, 30, 30, 30, 30, 30, 32, 10},
		{ 10, 20, 20, 20, 20, 20, 31, 31, 31, 31, 31, 31, 31, 31, 32, 10},
		{ 10, 20, 20, 20, 20, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10},
		{ 10, 20, 20, 20, 20, 10, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
		{ 10, 20, 20, 20, 20, 10, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00},
		{ 10, 10, 10, 10, 10, 12, 00, 00, 00, 00, 00, 00, 00, 33, 32, 31}//9,00 ~ 9,105
	};

	public int[,] map2 = {
		{ 10, 10, 10, 10, 10, 10, 00, 00, 00 },//00,00 ~ 00,8
		{ 10, 20, 20, 20, 20, 10, 00, 00, 00 },//10,00 ~ 10,8
		{ 10, 20, 20, 20, 20, 10, 10, 10, 10 },//20,00 ~ 20,8
		{ 10, 20, 20, 20, 20, 20, 30, 30, 10 },//30,00 ~ 30,8
		{ 10, 20, 20, 20, 20, 20, 30, 30, 10 },//4,00 ~ 4,8
		{ 10, 20, 20, 20, 20, 20, 30, 30, 10 },//5,00 ~ 5,8
		{ 10, 20, 20, 20, 20, 10, 10, 10, 10 },//6,00 ~ 6,8
		{ 10, 20, 20, 20, 20, 10, 00, 00, 00 },//7,00 ~ 7,8
		{ 10, 10, 10, 10, 10, 10, 00, 00, 00 },//8,00 ~ 8,8
	};
}
