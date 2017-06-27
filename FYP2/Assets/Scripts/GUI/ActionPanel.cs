using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ActionPanel : MonoBehaviour {

	// Use this for initialization
    public GameObject actionbutton;
    public UnitActions unit;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    


    public void PopulatePanel(UnitActions newunit)
    {
        ClearPanel();
        unit = newunit;

        List<GridAttack> actionlist = unit.ActionList;
        for (int i = 0; i < actionlist.Count; i++)
        {
            if (actionlist[i] == null)
                continue;
            GameObject button = Instantiate(actionbutton);
            button.transform.SetParent(this.transform);
            //myBB.Label = "Button " + i;
            //myBB.transform.positon = new Vector3(100, i * 80, 0);
            //button.GetComponent<Text>().text = actionlist[i].name;
        }

    }

    public void ClearPanel()//this deletes all children
    {
        Debug.Log("count: " + transform.childCount);
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Debug.Log("current" + i);
            GameObject button = transform.GetChild(i).gameObject;
            Destroy(button);
            //Destroy(transform.GetChild(i).GetComponent<GameObject>());

        }
    }

    public void SetCurrentAction(GameObject button)
    {    
        int action_index = button.transform.GetSiblingIndex();
        unit.currentaction = unit.ActionList[action_index];
        GameObject director = GameObject.Find("BattleDirector");
        director.GetComponent<Bdirector>().listening = false;
    }

}
