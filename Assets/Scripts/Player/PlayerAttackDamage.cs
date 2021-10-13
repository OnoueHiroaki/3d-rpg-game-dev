using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour
{

    public void GetAttackDamage(int m_attackPow, int magicDamage)
    {
        var damage = EnemyGenerator.Instance.EnemyList[EnemyGenerator.Instance.SelectNum].GetComponent<IDamagable>();
        EnemyGenerator.Instance.EnemyList[EnemyGenerator.Instance.SelectNum].
        ReceiveDamage(damage.AddDamage
        (m_attackPow, magicDamage, enemyTarget.MushroomEnemy[EnemyGenerator.Instance.SelectNum].DefensivePower));
    }
}
