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

    [Header("Fast Fall")]
    public float caidaRapidaExtra = 10f;

    [Header("Rodar")]
    public float fuerzaRodar = 7f;
    private bool rodando = false;

    [Header("Sonidos")]
    public AudioSource audioSource;
    public AudioClip runSound;
    public AudioClip jumpSound;
    public AudioClip idleSound;
    public AudioClip rollSound;

    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (rodando) return; // mientras rueda, no puede mover ni saltar normal

        // Movimiento animación
        if (horizontal != 0)
        {
            anim.SetFloat("walk", Mathf.Abs(horizontal));
            ReproducirSonido(runSound, true); // loop de correr
        }
        else
        {
            anim.SetFloat("walk", 0);
            ReproducirSonido(idleSound, true); // loop idle
        }

        // Saltar
        if (Input.GetButtonDown("Jump") && EstaEnSuelo())
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            anim.SetBool("salto", true);
            ReproducirSonido(jumpSound, false); // salto se reproduce una vez
        }

        if (EstaEnSuelo() && rb.velocity.y <= 0)
        {
            anim.SetBool("salto", false);
        }

        // Movimiento horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        // Voltear sprite
        if (mirandoDerecha && horizontal < 0f || !mirandoDerecha && horizontal > 0f)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.Rotate(0f, 180f, 0f);
        }

        // Fast Fall (cuando está en el aire y presiona S)
        if (!EstaEnSuelo() && Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - caidaRapidaExtra * Time.deltaTime);
        }

        // Rodar con tecla C
        if (Input.GetKeyDown(KeyCode.C) && EstaEnSuelo())
        {
            StartCoroutine(Rodar());
        }
    }

    private void FixedUpdate()
    {
        if (rodando) return; // no se mueve con Input mientras rueda

        rb.velocity = new Vector2(horizontal * velocidad, rb.velocity.y);
    }

    private bool EstaEnSuelo()
    {
        return Physics2D.OverlapCircle(checkSuelo.position, 0.2f, capaSuelo);
    }

    // Método para reproducir sonidos evitando que se corten
    private void ReproducirSonido(AudioClip clip, bool loop)
    {
        if (audioSource.clip == clip && audioSource.isPlaying) return;

        audioSource.loop = loop;
        audioSource.clip = clip;
        audioSource.Play();
    }

    // -----------------------------
    // MECÁNICA DE RODAR
    // -----------------------------
    private System.Collections.IEnumerator Rodar()
    {
        rodando = true;
        anim.SetBool("rodar", true);
        ReproducirSonido(rollSound, false);

        // aplicar impulso según hacia dónde mira
        float direccion = mirandoDerecha ? 1f : -1f;
        rb.velocity = new Vector2(direccion * fuerzaRodar, rb.velocity.y);

        // duración de la animación (ajústala a la tuya)
        yield return new WaitForSeconds(0.6f);

        anim.SetBool("rodar", false);
        rodando = false;
    }
}
