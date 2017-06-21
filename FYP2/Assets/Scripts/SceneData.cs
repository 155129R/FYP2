using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SceneData : MonoBehaviour
{
    public Unit player;
    public static SceneData sceneData;
    public Gridarray gridarray;
    public bool mouseinput = true;
	// Use this for initialization
    void Awake()
    {
        sceneData = this;
    }
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
