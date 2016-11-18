using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {
    [Range(0, 12000)]
    public int totalCoinAmount; // 作り出すコインすべてをあわせた量(枚数ではなく価値)

    //各コインの情報
    public int[] coinValue; // コインの価値を付加する。

    public GameObject[] createCoins; // 作り出すコイン一覧。6種類。

    [SerializeField]
    float createCoinRange; // コインの作り出される範囲の設定。
    // Use this for initialization
    void Start () {
        CreateCoin();

    }
	
	// Update is called once per frame
	void Update () {

    }

    void CoinGenerate(int coinNo, float createRate)
    {
        int createCount = 0;
        // 出したい金額の合計が今から生成する分の値を持っている間まわす。
        while (totalCoinAmount >= coinValue[coinNo] && createCount < 30)
        {
            if (totalCoinAmount / coinValue[coinNo] >= createRate)
            {
                //毎回同じポジションにならないようにオブジェクトの±２の範囲内で生み出す。
                Vector3 createRandPos = new Vector3(Random.Range(this.transform.position.x - createCoinRange, this.transform.position.x + createCoinRange),
                Random.Range(this.transform.position.y, this.transform.position.y + createCoinRange), Random.Range(this.transform.position.z - createCoinRange, this.transform.position.z + createCoinRange));
                Instantiate(createCoins[coinNo], createRandPos, Quaternion.Euler(90, 0, 0));
                //生成したコインの価値だけtotalCoinAmountから差し引く。
                totalCoinAmount -= coinValue[coinNo];
                createCount++;
            } else
            {
                break;
            }
        }
        createCount = 0;

    }

    void CreateCoin()
    {
        //0.LGold 1.LSilver 2.SGold 3.LBronze 4.SSilver 5.SBronze
        //金大メダルの確率は1パーセント
        //第一引数はコイン番号。第二引数はコインを生成する際どれぐらいの確率で出るかの数値。
        //金大と銅小はこれで決定…中間の調整をどうするか
        CoinGenerate(0, 10);
        CoinGenerate(1, 15);
        CoinGenerate(2, 10);
        CoinGenerate(3, 5);
        CoinGenerate(4, 3);
        CoinGenerate(5, 1);
    }
}
