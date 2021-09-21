using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentBase")]
public class EquipmentBase : ScriptableObject
{
    [SerializeField] List<Equipments> m_equipments = new List<Equipments>();
    public Equipments GetData(int num) => m_equipments[num];
}
[System.Serializable]
public class Equipments
{
    [SerializeField] string m_equipmentName;
    [SerializeField] int m_attackPow;
    [SerializeField] int m_defensePow;
    public string EquipmentName { get => m_equipmentName; }
    public int AttackPower { get => m_attackPow; }
    public int DefensePower { get => m_defensePow; }
}
