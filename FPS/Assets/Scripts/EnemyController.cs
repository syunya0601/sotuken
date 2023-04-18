using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime = 5;

    float time;
    public float colorspeed=0.2f;
    public float scaletime;
    private Renderer EnemyRend;
    private float colorValue;

    public bool SecondScale=false;

    Vector3 Enemy;  

    void Start()
    {
        scaletime = scaletime - 1;
        colorValue = 1;
        EnemyRend = GetComponent<Renderer>();

        Enemy = gameObject.transform.localScale; //ŸŒ»İ‚Ì‘å‚«‚³‚ğ‘ã“ü
    }

    // Update is called once per frame
    void Update()
    {
        if (SecondScale == true)
        {
            time += Time.deltaTime;
            float alpha = 1.0f - time / scaletime;
            //‘å‚«‚³‚ğ•Ï‚¦‚é
            Enemy.x = alpha;
            Enemy.y = alpha;
            Enemy.z = alpha;
            gameObject.transform.localScale = Enemy;
        }
        if(Enemy.x <= 0 && Enemy.y <= 0 && Enemy.z <= 0)
        {
            Destroy(gameObject);
        }
        
        //F•ÏX
        colorValue -= colorspeed * Time.deltaTime;
        EnemyRend.material.color = new Color(1, colorValue, colorValue, 1);

        //Á‚·
        Destroy(gameObject, lifetime);
        
    }
}
