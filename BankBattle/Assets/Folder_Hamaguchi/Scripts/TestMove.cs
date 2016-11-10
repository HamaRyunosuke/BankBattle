using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {


    public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
