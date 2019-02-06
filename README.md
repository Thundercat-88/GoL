# GoL

# An attempt at the Game of Life by Conway in C#
#### By Josh Harris, Submission for the role of BBC Software Engineering Graduate Scheme
## Conways Rules
1. Any live cell with fewer than two live neighbors dies, as if by underpopulation.
2. Any live cell with two or three live neighbors lives on to the next generation.
3. Any live cell with more than three live neighbors dies, as if by overpopulation.
4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

# Plan
## Variables
- Array - Cell
- Array - NextGenCell
- Height
- Width

## State 
- Alive(true) / Dead(false)

# Class
1. Life         
- The program will run from this point
2. LifeChoices
- This class will contain all the methods to execute

# Methods/Functions
- First Generation
- Alive Neighbours
- EdgeWrap
- Next Generation
- WriteLife
- UpdateLife

# Other
## Neighbour Cell Structure in the style of Cartesian Coordinates

- `[x - 1,y + 1],[x, y + 1],[x + 1,y + 1]`
- `[x - 1,y   0],[x, y   0],[x + 1,y   0]`
- `[x - 1,y - 1],[x, y - 1],[x + 1,y - 1]`
