using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRd;
    private float minSpeed = 10;
    private float maxSpeed = 16;
    private GameManager gameManager;

    private float maxTorque = 10;
    private float xRange = 4.2f;
    private float ySpawnPos = 0;
    public int targetPoint;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    private void Start()
    {
        targetRd = GetComponent<Rigidbody>();
        targetRd.AddForce(RandomForce(), ForceMode.Impulse);
        targetRd.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    //destroy the Target GameObject
    private void OnMouseEnter()
    {
        if (gameManager.isgameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            gameManager.UpdateScore(targetPoint);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
