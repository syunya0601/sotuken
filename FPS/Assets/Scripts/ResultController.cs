using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    float hitscore;
    float shootscore;
    float missscore;
    float accuracy1;
    float accuracy2;
    public Text Hscore;//ヒット数
    public Text Sscore;//ミスショット
    public Text Accuracy;//命中精度
    // Start is called before the first frame update
    void Start()
    {
        hitscore = CreateEnemy.score;
        shootscore = CreateEnemy.totalshoot;

    }

    // Update is called once per frame
    void Update()
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        missscore = shootscore - hitscore;
        accuracy1 = hitscore / shootscore;
        accuracy2 = accuracy1 * 100;


        Hscore.text = "ヒット数:" + hitscore.ToString();
        Sscore.text = "ミスショット:" + missscore.ToString();
        Accuracy.text = "命中精度：" + accuracy2.ToString()+"％";
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
