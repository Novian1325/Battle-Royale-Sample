using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BetterHierarchyCreations : MonoBehaviour
{
    [MenuItem("GameObject/Create Empty (Origin)", false, 0)]
    static void EmptyGO()
    {
        GameObject go = new GameObject();
        go.name = "GameObject";
        go.transform.position = new Vector3(0,0,0);
        go.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Cube (Origin)", false, 1)]
    static void CubeGO()
    {
        GameObject cubeGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeGO.name = "Cube";
        cubeGO.transform.position = new Vector3(0,0,0);
        cubeGO.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Sphere (Origin)", false, 2)]
    static void SphereGO()
    {
        GameObject sphereGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereGO.name = "Sphere";
        sphereGO.transform.position = new Vector3(0,0,0);
        sphereGO.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Capsule (Origin)", false, 3)]
    static void CapsuleGO()
    {
        GameObject capsuleGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsuleGO.name = "Plane";
        capsuleGO.transform.position = new Vector3(0,0,0);
        capsuleGO.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Cylinder (Origin)", false, 4)]
    static void CylinderGO()
    {
        GameObject cylinderGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinderGO.name = "Cylinder";
        cylinderGO.transform.position = new Vector3(0,0,0);
        cylinderGO.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Plane (Origin)", false, 5)]
    static void PlaneGO()
    {
        GameObject planeGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
        planeGO.name = "Plane";
        planeGO.transform.position = new Vector3(0,0,0);
        planeGO.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Quad (Origin)", false, 6)]
    static void QuadGO()
    {
        GameObject quadGO = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quadGO.name = "Quad";
        quadGO.transform.position = new Vector3(0,0,0);
        quadGO.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Ground Cube (Small)", false, -1)]
    static void GroundCubeSmall()
    {
        GameObject GroundCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GroundCube.name = "GroundCube";
        GroundCube.transform.position = new Vector3(0,-(0.5f),0);
        GroundCube.transform.localScale = new Vector3(10,1,10);
        GroundCube.transform.rotation = Quaternion.identity;
    }

    [MenuItem("GameObject/3D Object/Ground Cube (Large)", false, -1)]
    static void GroundCubeLarge()
    {
        GameObject GroundCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GroundCube.name = "GroundCube";
        GroundCube.transform.position = new Vector3(0,-(0.5f),0);
        GroundCube.transform.localScale = new Vector3(100,1,100);
        GroundCube.transform.rotation = Quaternion.identity;
        //Renderer rend = GroundCube.GetComponent<Renderer>();
        //rend.sharedMaterial.SetColor("_Color", Color.gray);
    }

    [MenuItem("GameObject/3D Object/SandBox (Small)", false, -3)]
    static void SandBoxSmall()
    {
        GameObject SandBoxSmall = new GameObject();
        SandBoxSmall.name = "SandBox Small";

        GameObject GroundCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GroundCube.name = "GroundCube";
        GroundCube.transform.position = new Vector3(0,-(0.5f),0);
        GroundCube.transform.localScale = new Vector3(10,1,10);
        GroundCube.transform.rotation = Quaternion.identity;
        //Renderer rend = GroundCube.GetComponent<Renderer>();
        //rend.sharedMaterial.SetColor("_Color", Color.gray);
        GroundCube.transform.parent = SandBoxSmall.transform;

        //First wall
        GameObject SandBoxWallA = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallA.name = "Wall A";
        SandBoxWallA.transform.localScale = new Vector3(10,5,1);
        SandBoxWallA.transform.position = new Vector3(4.5f,2.5f,0);
        SandBoxWallA.transform.Rotate(0,-90,0);
        SandBoxWallA.transform.parent = SandBoxSmall.transform;

        //First wall
        GameObject SandBoxWallB = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallB.name = "Wall B";
        SandBoxWallB.transform.localScale = new Vector3(10,5,1);
        SandBoxWallB.transform.position = new Vector3(-4.5f,2.5f,0);
        SandBoxWallB.transform.Rotate(0,-90,0);
        SandBoxWallB.transform.parent = SandBoxSmall.transform;

        //First wall
        GameObject SandBoxWallC = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallC.name = "Wall C";
        SandBoxWallC.transform.localScale = new Vector3(10,5,1);
        SandBoxWallC.transform.position = new Vector3(0,2.5f,4.5f);
        SandBoxWallC.transform.parent = SandBoxSmall.transform;

        //First wall
        GameObject SandBoxWallD = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallD.name = "Wall D";
        SandBoxWallD.transform.localScale = new Vector3(10,5,1);
        SandBoxWallD.transform.position = new Vector3(0,2.5f,-4.5f);
        SandBoxWallD.transform.parent = SandBoxSmall.transform;
    }

    [MenuItem("GameObject/3D Object/SandBox (Large)", false, -2)]
    static void SandBoxLarge()
    {
        GameObject SandBoxLarge = new GameObject();
        SandBoxLarge.name = "SandBox Large";

        GameObject GroundCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GroundCube.name = "GroundCube";
        GroundCube.transform.position = new Vector3(0,-(0.5f),0);
        GroundCube.transform.localScale = new Vector3(100,1,100);
        GroundCube.transform.rotation = Quaternion.identity;
        GroundCube.transform.parent = SandBoxLarge.transform;

        //First wall
        GameObject SandBoxWallA = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallA.name = "Wall A";
        SandBoxWallA.transform.localScale = new Vector3(100,5,1);
        SandBoxWallA.transform.position = new Vector3(49.5f,2.5f,0);
        SandBoxWallA.transform.Rotate(0,-90,0);
        SandBoxWallA.transform.parent = SandBoxLarge.transform;

        //First wall
        GameObject SandBoxWallB = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallB.name = "Wall B";
        SandBoxWallB.transform.localScale = new Vector3(100,5,1);
        SandBoxWallB.transform.position = new Vector3(-49.5f,2.5f,0);
        SandBoxWallB.transform.Rotate(0,-90,0);
        SandBoxWallB.transform.parent = SandBoxLarge.transform;

        //First wall
        GameObject SandBoxWallC = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallC.name = "Wall C";
        SandBoxWallC.transform.localScale = new Vector3(100,5,1);
        SandBoxWallC.transform.position = new Vector3(0,2.5f,49.5f);
        SandBoxWallC.transform.parent = SandBoxLarge.transform;

        //First wall
        GameObject SandBoxWallD = GameObject.CreatePrimitive(PrimitiveType.Cube);
        SandBoxWallD.name = "Wall D";
        SandBoxWallD.transform.localScale = new Vector3(100,5,1);
        SandBoxWallD.transform.position = new Vector3(0,2.5f,-49.5f);
        SandBoxWallD.transform.parent = SandBoxLarge.transform;
    }

}
