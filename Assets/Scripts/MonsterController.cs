using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float speed = 0.007f;

    float togDirTime = 0f; // togTime > tunrTime => ������ȯ
    float turnTime;
    float maxTurnTime = 8f;
    float minTurnTime = 1.5f;

    float currentTime = 0f; // cur > change => Idle <-> Move
    float changeTime; // Idle <-> Move �ð�
    float minIMTime = 3.5f;
    float maxIMTime = 5f;

    Vector2 dir = Vector2.right;
    Define.MonsterState monsterState = Define.MonsterState.Idle;
    public Transform target;
    Rigidbody2D rigid;
    void Start()
    {
        turnTime = Random.Range(minTurnTime, maxTurnTime);
        changeTime = Random.Range(minIMTime, maxIMTime);
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (monsterState)
        {
            case Define.MonsterState.Idle: UpdateIdle(); break;
            case Define.MonsterState.Move: UpdateMove(); break;
            case Define.MonsterState.Chase: UpdateChase(); break;
            case Define.MonsterState.Attack: UpdateAttack(); break;
        }
    }

    void UpdateIdle()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= changeTime)
            ChangeBetweenIdleMove(Define.MonsterState.Move);
        if (PlayerController.IsBulbOn())
        {
            monsterState = Define.MonsterState.Chase;
            speed = 0.012f;
        }
    }
    void UpdateMove() // �����ð��� �����ų� ���� �ε����� ���� ��ȯ
    {
        currentTime += Time.deltaTime;
        togDirTime += Time.deltaTime;
        rigid.position += dir * speed;
        if (togDirTime >= turnTime)
            ToggleDirection();
        if (currentTime >= changeTime)
            ChangeBetweenIdleMove(Define.MonsterState.Idle, 2.5f);
        if (PlayerController.IsBulbOn())
        {
            monsterState = Define.MonsterState.Chase;
            speed = 0.012f;
        }
    }
    void UpdateChase() // ���� ������ �÷��̾� �Ѿư�
    {
        dir = (target.position - transform.position).normalized;
        dir.y = 0;
        rigid.position += dir * speed;
        if (!PlayerController.IsBulbOn())
        {
            monsterState = Define.MonsterState.Move;
            speed = 0.007f;
        }
    }
    void UpdateAttack() // ���ݹ����ȿ� �÷��̾������� ����
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            ToggleDirection();
    }

    void ToggleDirection()
    {
        togDirTime = 0f;
        turnTime = Random.Range(minTurnTime, maxTurnTime);
        dir = -dir;
    }

    void ChangeBetweenIdleMove(Define.MonsterState state, float cutTime = 0f)
    {
        monsterState = state;
        currentTime = 0f;
        changeTime = Random.Range(minIMTime - cutTime, maxIMTime - cutTime);
    }
}