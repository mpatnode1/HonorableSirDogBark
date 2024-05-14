using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] int PointAmount;
    [SerializeField] AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats.Instance.PlayerScore += PointAmount;
        coinSound.Play();
        gameObject.SetActive(false);
    }
}
