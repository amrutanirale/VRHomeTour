using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 1f;
    public GameObject parabolicRaycaster, movementText, teleportText, gazeRing, lineRaycaster, menu;
    bool canTeleport = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame...
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back) && !menu.activeInHierarchy)
        {
            menu.SetActive(true);
            gazeRing.SetActive(true);
            lineRaycaster.SetActive(true);
        }
        //ToggleCheck();
        if (canTeleport)
        {
            Teleport();
        }
        else
        {
            Move();
        }
    }
    public void ToggleCheck()
    {
        ////if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (canTeleport)
            {
                canTeleport = false;
                teleportText.SetActive(true);
                movementText.SetActive(false);
            }
            else
            {
                canTeleport = true;
                teleportText.SetActive(false);
                movementText.SetActive(true);
            }
        }
    }
    public void Teleport()
    {
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad) && canTeleport)
        {
            parabolicRaycaster.SetActive(true);
        }
        else
        {
            parabolicRaycaster.SetActive(false);
        }
    }

    public void Move()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);

            var absX = Mathf.Abs(coord.x);
            var absY = Mathf.Abs(coord.y);
            if (absX > absY)
            {
                if (coord.x > 0)
                {
                    transform.Rotate(new Vector3(0, 1, 0));

                }
                else
                {

                    transform.Rotate(new Vector3(0, -1, 0));
                }

            }
            else
            {
                if (coord.y > 0)
                {
                    transform.position += transform.forward * playerSpeed * Time.deltaTime;
                }
                else
                {
                    transform.position -= transform.forward * playerSpeed * Time.deltaTime;
                }
            }
        }
        //if (OVRInput.GetDown(OVRInput.RawButton.DpadUp))
        //{
        //    transform.position += transform.forward * playerSpeed * Time.deltaTime;
        //}
        //if (OVRInput.GetDown(OVRInput.RawButton.DpadDown))
        //{
        //    transform.position -= transform.forward * playerSpeed * Time.deltaTime;
        //}

    }
}
