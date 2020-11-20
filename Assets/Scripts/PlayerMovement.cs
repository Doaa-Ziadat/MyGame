
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
   public float sidewaysForce = 20;
    public float turnTime = .1f;
    float turnSmoothVelocity;
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    { 
        float horizontal = Input.GetAxisRaw("Horizontal"); //x
        float vertical = Input.GetAxisRaw("Vertical");       //z
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f )
        {
            // transform.forward = new Vector3(horizontal, 0f, vertical).normalized;
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelocity,turnTime);
            Vector3 MoveDirection = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward; // ( moving from angle to direction)
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            

                // rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // when we use forcemode.velocitychange we egnore the mass so we lower the force something like 100
                rb.AddForce(MoveDirection.normalized * sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //fecics stuff adding forces and changing the latency 
        /*
        if (Input.GetKey("right"))
        {

           // rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // when we use forcemode.velocitychange we egnore the mass so we lower the force something like 100
            rb.AddForce(direction * sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("left"))
        {

            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("up"))
        {

            rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("down"))
        {

            rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        
        */
        

        //  if ((rb.position.y +75 > Terrain.activeTerrain.SampleHeight(transform.position)+3)) //& (rb.position.y + 78 < Terrain.activeTerrain.SampleHeight(transform.position)))  
        //  {

        //  Debug.Log(Terrain.activeTerrain.GetPosition());
        // var v = new Vector3(0, 0, 175);
        //rb.MovePosition(Terrain.activeTerrain.GetPosition()+v);

        //        rb.position = new Vector3(rb.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + 78, rb.position.z);

        //else if (rb.position.y + 78 >= Terrain.activeTerrain.SampleHeight(transform.position))
        //   rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z);

        // 74 at the beggining
       
        if ((Terrain.activeTerrain.SampleHeight(transform.position) - rb.position.y < 71) )
        { 
     
                rb.position = new Vector3(rb.position.x, Terrain.activeTerrain.SampleHeight(transform.position) -71, rb.position.z);
        
            Debug.Log(rb.position.y-Terrain.activeTerrain.SampleHeight(transform.position));

        }
    }


}
