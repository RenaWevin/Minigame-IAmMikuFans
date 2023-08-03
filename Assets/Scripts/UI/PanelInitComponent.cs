
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PanelInitComponent : MonoBehaviour {

    #region UI物件參照區

    [SerializeField]
    private Text Text_NowInitializing;
    [SerializeField]
    public bool bool_InitializingAnimationPlay = true;

    [SerializeField]
    private Text Text_ComponentNames;
    [SerializeField]
    private Text Text_ComponentStatus;

    #endregion
    #region 容器參照區

    /// <summary>
    /// 用以紀錄每個Component的狀態
    /// </summary>
    private class ComponentStatus {
        public string name;
        public ComponentStatusType status;

        public ComponentStatus(string name, bool isAvailable) {
            this.name = name;
            this.status = isAvailable ? ComponentStatusType.InQueue : ComponentStatusType.NotAvailable;
        }
        public string GetStatusString() {
            switch (status) {
                case ComponentStatusType.Done:
                    return "GOOD";
                case ComponentStatusType.Checking:
                    return "WAIT";
                case ComponentStatusType.InQueue:
                    return "....";
                default:
                    return "N/A";
            }
        }
    }

    public enum ComponentStatusType {
        Done, //GOOD
        Checking, //WAIT
        InQueue, //.... (正在等待確認)
        NotAvailable, //N/A
    }

    #endregion
    #region 參數參照區

    private readonly string str_nowInitializing = "........        ";
    private int initStringIndex = 0;
    private int initStringUpdateTimer = 0;

    //Component的名字
    private List<string> componentNames = new List<string>();
    //每個Component的狀態
    private Dictionary<string, ComponentStatus> componentStatuses = new Dictionary<string, ComponentStatus>();
    
    #endregion
    #region Awake/Update

    void Awake() {
        #region  -> 初始化每個Component的狀態

        componentNames.Clear();
        componentStatuses.Clear();
        string configComponent = nameof(ConfigComponent);
        componentNames.Add(configComponent);
        componentStatuses.Add(configComponent, new ComponentStatus(configComponent, true));

        #endregion
        UpdateDisplay_ComponentTexts();
    }

    void Update() {
        if (bool_InitializingAnimationPlay) {
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

    #endregion
    #region 設定特定Component的初始化狀態

    /// <summary>
    /// 設定特定Component的初始化狀態
    /// </summary>
    /// <param name="componentName"></param>
    /// <param name="type"></param>
    public void SetComponentStatus(string componentName, ComponentStatusType type) {
        componentStatuses[componentName].status = type;
    }

    #endregion
    #region 更新Component文字

    /// <summary>
    /// 更新Component文字
    /// </summary>
    public void UpdateDisplay_ComponentTexts() {

        StringBuilder sbName = new StringBuilder();
        StringBuilder sbStatus = new StringBuilder();

        for (int i = 0; i < componentNames.Count; i++) {
            sbName.AppendLine(componentNames[i]);
            sbStatus.Append(": ");
            sbStatus.AppendLine(componentStatuses[componentNames[i]].GetStatusString());
        }

        Text_ComponentNames.text = sbName.ToString();
        Text_ComponentStatus.text = sbStatus.ToString();

    }

    #endregion

}
