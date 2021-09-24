using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommandBattleAnimation : MonoBehaviour
{
    //[SerializeField] Transform[] m_enemyPosition;
    //[SerializeField] Transform m_playerPosition;
    //[SerializeField] float m_moveSpeed;
    //public Transform[] EnemyPosition { get; set; }
    //public Transform PlayerPosition { get; set; }
    //bool m_attackFlag;
    Animator m_anim;
    void Start()
    {
        m_anim = GetComponent<Animator>();
        //EnemyPosition = new Transform[EnemyGenerator.Instance.RandomNum];
        //for (int i = 0; i < EnemyPosition.Length; i++)
        //{
        //    EnemyPosition[i] = m_enemyPosition[i];
        //}
        //MovePosition(EnemyPosition[1].position);
    }
    public void MovePosition(Vector3 position)
    {
        //float move = m_moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, position, move);
    }
    public void MovePositionFinish(Vector3 position)
    {
        //float move = m_moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, position, move);
    }
    public void AttackAnimation()
    {
        m_anim.SetTrigger("Attack");
    }
    public void DamageAnimation()
    {
        m_anim.SetTrigger("Damage");
    }
}
