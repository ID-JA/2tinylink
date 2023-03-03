namespace Application.Common.Helpers.Consts
{
    public static class AppRegEx
    {
        public const string FIRST_NAME = "^[A-Za-z]+$";
        public const string PASSWORD = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).{6,}$";
        public const string USER_NAME = "^[A-Za-z0-9]{3,29}_?$";

    }
}