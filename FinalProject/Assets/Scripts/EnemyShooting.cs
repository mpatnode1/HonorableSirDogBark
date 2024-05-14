using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    /*
     This code was made with demo:
     3D Platformer in Unity - Enemy Shooting Tutorial by Kozmobot Games
     https://www.youtube.com/watch?v=k1kOtaM2NJg
    */

    [SerializeField] private float timer = 3;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    Animator animator;
    

    // Update is called once per frame
    void Update()
    {
        shootAtPlayer();
        animator = GetComponent<Animator>();
    }

    void shootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0)
        {
            //animator.SetBool("BossThrowing", false);
            return;
        } 

        bulletTime = timer;
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        //animator.SetBool("BossThrowing", true);
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 1f);

    }
}
