namespace Common.Constants
{
    public class CommonConstants
    {
        public const string SearchTerm = "*";
        public const string PathRegexp = @"^(?:[a-zA-Z]\:)\\{1,2}(?:[^?*:;|<>\r\n\\\/]+\\{0,2})*$";
        public const string DateFormat = "dd.MM.yyyy hh:mm:ss";
        public const int Shift = 10;

        private CommonConstants()
        { }
    }
}
