# Opening, only for placing the piece for Black
from MorrisBoard import Board
from Algorithms import *


def static(board, position):
    return board.estimateOpenBlack(position)


def eventHelper(board, position, depth):  # Consider only add for the opening phrase.
    if depth % 2 == 1:
        return board.GenerateAddWhite(position)
    else:
        return board.GenerateAddBlack(position)


def move(positionIn, depth):
    resetCount()
    board = Board()
    positionOut, score = miniMax(board, positionIn, 0, depth, static, eventHelper, True)
    print("Input Board: {}, Output Board: {}, Static Estimation: {}, MiniMax Estimation: {}".format(positionIn, positionOut, getCount(), score))
    return positionOut


if __name__ == "__main__":
    positionIn, positionOut, depth = terminal(argv)
    write_output(move(positionIn, depth), positionOut)