namespace MongoBlog.UI.Domain.Entities {
    public interface ISelectSpec {
        int NumberOfRows { get; }
        int SkipRows { get; }
    }

    public class SelectSpec : ISelectSpec {
        public int NumberOfRows { get; protected set; }
        public int SkipRows { get; protected set; }

        public SelectSpec(int numberOfRows)
            : this(numberOfRows, 0) {
        }

        public SelectSpec(int numberOfRows, int skipRows) {
            NumberOfRows = numberOfRows;
            SkipRows = skipRows;
        }

        public static ISelectSpec Default {
            get {
                return new SelectSpec(25);
            }
        }
    }
}