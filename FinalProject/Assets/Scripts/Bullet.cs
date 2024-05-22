using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.Instance.PlayerLoseHealth();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
