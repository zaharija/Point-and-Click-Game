using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent playerNavMeshAgent;
    public bool isWalking;
    
    private void Awake()
    {
        playerNavMeshAgent = player.GetComponent<NavMeshAgent>();
        isWalking = false;
    }

    private void Update()
    {
        if (playerNavMeshAgent.remainingDistance > playerNavMeshAgent.stoppingDistance) {
            isWalking = true;
        } else isWalking = false;
    }

    private void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0)) {
            MovePlayer();
        }
    }

    private void MovePlayer() {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit)) {
            Vector3 direction = (hit.point - player.transform.position).normalized;
            player.transform.LookAt(direction);

            playerNavMeshAgent.SetDestination(hit.point);
        }
    }
}
