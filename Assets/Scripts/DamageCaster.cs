using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{

    public int PlayerNormalAttack(int attack, int defense) => attack - defense / 2;

    public int EnemyNormalAttack(int attack, int defense) => attack - defense / 2;

    public int PlayerMagicArrowAttack(int attack, int defense) => attack + 5 - defense / 2;

}
public interface IDamage
{
    int ReceiveDamage(int attack, int defense);
}
