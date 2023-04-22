using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateEnemy : MonoBehaviour
{
    bool starttrigger=false;

    public GameObject PrefabEnemy;

    public static int score=0;
    public Text text;
    public Text shoot;

    public static int totalshoot = 0;

    public float GameTime = 5;
    public Text gametime;
    public Text CoutText;
    public Text deleateText;
    float countdown = 3f;
    int count;
    int retime;

    public bool createtrigger=false;
    float time;
    public float createtime=5;

    public bool numbertrigger=false;
    private float currentTime = 0f;
    public int number;
    public float span;

    // Start is called before the first frame update
    void Start()
    {
        totalshoot = 0;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //ç≈èâÇÃÉJÉEÉìÉg
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            starttrigger = true;
        }

        if (countdown == 0)
        {
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(1.0f, 5.0f);
            Vector3 pos = new Vector3(x, y, 6.0f);

            Instantiate(PrefabEnemy, pos, Quaternion.identity);
        }
        if (countdown >= 0)
        {
            if (starttrigger==true)
            {
                deleateText.gameObject.SetActive(false);
                countdown -= Time.deltaTime;
                count = (int)countdown;
                CoutText.text = count.ToString();
            }

        }else if (countdown <= 0)
        {
            
            //ìGÇê∂ê¨
            CoutText.text = "";
            GameTime-= Time.deltaTime;
            retime = (int)GameTime;
            gametime.text = "TIME:"+retime.ToString();
            if (Input.GetMouseButtonDown(0))
            {
                totalshoot += 1;
            }
            shoot.text = "TOTALSHOOOT:" + totalshoot;
            text.text = "HIT:" + score;

            if (time >= createtime || createtrigger==true)
            {
                time = 0;
                createtrigger = false;

                //1ïbë“Ç¬
                Invoke("createEnemy", 1.0f);
                


            }
            currentTime += Time.deltaTime;

            //êîÇëùÇ‚Ç∑
            if (numbertrigger == true)
            {
                if (currentTime > span)
                {

                    //Debug.LogFormat("{0}ïbåoâﬂ", span);
                    currentTime = 0f;


                    for (int a = 0; a < number; ++a)
                    {
                        createEnemy();
                    }
                    Debug.Log(number);
                    number += 1;

                }
            }
            
            if (GameTime <= 0)
            {
                SceneManager.LoadScene("Result");
            }
        }


    }
    public void createEnemy()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(1.0f, 5.0f);
        Vector3 pos = new Vector3(x, y, 6.0f);
        Instantiate(PrefabEnemy, pos, Quaternion.identity);
    }
}
