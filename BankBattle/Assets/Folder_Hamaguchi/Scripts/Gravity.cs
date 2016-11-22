using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

    Vector3 myPos;
    float time;
    [Range(0, 1)]
    public float gravityScale;

    // Use this for initialization
    void Start () {
        myPos = this.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        //重力を作ることはできたのでこれをストップさせるタイミング
        time += (Time.deltaTime * gravityScale);
        myPos.y += (-9.81f * time);
        this.transform.position = myPos;

	}
}
