using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayerStats.Instance.PlayerScore += 1;
            Debug.Log("You've hit an enemy!");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Boss")
        {
            PlayerStats.Instance.PlayerScore += 3;
            Debug.Log("You've hit the boss!");
            Animator bossAnimator = other.gameObject.GetComponent<Animator>();
            bossAnimator.SetBool("BossDead", true);
            deathCounter();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }

    void deathCounter()
    {
        int timer = 500;
        while (timer > 0)
        {
            timer--;
        }
    }
}
