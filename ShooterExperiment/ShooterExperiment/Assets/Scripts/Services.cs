using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services {

	public static SpawnpointControl SpawnpointControl { get; set; }
	public static RespawnControl RespawnControl { get; set; }
	public static KillzoneControl KillzoneControl { get; set; }
	public static CheckpointControl CheckpointControl { get; set; }
	public static TreadmillControl TreadmillControl { get; set; }
	public static TYCommonFunctions TYCommonFunctions { get; set; }
	public static PlayerSwitcherScript PlayerSwitcher { get; set; }
	public static EnemyDefs EnemyDefs { get; set; }
}
