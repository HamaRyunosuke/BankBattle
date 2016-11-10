using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {
    Vector3 myPos;

    public float moveSpeed;

	// Use this for initialization
	void Start () {
        myPos = this.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.RightArrow))
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
