using UnityEngine;
using System.Collections;

public class gridMouseImput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {

        switch(GetComponent<BGrid>().gridstate)
        {
            case BGrid.Gridstate.MOVE :
                //Debug.Log("pathing");
                SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>());
                break;
            default:
            case BGrid.Gridstate.ATTACK:
                //Debug.Log("pathing");
                SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>());
                break;
        }
        
    }
    void OnMouseExit()
    {
        //Debug.Log("de-pathing");
        switch (GetComponent<BGrid>().gridstate)
        {
            case BGrid.Gridstate.PATH:
                //Debug.Log("de-pathing");
                SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>(), true);
                break;
            case BGrid.Gridstate.HIT:
                //Debug.Log("pathing");
                SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>());
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
        //Debug.Log("de-pathing");
        switch (GetComponent<BGrid>().gridstate)
        {
            case BGrid.Gridstate.PATH:
                //Debug.Log("accepted path");
                GameObject director = GameObject.Find("BattleDirector");
                director.GetComponent<Bdirector>().MoveCurrentCharacter(this.GetComponent<BGrid>());
                //SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>(), true);
                break;
            // case BGrid.Gridstate.MOVE:
            // Debug.Log("de-pathing");
            // SceneData.sceneData.gridarray.RenderPathForGrid(GetComponent<BGrid>(), true);
            // break;
            default:

                break;
        }


    }
}
