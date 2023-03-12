using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyZoneOutTrigger : MonoBehaviour
{
    public Transform theMutant;

    public GameObject zoneIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            theMutant.GetComponent<Mutant>().GoBack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            zoneIn.SetActive(true);
        }
    }
}
