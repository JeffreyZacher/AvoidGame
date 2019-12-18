using UnityEngine;

public class LevelEditor : MonoBehaviour 
{
	public GameObject obstacle;
	public GameObject floor;
	public GameObject levelParent;

	//IMPORTANT: Make sure that the level Prefab is SQUARE & ODD NUMBERS!!!!!!!!!!!!
	private int FloorWidth { get {return (int)floor.transform.localScale.x; } }
	private int LevelNumber { get { return levelParent.transform.childCount; } }

	[SerializeField]
	public Vector2Int PlatformCoordinates;

	public GameObject CreatePlatform(Vector2Int platformCenter)
	{
		PlatformCoordinates = platformCenter;

		var platformcontainer = new GameObject("Level" + PlatformCoordinates.x + "x" + PlatformCoordinates.y + "z");
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
					var foo = GetObstaclePosition(i, j, PlatformCoordinates * FloorWidth);
					Instantiate(obstacle, new Vector3(foo.x, 0f, foo.y), Quaternion.identity, platformcontainer.transform);
				}
			}
		}

		return platformcontainer;
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
				obstacles[i, j] = rnd.Next(0, 5) == 1;
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
