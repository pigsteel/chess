using System.Xml;

public abstract class Piece {
    public bool white;
    public bool HasMoved;

    public Piece(bool white) {
        this.white = white;
    }

    public abstract bool Move(Board board, byte x1, byte y1, byte x2, byte y2, bool capture);
}