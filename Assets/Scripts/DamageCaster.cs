using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCaster : MonoBehaviour
{
    
    void Start()
    {

    }

    void Update()
    {

    }
    public void EnemyDamage(int hp,int player,int enemy)
    {
        hp -= player - enemy / 2;
    }
    public void EnemyDamage(Slider hp,int player,int enemy)
    {
        hp.value -= player - enemy / 2;
    }
    //public void EnemyDamageText(Text hp)
    //{
    //    hp.text = string.Format("HP        ", m_player.m_playerCurrentHp);
    //}
    public void PlayerDamage(int hp,int enemy,int player)
    {
        hp -= enemy - player / 2;
    }
    public void PlayerDamage(Slider hp, int enemy, int player)
    {
        hp.value -= enemy - player / 2;
    }
    public void EndAttack(Slider agility)
    {
        agility.value = 0;
    }
}
