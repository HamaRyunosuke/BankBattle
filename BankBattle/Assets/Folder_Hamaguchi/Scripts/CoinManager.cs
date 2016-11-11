using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public GameObject[] Coins;
    int count;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(count <= 150)
        {
            Instantiate(Coins[0], transform.position, Quaternion.identity);
            count++;
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
}
