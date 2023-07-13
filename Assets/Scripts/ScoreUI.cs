using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowui; // 점수 행을 나타내는 RowUI 객체
    public ScoreManager scoremanager;   // 점수를 관리하는 ScoreManager 객체
    public Text NicknameText;

    private void Start()
    {
        scoremanager.AddScore(new Score("A", 1)); // 예시로 ScoreManager에 점수를 추가
        scoremanager.AddScore(new Score("B", 2));
        scoremanager.AddScore(new Score("C", 5));
        scoremanager.AddScore(new Score("A", 10));
        
        ClearRows();

        var scores = scoremanager.GetHighScores().ToArray();    // 높은 점수 순으로 정렬된 Score 배열을 가져옴
        
        var displayedNames = new HashSet<string>();
        
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowui, transform).GetComponent<RowUI>();  // RowUI 객체를 생성하고 인스턴스화
            row.rank.text = (i + 1).ToString(); // 행의 등수 텍스트를 설정
            row.name.text = scores[i].name; // 행의 이름 텍스트를 설정
            row.score.text = scores[i].score.ToString();    // 행의 점수 텍스트를 설정
            
            displayedNames.Add(scores[i].name);
        }
    }
    
    private void ClearRows()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
