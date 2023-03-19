using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        string highScorePlayer = ScoreManager.Instance.ScoreData.playerName;
        int score = ScoreManager.Instance.ScoreData.highScore;
        highScore.SetText("High Score : " + highScorePlayer + " : " + score);
    }

    public void StartGame ()
    {
        ScoreManager.Instance.currentPlayerName = playerName.text;
        SceneManager.LoadScene("main");
    }
}
