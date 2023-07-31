
using UnityEngine;

/// <summary>
/// 初始化
/// </summary>
public class Init : MonoBehaviour {
    
    async void Start() {

        //顯示初始化模擬console畫面
        await ConfigComponent.Instance.isInited.Task;
        //讓每個Component初始化後更新畫面

    }

}
