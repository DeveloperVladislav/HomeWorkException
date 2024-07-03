namespace HomeWorkException
{

	public class MyException : Exception
	{
		public MyException() : base("Error") { }
		public MyException(string message) : base(message) { }
	}

	public class Program
	{
		static void PrintName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException(nameof(name));
			}
			Console.WriteLine("Your name: " + name);
		}

		static void Main(string[] args)
		{

			try
			{
				int num1 = Convert.ToInt32(Console.ReadLine());
				int num2 = Convert.ToInt32(Console.ReadLine());
				int result = num1 / num2;
				Console.WriteLine(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Исключение: {ex.Message}");
				Console.WriteLine($"InnerException: {ex.InnerException}");
				Console.WriteLine($"Метод: {ex.TargetSite}");
				Console.WriteLine($"Имя объекта: {ex.Source}");
				Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
			}

			Console.WriteLine("===============ArgumentException================================");


			try
			{
				PrintName(null);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("Error: " + ex.Message);
				Console.WriteLine("Incorrect argument value!");
			}

			Console.WriteLine("================================================");


			/*try
			{
				// Код, который может вызвать исключение
				throw new Exception("Possible error!");
			}
			finally
			{
				Console.WriteLine("This code will always execute");
			}*/


			Console.WriteLine("================================================");

			try
			{
				try
				{
					int x = 0;
					int y = 10;
					int res = y / x;
					Console.WriteLine(res);
				}
				catch(IndexOutOfRangeException ex)
				{
					Console.WriteLine("IndexOutOfRangeException ex");
				}
				
				finally
				{
					Console.WriteLine("finally");
				}

			}
			catch (DivideByZeroException ex)
			{
				Console.WriteLine("catch: " + ex.Message);
			}
			Console.WriteLine();

			Console.WriteLine("===========================================");


			try
			{
				int[] arr = new int[10];
				arr[11] = 6;

				throw new MyException("Something went wrong!");
			}
			catch (MyException ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}
	}
}