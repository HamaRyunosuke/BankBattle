using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
    public int rotSpeed;
    public enum coinState {
        NONE = 0,
        TAKEN,
    }
    public coinState state = coinState.NONE;

    GameObject takePlayer;

    float time;



    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //coinStateの説明　NONE フィールドにおかれた状態。　TAKEN キャラクターにとられた状態。
        switch (state)
        {
            case coinState.NONE:
                //コインがY軸回転する。
                //Vector3 myRot = this.transform.eulerAngles;
                //myRot.x = 0;
                //myRot.z = 180;
                //this.transform.eulerAngles = myRot;

                //回転させる処理。rotSpeedはエンジン上で変更可能。
                transform.Rotate(new Vector3(0, rotSpeed, 0));



                break;
            case coinState.TAKEN:
                time += Time.deltaTime * 0.2f;
                this.transform.position = new Vector3(Mathf.Lerp(takePlayer.transform.position.x, this.transform.position.x, time), 0, 0);
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
