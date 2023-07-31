
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class CollectionSaveHelper {

    // 收藏ID規格：初音ID為390**，非初音ID為000**
    // PlayerPrefs圖片ID規格：初音為Collection_M**，非初音為Collection_N**
    // Addressable圖片ID規格：初音為Sprite_M**，非初音為Sprite_N**
    // **為2位數，固定從01開始到99
    // PlayerPrefs中，有在收藏內的圖片int=1，反之int=0或不存在

    private const string CollectionPlayerPrefsKey_Miku = "Collection_M{0:00}";
    private const string CollectionPlayerPrefsKey_NotMiku = "Collection_N{0:00}";

    /// <summary>
    /// 新增登記收藏
    /// </summary>
    public static void AddCollections(params int[] ids) {
        for (int i = 0; i < ids.Length; i++) {
            int subId = ids[i] % 100;
            string key;
            if (ids[i] > 39000) {
                //初音
                key = string.Format(CollectionPlayerPrefsKey_Miku, subId);
            } else {
                //非初音
                key = string.Format(CollectionPlayerPrefsKey_NotMiku, subId);
            }
            PlayerPrefs.SetInt(key, 1);
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 清除所有收藏
    /// </summary>
    public static async Task ClearCollection() {
        await ConfigComponent.Instance.isInited.Task;

        string key;
        int spriteCount_Miku = ConfigComponent.Instance.spriteCount_Miku;
        for (int i = 1; i <= spriteCount_Miku; i++) {
            key = string.Format(CollectionPlayerPrefsKey_Miku, i);
            PlayerPrefs.SetInt(key, 0);
        }
        int spriteCount_NotMiku = ConfigComponent.Instance.spriteCount_NotMiku;
        for (int i = 1; i <= spriteCount_NotMiku; i++) {
            key = string.Format(CollectionPlayerPrefsKey_NotMiku, i);
            PlayerPrefs.SetInt(key, 0);
        }
        PlayerPrefs.Save();
    }

}
