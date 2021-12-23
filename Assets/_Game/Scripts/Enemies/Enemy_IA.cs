using UnityEngine;

public class Enemy_IA : MonoBehaviour
{
    [SerializeField] float attackDistance;  //minimo de distancia
    [SerializeField] float timer;  //Attack CD
    [SerializeField] Transform leftLimit;
    [SerializeField] Transform rightLimit;

    private Animator anim;
    private float distance; // distance entre inimigo e player
    private bool attackMode;
    private bool cooling;
    private float intTimer;

    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;

    public GameObject hotZone;
    public GameObject triggerArea;
    public float moveSpeed;



    void Awake()
    {
        SelectTarget();
        intTimer = timer; //value of timer
        anim = GetComponent<Animator>();
    }



    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }
    }



    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }



    void Move()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }



    void Attack()
    {
        timer = intTimer; //reset timer when player enter attack range
        attackMode = true; //check if enemy can still attack or not
                           //canMove = false;
                           //anim.SetBool("canWalk", false);
                           // anim.SetBool("Attack", true);
    }



    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
            // = true;
        }
    }



    public void StopAttack()
    {
        cooling = false;
        attackMode = false;
        // = true;
        //anim.SetBool("Attack", false);
    }



    public void TriggerCooling()
    {
        cooling = true;
        // = true;
    }



    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }



    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }



    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }
}
