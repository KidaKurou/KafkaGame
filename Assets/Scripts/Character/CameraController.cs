using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target = null; // ����, �� ������� ����� ������� ������
    [SerializeField] private float smoothSpeed = 0.125f; // �������� ������������
    [SerializeField] private float yOffset = 0f; 
    private SwitcherPlayer switcherPlayer = null;

    private void Start()
    {
        switcherPlayer = FindObjectOfType<SwitcherPlayer>();
        switcherPlayer.SwitchedPlayer.AddListener(SwitcherCamera);
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f); // ������������� ������� ������ � ������ �������� �� Z
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // ������������� ������� ������

            transform.position = smoothedPosition;
        }
    }

    private void SwitcherCamera()
    {
        CharacterMovement[] players = FindObjectsOfType<CharacterMovement>();
        foreach (CharacterMovement player in players)
        {
            if (player.GetComponent<CharacterMovement>().enabled == true)
            {
                target = player.transform;
            }
        }
    }
}
