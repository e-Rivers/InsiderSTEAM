using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    private int mazeRows = 20;
    private int mazeColumns = 20;
    public GameObject cellPrefab;

    // Dictionary to hold and locate all cells in maze.
    private Dictionary<Vector2, Cell> allCells = new Dictionary<Vector2, Cell>();
    // List to hold unvisited cells.
    private List<Cell> unvisited = new List<Cell>();
    // List to store 'stack' cells, cells being checked during generation.
    private List<Cell> stack = new List<Cell>();

    private Cell[] centerCells = new Cell[4];

    // Cell variables to hold current and checking Cells.
    private Cell currentCell;
    private Cell checkCell;

    // Array of all possible neighbour positions.
    private Vector2[] neighbourPositions = new Vector2[] { new Vector2(-1, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(0, -1) };

    // Size of the cells, used to determine how far apart to place cells during generation.
    private float cellSize;

    public static GameObject mazeParent;

    public void GenerateMaze() {
        if (mazeParent != null) DeleteMaze();
        CreateLayout();
    }

    // Creates the grid of cells.
    public void CreateLayout() {
        InitValues();

        // Set starting point, set spawn point to start.
        Vector2 startPos = new Vector2(-(cellSize * (mazeColumns / 2)) + (cellSize / 2), -(cellSize * (mazeRows / 2)) + (cellSize / 2));
        Vector2 spawnPos = startPos;

        for (int x = 1; x <= mazeColumns; x++) {
            for (int y = 1; y <= mazeRows; y++) {
                GenerateCell(spawnPos, new Vector2(x, y));
                // Increase spawnPos y.
                spawnPos.y += cellSize;
            }

            // Reset spawnPos y and increase spawnPos x.
            spawnPos.y = startPos.y;
            spawnPos.x += cellSize;
        }

        CreateCenter();
        RunAlgorithm();
        MakeExit();
    }

    public void RunAlgorithm() {
        // Get start cell, make it visited (i.e. remove from unvisited list).
        unvisited.Remove(currentCell);

        // While we have unvisited cells.
        while (unvisited.Count > 0) {
            List<Cell> unvisitedNeighbours = GetUnvisitedNeighbours(currentCell);
            if (unvisitedNeighbours.Count > 0) {
                // Get a random unvisited neighbour.
                checkCell = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
                // Add current cell to stack.
                stack.Add(currentCell);
                // Compare and remove walls.
                CompareWalls(currentCell, checkCell);
                // Make currentCell the neighbour cell.
                currentCell = checkCell;
                // Mark new current cell as visited.
                unvisited.Remove(currentCell);
            } else if (stack.Count > 0) {
                // Make current cell the most recently added Cell from the stack.
                currentCell = stack[stack.Count - 1];
                // Remove it from stack.
                stack.Remove(currentCell);
            }
        }
    }

    public void MakeExit() {
        // Create and populate list of all possible edge cells.
        List<Cell> edgeCells = new List<Cell>();

        foreach (KeyValuePair<Vector2, Cell> cell in allCells) {
            if (cell.Key.x == 0 || cell.Key.x == mazeColumns || cell.Key.y == 0 || cell.Key.y == mazeRows) {
                edgeCells.Add(cell.Value);
            }
        }

        // Get edge cell randomly from list.
        Cell newCell = edgeCells[Random.Range(0, edgeCells.Count)];

        // Remove appropriate wall for chosen edge cell.
        if (newCell.gridPos.x == 0) RemoveWall(newCell.cScript, 1);
        else if (newCell.gridPos.x == mazeColumns) RemoveWall(newCell.cScript, 2);
        else if (newCell.gridPos.y == mazeRows) RemoveWall(newCell.cScript, 3);
        else RemoveWall(newCell.cScript, 4);

    }

    public List<Cell> GetUnvisitedNeighbours(Cell curCell) {
        // Create a list to return.
        List<Cell> neighbours = new List<Cell>();
        // Create a Cell object.
        Cell nCell = curCell;
        // Store current cell grid pos.
        Vector2 cPos = curCell.gridPos;

        foreach (Vector2 p in neighbourPositions) {
            // Find position of neighbour on grid, relative to current.
            Vector2 nPos = cPos + p;
            // If cell exists.
            if (allCells.ContainsKey(nPos)) nCell = allCells[nPos];
            // If cell is unvisited.
            if (unvisited.Contains(nCell)) neighbours.Add(nCell);
        }

        return neighbours;
    }

    // Compare neighbour with current and remove appropriate walls.
    public void CompareWalls(Cell cCell, Cell nCell) {
        // If neighbour is left of current.
        if (nCell.gridPos.x < cCell.gridPos.x) {
            RemoveWall(nCell.cScript, 2);
            RemoveWall(cCell.cScript, 1);
        }
        // Else if neighbour is right of current.
        else if (nCell.gridPos.x > cCell.gridPos.x) {
            RemoveWall(nCell.cScript, 1);
            RemoveWall(cCell.cScript, 2);
        }
        // Else if neighbour is above current.
        else if (nCell.gridPos.y > cCell.gridPos.y) {
            RemoveWall(nCell.cScript, 4);
            RemoveWall(cCell.cScript, 3);
        }
        // Else if neighbour is below current.
        else if (nCell.gridPos.y < cCell.gridPos.y) {
            RemoveWall(nCell.cScript, 3);
            RemoveWall(cCell.cScript, 4);
        }
    }

    // Function disables wall of your choosing, pass it the script attached to the desired cell
    public void RemoveWall(CellScript cScript, int wallID) {
        if (wallID == 1) cScript.wallL.SetActive(false);
        else if (wallID == 2) cScript.wallR.SetActive(false);
        else if (wallID == 3) cScript.wallU.SetActive(false);
        else if (wallID == 4) cScript.wallD.SetActive(false);
    }

    public void CreateCenter() {
        // Get the 4 center cells using the rows and columns variables.
        // Remove the required walls for each.
        centerCells[0] = allCells[new Vector2((mazeColumns / 2), (mazeRows / 2) + 1)];
        RemoveWall(centerCells[0].cScript, 4);
        RemoveWall(centerCells[0].cScript, 2);
        centerCells[1] = allCells[new Vector2((mazeColumns / 2) + 1, (mazeRows / 2) + 1)];
        RemoveWall(centerCells[1].cScript, 4);
        RemoveWall(centerCells[1].cScript, 1);
        centerCells[2] = allCells[new Vector2((mazeColumns / 2), (mazeRows / 2))];
        RemoveWall(centerCells[2].cScript, 3);
        RemoveWall(centerCells[2].cScript, 2);
        centerCells[3] = allCells[new Vector2((mazeColumns / 2) + 1, (mazeRows / 2))];
        RemoveWall(centerCells[3].cScript, 3);
        RemoveWall(centerCells[3].cScript, 1);

        // Create a List of ints, using this, select one at random and remove it.
        // We then use the remaining 3 ints to remove 3 of the center cells from the 'unvisited' list.
        // This ensures that one of the center cells will connect to the maze but the other three won't.
        // This way, the center room will only have 1 entry / exit point.
        List<int> rndList = new List<int> { 0, 1, 2, 3 };
        int startCell = rndList[Random.Range(0, rndList.Count)];
        rndList.Remove(startCell);
        currentCell = centerCells[startCell];
        foreach(int c in rndList) {
            unvisited.Remove(centerCells[c]);
        }
    }

    public void GenerateCell(Vector2 pos, Vector2 keyPos) {
        // Create new Cell object.
        Cell newCell = new Cell();

        // Store reference to position in grid.
        newCell.gridPos = keyPos;
        // Set and instantiate cell GameObject.
        newCell.cellObject = Instantiate(cellPrefab, pos, cellPrefab.transform.rotation);
        // Child new cell to parent.
        if (mazeParent != null) newCell.cellObject.transform.parent = mazeParent.transform;
        // Set name of cellObject.
        newCell.cellObject.name = "Cell - X:" + keyPos.x + " Y:" + keyPos.y;
        // Get reference to attached CellScript.
        newCell.cScript = newCell.cellObject.GetComponent<CellScript>();

        // Add to Lists.
        allCells[keyPos] = newCell;
        unvisited.Add(newCell);
    }

    public void DeleteMaze() {
        if (mazeParent != null) Destroy(mazeParent);
    }

    public void InitValues() {
        // Determine size of cell using localScale.
        cellSize = cellPrefab.transform.localScale.x;

        // Create an empty parent object to hold the maze in the scene.
        mazeParent = new GameObject();
        mazeParent.transform.position = Vector2.zero;
        mazeParent.name = "Maze";
    }

    public class Cell {
        public Vector2 gridPos;
        public GameObject cellObject;
        public CellScript cScript;
    }
}
