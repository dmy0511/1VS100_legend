using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string name; // 점수를 가진 개체의 이름을 저장하는 문자열 변수
    public float score; // 실제 점수를 저장하는 부동 소수점 변수

    public Score(string name, float score)
    {
        this.name = name;   // 생성자를 통해 이름과 점수를 받아와서 멤버 변수에 할당
        this.score = score;
    }
}
