using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(dx, 0f, dy);
        if (dir != Vector3.zero)
        {
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

            if (dy > 0) //전진
            {
                animator.SetInteger("MoveMode", 1);
            }
            if (dy < 0) //후진
            {
                animator.SetInteger("MoveMode", 2);
            }
            if (dx > 0) //오른쪽
            {
                animator.SetInteger("MoveMode", 3);
            }
            if(dx < 0) //왼쪽
            {
                animator.SetInteger("MoveMode", 4);
            }
        }
        else
        {
            animator.SetInteger("MoveMode", 0);
        }
    }
}
