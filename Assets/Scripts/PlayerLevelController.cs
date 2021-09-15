using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerLevelController : ScriptableObject
{
    //プレイヤーのレベル
    [SerializeField] int m_level;
    public int Level { get { return m_level; } set { m_level = value; } }
    [SerializeField] int[] m_maxHP;
    public int MaxHP { get { return m_maxHP[m_level]; } }

    [SerializeField] int[] m_maxMP;
    public int MaxMP { get { return m_maxMP[m_level]; } }

    [SerializeField] int[] m_attackPow;
    public int AttackPow { get { return m_attackPow[m_level]; } }
    [SerializeField] int[] m_magicAttackPow;
    public int MagicAttackPow { get { return m_magicAttackPow[m_level]; } }
    [SerializeField] int[] m_defensivePower;
    public int DefensivePower { get { return m_defensivePower[m_level]; } }

    [SerializeField] int[] m_maxAgility;
    public int MaxAgility { get { return m_maxAgility[m_level]; } }

    [SerializeField] int[] m_agility;
    public int Agility { get { return m_agility[m_level]; } }
    [SerializeField] int[] m_defence;
    public int Defence { get { return m_defence[m_level]; } }
}
