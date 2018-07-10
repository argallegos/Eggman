using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Alex Gallegos and Andrew Bangs (In seperate region) Game manager script
public class GameManager : MonoBehaviour {

    public event System.Action<PlayerScript> OnLocalPlayerJoined;
    private GameObject gameObject;

    private static GameManager m_instance;

    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameManager();
                m_instance.gameObject = new GameObject ("_gameManager");
                m_instance.gameObject.AddComponent<InputController>();

            }
            return m_instance;
        }
    }
    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
                m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;
        }
    }
<<<<<<< HEAD

    private PlayerScript m_LocalPlayer;
    public PlayerScript LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
        set
        {
            m_LocalPlayer = value;
            if(OnLocalPlayerJoined != null)
                    OnLocalPlayerJoined(m_LocalPlayer);
        }
    }
=======
	
	#region Andrew Bangs Code
	void Awake () {		
		DontDestroyOnLoad(this.gameObject);
	}
	
	public int PlayerHP;
	
	public void ReduceHealth (){
		PlayerHP -= 1;
		
		if (PlayerHP <= 0){
			StartCoroutine(RestartLevel(1));
		}
	}
	
	IEnumerator RestartLevel(float delay) {
		// wait for the delay amount of seconds, by yield-returning a WaitForSeconds object:
		yield return new WaitForSeconds(delay);
		// Reload the active scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	#endregion
>>>>>>> 9b44500be751c0869f3e890deb9a41f507d0395d
}
