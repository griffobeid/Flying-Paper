using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Paperplane : MonoBehaviour {
	// we are making the plane a particle system
	// so that the windzone component can affect it
	public Transform obj;
	ParticleSystem particlesSystem;
	ParticleSystem.Particle[] particles;
	Rigidbody myRigidbody;


	// Use this for initialization
	void Start () {

		// make the plane a particle system
		particlesSystem = gameObject.GetComponent<ParticleSystem>();
		particles = new ParticleSystem.Particle[1];
		SetupParticleSystem();
		myRigidbody = gameObject.GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		particlesSystem.GetParticles(particles);

		myRigidbody.velocity += particles[0].velocity;
		particles[0].position = myRigidbody.position;
		particles[0].velocity = Vector3.zero;

		particlesSystem.SetParticles(particles, 1);
	}

	void SetupParticleSystem() {
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
	void OnCollisionEnter(Collision col) {
		// destroy the plane anytime it collides with a wall
		if(col.gameObject.tag == "wall") {
            FlyingPaper fpScript = Camera.main.GetComponent<FlyingPaper>();
            // call PlaneDestroyed() in the FlyingPaper script
            fpScript.PlaneDestroyed();
	}
}
}
