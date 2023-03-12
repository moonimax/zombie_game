using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmorBox : MonoBehaviour
{
    public int giveAmmor = 7;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //ȹ�� ȿ��
            PlayerStats.instance.AddAmmor(giveAmmor);            

            //ȹ�������Ʈ ų
            Destroy(gameObject);
        }
    }

}
