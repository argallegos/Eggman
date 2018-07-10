using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Alex Gallegos and Andrew Bangs (In seperate region) Game manager script
public class PlayerManager {
  
    public event System.Action<PlayerScript> OnLocalPlayerJoined;
    private GameObject gameObject;

    private static PlayerManager m_instance;

    public static PlayerManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new PlayerManager();
                m_instance.gameObject = new GameObject ("_PlayerManager");
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
	

}
