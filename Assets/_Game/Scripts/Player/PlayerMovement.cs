using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float MovementSpeed = 1;
    [SerializeField]
    public Animator anim;
    public float move = Input.GetAxis("Horizontal");

    void Start()
    {
        move = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(move));
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * MovementSpeed;
        if(!Mathf.Approximately(0, move))
        {
            transform.rotation = move < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }
}
