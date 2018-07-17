using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Andrew Bangs, Script for salt and pepper shakers
public class Shaker_Script : MonoBehaviour {

	private PlayerScript playerStats;
	
	[Tooltip("Value of 1 = Salt, 2 = Pepper")]
	public int ShakerType;
	public float ResetDelay;
	
	void Start(){
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
	}
	
	void OnTriggerEnter (Collider other){
		if (ShakerType == 1 && other.gameObject.CompareTag ("Player")){
			playerStats.speed = playerStats.speed / 2;
		} else if (ShakerType == 2 && other.gameObject.CompareTag ("Player")){
			GameManager.Instance.ChangeDMGMult(ResetDelay, false);
		}
	}
	
		void OnTriggerExit (Collider other){
		if (ShakerType == 1 && other.gameObject.CompareTag ("Player")){
			StartCoroutine(ResetSpeed(ResetDelay));
		} else if (ShakerType == 2 && other.gameObject.CompareTag ("Player")){
			GameManager.Instance.ChangeDMGMult(ResetDelay, true);
		}
	}
	
	IEnumerator ResetSpeed(float Delay){
		yield return new WaitForSeconds(Delay);
		playerStats.speed = playerStats.speed * 2;
	}
}
