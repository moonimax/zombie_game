using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneInTrigger : MonoBehaviour
{
    public Transform theMutant;

    public GameObject zoneOut;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            theMutant.GetComponent<Mutant>().Chaser();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            zoneOut.SetActive(true);
        }
    }
}
