#MiniMax Game for white using AB purning

from MorrisBoard import Board
from Algorithms import *


def static(board, pos):
    return board.estimateMidgameEndgame_White(pos)


def eventHelper(board, position, depth):
    if depth % 2 == 0:
        if board.numWhitePieces(position) == 3:
            return board.GenerateHoppingWhite(position)
        else:
            return board.GenerateMoveWhite(position)
    else:
        if board.numBlackPieces(position) == 3:
            return board.GenerateHoppingBlack(position)
        else:
            return board.GenerateMoveBlack(position)


def move(positionIn, depth):
    resetCount()
    board = Board()
    positionOut, score = nimiMax_ab(board, positionIn, 0, depth, static, eventHelper, -100000, 100000, False)
    print("Input Board: {}, Output Board: {}, Static Estimation: {}, AlphaBeta Estimation: {}".format(positionIn, positionOut, getCount(), score))
    return positionOut


if __name__ == "__main__":
    positionIn, positionOut, depth = terminal(argv)
    write_output(move(positionIn, depth), positionOut)