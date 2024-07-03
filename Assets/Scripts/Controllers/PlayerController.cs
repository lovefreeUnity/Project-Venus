using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    private float speed = 8f;
    private float jumpForce = 5;
    private bool isGrounded = false;
    Vector3 dirVec;
    // GameObject gameObject;
    public DialogueManager dialogueManager;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = dialogueManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        float moveZ = dialogueManager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed;

        playerRigidbody.velocity = new Vector3(movement.x, playerRigidbody.velocity.y, movement.z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !dialogueManager.isAction)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        if(moveZ == 1){
            dirVec = Vector3.forward; 
        }else if(moveZ == -1){
            dirVec = Vector3.back; 
        }else if(moveX == 1){
            dirVec = Vector3.right; 
        }else if(moveX == -1){
            dirVec = Vector3.left; 
        }
        
        if (Input.GetKeyDown(KeyCode.F) && Physics.Raycast(playerRigidbody.position, dirVec, out RaycastHit raycastHit,1.5f))
        {
            GameObject hitObject = raycastHit.collider.gameObject;
            ITalkable iTalkable = hitObject.GetComponent<ITalkable>();
            if (iTalkable != null){
                dialogueManager.ShowDialogue(iTalkable.GetDialogueNameText(), iTalkable.GetDialogueText());
            }
            
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }   
    }

}
