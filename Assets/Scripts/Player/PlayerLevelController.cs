using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLevelController")]
public class PlayerLevelController : ScriptableObject
{
    [SerializeField] List<PlayerLevel> m_players = new List<PlayerLevel>();
    public PlayerLevel GetData(int num) => m_players[num];
}
/// <summary>プレイヤーのステータスのデータ</summary>
[System.Serializable]
public class PlayerLevel
{
    [SerializeField] string m_levelName;
    [SerializeField] int m_level;
    public int Level { get => m_level; }

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
    [SerializeField] int m_maxExp;
    public int MaxExp { get => m_maxExp; }
}

