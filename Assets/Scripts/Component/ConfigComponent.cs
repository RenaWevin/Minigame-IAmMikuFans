
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ConfigComponent {

    #region 本體參照

    private static class LazyHolder {
        public static ConfigComponent instance = new ConfigComponent();
    }

    public static ConfigComponent Instance {
        get { return LazyHolder.instance; }
    }

    #endregion
    #region 初始化

    private ConfigComponent() {
        Init();
    }

    private async void Init() {
        var spriteSettingsHandle = Addressables.LoadAssetAsync<TextAsset>("Config_SpriteSettings");
        TextAsset spriteSettingsAsset = await spriteSettingsHandle.Task;

        isInited.SetResult(true);
    }

    #endregion
    #region 資料貯存區

    /// <summary>已經初始化</summary>
    public TaskCompletionSource<bool> isInited { get; private set; } = new TaskCompletionSource<bool>();

    /// <summary>Miku圖片總數</summary>
    public int spriteCount_Miku { get; private set; }

    /// <summary>非Miku圖片總數</summary>
    public int spriteCount_NotMiku { get; private set; }

    #endregion
    #region 資料獲取區

    /// <summary>
    /// 取得Miku圖片總數
    /// </summary>
    public async Task<int> GetSpriteCount_Miku() {
        await isInited.Task;
        return spriteCount_Miku;
    }

    #endregion

}
