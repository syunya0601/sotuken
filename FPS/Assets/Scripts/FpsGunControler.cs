using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI�������ׂɕK�v
using UnityEngine.UI;

public class FpsGunControler : MonoBehaviour
{
    //Image�N���X�ϐ���錾�BSerializeField��Inspector�ォ���`
    [SerializeField] Image sight;
    //ray�̒���
    float rayLength = 20000;
    //ray�����������I�u�W�F�N�g�̏����擾����ׂ̕ϐ�
    RaycastHit hit;
    //�G�ɗ^����_���[�W�̒l
    int damageScore = 1;

    public static bool HitTrigger=false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //�J�����̌��_���烌�C���΂��ƃv���C���[���g�̃^�O���擾���Ă��܂��ׁAZ�����ɃY����
        Ray ray = new Ray(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward);
        //ray�̉���
        Debug.DrawRay(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward * rayLength, Color.yellow);
        //ray��ɃR���C�_�[�����݂���ꍇ�ARayCastHit�^�ϐ��ɏ����i�[����Bout�C���q��t���āA�߂�l���擾�����Ɋ֐����ŕϐ��̒l�𑀍삷��
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            //hit�Ɏ擾�������̓��A�^�O�����擾
            string hitTagName = hit.transform.gameObject.tag;
            //�^�O����Enemy�������ꍇ
            if (hitTagName == "Enemy")
            {
                //Enemy�^�O�̃I�u�W�F�N�g��ray�������������̏Ə��̐F
                sight.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //�}�E�X�̍��{�^�����N���b�N���ꂽ��
                if (Input.GetMouseButtonDown(0))
                {
                    HitTrigger = true;
                    //Enemy�I�u�W�F�N�g�ɕt���Ă���EnemyHP��ReceveDamage�֐����Ăяo��
                    hit.collider.GetComponent<EnemyHP>().ReceveDamage(damageScore);
                    
                }
            }
            else
            {
                //Enemy�^�O�ȊO�̃I�u�W�F�N�g��ray�������������̏Ə��̐F
                sight.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            }
        }
        else
        {
            HitTrigger = false;
            //ray���ǂ̃I�u�W�F�N�g�ɂ��������Ă��Ȃ���(��������Ă��鎞)�̏Ə��̐F
            sight.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }
}