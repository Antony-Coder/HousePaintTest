using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HouseGenerator : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private Color colorWallA = Color.white;
    [SerializeField] private Color colorWallB = Color.white;
    [SerializeField] private Color colorWallC = Color.white;
    [SerializeField] private Color colorWallD = Color.white;
    public void Generate()
    {
        GameObject house = new GameObject();
        house.name = "House";



        Transform wallA = CreateWall(new Vector3(0, 0, width), new Vector3(0, 90, 0), "WallA", colorWallA, house.transform).transform;
        Transform wallB = CreateWall(Vector3.zero, Vector3.zero, "WallB", colorWallB, house.transform).transform;
        Transform wallC = CreateWall(new Vector3(width, 0, 0), new Vector3(0, -90, 0), "WallC", colorWallC, house.transform).transform;
        Transform wallD = CreateWall(new Vector3(width, 0, width), new Vector3(0, 180, 0), "WallD", colorWallD, house.transform).transform;

        Transform axis = CreateAxis(house.transform).transform;

        CreateShadow(axis);

        GenerateBoxColliders(house.transform);

        House houseScript = house.AddComponent<House>();
        houseScript.Initialize(wallA, wallB, wallC, wallD, axis);

    }

    private void CreateShadow(Transform axis)
    {
        GameObject shadow = GameObject.CreatePrimitive(PrimitiveType.Cube);
        shadow.name = "Shadow";
        shadow.transform.parent = axis;
        shadow.transform.localPosition = Vector3.zero;
        shadow.transform.localScale = new Vector3(width, height, width);

        DestroyImmediate(shadow.GetComponent<BoxCollider>());
        shadow.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
    }

    private void GenerateBoxColliders(Transform parent)
    {
        GameObject collisionBaseObject = new GameObject();
        collisionBaseObject.name = "CollisionBase";

        collisionBaseObject.transform.parent = parent;

        Transform collisionBase = collisionBaseObject.transform;

        CreateCollisionBox(new Vector3(-0.5f, height / 2f, width + 0.5f), Vector3.zero, parent, collisionBase, height);
        CreateCollisionBox(new Vector3(-0.5f, height / 2f, -0.5f), Vector3.zero, parent, collisionBase, height);
        CreateCollisionBox(new Vector3(width + 0.5f, height / 2f, width + 0.5f), Vector3.zero, parent, collisionBase, height);
        CreateCollisionBox(new Vector3(width + 0.5f, height / 2f, -0.5f), Vector3.zero, parent, collisionBase, height);

        CreateCollisionBox(new Vector3(-0.5f, height + 0.5f, width / 2f), new Vector3(90, 0, 0), parent, collisionBase, width);
        CreateCollisionBox(new Vector3(width + 0.5f, height + 0.5f, width / 2f), new Vector3(90, 0, 0), parent, collisionBase, width);
        CreateCollisionBox(new Vector3(width / 2f, height + 0.5f, width + 0.5f), new Vector3(90, 0, 90), parent, collisionBase, width);
        CreateCollisionBox(new Vector3(width / 2f, height + 0.5f, -0.5f), new Vector3(90, 0, 90), parent, collisionBase, width);

        CreateCollisionBox(new Vector3(-0.5f, -0.5f, width / 2f), new Vector3(90, 0, 0), parent, collisionBase, width);
        CreateCollisionBox(new Vector3(width + 0.5f, -0.5f, width / 2f), new Vector3(90, 0, 0), parent, collisionBase, width);
        CreateCollisionBox(new Vector3(width / 2f, -0.5f, width + 0.5f), new Vector3(90, 0, 90), parent, collisionBase, width);
        CreateCollisionBox(new Vector3(width / 2f, -0.5f, -0.5f), new Vector3(90, 0, 90), parent, collisionBase, width);

    }

    private GameObject CreateCollisionBox(Vector3 position, Vector3 rotation, Transform house, Transform collisionBase, float length)
    {
        GameObject collisionBox = new GameObject();
        collisionBox.name = "CollisionBox";

        collisionBox.transform.parent = house;
        collisionBox.transform.localPosition = position;
        collisionBox.transform.localRotation = Quaternion.Euler(rotation);
        collisionBox.transform.localScale = new Vector3(1, length, 1);

        collisionBox.transform.parent = collisionBase;

        collisionBox.AddComponent<BoxCollider>();
        collisionBox.AddComponent<Obstacle>();

        return collisionBox;
    }

    private GameObject CreateAxis(Transform parent)
    {
        GameObject axis = new GameObject();
        axis.name = "AxisRotation";
        axis.transform.parent = parent;
        axis.transform.localPosition = new Vector3(width / 2f, height / 2f, width / 2f);
        return axis;
    }

    private GameObject CreateWall(Vector3 position, Vector3 rotation, string nameWall, Color colorWall, Transform parent)
    {
        GameObject wall = new GameObject();
        wall.name = nameWall;

        wall.transform.parent = parent;
        wall.transform.localPosition = position;
        wall.transform.localRotation = Quaternion.Euler(rotation);

        SpriteRenderer spriteRenderer = wall.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = CreateSprite(colorWall);

        return wall;
    }

    private Sprite CreateSprite(Color color)
    {
        Texture2D tex = new Texture2D(width, height);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                tex.SetPixel(i, j, color);
            }
        }
        tex.filterMode = FilterMode.Point;

        tex.Apply();

        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.zero, 1);

        return sprite;
    }
}
