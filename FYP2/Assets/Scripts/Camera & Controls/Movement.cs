using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed;

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
    }

}
