using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");
        float fastTranslationX = 2 * Input.GetAxis("Horizontal");
        float fastTranslationY = 2 * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(fastTranslationX + fastTranslationY, 0, fastTranslationY - fastTranslationX);
        }
        else
        {
            transform.Translate(translationX + translationY, 0, translationY - translationX);
        }

        ////////////////////
        //mouse scrolling

        //var mousePosX = Input.mousePosition.x;
        //var mousePosY = Input.mousePosition.y;
        //int scrollDistance= 5;
        //float scrollSpeed = 70;

        ////Horizontal camera movement
        //if (mousePosX < scrollDistance)
        ////horizontal, left
        //{
        //    transform.Translate(-1, 0, 1);
        //}
        //if (mousePosX >= Screen.width - scrollDistance)
        ////horizontal, right
        //{
        //    transform.Translate(1, 0, -1);
        //}

        ////Vertical camera movement
        //if (mousePosY < scrollDistance)
        ////scrolling down
        //{
        //    transform.Translate(-1, 0, -1);
        //}
        //if (mousePosY >= Screen.height - scrollDistance)
        ////scrolling up
        //{
        //    transform.Translate(1, 0, 1);
        //}

        //////////////////////
        ////zooming
        //GameObject Eye  = GameObject.Find("Eye");

        ////
        //if (Input.GetAxis("Mouse ScrollWheel") > 0  Eye.camera.> 4)
        //{
        //    Eye.camera.orthographicSize = Eye.camera.orthographicSize - 4;
        //}

        ////
        //if (Input.GetAxis("Mouse ScrollWheel") < 0  Eye.camera.orthographicSize < 80)
        //{
        //    Eye.camera.orthographicSize = Eye.camera.orthographicSize + 4;
        //}

        ////default zoom
        //if (Input.GetKeyDown(KeyCode.Mouse2))
        //{
        //    Eye.camera.orthographicSize = 50;
        //}

    }
}

public class CamaraJugador : MonoBehaviour
{
    public Transform CameraTarget;
    private float x = 0.0f;
    private float y = 0.0f;

    private int mouseXSpeedMod = 5;
    private int mouseYSpeedMod = 5;

    public float MaxViewDistance = 15f;
    public float MinViewDistance = 1f;
    public int ZoomRate = 20;
    private int lerpRate = 5;
    private float distance = 3f;
    private float desireDistance;
    private float correctedDistance;
    private float currentDistance;

    public float cameraTargetHeight = 1.0f;

    //checks if first person mode is on
    private bool click = false;
    //stores cameras distance from player
    private float curDist = 0;

    // Use this for initialization
    void Start()
    {
        Vector3 Angles = transform.eulerAngles;
        x = Angles.x;
        y = Angles.y;
        currentDistance = distance;
        desireDistance = distance;
        correctedDistance = distance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {/*0 mouse btn izq, 1 mouse btn der*/
            x += Input.GetAxis("Mouse X") * mouseXSpeedMod;
            y += Input.GetAxis("Mouse Y") * mouseYSpeedMod;
        }
        else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            float targetRotantionAngle = CameraTarget.eulerAngles.y;
            float cameraRotationAngle = transform.eulerAngles.y;
            x = Mathf.LerpAngle(cameraRotationAngle, targetRotantionAngle, lerpRate * Time.deltaTime);
        }

        y = ClampAngle(y, -15, 25);
        Quaternion rotation = Quaternion.Euler(y, x, 0);

        desireDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomRate * Mathf.Abs(desireDistance);
        desireDistance = Mathf.Clamp(desireDistance, MinViewDistance, MaxViewDistance);
        correctedDistance = desireDistance;

        Vector3 position = CameraTarget.position - (rotation * Vector3.forward * desireDistance);

        RaycastHit collisionHit;
        Vector3 cameraTargetPosition = new Vector3(CameraTarget.position.x, CameraTarget.position.y + cameraTargetHeight, CameraTarget.position.z);

        bool isCorrected = false;
        if (Physics.Linecast(cameraTargetPosition, position, out collisionHit))
        {
            position = collisionHit.point;
            correctedDistance = Vector3.Distance(cameraTargetPosition, position);
            isCorrected = true;
        }

        //?
        //condicion ? first_expresion : second_expresion;
        //(input > 0) ? isPositive : isNegative;

        currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * ZoomRate) : correctedDistance;

        position = CameraTarget.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, -cameraTargetHeight, 0));

        transform.rotation = rotation;
        transform.position = position;

        //CameraTarget.rotation = rotation;

        float cameraX = transform.rotation.x;
        //checks if right mouse button is pushed
        if (Input.GetMouseButton(1))
        {
            //sets CHARACTERS x rotation to match cameras x rotation
            CameraTarget.eulerAngles = new Vector3(cameraX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        //checks if middle mouse button is pushed down
        if (Input.GetMouseButtonDown(2))
        {
            //if middle mouse button is pressed 1st time set click to true and camera in front of player and save cameras position before mmb.
            //if mmb is pressed again set camera back to it's position before we clicked mmb 1st time and set click to false
            if (click == false)
            {
                click = true;
                curDist = distance;
                distance = distance - distance - 1;
            }
            else
            {
                distance = curDist;
                click = false;
            }
        }

    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
