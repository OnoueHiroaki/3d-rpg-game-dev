using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerLevelController : ScriptableObject
{
    [SerializeField] int[] m_level;
    [SerializeField] int[] m_maxHP;
    [SerializeField] int[] m_maxMP;
    [SerializeField] int[] m_agility;
    [SerializeField] int[] m_defence;
}
