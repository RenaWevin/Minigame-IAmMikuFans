using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInitComponent : MonoBehaviour {

    [SerializeField]
    private Text Text_NowInitializing;

    private readonly string str_nowInitializing = "........        ";
    private int initStringIndex = 0;
    private int initStringUpdateTimer = 0;

    void Start() {

    }

    void Update() {
        initStringUpdateTimer++;
        if (initStringUpdateTimer >= 5) {
            initStringIndex--;
            if (initStringIndex < 0) {
                initStringIndex = str_nowInitializing.Length - 1;
            }
            Text_NowInitializing.text = $"Now Initializing{str_nowInitializing.Substring(initStringIndex)}{str_nowInitializing.Substring(0, initStringIndex)}";
            initStringUpdateTimer = 0;
        }
    }
}
