using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSettings : MonoBehaviour {

    private int numberOfSubStages;
    private int currentSubStageNumber;

    private GameObject building, outline, outline2, outline3, outline4;
    private SpriteRenderer outlineSpriteRenderer;

    private GameObject background2, background3, background4;
    private Animator background2Animator, background3Animator, background4Animator;

    private GameObject fact1, fact2, fact3;
    private Animator fact1Animator, fact2Animator, fact3Animator;

    private GameObject parentObject;
    private Animator parentAnimator;

    public float timer;

    public GameObject[] stageScreens;
    public int currentLevelNumber;
    
    private void Awake()
    {
        parentObject = GameObject.Find("PivotPoint");

        outline = GameObject.Find("Outline");
        outline2 = GameObject.Find("Outline2");
        outline3 = GameObject.Find("Outline3");
        outline4 = GameObject.Find("Outline4");

        background2 = GameObject.Find("Background2");
        background3 = GameObject.Find("Background3");
        background4 = GameObject.Find("Background4");
        background2Animator = background2.GetComponent<Animator>();
        background3Animator = background3.GetComponent<Animator>();
        background4Animator = background4.GetComponent<Animator>();

        fact1 = GameObject.Find("Fact1");
        fact2 = GameObject.Find("Fact2");
        fact3 = GameObject.Find("Fact3");
        fact1Animator = fact1.GetComponent<Animator>();
        fact2Animator = fact2.GetComponent<Animator>();
        fact3Animator = fact3.GetComponent<Animator>();

        parentAnimator = parentObject.GetComponent<Animator>();
        parentAnimator.StopPlayback();

        timer = 10f;

        SetNumberOfSubstages();
        currentSubStageNumber = 1;
        OnToNextStage();
    }

    private void OnToNextStage()
    {


        if (currentLevelNumber == 1)
        {
            if (currentSubStageNumber == 2)
            {
                stageScreens[0].SetActive(false);
                stageScreens[1].SetActive(true);
                stageScreens[2].SetActive(false);
                stageScreens[3].SetActive(false);
                background2Animator.SetInteger("Substage", 2);
                fact1Animator.SetInteger("Substage", 2);

                outline.SetActive(false);
                outline2.SetActive(true);
                outline3.SetActive(false);
                outline4.SetActive(false);

            }
            else if (currentSubStageNumber == 3)
            {
                stageScreens[0].SetActive(false);
                stageScreens[1].SetActive(false);
                stageScreens[2].SetActive(true);
                stageScreens[3].SetActive(false);
                background3Animator.SetInteger("Substage", 3);
                fact2Animator.SetInteger("Substage", 3);

                outline.SetActive(false);
                outline2.SetActive(false);
                outline3.SetActive(true);
                outline4.SetActive(false);
            }
            else if (currentSubStageNumber == 4)
            {
                stageScreens[0].SetActive(false);
                stageScreens[1].SetActive(false);
                stageScreens[2].SetActive(false);
                stageScreens[3].SetActive(true);
                background4Animator.SetInteger("Substage", 4);
                fact3Animator.SetInteger("Substage", 4);

                outline.SetActive(false);
                outline2.SetActive(false);
                outline3.SetActive(false);
                outline4.SetActive(true);
            }
            else if (currentSubStageNumber == 5)
            {
                stageScreens[0].SetActive(false);
                stageScreens[1].SetActive(false);
                stageScreens[2].SetActive(false);
                stageScreens[3].SetActive(false);
                building.SetActive(true);
                outline.SetActive(false);
                parentAnimator.SetInteger("CurrentStage", currentSubStageNumber);

                outline.SetActive(false);
                outline2.SetActive(false);
                outline3.SetActive(false);
                outline4.SetActive(false);

                
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (currentSubStageNumber == 5)
        {
            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                showEndMenu();
            }
        }
    }

    private void showEndMenu()
    {
        SceneManager.LoadScene(4);
    }

    #region GETTER & SETTERS

    private void SetNumberOfSubstages()
    {
        if (currentLevelNumber == 1)
        {
            numberOfSubStages = 4;
            stageScreens = new GameObject[numberOfSubStages];
            stageScreens[0] = GameObject.Find("Stage1");
            stageScreens[1] = GameObject.Find("Stage2");
            stageScreens[2] = GameObject.Find("Stage3");
            stageScreens[3] = GameObject.Find("Stage4");

            building = GameObject.Find("Plaza de España");

            stageScreens[0].SetActive(true);
            stageScreens[1].SetActive(false);
            stageScreens[2].SetActive(false);
            stageScreens[3].SetActive(false);
            building.SetActive(false);
            outline.SetActive(true);
            outline2.SetActive(false);
            outline3.SetActive(false);
            outline4.SetActive(false);


        }
    }

    public void SetCurrentSubstage()
    {
        if (currentSubStageNumber <= 4)
        {
            currentSubStageNumber++;
            OnToNextStage();
        }
    }
    public int GetCurrentSubStage()
    {
        return currentSubStageNumber;
    }

    #endregion
}
