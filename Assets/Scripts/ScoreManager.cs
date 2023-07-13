using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;   // 점수 데이터를 저장하는 ScoreData 개체

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");   // "scores" 키로 저장된 JSON 형식의 문자열을 불러옴
        sd = JsonUtility.FromJson<ScoreData>(json); // JSON 문자열을 ScoreData 개체로 변환하여 sd에 저장
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);   // 점수를 높은 순서로 정렬하여 반환
    }

    public void AddScore(Score newScore)
    {
        foreach (Score sc in sd.scores)
        {
            if (sc.name.Equals(newScore.name))
            {
                if (sc.score < newScore.score)
                {
                    sc.score = newScore.score;
                }
                return;
            }
        }
        sd.scores.Add(newScore);   // 주어진 Score 개체를 sd에 추가        
    }

    void OnDestroy()
    {
        SaveScore();    // 게임 오브젝트가 파괴될 때 SaveScore 함수 호출하여 점수 저장
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);  // sd를 JSON 형식으로 변환
        PlayerPrefs.SetString("scores", json);  // "scores" 키로 JSON 문자열을 PlayerPrefs에 저장
    }
}
