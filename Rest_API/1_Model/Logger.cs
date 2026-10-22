public class Logger
{
    public static void LogError(Exception e)
    {
         File.AppendAllText(
            "ErrorLog.txt",
            $"{Convert.ToString(DateTime.Now)}\n{e}\n\n\n"
         );
    }
    public static void LogCritical(Exception e)
    {
        File.AppendAllText(
            "CriticalErrorLog.txt",
            $"{Convert.ToString(DateTime.Now)}\n{e}\n\n\n"
        );
    }
}