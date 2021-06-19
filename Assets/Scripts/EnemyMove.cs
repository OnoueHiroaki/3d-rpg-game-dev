using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private float m_enemySpeed = 0f;
    bool m_isActive = false;
    NavMeshAgent m_navMesh;
    Rigidbody m_rb;
    Animator m_anim;


    void Start()
    {
        m_navMesh = GetComponent<NavMeshAgent>();
        m_rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
        m_navMesh.updatePosition = true;
        m_navMesh.updateRotation = false;
    }


    void Update()
    {
        if (m_isActive)
        {
            m_navMesh.isStopped = false;

            if (m_target != null)
            {
                m_navMesh.SetDestination(m_target.position);
            }
            if (m_navMesh.remainingDistance > m_navMesh.stoppingDistance)
            {
                m_rb.MovePosition(m_navMesh.desiredVelocity);
                this.transform.LookAt(m_target.transform);
            }
            else
            {
                m_rb.MovePosition(Vector3.zero);
            }
        }
        else
        {
            //m_rb.MovePosition(Vector3.zero);
            m_navMesh.isStopped = true;
            return;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_isActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_isActive = false;
        }
    }
    public void SetTarget(Transform tatget)
    {
        this.m_target = tatget;
    }
    void MoveAnimation()
    {

    }
}
