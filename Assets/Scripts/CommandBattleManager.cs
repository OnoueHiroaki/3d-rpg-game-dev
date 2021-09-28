using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandBattleManager : MonoBehaviour
{
    [SerializeField] Animator m_firstPanel;
    [SerializeField] Animator m_secondPanel;

    [SerializeField] EnemyGenerator m_enemyGenerator;
    [SerializeField] EnemyUIGenerator m_enemyUIGenerator;
    [SerializeField] PlayerCommandBattleAnimation m_playerAnim;
    [SerializeField] PlayerLevelController m_playerLevelController;

    [SerializeField] GetExp m_getExp;
    [SerializeField] GameObject m_winPanel;
    [SerializeField] TextManager m_textManager;
    [SerializeField] UIManager m_uIManager;

    [SerializeField] MushroomCommandBattleAnimation m_mushAnim;
    [SerializeField] EnemyTarget m_enemyTarget;
    [SerializeField] PlayerAttackDamage m_playerAttackDamage;
    [SerializeField] PlayerSliderUpdate m_playerSliderUpdate;

    PlayerHPChange m_playerHPChange;
    EnemyUI[] m_enemyUI;
    MushroomEnemyStatus[] m_mushroomEnemy;
    PlayerStatus m_player;
    Slider[] m_enemyHPSlider = default;
    Slider[] m_enemyAgilitySlider = default;
    bool flag1;
    bool flag2;
    bool flag3;

    void Start()
    {
        m_enemyUI = new EnemyUI[EnemyGenerator.Instance.RandomNum];
        m_enemyHPSlider = new Slider[EnemyGenerator.Instance.RandomNum];
        m_enemyAgilitySlider = new Slider[EnemyGenerator.Instance.RandomNum];
        m_mushroomEnemy = new MushroomEnemyStatus[EnemyGenerator.Instance.RandomNum];

        m_player = PlayerStatus.Instance;
        m_playerHPChange = PlayerHPChange.Instance;
        m_playerHPChange.PlyerStatusChange(m_player, m_playerLevelController);

        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyUI[i] = m_enemyUIGenerator.EnemyUIArray[i].GetComponent<EnemyUI>();
            m_mushroomEnemy[i] = m_enemyGenerator.EnemyList[i]
            .GetComponent<MushroomEnemyStatus>();
        }
        GetEnemyHPSlider();
        GetEnemyAgilitySlider();
        m_winPanel.gameObject.SetActive(false);
        SecondPanelInactive();
        m_playerSliderUpdate.PlayerUI();
        StartEnemyUI();

        m_player.OnPlayeHPChange += m_playerSliderUpdate.PlayerHPSliderUpdate;
        m_player.OnPlayerMPChange += m_playerSliderUpdate.PlayerMPSliderUpdate;
        m_mushroomEnemy[0].OnEnemyHPChange += EnemyHPSliderUpdate;
        if (2 == EnemyGenerator.Instance.RandomNum)
        {
            m_mushroomEnemy[1].OnEnemyHPChange += EnemyHPSliderUpdate;
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            m_mushroomEnemy[1].OnEnemyHPChange += EnemyHPSliderUpdate;
            m_mushroomEnemy[2].OnEnemyHPChange += EnemyHPSliderUpdate;
        }
    }
    void Update()
    {
        GetEnemyAgilityUpdate();
        m_textManager.PlayerStatusUpdate(m_player.CurrentHP, m_player.CurrentMP);
        m_playerSliderUpdate.AgilitySlider.value += m_player.Agility * Time.deltaTime;
        EnemyAttack();
    }

    void GetEnemyAgilityUpdate()
    {
        m_enemyUI[0].EnemyAgilityUpdate(m_mushroomEnemy[0].m_agility);
        if (2 == EnemyGenerator.Instance.RandomNum)
        {
            m_enemyUI[1].EnemyAgilityUpdate(m_mushroomEnemy[1].m_agility);
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            m_enemyUI[1].EnemyAgilityUpdate(m_mushroomEnemy[1].m_agility);
            m_enemyUI[2].EnemyAgilityUpdate(m_mushroomEnemy[2].m_agility);
        }
    }
    /// <summary>プレイヤーがボタンを使って攻撃するためのメソッド</summary>
    public void PlayerAttack()
    {
        if (m_playerSliderUpdate.AgilitySlider.value == m_playerSliderUpdate.AgilitySlider.maxValue)
        {
            m_playerAttackDamage.GetAttackDamage(m_enemyTarget, m_player.AttackPow, 0);
            EndAttack(m_playerSliderUpdate.AgilitySlider);
            m_playerAnim.AttackAnimation();
            if (m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].m_currentHP > 0)
            {
                m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].DamageAnim();
            }
        }
    }
    /// <summary>プレイヤーの魔法攻撃</summary>
    public void MagicArrowAttack()
    {
        if (m_playerSliderUpdate.AgilitySlider.value == m_playerSliderUpdate.AgilitySlider.maxValue &&
            m_playerSliderUpdate.MPSlider.value >= 3)
        {
            m_playerAttackDamage.GetAttackDamage(m_enemyTarget, m_player.MagicPow, 3);
            m_player.PlayerMPDown(3);
            EnemyHPSliderUpdate();
            EndAttack(m_playerSliderUpdate.AgilitySlider);
            if (m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].m_currentHP > 0)
            {
                m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].DamageAnim();
            }
        }
    }

    /// <summary>敵の攻撃処理</summary>
    private void EnemyAttack()
    {
        if (m_enemyAgilitySlider[0].value == m_enemyAgilitySlider[0].maxValue)
        {
            EnemyAttackDamage(0);
            m_playerAnim.DamageAnimation();
            m_mushroomEnemy[0].AttackAnim();
            //m_mushAnim.AttackAnim();
        }

        if (2 == EnemyGenerator.Instance.RandomNum)
        {
            if (m_enemyAgilitySlider[1].value == m_enemyAgilitySlider[1].maxValue)
            {
                EnemyAttackDamage(1);
                m_playerAnim.DamageAnimation();
                m_mushroomEnemy[1].AttackAnim();
            }
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            if (m_enemyAgilitySlider[1].value == m_enemyAgilitySlider[1].maxValue)
            {
                EnemyAttackDamage(1);
                m_playerAnim.DamageAnimation();
                m_mushroomEnemy[1].AttackAnim();
            }
            else if (m_enemyAgilitySlider[2].value == m_enemyAgilitySlider[2].maxValue)
            {
                EnemyAttackDamage(2);
                m_playerAnim.DamageAnimation();
                m_mushroomEnemy[2].AttackAnim();
            }
        }
    }
    void EnemyAttackDamage(int num)
    {
        var damage = m_mushroomEnemy[num].GetComponent<IDamagable>();
        m_player.PlayerDamage(damage.ReceiveDamage
        (m_mushroomEnemy[num].m_attackPow, 0, m_player.DefensePower)); ;
        EndAttack(m_enemyAgilitySlider[num]);
    }

    /// <summary>攻撃した後に素早さゲージを０にする</summary>
    /// <param name="agility">攻撃するオブジェクトのAgilitySlider</param>
    public void EndAttack(Slider agility)
    {
        agility.value = 0;
    }

    void GetEnemyHPSlider()
    {
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyHPSlider[i] = m_enemyUI[i].EnemyHPSlider;
        }
    }

    /// <summary>エネミーのHPバーが現在のHPと同じ数値にする関数</summary>
    void EnemyHPSliderUpdate()
    {
        m_enemyHPSlider[EnemyGenerator.Instance.SelectNum].value =
            m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].m_currentHP;
        if (1 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_currentHP)
            {
                m_mushroomEnemy[0].m_agility = 0;
                var getExp = m_mushroomEnemy[0].m_exp;
                m_winPanel.gameObject.SetActive(true);
                m_player.CurrentExp = m_getExp.SetExp(m_player.CurrentExp, getExp);
                m_playerHPChange.PlyerStatusChange(m_player, m_playerLevelController);
                m_player.Agility = 0;
                m_mushroomEnemy[0].DeathAnim();
                //m_mushAnim.DeathAnim();
                m_uIManager.WinButton.gameObject.SetActive(true);
            }
        }
        else if (2 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_currentHP && !flag1)
            {
                m_mushroomEnemy[0].m_agility = 0;
                m_mushroomEnemy[0].DeathAnim();
                flag1 = true;
            }
            if (0 >= m_mushroomEnemy[1].m_currentHP && !flag2)
            {
                m_mushroomEnemy[1].m_agility = 0;
                m_mushroomEnemy[1].DeathAnim();
                flag2 = true;
            }
            if (0 >= m_mushroomEnemy[0].m_currentHP && 0 >= m_mushroomEnemy[1].m_currentHP)
            {
                var getExp = m_mushroomEnemy[0].m_exp + m_mushroomEnemy[1].m_exp;
                m_winPanel.gameObject.SetActive(true);
                m_player.CurrentExp = m_getExp.SetExp(m_player.CurrentExp, getExp);
                m_playerHPChange.PlyerStatusChange(m_player, m_playerLevelController);
                m_player.Agility = 0;
                m_uIManager.WinButton.gameObject.SetActive(true);
            }
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_currentHP && !flag1)
            {
                m_mushroomEnemy[0].m_agility = 0;
                m_mushroomEnemy[0].DeathAnim();
                flag1 = true;
            }
            if (0 >= m_mushroomEnemy[1].m_currentHP && !flag2)
            {
                m_mushroomEnemy[1].m_agility = 0;
                m_mushroomEnemy[1].DeathAnim();
                flag2 = true;
            }
            if (0 >= m_mushroomEnemy[2].m_currentHP && !flag3)
            {
                m_mushroomEnemy[2].m_agility = 0;
                m_mushroomEnemy[2].DeathAnim();
                flag3 = false;
            }
            if (0 >= m_mushroomEnemy[0].m_currentHP && 0 >= m_mushroomEnemy[1].m_currentHP &&
                0 >= m_mushroomEnemy[2].m_currentHP)
            {
                var getExp = m_mushroomEnemy[0].m_exp + m_mushroomEnemy[1].m_exp +
                             m_mushroomEnemy[2].m_exp;
                m_winPanel.gameObject.SetActive(true);
                m_player.CurrentExp = m_getExp.SetExp(m_player.CurrentExp, getExp);
                m_playerHPChange.PlyerStatusChange(m_player, m_playerLevelController);
                m_player.Agility = 0;
                m_uIManager.WinButton.gameObject.SetActive(true);
            }
        }
    }
    void GetEnemyAgilitySlider()
    {
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyAgilitySlider[i] = m_enemyUI[i].EnemyAgilitySlider;
        }
    }

    void StartEnemyUI()
    {
        if (1 == EnemyGenerator.Instance.RandomNum)
        {
            EnemyUI(0);
        }
        else if (2 == EnemyGenerator.Instance.RandomNum)
        {
            for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
            {
                EnemyUI(i);
            }
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
            {
                EnemyUI(i);
            }
        }
    }
    void EnemyUI(int index)
    {
        m_enemyHPSlider[index].maxValue = m_mushroomEnemy[index].m_maxHP;
        m_enemyHPSlider[index].value = m_mushroomEnemy[index].m_currentHP;
        m_enemyAgilitySlider[index].maxValue = m_mushroomEnemy[index].MaxAgility;
        m_enemyAgilitySlider[index].value = 0;
    }

    /// <summary>最初のパネルを隠して二番目のパネルを表示する</summary>
    public void FirstPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen", false);
        m_secondPanel.SetBool("SecondOpen", true);
    }
    /// <summary>二番目のパネルを隠して最初のパネルを表示する</summary>
    public void SecondPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen", true);
        m_secondPanel.SetBool("SecondOpen", false);
    }
}
