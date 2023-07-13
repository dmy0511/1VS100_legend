using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<Score> scores;  // 점수 목록을 저장하는 Score 객체의 리스트

    public ScoreData()
    {
        scores = new List<Score>(); // Score 객체의 리스트를 초기화하는 생성자
    }
}
