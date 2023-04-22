using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //HPゲージ
    int enemyHP = 1;
    CreateEnemy CE;
    public bool ShootScaleTrigger;

    public float MissScale=0.1f;

    Vector3 Enemy;


    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.transform.localScale;

        GameObject obj = GameObject.Find("GameManager"); //Playerっていうオブジェクトを探す
        CE = obj.GetComponent<CreateEnemy>(); //付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootScaleTrigger == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (FpsGunControler.HitTrigger == false)
                {
                    //大きさを変える
                    Enemy.x = Enemy.x - MissScale;
                    Enemy.y = Enemy.y - MissScale;
                    Enemy.z = Enemy.z - MissScale;
                    gameObject.transform.localScale = Enemy;
                }
            }
        }
    }
    //被ダメージ処理
    public void ReceveDamage(int damageScore)
    {
        enemyHP -= damageScore;
        //オーバーキルでHPが0を飛び越えても対処できるよう、判定を0以下にしておく
        if (enemyHP <= 0)
        {

            CreateEnemy.score += 1;
            CE.createtrigger=true;
            //このスクリプトがアタッチされているオブジェクトを消す
            Destroy(this.gameObject);
        }

    }


}