namespace ReversiRestApi.Spel
{
	public class Direction
	{
		public int _row { get; set; }
		public int _column { get; set; }

		public Direction(int row, int column)
		{
			_row = row;
			_column = column;
		}
	}
}