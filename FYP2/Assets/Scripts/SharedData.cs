using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Members of class can be accessed in Unity editor
[System.Serializable]

public class SharedData : MonoBehaviour {

    public static SharedData instance = null;
    public Player player;
	// Use this for initialization
	void Start ()
    {
	    if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
    void Update()
    {
    }

}
