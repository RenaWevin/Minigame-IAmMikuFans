
using System.Threading.Tasks;
using UnityEngine;
using ComponentStatusType = PanelInitComponent.ComponentStatusType;

/// <summary>
/// 初始化
/// </summary>
public class Init : MonoBehaviour {

    [SerializeField]
    PanelInitComponent panelInitComponent;

    async void Start() {

        panelInitComponent.bool_InitializingAnimationPlay = true;

        panelInitComponent.UpdateDisplay_ComponentTexts();
        await Task.Delay(1000);

        panelInitComponent.SetComponentStatus(nameof(ConfigComponent), ComponentStatusType.Checking);
        panelInitComponent.UpdateDisplay_ComponentTexts();
        await Task.Delay(500);
        await ConfigComponent.Instance.isInited.Task;
        panelInitComponent.SetComponentStatus(nameof(ConfigComponent), ComponentStatusType.Done);
        panelInitComponent.UpdateDisplay_ComponentTexts();

        panelInitComponent.bool_InitializingAnimationPlay = false;

    }

}
