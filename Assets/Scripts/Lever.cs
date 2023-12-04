using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door; // —сылка на дверь, которую нужно открыть
    public GameObject lever;
    private bool isPlayerNear = false;
    private bool isLeverActive = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            isLeverActive = !isLeverActive;
            RotateLever();
            door.GetComponent<Door>().OpenDoor(isLeverActive);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void RotateLever()
    {
        // »зменить угол поворота рычага
        lever.transform.rotation = isLeverActive ? Quaternion.Euler(0, 0, -45) : Quaternion.Euler(0, 0, 0);
        lever.transform.localPosition = isLeverActive ? new Vector3(0.784f, 0.358f) : new Vector3(0, 0.6f);
    }
}
