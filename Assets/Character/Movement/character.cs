using UnityEngine;

public class character : MonoBehaviour
{
    public float characterSpeed = 1.0f;
    public float rotationSpeed = 250.0f;
    public float jumpForce = 1.0f;
    private Rigidbody rb;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
            anim.SetTrigger("jump 0");
        };

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool("isRunning", true);
            characterSpeed = 3.0f;
        }else if (Input.GetKeyUp(KeyCode.LeftShift)){
             anim.SetBool("isRunning", false);
              characterSpeed = 1.0f;
        }

        Vector3 movement = new Vector3(hMovement, 0.0f, vMovement) * characterSpeed * Time.deltaTime;
        transform.Translate(movement);

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0.0f, rotation, 0.0f);

        validateWalking(vMovement);
        anim.SetFloat("VelX", hMovement);
        anim.SetFloat("VelY", vMovement);
    }

    public void validateWalking(float verticalMovement){
        if(verticalMovement != 0.0f){
            anim.SetBool("isWalking", true);
        }else{
            anim.SetBool("isWalking", false);
        }
    }
}
