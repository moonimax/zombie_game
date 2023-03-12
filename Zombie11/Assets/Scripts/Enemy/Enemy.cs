using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //�÷��̾� ĳ����
    private Transform thePlayer;

    protected NavMeshAgent agent;

    //���� ���� ����
    private EnemyState eState = EnemyState.IDEL;

    [HideInInspector]
    public float health;
    public float startHealth = 20;

    //�ߺ� �״°� üũ
    protected bool isDeath = false;

    //����    
    public float attackRange = 3.0f;
    public float attackDamage = 5f;

    //ó�� �����Ҷ� Enemy�� ��ġ����
    protected Vector3 startPos;

    //waypoints
    public bool isPatrol = false; //��Ʈ�� Ÿ�� üũ
    public Transform[] wayPoints;
    public int wayIndex = 0;

    private void Start()
    {
        //�÷��̾� ������Ʈ ��������
        thePlayer = GameObject.FindWithTag("Player").transform;

        agent = this.GetComponent<NavMeshAgent>();
        startPos = this.transform.position;

        health = startHealth;
        if (isPatrol)
        {
            ChangeState(EnemyState.WALK);

            //��ǥ���� ����
            wayIndex = 0;
            agent.SetDestination(wayPoints[wayIndex].position);
        }
        else
        {
            ChangeState(EnemyState.IDEL);
        }
    }


    public void ChangeState(EnemyState newState)
    {
        if (eState == newState)
            return;

        this.eState = newState;
        if (newState == EnemyState.CHASE)
        {
            this.GetComponent<Animator>().SetInteger("eState", 1); //�ȴ� �ִϸ��̼�
        }
        else
        {
            this.GetComponent<Animator>().SetInteger("eState", (int)eState);
        }
        agent.ResetPath();
    }

    private void Update()
    {
        if (isDeath)
            return;

        //�÷��̾�� Enemy���� �Ÿ��� �̿��Ͽ� ���� ó��
        float distance = Vector3.Distance(thePlayer.position, transform.position);
        if (distance <= attackRange)
        {
            ChangeState(EnemyState.ATTACK);
        }

        switch (eState)
        {
            case EnemyState.WALK:
                //��ǥ������ �����ߴ��� üũ
                if(agent.velocity.sqrMagnitude >= 0.2f*0.2f && agent.remainingDistance <= 0.2f)
                {
                    if (isPatrol)
                    {
                        GetNextPoint();
                    }
                    else
                    {
                        ChangeState(EnemyState.IDEL);
                    }
                }
                break;

            case EnemyState.ATTACK:
                if (distance > attackRange)
                {
                    ChangeState(EnemyState.CHASE);
                }
                break;

            case EnemyState.CHASE:
                agent.SetDestination(thePlayer.position);
                break;
        }
    }

    private void GetNextPoint()
    {
        wayIndex++;
        if(wayIndex >= wayPoints.Length)
        {
            wayIndex = 0;
        }
        agent.SetDestination(wayPoints[wayIndex].position);
    }

    public void Chaser()
    {
        if (isDeath)
            return;

        ChangeState(EnemyState.CHASE);
    }

    public void Attack()
    {
        //���๮
        thePlayer.GetComponent<Player>().TakeDamage(attackDamage);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f && !isDeath)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        isDeath = true;
        ChangeState(EnemyState.DEATH);

        this.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 5f);
    }

}


public enum EnemyState
{
    IDEL,
    WALK,
    ATTACK,
    DEATH,
    CHASE,
}