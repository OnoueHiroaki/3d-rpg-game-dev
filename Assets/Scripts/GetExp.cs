using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExp : MonoBehaviour
{
    [SerializeField] PlayerLevelController m_levelData;
    [SerializeField] TextManager m_textManager;

    PlayerStatus m_playerStatus;
    static int m_levelId = 0;

    void Start()
    {
        m_playerStatus = PlayerStatus.Instance;
        //if (m_crrentEx == 0) m_crrentEx = m_levelData.GetData(m_levelId).MaxExp;
    }

    /// <summary>
    /// 次のレベルに上がるための残りの経験値の算出
    /// </summary>
    /// <param name="currentExp">現在の残り経験値</param>
    /// <param name="getExp">外部から取得した経験値</param>
    public int SetExp(int currentExp, int getExp)
    {
        if (currentExp == 0) currentExp = m_levelData.GetData(m_levelId).MaxExp;
        // 現在の残り経験値から、外部から取得した経験値を引いたものを一時的に保存する。
        int saveExp = currentExp - getExp;
        //Debug.Log($"一時的保存 :{saveExp}");
        if (saveExp > 0)
        {
            currentExp = saveExp;
            //m_textManager.WinLevelUpText(m_playerStatus.CurrentLevel);
            Debug.Log($"現在(残り)の Exp ;{currentExp}");
            return currentExp;
        }
        else
        {
            // レベルアップの処理
            m_levelId++;
            m_playerStatus.CurrentLevel++;
            m_textManager.WinLevelUpText(m_playerStatus.CurrentLevel);
            currentExp = m_levelData.GetData(m_levelId).MaxExp;
            Debug.Log($"レベルアップ後のExp :{currentExp}");
            // レベルアップの処理 別のパラメーター変化は省略

            if (saveExp == 0)
            {
                return currentExp;
            }
            else
            {
                SetExp(currentExp, saveExp * -1);
            }
        }

        Debug.LogError("aaaa");
        return 0;
    }
}
