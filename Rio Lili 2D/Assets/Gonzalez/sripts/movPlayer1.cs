using UnityEngine;

public class PlayerSimple : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Animator anim;
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;

    private float horizontal;
    private bool mirandoDerecha = true;

    [Header("Chequeo suelo")]
    public Transform checkSuelo;
    public LayerMask capaSuelo;

    private void Update()
    {
        //Movimiento animacion
        if (horizontal > 0 || horizontal < 0)
        {
            anim.SetFloat("walk", Mathf.Abs(horizontal));
        }
        else
        {
            anim.SetFloat("walk", 0);
        }



        if (Input.GetButtonDown("Jump") && EstaEnSuelo())
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            anim.SetBool("salto", true);

        }

        if (EstaEnSuelo() && rb.velocity.y <= 0)
        {
            anim.SetBool("salto", false);
        }


        // Movimiento horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnSuelo())
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        // Voltear sprite
        if (mirandoDerecha && horizontal < 0f || !mirandoDerecha && horizontal > 0f)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * velocidad, rb.velocity.y);
    }

    private bool EstaEnSuelo()
    {
        return Physics2D.OverlapCircle(checkSuelo.position, 0.2f, capaSuelo);
    }
}
