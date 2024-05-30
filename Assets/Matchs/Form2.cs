using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class Form2 : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int matchId;
    private bool isDragging;
    private Vector3 endPoint;
    private Form1 form1;


    private static int correctMatches = 0;

    private const int totalMatchesRequired = 4;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, mousePosition);
            }
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            lineRenderer.SetPosition(1, mousePosition);
            endPoint = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast((Vector2)endPoint, Vector2.zero);

            if (hit.collider != null && hit.collider.TryGetComponent(out form1) && matchId == form1.Get_ID())
            {
                Debug.Log("Ýstediðin gibi olsun");
                correctMatches++;
                CheckForCompletion();
                this.enabled = false;
            }
            else
            {
                lineRenderer.positionCount = 0;
            }

            // Reset Line Renderer for next drag
            lineRenderer.positionCount = 2;
        }
    }

    private void CheckForCompletion()
    {
        if (correctMatches >= totalMatchesRequired)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}