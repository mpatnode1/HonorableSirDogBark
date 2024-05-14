using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoguePatrol : MonoBehaviour
{
    /*
  This script originated from
  Enemy Patrolling Unity Tutorial Demo by MoreBBlakeyyy
  https://www.youtube.com/watch?v=4mzbDk4Wsmk
 */
    public Transform[] patrolPoints;
    public int TargetPoint;
    public float Speed;
    [SerializeField] int RogueSelect;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        TargetPoint = 0;
        animator.SetInteger("RogueSelect", RogueSelect);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[TargetPoint].position)
        {
            transform.Rotate(0, 180, 0, Space.Self);
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[TargetPoint].position, Speed * Time.deltaTime);

    }

    void increaseTargetInt()
    {
        TargetPoint++;
        if (TargetPoint >= patrolPoints.Length)
        {
            TargetPoint = 0;
        }

    }
}
