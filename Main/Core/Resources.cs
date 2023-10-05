namespace chess;

public static class Resources {
    static string Directory = @"Resources\\\";

    public static T Load<T> (string fileName) where T : ILoadable<T> {
        string file = Directory + fileName;
        FileStream stream = File.OpenRead(file);
        FileInfo info = new FileInfo(file);

        byte[] buffer = new byte[info.Length];
        stream.Read(buffer, 0, buffer.Length);

        Console.WriteLine($"Byte buffer loaded of length {buffer.Length.ToString()}");

        return T.LoadResource(ref buffer, file);
    }
}

public interface ILoadable<T> where T : ILoadable<T> {
    abstract static T LoadResource(ref byte[] bytes, string fileName);

    abstract static T LoadResource(ref FileStream stream, string fileName);
}