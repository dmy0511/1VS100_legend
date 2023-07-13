using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public void RankSceneLoad(string Ranking)
    {
        SceneManager.LoadScene(Ranking);
    }

    public void LogInSceneLoad(string Nickname)
    {
        SceneManager.LoadScene(Nickname);
    }
}
