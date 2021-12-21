using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed = 1;
    [SerializeField]
    public Animator anim;
    [SerializeField]
    Rigidbody2D rb;

    float move;

    bool moveLeft;
    bool moveRight;



    public void PointerDownLeft()
    {
        move = -1;
        Debug.Log("LeftDown");
    }



    public void PointerUpLeft()
    {
        Debug.Log("LeftUp");
        move = 0;
    }



    public void PointerDownRight()
    {
        move = 1;
        moveRight = true;
    }



    public void PointerUpRight()
    {
        move = 0;
        moveRight = false;
    }



    void Update()
    {
        move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * MovementSpeed;
        if(!Mathf.Approximately(0, move))
        {
            transform.rotation = move < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }
}
