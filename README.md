# Ball Collector NPC
## Summary
Prototyping an NPC that walks to gather randomly distributed golf balls on the map while returning to a stable golf cart for scoring. If all the balls are gathered, the player wins.
## The NPC
NavMesh implemented for pathfinding. The NPC is a NavMeshAgent that has health mechanic. Its health decreases over time (decreasing stops briefly only when it reaches the golf cart).
## Decision-Making Algorithm
The NPC uses an algorithm that includes a weighted distance calculation to choose a golf ball as its target. There are two weighted properties: The golf ball's point value and its distance. The weights of these properties constantly change based on the NPC's health. As health decreases, the weight given to distance increases, while the weight given to the golf ball's value decreases. At the beginning of the game, the first selection is random to create varied and balanced situations.
## Platform
* Unity 2021.3.5f1
## Gameplay
![gameplay_rapsodo_assignment](https://github.com/user-attachments/assets/f3f3d39d-ae20-466d-a791-1aa2bab63606)
* *The frame rate and resolution of the GIF are different from the actual game..
