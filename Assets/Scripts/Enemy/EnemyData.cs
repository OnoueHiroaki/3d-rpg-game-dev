using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] List<Enemies> m_enemies = new List<Enemies>();
    public Enemies GetData(int num) => m_enemies[num];
}
/// <summary>プレイヤーのステータスのデータ</summary>
[System.Serializable]
public class Enemies
{
    [SerializeField] string m_enemyName;
    [SerializeField] int m_maxHP;
    public int MaxHP { get => m_maxHP; }

    [SerializeField] int m_maxMP;
    public int MaxMP { get => m_maxMP; }

    [SerializeField] int m_attackPow;
    public int AttackPow { get => m_attackPow; }
    [SerializeField] int m_magicAttackPow;
    public int MagicAttackPow { get => m_magicAttackPow; }

    [SerializeField] int m_maxAgility;
    public int MaxAgility { get => m_maxAgility; }

    [SerializeField] int m_agility;
    public int Agility { get => m_agility; }
    [SerializeField] int m_defense;
    public int Defense { get => m_defense; }
    [SerializeField] int m_Exp;
    public int Exp { get => m_Exp; }
}
