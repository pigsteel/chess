public class Queen : Piece {
    public Queen(bool white) : base(white){}

    public override bool Move(Board board, byte x1, byte y1, byte x2, byte y2, bool capture)
    {
        throw new NotImplementedException();
    }
}