using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    //STATE = TAKENでの動きを調整するための変数。
    [SerializeField]
    AnimationCurve upCurve; // 上昇するときの動き方。
    [SerializeField]
    float upSpeed; // 上昇するときの速度
    [SerializeField]
    float upAmount; //上昇する高さ

    //STATE = APPROACHでの動きを調整するための変数。
    [SerializeField]
    AnimationCurve approCurve; // コインがプレイヤーに吸い寄せられるときの動き。
    [SerializeField]
    float approSpeed; // 吸い寄せられる速度。


    public int rotSpeed;
    public enum coinState {
        NONE = 0,
        TAKEN,
        APPROACH,
    }
    public coinState state = coinState.NONE;

    GameObject takePlayer;
    float time;

    Vector3 myPos;
    Vector3 endPos;

    Vector3 testPos;



    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //coinStateの説明　NONE フィールドにおかれた状態。　TAKEN キャラクターにとられた状態。
        switch (state)
        {
            case coinState.NONE:
                //ステージに置かれてる状態のときに自分のpositionをとっておく。
                myPos = this.transform.position;
                endPos = new Vector3(transform.position.x, transform.position.y + upAmount, transform.position.z);
                testPos = Vector3.Lerp(myPos, endPos, 0.5f);

                //回転させる処理。rotSpeedはエンジン上で変更可能。
                transform.Rotate(new Vector3(0, rotSpeed, 0));
                break;
            case coinState.TAKEN:
                time += Time.deltaTime * upSpeed;
                var curvePos = upCurve.Evaluate(time);
                this.transform.position = Vector3.Lerp(myPos, testPos, curvePos);
                if(this.transform.position.y == testPos.y)
                {
                    state = coinState.APPROACH;
                    time = 0;
                }
                //この上昇する動きが終わったら次にどういう動きをする？？
                break;
            case coinState.APPROACH:
                //上昇しきったあと、プレイヤーに吸い寄せられていくとき。
                time += Time.deltaTime * approSpeed;
                float approCurvePos = approCurve.Evaluate(time);
                this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position, approCurvePos);
                break;
            default:
                break;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("ok");
            state = coinState.TAKEN;
            takePlayer = col.gameObject;
        }
    }
}
