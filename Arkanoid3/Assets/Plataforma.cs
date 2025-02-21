using UnityEngine;


public class Plataforma : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rB2D;
    public float Speed = 1.0f;


    public float bounceForce = 10f; // For�a de impulso quando a bola colide com a plataforma


    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rB2D.transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rB2D.transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {


            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 platformCenter = GetComponent<Collider2D>().bounds.center;


            // Calcula a dire��o do impulso com base no ponto de colis�o
            float hitFactor = (contactPoint.x - platformCenter.x) / (GetComponent<Collider2D>().bounds.size.x / 2);


            // Aplica o impulso na bola
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                // Aplique o impulso com base no hitFactor e na for�a de impulso
                Vector2 bounceDirection = new Vector2(hitFactor, 1).normalized; // Dire��o para cima e para os lados
                ballRb.linearVelocity = bounceDirection * bounceForce; // Aplica o impulso na bola
            }


        }
    }
}



