using UnityEngine;

public class MovimientoHorizontalRango : MonoBehaviour
{
    public float velocidad = 3f;      
    public float rango = 2f;          

    private Vector3 posicionInicial;
    private int direccion = 1;       

    void Start()
    {
        
        posicionInicial = transform.position;
    }

    void Update()
    {
       
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        
        if (Mathf.Abs(transform.position.x - posicionInicial.x) >= rango)
        {
            direccion *= -1; 
        }
    }
}

