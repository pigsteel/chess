public class Board {
    Spot[,] board = new Spot[8,8];
    public byte?[]? justPushed;

    public Board() {
        for(byte i = 0; i < 8; i++) {
            for(byte j = 0; j < 8; j++) {
                board[i,j] = new Spot();
            }
        }
    }

    public bool Select(byte x, byte y) {
        if(board[x, y].isEmpty) {
            return false;
        } else {
            return true;
        }
    }

    public bool CheckMove(byte x1, byte y1, byte x2, byte y2, bool white) {
        if(!(IfValid(x1, y1) && IfValid(x2, y2))) {
            return false;
        }

        ref Spot spot1 = ref board[x1, y1];
        ref Spot spot2 = ref board[x2, y2];

        if(spot1.isEmpty) { // If this is true, something has gone very wrong.
            return false;
        } else if (spot1.piece?.white != white) { // Can't move a piece you don't own
            return false;
        } else if(spot2.isEmpty) { // Standard move (piece to empty square)
            bool i = spot1.piece.Move(this, x1, y1, x2, y2, false);
            if (i == true) {
                justPushed = null;
            }
            return i;
        } else if(spot2.IsOccupied(spot1.piece.white)) { // Move can't happen because other piece is the same color.
            return false;
        } else {
            // BY THE TIME THIS RUNS:
            // All of the initial, less costly calculations will have happened.
            // This is done to save time in case the move that needs to execute is relatively simple.
            bool i = spot1.piece.Move(this, x1, y1, x2, y2, true);
            if (i == true) {
                justPushed = null;
            }
            return i;
        }
    }

    public bool CheckLine(byte x1, byte y1, byte x2, byte y2) {
        if(x1 == x2) {
            for(byte i = 0; i < Math.Abs(y1 - y2); i++) {
                if(!board[x1, i].isEmpty) {
                    return false;
                }
            }
            return true;
        } else if (y1 == y2) {
            for(byte i = 0; i < Math.Abs(x1 - x2); i++) {
                if(!board[i, y1].isEmpty) {
                    return false;
                }
            }
            return true;
        }
            
        throw new Exception("Improper use of CheckLine.");
    }

    public bool CheckDiagonal(byte x1, byte y1, byte x2, byte y2) {
        for(byte i = 0; i < Math.Abs(x1 - x2); i++) {
            for(byte j = 0; j < Math.Abs(y1 - y2); j++) {
                if(!board[i, j].isEmpty) {
                    return false;
                }
            }
        }
        return true;
    }

    public bool CheckEmpty(byte x, byte y) {
        return board[x, y].isEmpty;
    }

    public bool CheckOccupied(byte x, byte y) {
        return board[x, y].isEmpty;
    }

    public Piece? GetPiece(byte x, byte y) {
        return board[x, y].piece;
    }

    public void Move(byte x1, byte y1, byte x2, byte y2) {
        board[x2,y2].piece = board[x1,y1].piece;
        board[x1,y1].Remove();
    }

    public void Remove(byte x, byte y) {
        board[x,y].Remove();
    }

    public ref Spot GetSpot() {
        return ref board[3,3];
    }

    public static bool IfValid(byte x, byte y) {
        return x < 8 && y < 8;
    }
}