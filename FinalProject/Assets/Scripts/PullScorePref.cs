using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PullScorePref : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText;
    int playerScore;

    private void Start()
    {
        playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        playerScoreText.text = "Score: " + playerScore;
    }
}
