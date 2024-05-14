using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScreen");
            PlayerPrefs.SetInt("PlayerScore", PlayerStats.Instance.PlayerScore);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //gameObject.SetActive(false);
            SceneManager.LoadScene("WinScreen");
        }


    }
}
