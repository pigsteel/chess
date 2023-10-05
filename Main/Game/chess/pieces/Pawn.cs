public class Pawn : Piece {
    public Pawn(bool white) : base(white) {}

    private sbyte forward { get{
        sbyte i = white ? (sbyte)1 : (sbyte)-1;
        return i;
    }}
    private sbyte push { get{
        return (sbyte)(forward * 2);
    }}

    public override bool Move(Board board, byte x1, byte y1, byte x2, byte y2, bool capture) {
        if(x1 == x2 && !capture) { // Is move straight
            if(!HasMoved && y2 == y1 + 2) { // Check double pawn push
                if(board.CheckEmpty(x1, (byte)(y1 + forward)) && board.CheckEmpty(x1, (byte)(1 + push))) {
                    board.Move(x1, y1, x2, y2);
                    return true;
                } else
                return false;
            } else if (y2 == y1 + 1) { // Check pawn push
                if(board.CheckEmpty(x1, (byte)(y1 + forward))) {
                    board.Move(x1, y1, x2, y2);
                    return true;
                } else
                return false;
            } else
            return false;
        } else if(x2 == x1 + 1 || x2 == x1 - 1) { // Is move diagonal
            if(y2 == y1 + forward) { // Is move diagonal pt. 2
                byte?[]? temp = board.justPushed;
 
                if(capture) { // Check capture
                    board.Move(x1, y1, x2, y2);
                    return true;
                } else if(temp != null && temp[0] == x2 && temp[1] == y2) { // Check en passant
                    board.Move(x1, y1, x2, y2);
                    board.Remove(x2, (byte)(y2 - forward));
                    return true;
                } else // Nothing happens
                return false;
            } else
            return false;
        } else
        return false;
    }


}

