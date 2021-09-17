using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    [SerializeField] float m_movingSpeed = 5f;
    /// <summary>ターンの速さ</summary>
    [SerializeField] float m_turnSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    [SerializeField] float m_jumpPower = 5f;
    /// <summary>接地判定の際、中心 (Pivot) からどれくらいの距離を「接地している」と判定するかの長さ</summary>
    [SerializeField] float m_isGroundedLength = 1.1f;
    //当たり判定
    [SerializeField] Collider m_attackTriger;
    //m_movingSpeedを一時的に保存する変数
    float subSpeed = 0f;

    Animator m_anim;
    Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
    }

    void Update()
    {

        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            // メインカメラを基準に入力方向のベクトルを変換する
            dir = Camera.main.transform.TransformDirection(dir);
            // y 軸方向はゼロにして水平方向のベクトルにする
            dir.y = 0;

            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);  // Slerp を使うのがポイント

            // 入力した方向に移動する
            Vector3 velo = dir.normalized * m_movingSpeed;
            // ジャンプした時の y 軸方向の速度を保持する
            velo.y = m_rb.velocity.y;
            // 計算した速度ベクトルをセットする
            m_rb.velocity = velo;
        }
        // ジャンプの入力を取得し、接地している時に押されていたらジャンプする
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            m_rb.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
            m_anim.SetTrigger("Jump");
        }
        //攻撃（キック）
        if (Input.GetButtonDown("Fire1"))// && IsGrounded()を入れていたが、HasExitTimeがあるのでジャンプ中にキックはしない
        {
            m_anim.SetTrigger("Kick");
        }
    }

    // Update の後に呼び出される。Update の結果を元に何かをしたい時に使う。
    void LateUpdate()
    {
        // 水平方向の速度を求めて Animator Controller のパラメーターに渡す
        Vector3 horizontalVelocity = m_rb.velocity;
        horizontalVelocity.y = 0;
        m_anim.SetFloat("Speed", horizontalVelocity.magnitude);
    }
    // 地面に接触しているか判定する
    bool IsGrounded()
    {
        // Physics.Linecast() を使って足元から線を張り、そこに何かが衝突していたら true とする
        Vector3 start = this.transform.position;   // start: オブジェクトの中心
        Vector3 end = start + Vector3.down * m_isGroundedLength;  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする
        return isGrounded;
    }
    //当たり判定をアクティブ
    void BeginAttack()
    {
        if (m_attackTriger)
        {
            m_attackTriger.gameObject.SetActive(true);
        }
    }
    //当たり判定を非アクティブ
    void EndAttack()
    {
        if (m_attackTriger)
        {
            m_attackTriger.gameObject.SetActive(false);
        }
    }
    //攻撃時に動きを止める
    void BeginMoveStop()
    {
        //m_movingSpeedをsubSpeedに保存しm_movingSpeedに0を入れて動きを止める
        subSpeed = m_movingSpeed;
        m_movingSpeed = 0;
    }
    //攻撃後に動き出す
    void EndMoveStop()
    {
        //m_movingSpeedにsubSpeedを入れて動かせる
        m_movingSpeed = subSpeed;
    }
    //コマンドバトルに移行する
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("CommandBattleTestScene");
        }
    }
}

