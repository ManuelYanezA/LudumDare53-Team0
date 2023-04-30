using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    private BoxCollider2D managerBox;
    private Transform player;
    public GameObject[] boundaries;
    private GameObject currentBoundary;

    // Start is called before the first frame update
    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Robot").GetComponent<Transform>();

        // Buscamos el boundary activo al inicio
        foreach (GameObject boundary in boundaries)
        {
            if (managerBox.bounds.Contains(boundary.transform.position))
            {
                currentBoundary = boundary;
                currentBoundary.SetActive(true);
            }
            else
            {
                boundary.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManageBoundary();
    }

    void ManageBoundary()
    {
        // Buscamos el boundary correspondiente al límite actual
        foreach (GameObject boundary in boundaries)
        {
            if (managerBox.bounds.Contains(boundary.transform.position))
            {
                if (boundary != currentBoundary)
                {
                    // Desactivamos el boundary actual y activamos el nuevo
                    currentBoundary.SetActive(false);
                    currentBoundary = boundary;
                    currentBoundary.SetActive(true);
                }
                return;
            }
        }

        // Si el jugador está fuera de todos los límites, desactivamos el boundary actual
        if (currentBoundary != null)
        {
            currentBoundary.SetActive(false);
            currentBoundary = null;
        }
    }
}
