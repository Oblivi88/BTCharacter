using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private LayerMask groundLayer;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        groundLayer = LayerMask.GetMask("Ground");
    }
    private void Update()
    {
        // CLICK TO MOVE
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, float.MaxValue, groundLayer))
            {
                navAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
