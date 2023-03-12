using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //플레이어 캐릭터
    private Transform thePlayer;

    protected NavMeshAgent agent;

    //좀비 상태 변수
    private EnemyState eState = EnemyState.IDEL;

    [HideInInspector]
    public float health;
    public float startHealth = 20;

    //중복 죽는것 체크
    protected bool isDeath = false;

    //공격    
    public float attackRange = 3.0f;
    public float attackDamage = 5f;

    //처음 시작할때 Enemy의 위치정보
    protected Vector3 startPos;

    //waypoints
    public bool isPatrol = false; //패트롤 타입 체크
    public Transform[] wayPoints;
    public int wayIndex = 0;

    private void Start()
    {
        //플레이어 오브젝트 가져오기
        thePlayer = GameObject.FindWithTag("Player").transform;

        agent = this.GetComponent<NavMeshAgent>();
        startPos = this.transform.position;

        health = startHealth;
        if (isPatrol)
        {
            ChangeState(EnemyState.WALK);

            //목표지점 설정
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
            this.GetComponent<Animator>().SetInteger("eState", 1); //걷는 애니메이션
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

        //플레이어와 Enemy와의 거리를 이용하여 상태 처리
        float distance = Vector3.Distance(thePlayer.position, transform.position);
        if (distance <= attackRange)
        {
            ChangeState(EnemyState.ATTACK);
        }

        switch (eState)
        {
            case EnemyState.WALK:
                //목표지점에 도착했는지 체크
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
        //실행문
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