using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 0.5f;
    public float fuerzaSalto = 25f;
    public float longitudRaycast = 3.1f;
    public LayerMask capaSuelo; // Asegúrate de que el nombre del layer coincida con el que tienes en tu proyecto
    
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal
        float entradaX = Input.GetAxis("Horizontal");
        float velocidadX = entradaX * speed;

        anim.SetFloat("Movement", Mathf.Abs(entradaX)); 

        // Voltear el sprite
        if (entradaX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (entradaX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        // Corregido: Vector3 con V mayúscula
        Vector3 posicion = transform.position;
        transform.position = new Vector3(posicion.x + velocidadX, posicion.y, posicion.z);

        // Detección de suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        isGrounded = hit.collider != null;
   
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reiniciar la velocidad vertical antes de saltar
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}