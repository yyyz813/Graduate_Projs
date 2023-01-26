#MiniMax Game for black

from MorrisBoard import Board
from Algorithms import *


def static(board, pos):
    return board.estimateMidgameEndgame_Black(pos)


def eventHelper(board, position, depth):  # Consider move and hope for the game phrase.
    if depth % 2 == 1:
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
    positionOut, score = miniMax(board, positionIn, 0, depth, static, eventHelper, False)
    print("Input Board: {}, Output Board: {}, Static Estimation: {}, MiniMax Estimation: {}".format(positionIn, positionOut, getCount(), score))
    return positionOut


if __name__ == "__main__":
    positionIn, positionOut, depth = terminal(argv)
    write_output(move(positionIn, depth), positionOut)