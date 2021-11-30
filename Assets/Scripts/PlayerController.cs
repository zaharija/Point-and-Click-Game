using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent playerNavMeshAgent;
    public TextController textController;
    public bool isWalking;
    private string target;
    private bool first;
    
    private void Awake()
    {
        playerNavMeshAgent = player.GetComponent<NavMeshAgent>();
        isWalking = false;
        first = true;
    }

    private void Update()
    {
        if (playerNavMeshAgent.remainingDistance > playerNavMeshAgent.stoppingDistance) {
            isWalking = true;
        } else isWalking = false;

        
        if(target != null && !isWalking && !first) {
            initiateConversation(target);
            target = null;
        }
    }

    private void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0)) {
            MovePlayer();
        }
    }

    private void MovePlayer() {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        first = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit)) {
            Vector3 direction = (hit.point - player.transform.position).normalized;
            player.transform.LookAt(direction);
            playerNavMeshAgent.SetDestination(hit.point);
            if(hit.transform.gameObject.tag == "Clickable") {
                target = hit.transform.gameObject.name;
            } else target = null;
        }
    }

    private void initiateConversation(string target) {
        textController.generateText(target);
    }
}
