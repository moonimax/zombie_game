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
            //È¹µæ È¿°ú
            PlayerStats.instance.AddAmmor(giveAmmor);            

            //È¹µæ¿ÀºêÁ§Æ® Å³
            Destroy(gameObject);
        }
    }

}
