﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	enum tileCode{none, wall, ground, water};

	/* 2017.0f8.0f4 현재 floorCode
	 *#0: 타일 없음
	 *#1: 벽
	 *#2: 땅
	 *#3: 물(흐르는 애니메이션 포함)
	 */

	public float[,] map1 = {
		{ 1.2f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f},//0.0f,0.0f ~ 0.0f,1.0f5
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f},
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f},
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 3.0f, 3.0f, 3.0f, 3.0f, 3.3f, 3.2f, 3.1f, 3.1f, 3.1f, 1.0f},
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 3.0f, 3.0f, 3.0f, 3.0f, 3.3f, 3.2f, 3.1f, 3.1f, 3.1f, 1.0f},
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 3.0f, 3.0f, 3.0f, 3.0f, 3.3f, 3.2f, 3.1f, 3.1f, 3.1f, 1.0f},
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f},
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f},
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f},
		{ 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f}//9,0.0f ~ 9,1.0f5
	};

	public float[,] map2 = {
		{ 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f },//0.0f,0.0f ~ 0.0f,8
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 0.0f, 0.0f, 0.0f },//1.0f,0.0f ~ 1.0f,8
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f },//2.0f,0.0f ~ 2.0f,8
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 3.0f, 3.0f, 1.0f },//3.0f,0.0f ~ 3.0f,8
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 3.0f, 3.0f, 1.0f },//4,0.0f ~ 4,8
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 2.0f, 3.0f, 3.0f, 1.0f },//5,0.0f ~ 5,8
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 1.0f, 1.0f, 1.0f },//6,0.0f ~ 6,8
		{ 1.0f, 2.0f, 2.0f, 2.0f, 2.0f, 1.0f, 0.0f, 0.0f, 0.0f },//7,0.0f ~ 7,8
		{ 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f },//8,0.0f ~ 8,8
	};
}
