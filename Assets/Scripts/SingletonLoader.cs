using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonLoader : MonoBehaviour {

	public GameObject gameManager;
	
	void Awake (){
		if (GameManager.Instance == null){
			Instantiate(gameManager);
		}
	}
}
