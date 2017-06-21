using UnityEngine;
using System.Collections;

public class gridMouseInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




    void OnMouseEnter()
    {
        if (!SceneData.sceneData.mouseinput)
            return;

        switch(GetComponent<BGrid>().gridstate)
        {
            case BGrid.Gridstate.MOVE :
                //Debug.Log("pathing");
                SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>());
                break;
            case BGrid.Gridstate.ATTACK:
                //Debug.Log("pathing");
                SceneData.sceneData.gridarray.SetGridState(GetComponent<BGrid>(), BGrid.Gridstate.HIT);
                break;
            default:

                break;
        }
        
    }
    void OnMouseExit()
    {
        if (!SceneData.sceneData.mouseinput)
            return;

        //Debug.Log("de-pathing");
        switch (GetComponent<BGrid>().gridstate)
        {
            case BGrid.Gridstate.PATH:
                //Debug.Log("de-pathing");
                SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>(), true);
                break;
            case BGrid.Gridstate.HIT:
                //Debug.Log("pathing");
                SceneData.sceneData.gridarray.SetGridState(GetComponent<BGrid>(), BGrid.Gridstate.ATTACK);
                break;
           // case BGrid.Gridstate.MOVE:
               // Debug.Log("de-pathing");
               // SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>(), true);
               // break;
            default:

                break;
        }


    }
    void OnMouseDown()
    {
        if (!SceneData.sceneData.mouseinput)
            return;

        //Debug.Log("de-pathing");
        GameObject director = GameObject.Find("BattleDirector");
        switch (GetComponent<BGrid>().gridstate)
        {
            case BGrid.Gridstate.PATH:
                //Debug.Log("accepted path");
                director.GetComponent<Bdirector>().MoveCurrentCharacter(this.GetComponent<BGrid>());
                //SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>(), true);
                break;
            case BGrid.Gridstate.HIT:
                //Debug.Log("pathing");
                director.GetComponent<Bdirector>().CastCurrentAction(this.GetComponent<BGrid>());
                break;

            default:

                break;
        }


    }
}
