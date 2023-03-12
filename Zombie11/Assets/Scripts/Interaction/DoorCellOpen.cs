using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCellOpen : Interaction
{    
    public GameObject door;
    
    public override void DoAction()
    {
        //interacive action
        door.GetComponent<Animation>().Play("DoorOpenAnim");
        AudioManager.instance.Play("CreakyDoor");
    }
}
