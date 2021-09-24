using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCommandBattleAnimation : MonoBehaviour
{
    [SerializeField] AnimationClip[] m_animClip;
    Animation m_anim;
    void Start()
    {
        m_anim = gameObject.GetComponent<Animation>();
    }

    public void AttackAnim()
    {
        m_anim.clip = m_animClip[1];
        m_anim.IsPlaying("Attack");
        //m_anim.Play("Attack");
    }
    public void DamageAnim()
    {
        Debug.Log(m_animClip[2]);
        m_anim.clip = m_animClip[2];
        m_anim.Play();
    }
    public void DeathAnim()
    {
        m_anim.clip = m_animClip[3];
        m_anim.Play("Death");
    }
}
