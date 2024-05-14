using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerScore { get; set; }
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }   
}
