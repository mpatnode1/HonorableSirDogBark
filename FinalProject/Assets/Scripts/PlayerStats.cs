using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats instance;

    private int playerScore { get; set; }
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    private int playerHealth { get; set; }
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }

    public string PlayerHealthDisplay = "♥♥♥";

    [SerializeField] GameObject Player;
    [SerializeField] AudioSource playerDamage;

    void Start()
    {
        playerHealth = 3;
        
    }
    public static PlayerStats Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void PlayerLoseHealth()
    {
        //if player loses health change display and count
        playerHealth -= 1;
        PlayerHealthDisplay = "";
        playerDamage.Play();

        for (int i = 0; i < playerHealth; i++)
        {
            PlayerHealthDisplay += "♥";
        }

        CheckDeath();
    }


    public void CheckDeath()
    {
        if(playerHealth == 0)
        {
            PlayerPrefs.SetInt("PlayerScore", playerScore);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");

        }
    }

    [ContextMenu("KillTest")]
    public void KillTest()
    {
        SceneManager.LoadScene("GameOver");
        
    }
}
