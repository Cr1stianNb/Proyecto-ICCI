using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public SpriteRenderer theSR;

    public Transform PlayerPosition;

    public float distanceToAttackPlayer, chaseSpeed;

    private Vector3 attackTarget;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }

        PlayerPosition = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, PlayerPosition.position) > distanceToAttackPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[currentPoint].position) < .05f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }

        if(transform.position.x < points[currentPoint].position.x)
        {
            theSR.flipX = true;
        } else if(transform.position.x > points[currentPoint].position.x)
        {
            theSR.flipX = false;
        }
        }
        else
        {
            //atacando al jugador
            if(attackTarget == Vector3.zero)
            {
                attackTarget = PlayerPosition.position;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);
        }
        
            
    }
}
