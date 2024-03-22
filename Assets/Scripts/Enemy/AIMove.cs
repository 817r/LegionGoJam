using JetBrains.Annotations;
using RDCT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMove : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    public PlayerController playerController;
    public GameObject parent;

    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; 
    public float timer; 
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange; 
    private bool cooling; 
    private float intTimer;

    public int HP;
    public int MHP;
    #endregion

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        HP = MHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP == 0)
        {
            Destroy(parent);
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
        }

        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            
        }

        if (isChasing)
        {
            anim.SetBool("Attack", true);

            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            }
            else if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        else
        {

            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }

            anim.SetBool("Attack", false);
        }

        if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance * 1.1f)
        {
            isChasing = false;
        }

        void Attack()
        {
            timer = intTimer;
            attackMode = true;
            anim.SetBool("Attack", true);
        }

        void EnemyLogic()
        {
            distance = Vector2.Distance(transform.position, target.transform.position);

            if (attackDistance >= distance)
            {
                Attack();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(playerController._counterAttack == true)
            {
                HP--;
            }
        }
    }

    public void Colldowntrigger()
    {
        cooling = true;
    }

    public void onDamageTaken()
    {
        HP--;
    }
}
