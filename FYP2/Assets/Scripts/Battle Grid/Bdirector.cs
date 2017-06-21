using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bdirector : MonoBehaviour {

	// Use this for initialization
    public enum Bstate//battle state cycles in downaward order
    {
        P_SET_MOVE,//move phase starts here, wait for player to move all allied char
        E_SET_MOVE,//AI here

        P_SET_ACTION,//action phase starts here, wait for player to assign action to all allied char
        E_SET_ACTION,//AI Action based on position/own health/wtv
        //check for victory/defeat at the end of ^this state

        END_DEFEAT,
        END_VICTORY,
    }
    public Bstate currentphase;
    public Unit currentunit,testenemy,player;
    //public Unit testenemy;
    public int phase_count;

    public List<Unit> player_party;
    public Queue<Unit> player_units;
    bool isqueue=false;
    public List<Unit> enemy_party;


    public Gridarray board;//thsi hoolds the level grid
    List<BGrid> tiles;//this holds appopratie tile information for the current state 
    public List<Vector2> spawn_points;// this are the spawn indexes for friendly units

    public bool listening = false;

	void Start () {

        SetBattleStart();
	}
	
	// Update is called once per frame
	void Update () {

	    switch(currentphase)
        {
            case Bstate.P_SET_MOVE:
                if(!isqueue)
                {
                    for (int i = 0; i < player_party.Count; i++)
                    {
                        player_units.Enqueue(player_party[i]);
                    }
                    //Unit unit = player;
                    //player_units.Enqueue(); 
                    isqueue = true;

                   
                    currentunit = player_units.Dequeue();
                }

                if(!listening)
                {
                    setCurrentMoveGrids();
                    listening = true;
                }
                //display mouse over paths

                //waiting for input

                break;
            case Bstate.E_SET_MOVE:
                //currentunit = testenemy;
                //MoveCurrentCharacter(currentunit.GetComponent<Enemy>().GetTargetTile());
                //currentphase = Bstate.P_SET_ACTION;
               break;
            case Bstate.P_SET_ACTION:
               currentphase = Bstate.P_SET_MOVE;
               listening = false;
               break;
        }


	}

    void SetBattleStart()
    {
        //spawn all players and monsters at the correct location
        player_units = new Queue<Unit>();
        //friendly(need loop later)
        for (int i = 0; i < player_party.Count; i++)
        {
            currentunit = player_party[i];
            //int point = Random.Range(0, spawn_points.Count);
            currentunit.tile = board.GetGridAt(spawn_points[i]).GetComponent<BGrid>();
            currentunit.transform.position = currentunit.tile.transform.position;
            currentunit.Place(currentunit.tile);
        }
        for (int j = 0; j < enemy_party.Count; j++)
        {
            currentunit = enemy_party[j];
            currentunit.tile = board.GetRandomEmptyGrid();
            currentunit.transform.position = currentunit.tile.transform.position;
            currentunit.Place(currentunit.tile);
        }

        //currentunit = testenemy;
        //currentunit.tile = board.GetGridAt(6,8).GetComponent<BGrid>();
        //currentunit.transform.position = currentunit.tile.transform.position;
        //currentunit.Place(board.GetGridAt(6, 8).GetComponent<BGrid>());



        currentphase = Bstate.P_SET_MOVE;//start every encounter with player move phase
        phase_count = 0;
    }
    void setCurrentMoveGrids()
    {
        //board.DerenderGrids();
        GridMovement mover = currentunit.GetComponent<GridMovement>();
        tiles = mover.GetTilesInRange(board);
        board.SetMovableGrids(tiles);
    }
    public void MoveCurrentCharacter(BGrid destination)
    {
        //Debug.Log("calling move funcc");
       // SceneData.sceneData.mouseinput = false;
        board.DerenderGrids();
        GridMovement m = currentunit.GetComponent<GridMovement>();
        StartCoroutine(m.Traverse(destination));
        //check if anymore friendly chaar
        if(player_units.Count !=0)
        {
            Debug.Log("next allied unit");
            listening = false;
            currentunit = player_units.Dequeue();
        }
        else
        currentphase = Bstate.E_SET_MOVE;


       // SceneData.sceneData.mouseinput = false;

       //move to next char

       //enable controls


    
        
        //currentunit.GetComponent<GridMovement>().Traverse(destination);
        //board.DerenderGrids();
        //currentunit
    }
    public void ResetMovePhase()
    {
        Debug.Log("reseting");
        SceneData.sceneData.mouseinput = true;
        setCurrentMoveGrids();
        
    }

}
