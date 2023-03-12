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
        //��,�� �¿�� moveSpeed�� �̵� : ȭ��ǥ �Ǵ� wsad Ű �Է� �޾�
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3 (dx, 0f, dy);
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

        RaycastHit hit;
        //Physics.Raycast (�������� �߻��� ��ġ����, �������� �߻��� ����, �浹 ���, �ִ�Ÿ�)
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //�������� ������Ʈ�� �浹�ϸ� true�� ��ȯ�ؼ� ����
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
