using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarChart : MonoBehaviour
{

	[SerializeField] private CanvasRenderer radarMeshRenderer;
	[SerializeField] private Material radarMeshMaterial;
	// Radar dependencies
	private const int MIN = 0;
	private const int MAX = 100;
	private const float radarLength = 190f;
	private float angleCalc = 360f / 9;
	// Dummy data
	private float mentalAgility = ((float)50/MAX);
	private float MathReasoning = ((float)60/MAX);
	private float Memory = ((float)25/MAX);
	private float CreativeThinking = ((float)100/MAX);
	private float Coordination = ((float)28/MAX);
	private float Attention = ((float)90/MAX);
	private float Deduction = ((float)75/MAX);
	private float AbstractReasoning = ((float)23/MAX);
	private float NumericReasoning = ((float)100/MAX);

    // Start is called before the first frame update
    void Start()
    {
        drawRadarMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Method to draw the radar mesh
    private void drawRadarMesh() {
    	Mesh mesh = new Mesh();
    	
    	// Arrays of mesh components
    	Vector3[] vertices = new Vector3[10];
    	Vector2[] uv = new Vector2[10];
    	int[] triangles = new int[3 * 9];

    	// Vertices setup for all competencies
    	vertices[0] = Vector3.zero;
    	vertices[1] = Quaternion.Euler(0,0,-angleCalc * 0) * Vector3.up * radarLength * mentalAgility;
    	vertices[2] = Quaternion.Euler(0,0,-angleCalc * 1) * Vector3.up * radarLength * MathReasoning;
    	vertices[3] = Quaternion.Euler(0,0,-angleCalc * 2) * Vector3.up * radarLength * Memory;
    	vertices[4] = Quaternion.Euler(0,0,-angleCalc * 3) * Vector3.up * radarLength * CreativeThinking;
    	vertices[5] = Quaternion.Euler(0,0,-angleCalc * 4) * Vector3.up * radarLength * Coordination;
    	vertices[6] = Quaternion.Euler(0,0,-angleCalc * 5) * Vector3.up * radarLength * Attention;
    	vertices[7] = Quaternion.Euler(0,0,-angleCalc * 6) * Vector3.up * radarLength * Deduction;
    	vertices[8] = Quaternion.Euler(0,0,-angleCalc * 7) * Vector3.up * radarLength * AbstractReasoning;
    	vertices[9] = Quaternion.Euler(0,0,-angleCalc * 8) * Vector3.up * radarLength * NumericReasoning;
    	// Triangle for Mental Agility
    	triangles[0] = 0;
    	triangles[1] = 1;
    	triangles[2] = 2;
    	// Triangle for Math Reasoning
    	triangles[3] = 0;
    	triangles[4] = 2;
    	triangles[5] = 3;
    	// Triangle for Memory
    	triangles[6] = 0;
    	triangles[7] = 3;
    	triangles[8] = 4;
    	// Triangle for Creative Thinking
    	triangles[9] = 0;
    	triangles[10] = 4;
    	triangles[11] = 5;
    	// Triangle for Coordination
    	triangles[12] = 0;
    	triangles[13] = 5;
    	triangles[14] = 6;
    	// Triangle for Attention
    	triangles[15] = 0;
    	triangles[16] = 6;
    	triangles[17] = 7;
    	// Triangle for Deduction
    	triangles[18] = 0;
    	triangles[19] = 7;
    	triangles[20] = 8;
    	// Triangle for Abstract Reasoning
    	triangles[21] = 0;
    	triangles[22] = 8;
    	triangles[23] = 9;
    	// Triangle for Numeric Reasoning
    	triangles[24] = 0;
    	triangles[25] = 9;
    	triangles[26] = 1;
    	
    	// Configures the mesh with the previously defined components
    	mesh.vertices = vertices;
    	mesh.uv = uv;
    	mesh.triangles = triangles;
    	// Draws the mesh into the screen
    	radarMeshRenderer.GetComponent<CanvasRenderer>().SetMesh(mesh);
    	radarMeshRenderer.GetComponent<CanvasRenderer>().SetMaterial(radarMeshMaterial, null);    	
    }
    
}









