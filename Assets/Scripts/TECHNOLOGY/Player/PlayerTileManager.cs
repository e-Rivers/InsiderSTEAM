using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    // Public attributes
    public GameObject currTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get current tile
        currTile = TileGridCreator.instance.tileMatrix[TechPlayerMovement.instance.x, TechPlayerMovement.instance.y];
        // Modify current tile if player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currTile.GetComponent<TileModifier>().isActive = !currTile.GetComponent<TileModifier>().isActive;
        }
    }
}
