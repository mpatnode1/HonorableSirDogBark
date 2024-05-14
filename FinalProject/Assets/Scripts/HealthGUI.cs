using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthGUI : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = PlayerStats.Instance.PlayerHealthDisplay.ToString();
    }
}

