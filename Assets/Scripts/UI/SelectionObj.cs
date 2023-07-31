
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObj : MonoBehaviour {

    [SerializeField]
    private Toggle myToggle;
    [SerializeField]
    private Image imageContent;

    public bool IsOn {
        get { return myToggle.isOn; }
    }

    private void Awake() {
        if (!imageContent) {
            Debug.LogError("找不到imageContent");
        }
        if (myToggle) {
            myToggle.onValueChanged.AddListener(OnValueChanged);
        } else {
            Debug.LogError("找不到Toggle");
        }
        Reset();
    }

    private void OnValueChanged(bool on) {
        float scale = on ? 0.8f : 1f;
        imageContent.rectTransform.DOScale(Vector3.one * scale, 0.15f);
    }

    public void Reset() {
        if (imageContent) imageContent.rectTransform.localScale = Vector3.one;
        if (myToggle) myToggle.isOn = false;
    }

}
