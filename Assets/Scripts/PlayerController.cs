using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent playerNavMeshAgent;
    public TextController textController;
    public ItemCombine icBook;
    public ItemCombine icGem;
    public Animator playerAnimator;

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
            InitiateConversation(target);
            target = null;
        }
        
        playerAnimator.SetBool("isWalking", isWalking);
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
        Quaternion rotGoal;
        float turnSpeed = 0.5f;

        if(Physics.Raycast(ray, out RaycastHit hit)) {
            Vector3 direction = (hit.point - player.transform.position).normalized;
            //player.transform.LookAt(direction);
            rotGoal = Quaternion.LookRotation(direction);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotGoal, turnSpeed);
            playerNavMeshAgent.SetDestination(hit.point);
            if(hit.transform.gameObject.tag == "Clickable") {
                if(!icBook.itemClicked && !icGem.itemClicked) {
                    target = hit.transform.gameObject.name;
                } else {
                    target = "SecondCombine";
                    icBook.itemClicked = false;
                    icGem.itemClicked = false;
                }
            } else target = null;
        }
    }

    private void InitiateConversation(string target) {
        textController.generateText(target);
    }
}
