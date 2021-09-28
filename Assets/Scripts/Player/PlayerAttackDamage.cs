using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour
{
    public void GetAttackDamage(EnemyTarget enemyTarget ,int m_attackPow, int magicDamage)
    {
        enemyTarget.GetMushroomEnemy();
        var damage = enemyTarget.MushroomEnemy[EnemyGenerator.Instance.SelectNum].GetComponent<IDamagable>();
        enemyTarget.MushroomEnemy[EnemyGenerator.Instance.SelectNum].
        EnemyDamage(damage.ReceiveDamage
        (m_attackPow, magicDamage, enemyTarget.MushroomEnemy[EnemyGenerator.Instance.SelectNum].m_defensivePower));
    }
}
