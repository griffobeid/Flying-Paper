using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Paperplane : MonoBehaviour
{   /*
    // vars set in unity


    public bool _______________;

    // we are making the plane a particle system
    // so that the windzone component can affect it
    public Transform obj;
    ParticleSystem particlesSystem;
    ParticleSystem.Particle[] particles;
    Rigidbody myRigidbody;
    FlyingPaper fpScript;
    GameObject plane;
    float initialThrust;

    // Use this for initialization
    void Awake()
    {
        // position the plane at the start point
        GameObject start = GameObject.FindGameObjectWithTag("Start");
        gameObject.transform.position = new Vector3(start.transform.position.x - 3, start.transform.position.y - 4, 2.5f);

        initialThrust = 1f;

        fpScript = Camera.main.GetComponent<FlyingPaper>();

        // make the plane a particle system
        particlesSystem = this.GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[1];
        SetupParticleSystem();
        myRigidbody = this.GetComponent<Rigidbody>();


        myRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    void FixedUpdate()
    {
        particlesSystem.GetParticles(particles);

        myRigidbody.velocity += particles[0].velocity;
        particles[0].position = myRigidbody.position;
        particles[0].velocity = Vector3.zero;

        particlesSystem.SetParticles(particles, 1);
    }

    void SetupParticleSystem()
    {
        particlesSystem.startLifetime = Mathf.Infinity;
        particlesSystem.startSpeed = 0;
        particlesSystem.simulationSpace = ParticleSystemSimulationSpace.World;
        particlesSystem.maxParticles = 1;
        particlesSystem.emissionRate = 1;
        // can't set the following with code so do manually
        // 1 - Enable "External Forces"
        // 2 - Disable "Renderer"

        // the below is to start the particle at the center
        particlesSystem.Emit(1);
        particlesSystem.GetParticles(particles);
        particles[0].position = Vector3.zero;
        particlesSystem.SetParticles(particles, 1);
    }

    // use case: round fail
    // for use with detecting collision of walls.
    void OnCollisionEnter(Collision col)
    {
        // destroy the plane anytime it collides with a wall
        if (col.gameObject.tag == "Wall")
        {
            // call PlaneDestroyed() in the FlyingPaper script
            fpScript.PlaneDestroyed();
        }
    }

    // implementing coin pick up and finish line
    // calls a script in the FlyingPaper class
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // call CoinPickup() in the FlyingPaper script
            fpScript.CoinPickup(other);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            // call FinishLine() in the FlyingPaper script
            fpScript.FinishLine();
        }
    }

    // sets the initial force added to the plane 
    // based on the length of the arrow
    public void setThrust(float v) {
        initialThrust = initialThrust + v;
        Debug.Log(initialThrust);
    }


    // this method is called when the fly button is clicked
    // it gives the plane an initial velocity that diminishes over time
    // also will hide the fly button in here
    public void BeginFlight()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        Destroy(GameObject.FindGameObjectWithTag("Arrow"));
        Destroy(GameObject.FindGameObjectWithTag("ArrowContainer"));

        myRigidbody.constraints = RigidbodyConstraints.None;
        myRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        myRigidbody.AddForce(transform.forward * initialThrust, ForceMode.Impulse);
    }
    */
}
