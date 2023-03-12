using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mutant : Enemy
{    
    public void GoBack()
    {
        if (isDeath)
            return;

        ChangeState(EnemyState.WALK);
        if (isPatrol)
        {
            agent.SetDestination(wayPoints[wayIndex].position);
        }
        else
        {
            agent.SetDestination(startPos);
        }
    }
}
