using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Image read_next;
    [SerializeField] Canvas helloWorldCanvas;
    public void CloseReadNext()
    {
        read_next.gameObject.SetActive(false);
        helloWorldCanvas.gameObject.SetActive(false);
        gameController.dialoguesController.ninthDialogue.TriggerDialog();
        gameController.dialogManager.dialogueWindow.SetActive(true);
        gameController.HelloWorldCat.gameObject.SetActive(false);
        gameController.catsCount = 1;
        gameController.CATScounter.text = $"({gameController.catsCount}/3)";
    }
}
