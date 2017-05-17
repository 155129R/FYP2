using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class VirtualJoystick : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler {


	// Use this for initialization    
    public Image bg, joystick;
    private Vector3 input;
    public bool ismoving;

	private void Start () {
        bg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        Debug.Log("started");
        ismoving = false;
	
	}
	
    public virtual void OnPointerDown(PointerEventData pointer)
    {
        Debug.Log("down");
        //OnDrag(pointer);
        //this function is actually obselete(ithink)
    }

    public virtual void OnPointerUp(PointerEventData pointer)
    {
        input = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
        ismoving = false;
    }

    public virtual void OnDrag(PointerEventData pointer)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bg.rectTransform, pointer.position, pointer.pressEventCamera, out pos)) 
        {
            ismoving = true;
            //joystick.rectTransform.anchoredPosition = pos;
            pos.x = (pos.x / bg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bg.rectTransform.sizeDelta.y);
            input = new Vector3(pos.x*2 , 0, pos.y * 2);
            //Debug.Log(input);
            input = (input.magnitude > 1.0f) ? input.normalized : input;

            joystick.rectTransform.anchoredPosition = new Vector3(input.x * (bg.rectTransform.sizeDelta.x / 2)
              , input.z * (bg.rectTransform.sizeDelta.y / 2));

        }
    }

    public Vector3 GetStickDirection()
    {
        return new Vector3(input.x ,input.z,0);
    }
    public float GetStickMagnitude()
    {
        return input.magnitude;
    }

	// Update is called once per frame
	void Update () {

	}
}
