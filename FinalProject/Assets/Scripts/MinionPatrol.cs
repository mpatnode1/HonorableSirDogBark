using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionPatrol : MonoBehaviour
{
    /*
     This script originated from
     Enemy Patrolling Unity Tutorial Demo by MoreBBlakeyyy
     https://www.youtube.com/watch?v=4mzbDk4Wsmk
    */

    public Transform[] patrolPoints;
    public int TargetPoint;
    public float Speed;
    


    // Start is called before the first frame update
    void Start()
    {
        TargetPoint = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[TargetPoint].position)
        {

            transform.Rotate(-0, -90, 0, Space.Self);
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[TargetPoint].position, Speed * Time.deltaTime);
       
    }

    void increaseTargetInt()
    {
        TargetPoint++;
        if(TargetPoint >= patrolPoints.Length)
        {
            TargetPoint = 0;
        }
        
    }
}
