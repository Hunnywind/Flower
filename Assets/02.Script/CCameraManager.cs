using UnityEngine;
using System.Collections;

public class CCameraManager : MonoBehaviour {


    private Camera cam;
    private Vector2 nowPos;
    private Vector2 prePos;
    private Vector3 movePos;

    private float speed = 0.1f;
    private float distX;
    private float distY;

    private BoxCollider _box;

    void Awake ()
    {
        cam = GetComponent<Camera>();
    }

    void CameraZoom()
    {
        if (cam.orthographicSize > 20f)
            cam.orthographicSize = 19.5f;
        else if (cam.orthographicSize < 3f)
            cam.orthographicSize = 3.5f;

        if (Input.touchCount >= 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                distX = Mathf.Abs(touch1.position.x - touch2.position.x);
                distY = Mathf.Abs(touch1.position.y - touch2.position.y);
            }
            else if (touch2.phase == TouchPhase.Moved)
            {
                float disX2 = Mathf.Abs(touch1.position.x - touch2.position.x);
                float disY2 = Mathf.Abs(touch1.position.y - touch2.position.y);

                if (distX > disX2)
                {
                    cam.orthographicSize += 1f;
                }
                else if (distX < disX2)
                {
                    cam.orthographicSize -= 1f;
                }
            }
            else if (touch2.phase == TouchPhase.Ended)
            {
                distX = Mathf.Abs(touch1.position.x - touch2.position.x);
                distY = Mathf.Abs(touch1.position.y - touch2.position.y);
            }
        }
    }

    void SetCameraPosition()
    {
        Vector3 pos = transform.position;

        if (transform.position.x >= 33f)
        {
            pos.x = 33f;
        }
        if (transform.position.x <= -33f)
        {
            pos.x = -33f;
        }
        if (transform.position.z >= 36f)
        {
            pos.z = 36f;
        }
        if (transform.position.z <= -53.5f)
        {
            pos.z = -53.5f;
        }

        transform.position = pos;
    }
    
	void Update () {

        CameraZoom();

        SetCameraPosition();
    }

    void FixedUpdate()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)((prePos - nowPos) * speed);
                movePos.z = movePos.y; movePos.y = 0;
                cam.transform.Translate(movePos, Space.World);
                prePos = touch.position - touch.deltaPosition;
            }
            else if(touch.phase == TouchPhase.Ended)
            {

            }
        }
    }
}
