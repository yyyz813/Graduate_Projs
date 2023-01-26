from sys import argv
from MorrisBoard import Board
import numpy as np

count = 0

def resetCount():
    global count
    count = 0

def addCount():
    global count
    count += 1

def getCount():
    global count
    return count


def terminal(args):
    if len(args) != 4:
        print("{} <inputFile> <outputFile> <Depth>".format(args[0]))
        exit(1)
    inFile, outFile, depth = args[1:4]
    with open(inFile) as file:
        inputPosition = file.read()
    return inputPosition.strip(), outFile, int(depth)

def write_output(position, outFile):
    with open(outFile, 'w') as file:
        file.write(position)

# If the max_depth = 0 or if board only have 2 black or 2 white. We consider it as the leaf node.
def ifLeafNode(board, position, zeroDepth, maxDepth, staticEstimate, Flag=False):
    if zeroDepth == maxDepth or (not Flag and (board.numWhitePieces(position) == 2 or board.numBlackPieces(position) == 2)):  # leaf node
        addCount()
        score = staticEstimate(board, position)
        return score
'''
function minimax(board, depth, isMaximizingPlayer):

    if current board state is a terminal state :
        return value of the board 
    
    if isMaximizingPlayer :
        bestVal = -INFINITY 
        for each move in board :
            value = minimax(board, depth+1, false)
            bestVal = max( bestVal, value) 
        return bestVal

    else :
        bestVal = +INFINITY 
        for each move in board :
            value = minimax(board, depth+1, true)
            bestVal = min( bestVal, value) 
        return bestVal 
'''
def miniMax(board, position, currentDepth, maxDepth, staticEstimation, eventHelper, Flag):
    value = ifLeafNode(board, position, currentDepth, maxDepth, staticEstimation, Flag)
    if value is not None:     # Base case  -- target leaf reached
        return position, value

    bestValue = -100000
    bestPosition = ""
    for _, childNode in eventHelper(board, position, currentDepth):  #write() argument must be str, not tuple.
        _, score = maxMin(board, childNode, currentDepth+1, maxDepth, staticEstimation, eventHelper, Flag)
        if score > bestValue:
            bestValue = score
            bestPosition = childNode
    return bestPosition, bestValue


def maxMin(board, position, currentDepth, maxDepth, staticEstimation, eventHelper, Flag):
    value = ifLeafNode(board, position, currentDepth, maxDepth, staticEstimation, Flag)
    if value is not None:
        return position, value

    bestValue = 100000
    bestPosition = ""
    for _, childNode in eventHelper(board, position, currentDepth):
        _, score = miniMax(board, childNode, currentDepth+1, maxDepth, staticEstimation, eventHelper, Flag)
        if score < bestValue:
            bestValue = score
            bestPosition = childNode
    return bestPosition, bestValue

'''
function minimax(node, depth, isMaximizingPlayer, alpha, beta):

    if node is a leaf node :
        return value of the node
    
    if isMaximizingPlayer :
        bestVal = -INFINITY 
        for each child node :
            value = minimax(node, depth+1, false, alpha, beta)
            bestVal = max( bestVal, value) 
            alpha = max( alpha, bestVal)
            if beta <= alpha:   # puring the rest of the tree
                break
        return bestVal

    else :
        bestVal = +INFINITY 
        for each child node :
            value = minimax(node, depth+1, true, alpha, beta)
            bestVal = min( bestVal, value) 
            beta = min( beta, bestVal)
            if beta <= alpha:
                break
        return bestVal
'''
def nimiMax_ab(board, position, currDepth, maxDepth, staticEstimation, eventHelper, a, b, Flag):
    value = ifLeafNode(board, position, currDepth,maxDepth, staticEstimation, Flag)
    if value is not None:
        return position, value

    bestValue = -100000
    bestPosition = ""
    for _, childNode in eventHelper(board, position, currDepth):
        _, score = Maxmin_ab(board, childNode, currDepth+1, maxDepth, staticEstimation, eventHelper, a, b, Flag)
        if score > bestValue:
            bestValue = score
            bestPosition = childNode
        if bestValue >= b:   # puring the rest of the tree
            return bestPosition, bestValue
        else:
            a = max([bestValue, a])
    return bestPosition, bestValue


def Maxmin_ab(board, position, currDepth, maxDepth, staticEstimation, eventHelper, a, b, Flag):
    value = ifLeafNode(board, position, currDepth, maxDepth, staticEstimation, Flag)
    if value is not None:
        return position, value

    bestValue = 100000
    bestPosition = ""
    for _, childNode in eventHelper(board, position, currDepth):
        _, score = nimiMax_ab(board, childNode, currDepth+1, maxDepth, staticEstimation, eventHelper, a, b, Flag)
        if score < bestValue:
            bestValue  = score
            bestPosition = childNode
        if bestValue <= a:   # puring the rest of the tree
            return bestPosition, bestValue
        else:
            b = min([bestValue, b])
    return bestPosition, bestValue




