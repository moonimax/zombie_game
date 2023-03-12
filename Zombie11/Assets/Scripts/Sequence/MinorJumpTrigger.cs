using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class MinorJumpTrigger : MonoBehaviour
{
    public GameObject thePlayer;

    public GameObject activatorObject;
    public GameObject flyingObject;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(SequencePlayer());        
    }

    IEnumerator SequencePlayer()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<FirstPersonController>().enabled = false;

        activatorObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        activatorObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);
        thePlayer.GetComponent<FirstPersonController>().enabled = true;

        yield return new WaitForSeconds(1.0f);
        //flyingObject.SetActive(false);
    }
}
