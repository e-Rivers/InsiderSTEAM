using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    // Public attributes
    public GameObject currTile;
    public int x, y;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Get player position
        x = TechPlayerMovement.instance.x;
        y = TechPlayerMovement.instance.y;
        // Get current tile
        currTile = TileGridCreator.instance.tileMatrix[x, y];
        // Modify current tile if player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currTile.GetComponent<TileModifier>().isActive) {
                TileManager.instance.SetValueAt(x, y, 0);
                currTile.GetComponent<TileModifier>().isActive = false;
            } else
            {
                TileManager.instance.SetValueAt(x, y, 1);
                currTile.GetComponent<TileModifier>().isActive = true;
            }
        }
    }
}
