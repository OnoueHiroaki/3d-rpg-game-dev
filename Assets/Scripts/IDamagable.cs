using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int ReceiveDamage(int attack, int defense);
}
