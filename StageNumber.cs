using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNumber : MonoBehaviour {

    private GameObject stageSettingsObject;
    private StageSettings stageSettings;
    private Text currentStageText;

	// Use this for initialization
	void Awake () {
        stageSettingsObject = GameObject.Find("GlobalStageSetter");
        stageSettings = stageSettingsObject.GetComponent<StageSettings>();
        currentStageText = gameObject.transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        currentStageText.text = stageSettings.GetCurrentSubStage().ToString();
	}
}
