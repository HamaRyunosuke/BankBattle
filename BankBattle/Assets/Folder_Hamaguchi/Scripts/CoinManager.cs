using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {
    [SerializeField]
    int totalCoinAmount; // 作り出すコインすべてをあわせた量(枚数ではなく価値)

    //各コインの情報
    [SerializeField]
    int[] coinMax; // 各コインの枚数上限を決める。
    [SerializeField]
    int[] coinValue; // コインの価値を付加する。
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

    void CoinGenerate(int coinNo)
    {
        int createCount = 0;
        while (totalCoinAmount > 0 && createCount < coinMax[coinNo])
        {
            Instantiate(createCoins[coinNo], transform.position, Quaternion.identity);
            totalCoinAmount -= coinValue[coinNo];
            createCount++;
        }
        createCount = 0;
    }

    void CreateCoin()
    {
        int createCount = 0;
        //金の大きいコインを生成。
        while (totalCoinAmount > 0 && createCount < coinMax[0])
        {
            Instantiate(createCoins[0], transform.position, Quaternion.identity);
            totalCoinAmount -= coinValue[0];
            createCount++;
        }
        createCount = 0;
        CoinGenerate(0);
        //銀大は７５の価値がある。一旦実験として金大を作って差し引かれたtotalCoinAmountの分をすべて銀大にしてみる。
        while(totalCoinAmount > 0 && createCount < coinMax[1])
        {
            Instantiate(createCoins[1], transform.position, Quaternion.identity);
            totalCoinAmount -= coinValue[1];
            createCount++;
        }
        createCount = 0;
        while (totalCoinAmount > 0 && createCount < coinMax[2])
        {
            Instantiate(createCoins[2], transform.position, Quaternion.identity);
            totalCoinAmount -= coinValue[2];
            createCount++;
        }
        createCount = 0;
    }
}
