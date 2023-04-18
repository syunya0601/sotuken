using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //HP�Q�[�W
    int enemyHP = 1;
    CreateEnemy CE;
    public bool ShootScaleTrigger;

    public float MissScale=0.1f;

    Vector3 Enemy;


    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.transform.localScale;

        GameObject obj = GameObject.Find("GameManager"); //Player���Ă����I�u�W�F�N�g��T��
        CE = obj.GetComponent<CreateEnemy>(); //�t���Ă���X�N���v�g���擾
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
                    //�傫����ς���
                    Enemy.x = Enemy.x - MissScale;
                    Enemy.y = Enemy.y - MissScale;
                    Enemy.z = Enemy.z - MissScale;
                    gameObject.transform.localScale = Enemy;
                }
            }
        }
    }
    //��_���[�W����
    public void ReceveDamage(int damageScore)
    {
        enemyHP -= damageScore;
        //�I�[�o�[�L����HP��0���щz���Ă��Ώ��ł���悤�A�����0�ȉ��ɂ��Ă���
        if (enemyHP <= 0)
        {

            CreateEnemy.score += 1;
            CE.createtrigger=true;
            //���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g������
            Destroy(this.gameObject);
        }

    }


}