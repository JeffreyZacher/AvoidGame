using UnityEngine;

public class LevelEditor : MonoBehaviour 
{
	public GameObject obstacle;
	public GameObject floor;
	public GameObject levelParent;

	//IMPORTANT: Make sure that the level Prefabe is SQUARE & ODD NUMBERS!!!!!!!!!!!!
	private int FloorWidth { get {return (int)floor.transform.localScale.x; } }
	private int levelNumber { get { return levelParent.transform.childCount; } }

	[SerializeField]
	public Vector2Int PlatfromCenterTile;



	public void CreatePlatform(Vector2Int platformCenter)
	{
		PlatfromCenterTile = platformCenter;

		var platformcontainer = new GameObject("Level" + PlatfromCenterTile.x + "x" + PlatfromCenterTile.y + "y");
		platformcontainer.transform.parent = levelParent.transform;

		//Create the floor .75 meters below 0 so that the obstaclys have a transform of 0 in the y-axis)
		Instantiate(floor, new Vector3(platformCenter.x, 0f, platformCenter.y) * FloorWidth + new Vector3(0f, -.75f, 0f), Quaternion.identity, platformcontainer.transform);

		var array = CreateObstacleGrid();

		for (int i = 0; i < FloorWidth; i++)
		{
			for (int j = 0; j < FloorWidth; j++)
			{
				if (array[i, j])
				{
					var foo = GetObstaclePosition(i, j, PlatfromCenterTile * FloorWidth);
					Instantiate(obstacle, new Vector3(foo.x, 0f, foo.y), Quaternion.identity, platformcontainer.transform);
				}
			}
		}
	}

	public void DestroyPlatform()
	{

	}

	public bool[,] CreateObstacleGrid()
	{
		bool[,] obstacles = new bool[FloorWidth, FloorWidth];
		System.Random rnd = new System.Random();

		for (int i = 0; i < FloorWidth; i++)
		{
			for (int j = 0; j < FloorWidth; j++)
			{
				obstacles[i, j] = rnd.Next(0, 2) == 1;
			}
		}
		return obstacles;
	}

	public Vector2Int GetObstaclePosition(int x, int z, Vector2Int platformCenter)
	{
		return platformCenter
			+ new Vector2Int(-4, -4)
			+ new Vector2Int(x, z);
	}
}
