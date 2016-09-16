﻿using UnityEngine;
using System.Collections;

public class EnemyBuilder : MonoBehaviour {

	public float nextWaveTime=5f;
	public float intervelTime=0.5f;

	[System.Serializable]
	public class WaveComponent{
		public GameObject enenmyPrefab;
		public int num;
		public int shooted = 0;
	}
	public WaveComponent[] wave;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		nextWaveTime -= Time.deltaTime;
		if (nextWaveTime < 0) {
			nextWaveTime = intervelTime;
			bool finised = true;
			//This wave Enemy Comes
			foreach(WaveComponent wc in wave ){
				if(wc.shooted<wc.num){
					//shoot it, enenmyPrefab is a prefab object
					finised=false;
					wc.shooted++;
					Instantiate(wc.enenmyPrefab,this.transform.position, this.transform.rotation);
					break;
				}
			}
			if (finised == true) {
				Destroy (gameObject);
				//or Instantiate the next wave enemy
			}
		}
	}
}