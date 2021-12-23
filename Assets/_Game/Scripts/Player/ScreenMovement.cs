using UnityEngine;

public class ScreenMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    bool moveLeft;
    bool moveRight;
    public float horizontalMove;
    public float speed = 5;
    [SerializeField]
    Animator anim;



    void Start()
    {
        moveLeft = false;
        moveRight = false;
    }



    private void Update()
    {
        Movement();
    }



    public void PointerDownLeft()
    {
        moveLeft = true;
    }



    public void PointerUpLeft()
    {
        moveLeft = false;
    }



    public void PointerDownRight()
    {
        moveRight = true;
    }



    public void PointerUpRight()
    {
        moveRight = false;
    }



    private void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }

        else
        {
            horizontalMove = 0;
        }
    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (!Mathf.Approximately(0, horizontalMove))
        {
            transform.rotation = horizontalMove < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }
}
