using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {
    [SerializeField]
    int totalCoinAmount; // 作り出すコインすべてをあわせた量(枚数ではなく価値)
    [SerializeField]
    int[] coinMax; // 各コインの枚数上限を決める。
    public GameObject[] createCoins; // 作り出すコイン一覧。6種類。

    public GameObject[] Coins;
    int count;



	// Use this for initialization
	void Start () {
        CreateCoin();

    }
	
	// Update is called once per frame
	void Update () {
        //if (count <= 150)
        //{
        //    Instantiate(Coins[0], transform.position, Quaternion.identity);
        //    count++;
        //}
        if(totalCoinAmount >= 0)
        {
            Instantiate(createCoins[1], transform.position, Quaternion.identity);
            totalCoinAmount -= 75;
        }


        //int rand = Random.Range(0, 100);
        //if(rand <= 80)
        //{
        //    Instantiate(Coins[0], transform.position, Quaternion.identity);
        //} else if(rand <= 97)
        //{
        //    Instantiate(Coins[1], transform.position, Quaternion.identity);
        //} else
        //{
        //    Instantiate(Coins[2], transform.position, Quaternion.identity);
        //}

    }

    void CreateCoin()
    {
        //金の大きいコインを生成。
        for (int i = 0; i < coinMax[0]; ++i)
        {
            Instantiate(createCoins[0], transform.position, Quaternion.identity);
            totalCoinAmount -= 300;
        }
        Debug.Log(totalCoinAmount);
        //銀大は７５の価値がある。一旦実験として金大を作って差し引かれたtotalCoinAmountの分をすべて銀大にしてみる。
        //for (int i = totalCoinAmount; 0 <= i; totalCoinAmount -= 75)
        //{
        //    Instantiate(createCoins[1], transform.position, Quaternion.identity);
        //   // totalCoinAmount -= 75;
        //}
    }
}
