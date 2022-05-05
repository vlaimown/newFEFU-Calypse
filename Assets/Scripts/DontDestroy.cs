using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        Object.FindObjectOfType<DontDestroy>();
        DontDestroyOnLoad(gameObject);
    }
}
