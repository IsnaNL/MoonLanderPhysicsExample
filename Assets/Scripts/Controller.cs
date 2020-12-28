using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody rB;
   // private Vector2 forceDir;
    private KeyCode giveForce = KeyCode.Space;
    private KeyCode Break = KeyCode.Z;
    private float force;
    private float verInput;
    public float tourqeAmount;
    public float forceAcc;
    public float forceDeacc;
    public float forceMax;
    public LayerMask groundLayer;
    public float rotateBackToDefaultSpeed;
    public Slider slider;
    private bool isgrounded;
    public GameObject fire;


    // bool isGivingForce;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        //forceDir = Vector2.up;

    }
    private void Update()
    {
        slider.value = force * 0.1f;
        verInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(giveForce) && isgrounded)
        {
            rB.AddForce(transform.up * 500);
            //transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }

        if (Input.GetKey(giveForce))
        {

            //isGivingForce = true; 
            force = Mathf.MoveTowards(force, forceMax, forceAcc * Time.deltaTime);
            fire.SetActive(true);
        }
        else
        {
            force = Mathf.MoveTowards(force, 0, forceDeacc * Time.deltaTime);
            fire.SetActive(false);

            //  isGivingForce = false;

        }
        //  if (Input.GetKey(Break))
        // {
        //    isBreaking = true;
        // }
        //  else
        // {
        //    isBreaking = false;

        // }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(verInput != 0)
        {
          rB.AddRelativeTorque(verInput * tourqeAmount * transform.forward * Time.fixedDeltaTime,ForceMode.Impulse);

        }
        

        
        rB.AddRelativeForce(transform.up * force * Time.fixedDeltaTime);
        rB.velocity = Vector2.ClampMagnitude(rB.velocity, 20);
        //  bool hit = Physics.Raycast(transform.position, Vector3.down, 2, groundLayer);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 3.5f);
       
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3.5f, groundLayer))
        {
            isgrounded = true;
          //  float y = rB.velocity.y;
           Debug.Log(" raycastHit");
            rB.velocity *= 0.5f;

            //Quaternion target = Quaternion.Euler);
            // transform.Rotate(new Vector3(0, 0, Mathf.MoveTowards(transform.rotation.z, 0, rotateBackToDefaultSpeed * Time.deltaTime)));


        }
        else
        {
            isgrounded = false;
        }
       

    }
   
}
