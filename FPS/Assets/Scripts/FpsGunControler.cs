using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UIを扱う為に必要
using UnityEngine.UI;

public class FpsGunControler : MonoBehaviour
{
    //Imageクラス変数を宣言。SerializeFieldでInspector上から定義
    [SerializeField] Image sight;
    //rayの長さ
    float rayLength = 20000;
    //rayが当たったオブジェクトの情報を取得する為の変数
    RaycastHit hit;
    //敵に与えるダメージの値
    int damageScore = 1;

    public static bool HitTrigger=false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //カメラの原点からレイを飛ばすとプレイヤー自身のタグを取得してしまう為、Z方向にズラす
        Ray ray = new Ray(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward);
        //rayの可視化
        Debug.DrawRay(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward * rayLength, Color.yellow);
        //ray上にコライダーが存在する場合、RayCastHit型変数に情報を格納する。out修飾子を付けて、戻り値を取得せずに関数内で変数の値を操作する
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            //hitに取得した情報の内、タグ名を取得
            string hitTagName = hit.transform.gameObject.tag;
            //タグ名がEnemyだった場合
            if (hitTagName == "Enemy")
            {
                //Enemyタグのオブジェクトにrayが当たった時の照準の色
                sight.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //マウスの左ボタンがクリックされたら
                if (Input.GetMouseButtonDown(0))
                {
                    HitTrigger = true;
                    //Enemyオブジェクトに付いているEnemyHPのReceveDamage関数を呼び出す
                    hit.collider.GetComponent<EnemyHP>().ReceveDamage(damageScore);
                    
                }
            }
            else
            {
                //Enemyタグ以外のオブジェクトにrayが当たった時の照準の色
                sight.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            }
        }
        else
        {
            HitTrigger = false;
            //rayがどのオブジェクトにも当たっていない時(空を向いている時)の照準の色
            sight.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }
}