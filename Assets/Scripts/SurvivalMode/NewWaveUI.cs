using UnityEngine;
using UnityEngine.UI;

public class NewWaveUI : MonoBehaviour
{
    [SerializeField] Image waveCounterImg;
    void UpdateImg()
    {
        waveCounterImg.gameObject.SetActive(false);
    }
}
