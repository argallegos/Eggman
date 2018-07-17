using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Andrew Bangs Heat Vent script
public class HeatVent_Script : MonoBehaviour {

	public int dmgAmount;
	public int tickAmount;
	
	void OnTriggerExit (Collider other){
		if (other.gameObject.CompareTag("Player")){
			GameManager.Instance.BurnPlayer(tickAmount, dmgAmount);
			Debug.Log("Trigger Burnination");
		}
	}
	
	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag("Player")){
			GameManager.Instance.BurnPlayer(tickAmount, dmgAmount);
			Debug.Log("Trigger Burnination");
		}
	}
}
