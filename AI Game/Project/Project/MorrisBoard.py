# Creating Morris Board, Connected valid vertex.

import numpy as np
import pandas as pd

class Board:
    #Pieces can be placed on intersections of lines. (There are a total of 21 locations for pieces.)
    #Giving that start-end as a link. For example a0-a3 | a0-g0| a0-b1 and so on.
    positions = ['a0', 'g0', 'b1', 'f1', 'c2', 'e2', 'a3', 'b3', 'c3', 'e3', 'f3', 'g3', 'c4', 'd4', 'e4', 'b5', 'd5', 'f5', 'a6', 'd6', 'g6']
    start =  ['a0', 'a0', 'a0', 'g0', 'b1', 'b1', 'b1', 'f1', 'c2', 'c2', 'e2', 'a3', 'a3', 'b3', 'b3', 'c3', 'e3', 'e3', 'f3', 'f3', 'g3', 'd4', 'd4', 'd4', 'b5', 'd5', 'd5', 'a6', 'd6']
    end = ['a3', 'g0', 'b1', 'g3', 'b3', 'f1', 'c2', 'f3', 'c3', 'e2', 'e3', 'a6', 'b3', 'b5', 'c3', 'c4', 'e4', 'f3', 'f5', 'g3', 'g6', 'e4', 'c4', 'd5', 'd5', 'd6', 'f5', 'd6', 'g6']
    mills = [['a0', 'a3', 'a6'], ['b1', 'b3', 'b5'], ['c2', 'c3', 'c4'], ['d4', 'd5', 'd6'], ['e2', 'e3', 'e4'], ['f1', 'f3', 'f5'], ['g0', 'g3', 'g6'],
             ['a3', 'b3', 'c3'], ['e3', 'f3', 'g3'], ['c4', 'd4', 'e4'], ['b5', 'd5', 'f5'], ['a6', 'd6', 'g6'], ['a0', 'b1', 'c2']]

    def __init__(self):

        self.dataframe = pd.DataFrame({"start": self.start, "end": self.end}) #define two-dimensional data frame to store positions
        self.matrixMills= np.zeros([len(self.mills), len(self.positions)]) #define array with same shape, filled with zeros.[13][21]
        # iterate through the array and assign the values.
        for i, mill in enumerate(self.mills):
            for m in mill:
                n = self.positions.index(m)
                self.matrixMills[i][n] = 1  # all 0's now filled in with 1

    def positionLabel(self, i: int):
        return self.positions[i]

    def positionIndex(self, s: str):
        return self.positions.index(s)

    def pieceSymbol(self, vertex, pos):
        if type(vertex) is str:
            vertex = self.positionIndex(vertex)
        return pos[vertex]   # return string x|W|B

    '''
    Input: a location j in the array representing the board
    Output: a list of locations in the array corresponding to j's neighbors
    switch(j) f
    case j==0 (a0) : return [1,2,6]. (These are g0,b1,a3.)
    case j==1 (g0) : return [0,3,11]. (These are a0,f1,g3.)
    etc.
    '''
    def neighbors(self, x):
        if type(x) is int:
            x = self.positionLabel(x)
        #Same as switch function, the pairs are all stored in dataframe start and end.
        # ie, a0 could go to position g0 or b1 or a3 based on the dataFrame.
        edge = list(self.dataframe[self.dataframe.start == x]['end'])  # not connected edges
        edge.extend(list(self.dataframe[self.dataframe.end == x]['start']))  # (list e end adjacent list e start) in edges
        return set(edge)

    ''' GenerateAdd
          Input: a board position
          Output: a list L of board positions
          L = empty list
          for each location in board:
              if board[location] == empty f
              b = copy of board; b[location] = W
              if closeMill(location, b) generateRemove(b, L)
              else add b to L
          return L
          Simply add on the board.'''

    def GenerateAddWhite(self, position):
        for i, j in enumerate(position):
            if j == 'x':
                vertex = list(position)
                vertex[i] = 'W'
                newPosition = ''.join(vertex)
                if self.closeMill(i, newPosition):  # If form a mill, remove opponent piece.
                    for p in self.GenerateRemove(i, newPosition):
                        yield i, p
                else:
                    yield i, newPosition

    '''
GenerateMove
Input: a board position
Output: a list L of board positions
L = empty list
for each location in board
    if board[location]==W f
    n = list of neighbors of location
    for each j in n
        if board[j] == empty f
            b = copy of board; b[location] = empty; b[j]=W
        if closeMill(j, b) GenerateRemove(b, L)
        else add b to L
return L
    '''
    def GenerateMoveWhite(self, position):
        for i, symbol in enumerate(position):
            if symbol == 'W':
                for neigbor in self.neighbors(i):
                    if self.pieceSymbol(neigbor, position) == 'x':
                        n = self.positionIndex(neigbor)
                        vertex = list(position)
                        vertex[i] = 'x'
                        vertex[n] = 'W'
                        newPosition = ''.join(vertex)
                        if self.closeMill(n, newPosition):
                            for nnp in self.GenerateRemove(n, newPosition):
                                yield n, nnp
                        else:
                            yield n, newPosition

    '''
GenerateHopping
Input: a board position
Output: a list L of board positions
L = empty list
for each location alpha in board
if board[alpha] == W f
for each location Beta in board
if board[Beta] == empty f
b = copy of board; b[alpha] = empty; b[Beta] = W
if closeMill(Beta, b) generateRemove(b, L)
else add b to L
g
g
return L
    '''
    def GenerateHoppingWhite(self, position):
        for i, symbol in enumerate(position):
            if symbol == 'W':
                for j, x in enumerate(position):
                    if i == j:
                        continue
                    if x == 'x':
                        vertex = list(position)
                        vertex[i] = 'x'
                        vertex[j] = 'W'
                        newp = ''.join(vertex)
                        if self.closeMill(j, newp):
                            for nnp in self.GenerateRemove(j, newp):
                                yield j, nnp
                        else:
                            yield j, newp

    '''
    Input: a board position b.
    Output: a list L of all positions reachable by a black move.
    1. compute the board tempb by swapping the colors in b. Replace each W by a B, and each B by a W.
    2. Generate L containing all positions reachable from tempb by a white move.
    3. Swap colors in all board positions in L, replacing W with B and B with W.
    '''
    def GenerateAddBlack(self, position):
        for i, symbol in enumerate(position):
            if symbol == 'x':
                vertex = list(position)
                vertex[i] = 'B'
                newPosition = ''.join(vertex)
                if self.closeMill(i, newPosition):
                    for nnp in self.GenerateRemove(i, newPosition):
                        yield i, nnp
                else:
                    yield i, newPosition

    @staticmethod  #Flip -- Trick to simulate black as the flip of the white.
    def flipBoard(position:str):
        position = position.replace('B', 'w')
        position = position.replace('W', 'B')
        return position.replace('w', 'W')

    def GenerateMoveBlack(self, position):   #Same as white but flip
        for i, j in self.GenerateMoveWhite(self.flipBoard(position)):
            yield i, self.flipBoard(j)

    def GenerateHoppingBlack(self, position):
        for i, j in self.GenerateHoppingWhite(self.flipBoard(position)):
            yield i, self.flipBoard(j)



        '''
        closeMill
            Input: a location j in the array representing the board and the board b
            Output: true if the move to j closes a mill
            C = b[j]; C must be either W or B. Cannot be x.
            switch(j) f
            case j==0 (a0) : return true if
            (b[2]==C and b[4]==C) f the mill is a0, b1, c2 g
            or (b[6]==C and b[18]==C) f the mill is a0, a3, a6 g
            else return false
            case j==1 (g0) : return true if
            (b[3]==C and b[5]==C) f the mill is g0, f1, e2 g
            or (b[11]==C and b[20]==C) f the mill is g0, g3, g6 g
            else return false
            etc.
        '''

    def closeMill(self, i, position):
        if position[i] == 'x':  # Either W or B, can not be x
            return False
        Symbol = position[i]
        matrixPosition = np.array([1 if x == Symbol else 0 for x in position])
        matrixLocation = np.where(self.matrixMills[:, i] == 1)[0] # all the mills conditions included in np array mills, same as switch function.
        return np.any(np.matmul(self.matrixMills[matrixLocation], matrixPosition ) == 3)  # If forming a mill(3 in a line) then return true.


    '''
    GenerateRemove
    Input: a board position and a list L
    Output: positions are added to L by removing black pieces
    for each location in board:
        if board[location]==B f
        if not closeMill(location, board) f
        b = copy of board; b[location] = empty
        add b to L
    If no positions were added (all black pieces are in mills) add b to L.
    '''

    def GenerateRemove(self, index, position):
        val = position[index]
        counter = 0
        for i in range(21): #21 locations
            if index == i:
                continue
            if position[i] not in [val, 'x'] and not self.closeMill(i, position):
                counter  += 1
                vertex = list(position)
                vertex[i] = 'x'
                yield ''.join(vertex)
        if counter  == 0:
            yield position

    '''
    numWhitePieces = the number of white pieces in b.
    numBlackPieces = the number of black pieces in b.
    L = the MidgameEndgame positions generated from b by a black move.
    numBlackMoves = the number of board positions in L.
    '''
    @staticmethod
    def numWhitePieces(position):
        return position.count('W')

    @staticmethod
    def numBlackPieces(position):
        return position.count('B')

    def numWhiteMoves(self, position):
        new = self.numWhitePieces(position)
        if new <= 2:
            return 0
        if new == 3:
            return len(list(self.GenerateHoppingWhite(position)))
        return len(list(self.GenerateMoveWhite(position)))

    def numBlackMoves(self, position):
        new = self.numBlackPieces(position)
        if new <= 2:
            return 0
        if new == 3:
            return len(list(self.GenerateHoppingBlack(position)))
        return len(list(self.GenerateMoveBlack(position)))

    '''
    static
    estimation
    for Opening:
        return (numWhitePieces 􀀀 numBlackPieces)
    5
    '''
    def estimateOpenWhite(self, position):
        return self.numWhitePieces(position) - self.numBlackPieces(position)

    def estimateOpenBlack(self, position):
        return self.estimateOpenWhite(self.flipBoard(position))

    '''
    A static estimation for MidgameEndgame:
    if (numBlackPieces <=2) return(10000)
    else if (numWhitePieces <= 2) return(-10000)
    else if (numBlackMoves==0) return(10000)
    else return ( 1000(numWhitePieces 􀀀 numBlackPieces) - numBlackMoves)
    '''
    def estimateMidgameEndgame_White(self, position):
        if self.numBlackPieces(position) <= 2:
            return 10000  # inf, win
        if self.numWhitePieces(position) <= 2:
            return -10000  # -inf, loss
        if self.numBlackMoves(position) == 0:
            return 10000  # inf, win
        return 1000 * (self.numWhitePieces(position) - self.numBlackPieces(position)) - self.numBlackMoves(position)

    def estimateMidgameEndgame_Black(self, position):
        return self.estimateMidgameEndgame_White(self.flipBoard(position))

    '''Improvement of Static Estimation function: I created a function to calculate how many potential mills W has. 
           I returned estimated value as 1000*(whiteCount - blackCount + potentialMillCount) - movesCount
           in case where all given conditions i.e. #black pieces and #white pieces are more than 2.'''

    # This run into trouble when testing
    def potentialEdgeCount(board, i, j, position):
        p0 = position[board.positionIndex(i)]
        p1 = position[board.positionIndex(j)]
        if p0 == 'x' and p1 == 'W':
            return i
        if p1 == 'x' and p0 == 'W':
            return j
        return None

    def potentialMillCountWhite(self,_,position):
        count = 0
        for i in range(len(self.positions)):
                count += 1
        return count

    def potentialMillCountBlack(self,_,position):
        return self.potentialMillCountWhite(self.flipBoard(position))

    def estimateOpenWhiteImproved(self, position):
        return self.numWhitePieces(position) - self.numBlackPieces(position)+ self.potentialMillCountWhite(position)

    def estimateOpenBlackImproved(self, position):
        return self.numWhitePieces(position) - self.numBlackPieces(position)+ self.potentialMillCountBlack(position)