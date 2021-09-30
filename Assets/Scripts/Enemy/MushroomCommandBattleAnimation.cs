using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCommandBattleAnimation : MonoBehaviour
{
    Animation m_anim;
    void Start()
    {
        m_anim = gameObject.GetComponent<Animation>();
    }

    public void AttackAnim()
    {
        m_anim.Play("Attack");
    }
    public void DamageAnim()
    {
        m_anim.Play("Damage");
    }
    public void DeathAnim()
    {
        m_anim.Play("Death");
    }
}
