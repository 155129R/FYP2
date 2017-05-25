using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed;
    public VirtualJoystick joystick;
    Vector2 tileSize;
    Vector3 waypoint;

    Vector3 up;
    Vector3 down;
    Vector3 left;
    Vector3 right;


    bool moving = false;

    void Start()
    {
        Tiled2Unity.TiledMap Map = GameObject.Find("Map").GetComponent<Tiled2Unity.TiledMap>();
        tileSize.Set(Map.TileWidth, Map.TileHeight);
        up.Set(0, tileSize.y, 0);
        down.Set(0, -tileSize.y, 0);
        left.Set(-tileSize.x, 0, 0);
        right.Set(tileSize.x, 0, 0);

        //setting speed
        speed = 500;
    }

	// Update is called once per frame
	void Update () {
        if (!moving)
        {

            if (Input.GetKey(KeyCode.W))
            {
                waypoint = this.gameObject.transform.position + up;
                moving = true;
            }
           if (Input.GetKey(KeyCode.A))
            {
                waypoint = this.gameObject.transform.position + left;
                moving = true;
            }
           if (Input.GetKey(KeyCode.S))
            {
                waypoint = this.gameObject.transform.position + down;
                moving = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                waypoint = this.gameObject.transform.position + right;
                moving = true;
            }
        }
        if (moving == true)
        {
            if (waypoint - this.gameObject.transform.position != Vector3.zero)
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, waypoint, tileSize.x * speed * Time.deltaTime);
            else
                moving = false;
        }


        //virtual joystick
        if(joystick.ismoving)
        {
            moveplayer(joystick.GetStickDirection());
        }
        else
        {
            //play idle animation in correct direction? stop sprite anim for now in correct direction
            this.gameObject.GetComponentInParent<Animator>().speed = 0;
        }

    }
    public void moveplayer(Vector3 direction)
    {
        //Debug.Log(direction);//the below line isnt necessary for just 4 directions
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.gameObject.transform.position+direction.normalized, joystick.GetStickMagnitude()*speed * Time.deltaTime);
        UpdateAnimations(direction);
    }
    public void UpdateAnimations(Vector3 dir)
    {
        ResetSpriteDirection();
        if(dir.x != 0)//east/west
        {
            if(dir.x > 0)//traveling east
            {
                this.gameObject.GetComponentInParent<Animator>().SetBool("east", true);
                return;
            }
            else//traveling west
            {
                this.gameObject.GetComponentInParent<Animator>().SetBool("west", true);
                return;
            }
 
        }
        if (dir.y != 0)//enorth/south
        {
            if (dir.y > 0)//traveling north
            {
                this.gameObject.GetComponentInParent<Animator>().SetBool("north", true);
                return;
            }
            else//south
            {
                this.gameObject.GetComponentInParent<Animator>().SetBool("south", true);
                return;
            }

        }

        //if the above dont trigger , player is standing still
    }

    public void ResetSpriteDirection()
    {
        this.gameObject.GetComponentInParent<Animator>().speed = 1;
        this.gameObject.GetComponentInParent<Animator>().SetBool("north", false);
        this.gameObject.GetComponentInParent<Animator>().SetBool("south", false);
        this.gameObject.GetComponentInParent<Animator>().SetBool("east", false);
        this.gameObject.GetComponentInParent<Animator>().SetBool("west", false);
    }

}
