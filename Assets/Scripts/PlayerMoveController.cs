using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    Animator animator;
    public float x;
    public float y;
    public float lastX;
    public float lastY;
    bool moving = false;
    public bool moveMode = true;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveMode)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
            rigid.velocity = new Vector2(x * speed, y * speed);

            if (x > 0 || x < 0 || y > 0 || y < 0)
            {
                lastX = x;
                lastY = y;
                moving = true;
            }
            else if (x == 0 || y == 0)
            {
                moving = false;
            }
            if (moving == false)
            {
                animator.SetFloat("lastX", lastX);
                animator.SetFloat("lastY", lastY);
            }
            animator.SetBool("moving", moving);

            animator.SetFloat("x", x);
            animator.SetFloat("y", y);
        }

    }
}
