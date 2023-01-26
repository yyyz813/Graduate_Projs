# Opening, only for placing the piece. Using AB Purning

from MorrisBoard import Board
from Algorithms import *


def static(board, pos):
    return board.estimateOpenWhite(pos)


def eventHelper(board, position, depth):
    if depth % 2 == 0:
        return board.GenerateAddWhite(position)
    else:
        return board.GenerateAddBlack(position)


def move(positionIn, depth):
    resetCount()
    board = Board()
    positionOut, score = nimiMax_ab(board, positionIn, 0, depth, static, eventHelper, -100000, 100000, True)
    print("Input Board: {}, Output Board: {}, Static Estimation: {}, AlphaBeta estimate: {}".format(positionIn, positionOut, getCount(), score))
    return positionOut


if __name__ == "__main__":
    positionIn, positionOut, depth = terminal(argv)
    write_output(move(positionIn, depth),positionOut)