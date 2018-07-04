using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Andrew Bangs, Script for salt and pepper shakers
public class Shaker_Script : MonoBehaviour {

	private PlayerScript playerStats;
	
	[Tooltip("Value of 1 = Salt, 2 = Pepper")]
	public int ShakerType;
	
	void Start(){
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}
	
	void OnTriggerEnter (Collider other){
		if (ShakerType == 1 && other.gameObject.CompareTag ("Player")){
			playerStats.speed = playerStats.speed / 2;
		} else if (ShakerType == 2 && other.gameObject.CompareTag ("Player")){
			playerStats.dmgMult = playerStats.dmgMult * 2;
		}
	}
	
		void OnTriggerExit (Collider other){
		if (ShakerType == 1 && other.gameObject.CompareTag ("Player")){
			playerStats.speed = playerStats.speed * 2;
		} else if (ShakerType == 2 && other.gameObject.CompareTag ("Player")){
			playerStats.dmgMult = playerStats.dmgMult / 2;
		}
	}
}
