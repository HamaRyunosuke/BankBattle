using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {
    //移動速度
    public float moveSpeed;
    //自分の現在のスコア
    public int myScore = 5000;
    public bool testFlg = true;

    public bool isDead = false;

    public float InjectionPower;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //試験的に上下左右のキーで動かしている。
        Move();

        //ある一定の高さまで落ちたら死亡判定
        //if(this.transform.position.y <= -0.5f && !isDead)
        //{
        //    DisCharge();
        //}

    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeathZone" && !isDead)
        {
            DisCharge(); // 自分の持っているポイントを半分にしてその半分をステージ上にばら撒く処理。
            Destroy(this.gameObject); //自らを消去。
        }
    }

    void DisCharge()
    {
        //失う分のスコアの計算
        isDead = true;
        int loseScore = myScore / 2;
        myScore = loseScore;
        GameObject coinManager = GameObject.Find("CoinManager");
        for (int i = 0; i < coinManager.GetComponent<CoinManager>().coins.Length; i++)
        {
            while (loseScore >= coinManager.GetComponent<CoinManager>().coins[i].value)
            {
                GameObject target = GameObject.Find("SpawnDirection");
                Vector3 spawnDirection = (target.transform.position - this.transform.position).normalized;
                GameObject insCoin = Instantiate(coinManager.GetComponent<CoinManager>().coins[i].model, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;

                insCoin.GetComponent<Rigidbody>().AddForce(spawnDirection * InjectionPower);
                loseScore -= coinManager.GetComponent<CoinManager>().coins[i].value;
            }
        }
    }

    void Move()
    {
        Vector3 myPos = this.transform.position;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myPos.x += moveSpeed;
            this.transform.position = myPos;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myPos.x -= moveSpeed;
            this.transform.position = myPos;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            myPos.z += moveSpeed;
            this.transform.position = myPos;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            myPos.z -= moveSpeed;
            this.transform.position = myPos;
        }
    }


}
