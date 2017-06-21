using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected List<BGrid> GetMovementRange()
    {
        return GetComponent<GridMovement>().GetTilesInRange(SceneData.sceneData.gridarray);
        //return tiles;
    }

    public virtual BGrid GetTargetTile()
    {
        return null;
    }

    protected BGrid GetAdjacentTile(BGrid target,List<BGrid> checklist)
    {
        Gridarray temp = SceneData.sceneData.gridarray;
        Vector2 tempindex;

        tempindex =target.index + new Vector2(0,1);//check above;
        if (checklist.Contains(temp.GetGridAt(tempindex).GetComponent<BGrid>()))
            return temp.GetGridAt(tempindex).GetComponent<BGrid>();
        tempindex = target.index + new Vector2(0, -1);//check below;
        if (checklist.Contains(temp.GetGridAt(tempindex).GetComponent<BGrid>()))
            return temp.GetGridAt(tempindex).GetComponent<BGrid>();
        tempindex = target.index + new Vector2(-1, 0);//check left;
        if (checklist.Contains(temp.GetGridAt(tempindex).GetComponent<BGrid>()))
            return temp.GetGridAt(tempindex).GetComponent<BGrid>();
        tempindex = target.index + new Vector2(1, 0);//check right;
        if (checklist.Contains(temp.GetGridAt(tempindex).GetComponent<BGrid>()))
            return temp.GetGridAt(tempindex).GetComponent<BGrid>();
        else return null;

    }
}
