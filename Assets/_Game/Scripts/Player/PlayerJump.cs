using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerJump : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField]
    float jumpForce;

    [Header("Others")]
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Animator anim;
    [SerializeField]
    Rigidbody2D rb2d;

    int extraJumps = 1;

    void Update()
    {
        //anim.SetBool("isJumping", rb2d.velocity.y != 0);
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            extraJumps = 1;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
        else if (extraJumps > 0 && !IsGrounded())
        {
            rb2d.velocity = Vector2.up * jumpForce;
            extraJumps -= 1;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

}
