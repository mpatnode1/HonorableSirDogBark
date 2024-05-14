using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinGUI : MonoBehaviour
{ 
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + PlayerStats.Instance.PlayerScore;
    }
}
