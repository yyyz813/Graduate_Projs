'''Improved Static Estimate '''

from MorrisBoard import Board
from Algorithms import *


def static_white(board, pos):
    return board.estimateOpenWhiteImproved(board,pos)


def eventHelper(board, pos, d):
    if d % 2 == 0:
        return board.GenerateAddWhite(pos)
    else:
        return board.GenerateAddBlack(pos)


def move(positionIn, depth):
    resetCount()
    board = Board()
    positionOut, score = miniMax(board, positionIn, 0, depth, static_white, eventHelper, True)
    print("Input position: {}, Output position: {}, Positions evaluated by static: {}, MINIMAX estimate: {}".format(positionIn, positionOut, getCount(), score))
    return positionOut


if __name__ == "__main__":
    positionIn, positionOut, depth = terminal(argv)
    write_output(move(positionIn, depth), positionOut)