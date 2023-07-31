
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTitleComponent : MonoBehaviour {

    #region UI物件參照區

    [SerializeField] Button Btn_Exit;

    #endregion

    void Awake() {
        Btn_Exit.onClick.AddListener(OnClick_Btn_Exit);
    }

    void Start() {

    }

    void Update() {

    }

    #region UIEvent

    #region  -> 標題按鈕事件

    /// <summary>
    /// 離開按鈕
    /// </summary>
    private void OnClick_Btn_Exit() {

    }

    #endregion

    #endregion

}
