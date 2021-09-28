using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillBase : MonoBehaviour
{
    public abstract void MagicArrow(EnemyTarget enemyTarget ,Slider agilitySlider, Slider mPSlider);
}
