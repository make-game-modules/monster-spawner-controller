# 2D Monster Spawner Controller

[中文](https://github.com/make-game-modules/monster-spawner-controller/blob/main/README.zh-cn.md)

This project provides a Unity script that spawns monsters within a specified range in Unity, while maintaining a certain safe zone around the protagonist.

## How to Install

In your Unity project, clone this repository at any location using Git.

## How to Use

Attach this script to the GameObject where you want to spawn monsters. You can set the following properties in the Unity editor:

- `role`: Your protagonist object.
- `monsterPrefab`: The monster prefab you want to spawn.
- `maxMonsters`: The maximum number of monsters in the scene.
- `spawnRadius`: The radius of the area where monsters are spawned.
- `spawnInterval`: The time interval between each monster spawn.
- `checkRadius`: The radius to check for other monsters nearby.
- `safeZoneRadius`: The radius of the safe zone around the protagonist.

## Parameter Settings

Parameters that can be set in the Unity editor include:

- `role`: The protagonist object.
- `monsterPrefab`: The monster prefab to spawn.
- `maxMonsters`: The maximum number of monsters.
- `spawnRadius`: The radius of the monster spawn area.
- `spawnInterval`: The time interval between each monster spawn.
- `checkRadius`: The radius to check for other monsters nearby.
- `safeZoneRadius`: The radius of the safe zone around the protagonist.

## Operating Principle

This script spawns monsters within a certain range around the protagonist, but ensures that the spawned monsters will not appear in the protagonist's safe zone. Also, it checks whether there are other monsters near the spawn position of the monster. If there are, it will re-select the position.

## Copyright Information

This project uses the MIT open source license. Everyone is welcome to improve and use the project.
