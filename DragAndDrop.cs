using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    #region Declerations
    //Private
    private Vector3 mouseOffset;
    private Vector3 imageStartingCoordinates;

    private float mouseZCoordinates;
    private bool overlappingOutlineImage;

    private GameObject globalStageSetter;
    private StageSettings stageSettings;

    public GameObject heartObjects;
    public PlayerHealth playerHealthScript;


    //Public
    public bool correctImage;
    #endregion

    private void Awake()
    {
        imageStartingCoordinates = gameObject.transform.position;
        globalStageSetter = GameObject.Find("GlobalStageSetter");
        stageSettings = globalStageSetter.GetComponent<StageSettings>();

        heartObjects = GameObject.Find("NumberOfHearts");
        playerHealthScript = heartObjects.GetComponent<PlayerHealth>();

    }

    #region MOUSE FUNCTIONS

    private void OnMouseDown()
    {
        if (playerHealthScript.GetPlayerHealth() > 0)
        {
            mouseZCoordinates = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mouseOffset = gameObject.transform.position - GetMousePosition();
        }
    }

    private void OnMouseDrag()
    {
        if (playerHealthScript.GetPlayerHealth() > 0)
        {
            transform.position = GetMousePosition() + mouseOffset;
        }
    }

    private void OnMouseUp()
    {
        if (overlappingOutlineImage == false)
        {
            Debug.Log("Resesting Position of Image to it's start position");
            resetImagePosition();
        }
        else if (overlappingOutlineImage == true)
        {
            Debug.Log("Image is overlapping with outline image, will now check if this is image is correct");
            CheckImage();
        }
    }

    #endregion

    private void resetImagePosition()
    {
        transform.position = imageStartingCoordinates;
    }


    private Vector3 GetMousePosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoordinates;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void CheckImage()
    {
        if (correctImage == true)
        {
            Debug.Log("The Image is correct, well done!");
            stageSettings.SetCurrentSubstage();
        }
        else if (correctImage == false)
        {
            Debug.Log("The image is not correct, try again!");
            playerHealthScript.SetPlayerHealth();
        }

        resetImagePosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OutlineImage")
        {
            overlappingOutlineImage = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OutlineImage")
        {
            overlappingOutlineImage = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "OutlineImage")
        {
            overlappingOutlineImage = false;
        }
    }

   




}
