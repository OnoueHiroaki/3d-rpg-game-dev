using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;

    public void Target()
    {
        targets = GameObject.FindGameObjectsWithTag("Mushroom");
    }
}
