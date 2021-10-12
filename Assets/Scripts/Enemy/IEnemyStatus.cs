using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStatus
{
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
    public int MaxMP { get; set; }
    public int CurrentMP { get; set; }
    public int AttackPow { get; set; }
    public int MagicPow { get; set; }
    public int DefensivePower { get; set; }
    public int Agility { get; set; }
    public int MaxAgility { get; set; }
    public int Exp { get; set; }
    void ReceiveDamage(int damage);
}
