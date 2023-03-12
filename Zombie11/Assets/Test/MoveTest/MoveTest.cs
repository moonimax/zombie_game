using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.LookAt(target);
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
