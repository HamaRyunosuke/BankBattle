using UnityEngine;
using System.Collections;

public class deleteParticle : MonoBehaviour {

    float time;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (this.GetComponent<ParticleSystem>().startLifetime <= time)
        {
            Destroy(this.gameObject);
        }
	}
}
