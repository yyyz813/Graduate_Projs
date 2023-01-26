#MiniMax Game for white

from MorrisBoard import Board
from Algorithms import *


def static(board, pos):
    return board.estimateMidgameEndgame_White(pos)


def eventHelper(board, pos, d):
    if d % 2 == 0:
        if board.numWhitePieces(pos) == 3:
            return board.GenerateHoppingWhite(pos)
        else:
            return board.GenerateMoveWhite(pos)
    else:
        if board.numBlackPieces(pos) == 3:
            return board.GenerateHoppingBlack(pos)
        else:
            return board.GenerateMoveBlack(pos)


def move(positionIn, depth):
    resetCount()
    board = Board()
    positionOut, score = miniMax(board, positionIn, 0, depth, static, eventHelper, False)
    print("Input Board: {}, Output Board: {}, Static Estimation: {}, MiniMax Estimation: {}".format(positionIn, positionOut, getCount(), score))
    return positionOut


if __name__ == "__main__":
    positionIn, positionOut, depth = terminal(argv)
    write_output(move(positionIn, depth), positionOut)