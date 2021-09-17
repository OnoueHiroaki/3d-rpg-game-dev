using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExp : MonoBehaviour
{
    [SerializeField] PlayerLevelController m_levelData;
    [SerializeField] int m_getEx;
    PlayerStatus m_playerStatus;

    int m_crrentEx;
    bool m_flag = false;
    //int m_levelId = 0;

    void Start()
    {
        m_playerStatus = PlayerStatus.Instance;
        //if (m_crrentEx == 0) m_crrentEx = m_levelData.GetData(m_playerStatus.CurrentLevel).Level;

        //SetEx(m_crrentEx, m_getEx);
    }

    /// <summary>
    /// 次のレベルに上がるための残りの経験値の算出
    /// </summary>
    /// <param name="currentExp">現在の残り経験値</param>
    /// <param name="getExp">外部から取得した経験値</param>
    public void SetExp(int currentExp, int getExp)
    {
        // 現在の残り経験値から、外部から取得した経験値を引いたものを一時的に保存する。
        int saveExp = currentExp - getExp;

        if (saveExp > 0)
        {
            currentExp = saveExp;
            //Debug.Log($"現在のレベル :{m_levelData.GetData(m_playerStatus.CurrentLevel).Level} 次のレベルまで :{crrentEx}");
            return;
        }
        else
        {
            if (saveExp >= m_levelData.GetData(m_playerStatus.CurrentLevel).MaxExp)
            {
                // レベルアップの処理
                m_playerStatus.CurrentLevel++;
                Debug.Log("aaa");
            }
            // レベルアップの処理 別のパラメーター変化は省略

            currentExp = m_levelData.GetData(m_playerStatus.CurrentLevel).MaxExp;
            m_flag = true;
            if (saveExp == 0)
            {
                //Debug.Log($"現在のレベル :{m_levelData.GetData(m_playerStatus.CurrentLevel).Level} 次のレベルまで :{crrentEx}");
                return;
            }
            else
            {
                SetExp(currentExp, saveExp * -1);
            }
        }
    }
}
