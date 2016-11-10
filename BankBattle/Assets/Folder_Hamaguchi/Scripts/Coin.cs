﻿using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {


    //STATE = TAKENでの動きを調整するための変数。
#if false
    [SerializeField]
    AnimationCurve upCurve; // 上昇するときの動き方。
    [SerializeField]
    float upSpeed; // 上昇するときの速度
    [SerializeField]
    float upAmount; //上昇する高さ
#endif

    //STATE = APPROACHでの動きを調整するための変数。
    [SerializeField]
    AnimationCurve approCurve; // コインがプレイヤーに吸い寄せられるときの動き。
    [SerializeField]
    float approSpeed; // 吸い寄せられる速度。


    public int rotSpeed;
    public enum coinState {
        NONE = 0,
        APPROACH,

        TAKEN,
    }
    public coinState state = coinState.NONE;

    GameObject takePlayer; // コインを取得したプレイヤーを入れる変数。
    float time; //コインが移動するときに使うTime.deltatimeを入れる変数。

    Vector3 myPos; //自分の座標
    Vector3 endPos;

    Vector3 testPos;



    // Use this for initialization
    void Start () {
        takePlayer = GameObject.Find("Capsule");
	}
	
	// Update is called once per frame
	void Update () {

        //coinStateの説明　NONE フィールドにおかれた状態。　TAKEN キャラクターにとられた状態。
        switch (state)
        {
            case coinState.NONE:
#if false

                //ステージに置かれてる状態のときに自分のpositionをとっておく。
                myPos = this.transform.position;
                endPos = new Vector3(this.transform.position.x, this.transform.position.y + upAmount, this.transform.position.z);
                testPos = Vector3.Lerp(myPos, endPos, 0.5f);
#endif
                break;
            case coinState.APPROACH:
                //上昇しきったあと、プレイヤーに吸い寄せられていくとき。
                //this.GetComponent<MeshCollider>().isTrigger = true;
                Vector3 approachPoint = new Vector3(takePlayer.transform.position.x, takePlayer.transform.position.y + 0.7f, takePlayer.transform.position.z);
                time += Time.deltaTime * approSpeed;
                float approCurvePos = approCurve.Evaluate(time);
                this.transform.position = Vector3.Lerp(this.transform.position, approachPoint, approCurvePos);
                break;
#if false

            case coinState.TAKEN:
                //回転させる処理。rotSpeedはエンジン上で変更可能。
                transform.Rotate(new Vector3(0, rotSpeed, 0));

                time += Time.deltaTime * upSpeed;
                float curvePos = upCurve.Evaluate(time);
                this.transform.position = Vector3.Lerp(myPos, testPos, curvePos);

                //自分の今のポジションがある一定の距離まで上昇したら
                //コインが上がりきったら次のSTATEに行くようにする。
                if(this.transform.position.y == testPos.y)
                {
                    this.GetComponent<Rigidbody>().useGravity = false;
                    time = 0;
                    state = coinState.APPROACH;
                }
                //この上昇する動きが終わったら次にどういう動きをする？？
                break;
#endif
            default:
                break;
        }
	}

    //コインをプレイヤーが取得した時の処理。
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && state == coinState.NONE)
        {
            //stateを変える。
            state = coinState.APPROACH;
            //コインをとったプレイヤーが誰かを取得。
            takePlayer = col.gameObject;
            //取得者が重複するのを防ぐため、Triggerを削除する。
            GameObject takeTrigger = transform.FindChild("TakeTrigger").gameObject;
            GameObject.Destroy(takeTrigger);
        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if(col.gameObject.tag == "Player")
    //    {
    //        state = coinState.APPROACH;
    //        takePlayer = col.gameObject;
    //    }
    //}
}
