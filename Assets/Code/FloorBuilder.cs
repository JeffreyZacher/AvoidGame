using System;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilder : MonoBehaviour
{
	[SerializeField]
	private GameObject PlayerObject;

	private int x;
	private int z;

	private GameObject CurrentPlatform
	{
		get { return GameObject.Find(string.Format("Level{0}x{1}z", x, z)); }
	}

	private LevelEditor GetLevelEditor
	{
		get { return GetComponent<LevelEditor>(); }
	}

	/// <summary>
	/// Describes a grid of Platforms where the center ([1][1]) is the players platform
	/// the first index increases in the positive x direction
	/// the second index increases in the positive z direction
	/// </summary>
	private GameObject[][] ActivePlatforms = new GameObject[3][]
	{
		new GameObject[3],
		new GameObject[3],
		new GameObject[3]
	};

	// Use this for initialization
	void Start()
	{
		int k = 0;

		for (int i = 1; i >= -1; i--)
		{
			for (int j = 1; j >= -1; j--)
			{
				Vector2Int vector2Int = new Vector2Int(i, j);

				this.ActivePlatforms[i + 1][j + 1] = this.GetLevelEditor.CreatePlatform(vector2Int);
				k++;
			}
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		// these give the platform the player is standing on
		int xNew = (int)Math.Ceiling((PlayerObject.transform.position.x - 4.5) / 9);
		int zNew = (int)Math.Ceiling((PlayerObject.transform.position.z - 4.5) / 9);

		if (xNew > x)
		{
			Destroy(this.ActivePlatforms[0][0]);
			Destroy(this.ActivePlatforms[0][1]);
			Destroy(this.ActivePlatforms[0][2]);

			Array.Copy(this.ActivePlatforms[1], this.ActivePlatforms[0], 3);
			Array.Copy(this.ActivePlatforms[2], this.ActivePlatforms[1], 3);

			this.ActivePlatforms[2][0] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew + 1, z - 1));
			this.ActivePlatforms[2][1] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew + 1, z));
			this.ActivePlatforms[2][2] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew + 1, z + 1));
		}
		else if (xNew < x)
		{
			Destroy(this.ActivePlatforms[2][0]);
			Destroy(this.ActivePlatforms[2][1]);
			Destroy(this.ActivePlatforms[2][2]);

			Array.Copy(this.ActivePlatforms[1], this.ActivePlatforms[2], 3);
			Array.Copy(this.ActivePlatforms[0], this.ActivePlatforms[1], 3);

			this.ActivePlatforms[0][0] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew - 1, z - 1));
			this.ActivePlatforms[0][1] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew - 1, z));
			this.ActivePlatforms[0][2] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew - 1, z + 1));
		}

		if (zNew > z)
		{
			Destroy(this.ActivePlatforms[0][0]);
			Destroy(this.ActivePlatforms[1][0]);
			Destroy(this.ActivePlatforms[2][0]);

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					this.ActivePlatforms[i][j] = this.ActivePlatforms[i][j + 1];
				}
			}

			this.ActivePlatforms[0][2] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew - 1,	zNew + 1));
			this.ActivePlatforms[1][2] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew,		zNew + 1));
			this.ActivePlatforms[2][2] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew + 1,	zNew + 1));
		}
		else if (zNew < z)
		{
			Destroy(this.ActivePlatforms[0][2]);
			Destroy(this.ActivePlatforms[1][2]);
			Destroy(this.ActivePlatforms[2][2]);

			for (int i = 0; i < 3; i++)
			{
				for (int j = 2; j > 0; j--)
				{
					this.ActivePlatforms[i][j] = this.ActivePlatforms[i][j - 1];
				}
			}

			this.ActivePlatforms[0][0] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew - 1,	zNew - 1));
			this.ActivePlatforms[1][0] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew,		zNew - 1));
			this.ActivePlatforms[2][0] = this.GetLevelEditor.CreatePlatform(new Vector2Int(xNew + 1,	zNew - 1));
		}

		x = xNew;
		z = zNew;
	}
}