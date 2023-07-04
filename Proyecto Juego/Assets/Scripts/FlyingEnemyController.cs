using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public SpriteRenderer theSR;

    public GameObject[] players;
    public Transform PlayerPosition;

    public float distanceToAttackPlayer, chaseSpeed;

    private Vector3 attackTarget;

    public float waitAfterAttack;
    private float attackCounter;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }

        //players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            foreach(GameObject player in players)
            {
                PlayerPosition = player.transform;
                if (Vector3.Distance(transform.position, PlayerPosition.position) > distanceToAttackPlayer)
                {

                    attackTarget = Vector3.zero;

                    transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, points[currentPoint].position) < .05f)
                    {
                        currentPoint++;

                        if (currentPoint >= points.Length)
                        {
                            currentPoint = 0;
                        }
                    }

                    if (transform.position.x < points[currentPoint].position.x)
                    {
                        theSR.flipX = true;
                    }
                    else if (transform.position.x > points[currentPoint].position.x)
                    {
                        theSR.flipX = false;
                    }
                }
                else
                {
                    //atacando al jugador
                    if (attackTarget == Vector3.zero)
                    {
                        attackTarget = PlayerPosition.position;
                    }

                    transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                    {
                        attackCounter = waitAfterAttack;
                        attackTarget = Vector3.zero;
                    }

                }
            }
            
        }


        
        
            
    }
}
