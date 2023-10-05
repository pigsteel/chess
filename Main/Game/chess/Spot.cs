using System.ComponentModel;

public class Spot {
    public Piece? piece = null;

    public bool isEmpty {
        get {
            return piece == null;
        }
        private set{}
    }

    public void SetPiece(Piece newPiece) {
        this.piece = newPiece;
    }

    public void Remove() {
        this.piece = null;
    }

    public bool IsOccupied(bool white) {
        if (piece != null && white == piece.white) {
            return true;
        } else {
            return false;
        }
    }
}