using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : Enemy
{
    public override void Die()
    {
        base.Die();

        //배경음 변경
        AudioManager.instance.PlayBgm("SHAmb");
    }
}
