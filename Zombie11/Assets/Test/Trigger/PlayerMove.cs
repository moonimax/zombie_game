using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//좌우로 이동하는 스크립트 작성
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float moveForce = 200f;

    private Rigidbody rb;
    private float moveX;

    private Color originColor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originColor = this.GetComponent<Renderer>().material.color;
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * moveX * moveSpeed);
    }

    public void SetPlayerColor(Color _color)
    {
        this.GetComponent<Renderer>().material.color = _color;
    }

    public void ResetPlayerColor()
    {
        this.GetComponent<Renderer>().material.color = originColor;
    }

    public void PlayerMoveRight()
    {
        rb.AddForce(Vector3.right * moveForce);
    }

    public void PlayerMoveLeft()
    {
        rb.AddForce(Vector3.left * moveForce);
    }
}
