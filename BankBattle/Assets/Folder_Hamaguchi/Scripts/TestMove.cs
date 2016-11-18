using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {
    //移動速度
    public float moveSpeed;
    //自分の現在のスコア
    public int myScore = 5000;
    public bool testFlg = true;

    public float InjectionPower;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Move();
        //ある一定のところまで落ちたら
        //プレイヤーの今持っているポイント（金額）を取得。
        //2で割った数ぶんコインを出す。
        //出すコインは高価なものから出してよい。
        //もし出す金額よりも今出しているコインの方が価値があれば1こ下の価値の低いものに変更する。
        if(this.transform.position.y <= -1.5f && testFlg)
        {
            DisCharge();
        }

    }

    void DisCharge()
    {
        //失う分のスコアの計算
        testFlg = false;
        int loseScore = myScore / 2;
        myScore = loseScore;
        GameObject coinManager = GameObject.Find("CoinManager");
        for (int i = 0; i < coinManager.GetComponent<CoinManager>().coinValue.Length; i++)
        {
            while (loseScore >= coinManager.GetComponent<CoinManager>().coinValue[i])
            {
                Vector3 targetVec = (coinManager.transform.position - this.transform.position).normalized;
                GameObject insCoin = Instantiate(coinManager.GetComponent<CoinManager>().createCoins[i], new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
                insCoin.GetComponent<Rigidbody>().AddForce(targetVec * InjectionPower);
                loseScore -= coinManager.GetComponent<CoinManager>().coinValue[i];
            }
        }
        testFlg = true;
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
