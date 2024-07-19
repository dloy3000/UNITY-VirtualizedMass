# UNITY-VirtualizedMass
Simple scripts I made to compute the center of mass and weight distribution of an object comprised of multiple meshes in Unity.

## What it does
- **VirtualMass** computes a centroid (center of volume) for a mesh, displaced by its local position, and scales the centroid by the mass to get the center of mass for that mesh.
- **MassVirtualizer** takes all of the VirtualMass components in an object and computes the center of mass for that object.

## How to Use
Make sure that the meshes are parented under an object. Add a **VirtualMass** to each child object which contains a mesh, and assign an appropriate mass. Then, add **MassVirtualizer** to the parent transform.

## Future Updates
I will work on this script over time and add some more functionality, like dynamic center of mass for semi-solid and liquid objects. And functionality to automatically recompute center of mass when a mesh is bisected or split apart.
