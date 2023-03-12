using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float toTarget;

    // Update is called once per frame
    void Update()
    {
        //앞,뒤 좌우로 moveSpeed로 이동 : 화살표 또는 wsad 키 입력 받아
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3 (dx, 0f, dy);
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

        RaycastHit hit;
        //Physics.Raycast (레이저를 발사할 위치정보, 레이저를 발사할 방향, 충돌 결과, 최대거리)
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //레이저가 오브젝트와 충돌하면 true를 반환해서 실행
            toTarget = hit.distance;
        }
    }

    private void OnDrawGizmosSelected()
    {
        float maxDistance = 100f;
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, maxDistance);
        Gizmos.color = Color.red;
        if (isHit)
        {
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
