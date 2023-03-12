using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : Enemy
{
    public override void Die()
    {
        base.Die();

        //����� ����
        AudioManager.instance.PlayBgm("SHAmb");
    }
}