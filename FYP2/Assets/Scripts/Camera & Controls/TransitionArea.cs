using UnityEngine;
using System.Collections;

public class TransitionArea : MonoBehaviour {

	// Use this for initialization
    public float movetimer;
    public TransitionArea nextarea;
    public Vector3 direction;
    bool triggered,isExit;


	void Start () {
        movetimer = 0;
        triggered = false;
        isExit = false;
	}
	
	// Update is called once per frame
	void Update () {



 
        if(isExit)
        {   
            LeaveTriggerArea();
            return;    
        }



        if (triggered && SharedData.instance.player.GetComponent<Movement>().forcemoveplayer(this.transform.position))//upon being triggered move player 
        {
            nextarea.isExit = true;
            SharedData.instance.player.GetComponent<Movement>().changeArea(nextarea);
        }
	}
    void OnTriggerEnter2D(Collider2D other)//eneter transition area
    {
        
        if (other.gameObject.name == "the_player")
        {
            triggered = true;
            other.gameObject.GetComponent<Movement>().m_input = false;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "the_player")
        {
            movetimer = 0;
            triggered = false;
        }

    }

    void LeaveTriggerArea()//shift the player out of the transition area he just arrived at;
    {
        if (SharedData.instance.player.GetComponent<Movement>().forcemoveplayer(this.transform.position + -direction * 100))
        {
            Debug.Log("exit sucess");
            SharedData.instance.player.GetComponent<Movement>().m_input = true;
            isExit = false;
        }
	
    }
}
