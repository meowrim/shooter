using UnityEngine;

public class PlayerWinTrigger : MonoBehaviour
{
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FinishZone")
        {
            Debug.Log("коснулся");
            winCanvas.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
