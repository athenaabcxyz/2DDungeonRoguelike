using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeTest
{
    // Prefabs
    GameObject player = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player/Player.prefab");
    GameObject door = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Dungeon/Doors/DoorEW/DoorEW.prefab");

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator DoorOpen_Test()
    {
        var newPlayer = Object.Instantiate(player, new Vector3(0, 0, 0), player.transform.rotation);
        var newDoor = Object.Instantiate(door, new Vector3(0, 0, 0), door.transform.rotation);
        newPlayer.transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1);
        Assert.AreEqual(newDoor.GetComponent<Animator>().GetBool(Settings.open), true);
        yield return null;
    }
}
