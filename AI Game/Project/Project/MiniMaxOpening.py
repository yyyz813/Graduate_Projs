# Opening, only for placing the piece for White

from MorrisBoard import Board
from Algorithms import *


def static(board, position):    # Get the value of static estimate.
    return board.estimateOpenWhite(position)


def eventHelper(board, position, depth):
    if depth % 2 == 0:         # Evaluate the level.
        return board.GenerateAddWhite(position)
    else:
        return board.GenerateAddBlack(position)


def move(positionIn, depth):
    resetCount()  # count =0
    board = Board()
    positionOut, score = miniMax(board,positionIn, 0, depth, static, eventHelper, True) # White True, Black Flase.
    # Get the global count
    print("Input Board: {}, Output Board: {}, Static Estimation: {}, MiniMax Estimation: {}".format( positionIn, positionOut, getCount(), score))
    return positionOut


if __name__ == "__main__":
    positionIn, positionOut, depth = terminal(argv)
    write_output(move(positionIn, depth), positionOut)